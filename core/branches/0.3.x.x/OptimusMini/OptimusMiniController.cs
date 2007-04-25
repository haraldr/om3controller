/*
The contents of this file are subject to the Mozilla Public License
Version 1.1 (the "License"); you may not use this file except in
compliance with the License. You may obtain a copy of the License at
http://www.mozilla.org/MPL/

Software distributed under the License is distributed on an "AS IS"
basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
License for the specific language governing rights and limitations
under the License.

The Original Code is om3 controller library, UI and various plugins.

The Initial Developer of the Original Code is Harald Röxeisen.
Portions created by the initial developer are Copyright (C) 2007
the initial developer. All Rights Reserved.

Contributor(s): Harald Röxeisen.
*/


using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using Microsoft.Win32;

using Toolz.OptimusMini.Plugins;


[assembly: CLSCompliant(true)]
namespace Toolz.OptimusMini
{

  /// <summary>
  /// Represents the method that will handle the ConnectionStateChanged event.
  /// </summary>
  /// <param name="sender">An <see cref="OptimusMiniController" /> instance.</param>
  /// <param name="connected">Boolean whether connected or not.</param>
  public delegate void OptimusMiniConnectionStateChangedEventHandler(OptimusMiniController sender, bool connected);


  /// <summary>
  /// Represents the method that will handle the various key events.
  /// </summary>
  /// <param name="sender">An <see cref="OptimusMiniController" /> instance.</param>
  /// <param name="keyIndex">0-based key index.</param>
  public delegate void OptimusMiniKeyEventHandler(OptimusMiniController sender, byte keyIndex);



  public delegate void OptimusMiniNotificationEventHandler(OptimusMiniController sender, OptimusMiniEventLog notification);


  /// <summary>
  /// Controls an optimus mini device.
  /// </summary>
  public class OptimusMiniController
  {

    private OptimusMiniConnection _Connection;
    private PluginManager _PluginManager;
    private OptimusMiniKeyState[] _KeyState;
    public Bitmap[] _LastImage;

    private OptimusMiniBrightness _Brightness;
    private OptimusMiniOrientation _Orientation;
    private float _Gamma;
    private int _IdleTime;

    private Thread _UpdateThread;
    private bool _UpdateThreadExit;
    private bool _IsTerminating;

    private bool _IsConnected;
    private bool _IsIdle;

    private bool _ConnectedBeforeSuspend;
    private bool _IsSuspending;


    /// <summary>
    /// Creates a new instance of the <see cref="OptimusMini" /> class and returns it.
    /// </summary>
    public OptimusMiniController()
    {
      _KeyState = new OptimusMiniKeyState[3];
      _LastImage = new Bitmap[3];
      _Connection = new OptimusMiniConnection();
      _Brightness = OptimusMiniBrightness.Low;
      _Orientation = OptimusMiniOrientation.Right;
      _Gamma = 0.65f;
      _IdleTime = 300;

      SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(PowerModeChanged);
    }


    /// <summary>
    /// Opens connection to device and initializes the class.
    /// </summary>
    /// <returns>0 if successful, otherwise an error code.</returns>
    /// <remarks>
    /// Error codes: 0=successful, 1=device not found, 2=device not responding, 3=system is suspending
    /// </remarks>
    public int Init()
    {
      return Init(true, true);
    }


    /// <summary>
    /// Opens connection to device and initializes the class.
    /// </summary>
    /// <param name="raiseEvent">Boolean whether to raise ConnectionStateChanged event or not.</param>
    /// <param name="clearImages">Boolean whether to clear images or not.</param>
    /// <returns>0 if successful, otherwise an error code.</returns>
    /// <remarks>
    /// Error codes: 0=successful, 1=device not found, 2=device not responding,
    /// 3=access to port denied, 10=system is suspending
    /// </remarks>
    private int Init(bool raiseEvent, bool clearImages)
    {
      if (_IsConnected) { return 0; }
      if (_IsSuspending) { return 10; }

      _KeyState[0] = new OptimusMiniKeyState(this, 0);
      _KeyState[1] = new OptimusMiniKeyState(this, 1);
      _KeyState[2] = new OptimusMiniKeyState(this, 2);

      int lConnectionError;
      lConnectionError = _Connection.Init();
      if (lConnectionError != 0) { return lConnectionError; }

      _UpdateThread = new Thread(ProcessUpdates);
      _UpdateThread.Start();

      if (clearImages)
      {
        ClearImage(0);
        ClearImage(1);
        ClearImage(2);
      }

      _Connection.SetBrightness(_Brightness);
      _Connection.SetGamma(_Gamma);
      _Connection.SwitchOn();
      _Connection.ShowAll();

      _IsConnected = true;

      if (raiseEvent) { RaiseConnectionStateChanged(true); }

      return 0;
    }


    /// <summary>
    /// Closes connection to device.
    /// </summary>
    /// <returns>0 if successful, otherwise an error code.</returns>
    /// <remarks>
    /// Error codes: 0=successful, 1=system is suspending
    /// </remarks>
    public int Terminate()
    {
      return Terminate(true, false);
    }


    /// <summary>
    /// Closes connection to device.
    /// </summary>
    /// <param name="raiseEvent">Boolean whether to raise ConnectionStateChanged event or not.</param>
    /// <param name="ignoreSuspending">Boolean whether to ignore suspending flag or not.</param>
    /// <returns>0 if successful, otherwise an error code.</returns>
    /// <remarks>
    /// Error codes: 0=successful, 1=system is suspending
    /// </remarks>
    private int Terminate(bool raiseEvent, bool ignoreSuspending)
    {
      if (!_IsConnected) { return 0; }
      if (_IsTerminating) { return 0; }
      if (!ignoreSuspending && _IsSuspending) { return 1; }

      try
      {
        _IsTerminating = true;

        if (!_UpdateThreadExit)
        {
          _UpdateThread.Abort();
          _UpdateThread.Join(1000);
        }

        _Connection.Terminate();

        _IsConnected = false;

        if (raiseEvent) { RaiseConnectionStateChanged(false); }

        return 0;
      }
      finally
      {
        _IsTerminating = false;
      }
    }


    /// <summary>
    /// Gets connection state.
    /// </summary>
    public bool IsConnected
    {
      get { return _IsConnected; }
    }


    /// <summary>
    /// Gets assigned plugin manager.
    /// </summary>
    public PluginManager PluginManager
    {
      get { return _PluginManager; }
    }


    /// <summary>
    /// Assigns plugin manager.
    /// </summary>
    /// <param name="pluginManager">Plugin manager to set.</param>
    /// <returns>0 if successful, otherwise an error code.</returns>
    public int SetPluginManager(PluginManager pluginManager)
    {
      _PluginManager = pluginManager;
      return 0;
    }


    /// <summary>
    /// Gets brightness level of device.
    /// </summary>
    public OptimusMiniBrightness Brightness
    {
      get { return _Brightness; }
    }


    /// <summary>
    /// Sets brightness level of device.
    /// </summary>
    /// <param name="brightness">Brightness to set.</param>
    /// <returns>0 if successful, otherwise an error code.</returns>
    public int SetBrightness(OptimusMiniBrightness brightness)
    {
      _Connection.SetBrightness(brightness);
      _Brightness = brightness;
      return 0;
    }

    
    /// <summary>
    /// Gets orientation of device.
    /// </summary>
    public OptimusMiniOrientation Orientation
    {
      get { return _Orientation; }
    }


    /// <summary>
    /// Sets orientation of device.
    /// </summary>
    /// <param name="orientation">Orientation to set.</param>
    /// <returns>0 if successful, otherwise an error code.</returns>
    public int SetOrientation(OptimusMiniOrientation orientation)
    {
      if (_Orientation != orientation)
      {
        _Orientation = orientation;
        for (byte i = 0; i <= 2; i++)
        {
          if (_LastImage[i] != null)
          {
            Bitmap lBitmap = _LastImage[i].Clone(new Rectangle(0, 0, 96, 96), PixelFormat.Format24bppRgb);
            RotateImage(lBitmap);
            _Connection.SetImage(MapKeyIndex(i), lBitmap);
          }
        }
      }
      return 0;
    }


    /// <summary>
    /// Gets gamma of device.
    /// </summary>
    public float Gamma
    {
      get { return _Gamma; }
    }


    /// <summary>
    /// Sets gamma of device.
    /// </summary>
    /// <param name="gamma">Gamma to set.</param>
    /// <returns>0 if successful, otherwise an error code.</returns>
    /// <exception cref="ArgumentException">Thrown when gamma is not between 0 and 1.</exception>
    public int SetGamma(float gamma)
    {
      if (gamma < 0f || gamma > 1f) { throw new ArgumentException("Gamma must be between 0 and 1."); }
      _Connection.SetGamma(gamma);
      _Gamma = gamma;
      return 0;
    }


    /// <summary>
    /// Shows an image on the specified key.
    /// </summary>
    /// <param name="index">0-based index of key.</param>
    /// <param name="image">Image to show.</param>
    /// <returns>0 if successful, otherwise an error code.</returns>
    public int ShowImage(byte index, Bitmap image)
    {
      if (_LastImage[index] != null)
      {
        Bitmap lOld = _LastImage[index];
        _LastImage[index] = null;
        lOld.Dispose();
      }

      _LastImage[index] = image.Clone(new Rectangle(0, 0, 96, 96), PixelFormat.Format24bppRgb);

      Bitmap lBitmap = image.Clone(new Rectangle(0, 0, 96, 96), PixelFormat.Format24bppRgb);
      RotateImage(lBitmap);
      _Connection.SetImage(MapKeyIndex(index), lBitmap);
      lBitmap.Dispose();

      return 0;
    }


    /// <summary>
    /// Clears displayed image on the specified key.
    /// </summary>
    /// <param name="index">0-based index of key.</param>
    /// <returns>0 if successful, otherwise an error code.</returns>
    public int ClearImage(byte index)
    {
      Bitmap lBitmap = new Bitmap(96, 96, PixelFormat.Format16bppRgb565);
      Graphics lGraphic = Graphics.FromImage(lBitmap);
      lGraphic.FillRectangle(Brushes.Black, 0, 0, 96, 96);
      lGraphic.Flush();

      int lResult = ShowImage(MapKeyIndex(index), lBitmap);

      lGraphic.Dispose();
      lBitmap.Dispose();

      return lResult;

    }


    /// <summary>
    /// Shows logo and version information on specified key.
    /// </summary>
    /// <param name="index">0-based index of key.</param>
    /// <returns>0 if successful, otherwise an error code.</returns>
    public int ShowVersion(byte index)
    {
      Bitmap lBitmap = new Bitmap(96, 96, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
      Graphics lGraphic = Graphics.FromImage(lBitmap);
      lGraphic.DrawImageUnscaled(Resources.Logo, 0, 0);
      lGraphic.Flush();

      int lResult = ShowImage(index, lBitmap);

      lGraphic.Dispose();
      lBitmap.Dispose();

      return lResult;
    }


    /// <summary>
    /// Shows color calibration image on the specified key.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public int ShowCalibrate(byte index)
    {
      Bitmap lBitmap = new Bitmap(96, 96, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
      Graphics lGraphic = Graphics.FromImage(lBitmap);
      lGraphic.DrawImageUnscaled(Resources.Calibrate, 0, 0);
      lGraphic.Flush();

      int lResult = ShowImage(index, lBitmap);

      lGraphic.Dispose();
      lBitmap.Dispose();

      return lResult;
    }


    /// <summary>
    /// Gets idle time threshold in seconds after which device is switched off.
    /// </summary>
    public int IdleTime
    {
      get { return _IdleTime; }
    }


    /// <summary>
    /// Sets idle time threshold in seconds after which device is switched off.
    /// </summary>
    /// <returns>0 if successful, otherwise an error code.</returns>
    public int SetIdleTime(int idleTime)
    {
      _IdleTime = idleTime;
      return 0;
    }


    /// <summary>
    /// Gets idle state.
    /// </summary>
    public bool IsIdle
    {
      get { return _IsIdle; }
    }


    /// <summary>
    /// Raised when connection state changes.
    /// </summary>
    public event OptimusMiniConnectionStateChangedEventHandler OnConnectionStateChanged;


    public event OptimusMiniNotificationEventHandler OnNotification;


    /// <summary>
    /// Raised when a key goes down.
    /// </summary>
    public event OptimusMiniKeyEventHandler OnKeyDown;


    /// <summary>
    /// Raised when a key goes up.
    /// </summary>
    public event OptimusMiniKeyEventHandler OnKeyUp;


    /// <summary>
    /// Raised when a key is held down.
    /// </summary>
    public event OptimusMiniKeyEventHandler OnKeyHold;


    /// <summary>
    /// Raised when a key is released after being held down.
    /// </summary>
    public event OptimusMiniKeyEventHandler OnKeyRelease;


    /// <summary>
    /// Raised when a key is pressed.
    /// </summary>
    public event OptimusMiniKeyEventHandler OnKeyPress;


    /// <summary>
    /// Raised when a key is double pressed.
    /// </summary>
    public event OptimusMiniKeyEventHandler OnKeyDoublePress;


    private void ProcessUpdates()
    {
      try
      {
        _UpdateThreadExit = false;

        while (_Connection.GetConnectionState() && !_UpdateThreadExit)
        {
          // ----- Check if user is idle
          if (_IdleTime != 0 && Win32Library.GetUserIdleTime() > _IdleTime)
          {
            if (!_IsIdle)
            {
              _Connection.SwitchOff();
              _IsIdle = true;
            }
          }
          else
          {
            if (_IsIdle)
            {
              _Connection.SwitchOn();
              _Connection.ShowAll();
              _Connection.SetBrightness(_Brightness);
              _IsIdle = false;
            }
          }


          // ----- Update plugins
          if (_PluginManager != null) { _PluginManager.Update(); }


          // ----- Update key state
          byte lKeyState = _Connection.GetKeyState();
          _KeyState[0].Update((lKeyState & 1) == 1);
          _KeyState[1].Update((lKeyState & 2) == 2);
          _KeyState[2].Update((lKeyState & 4) == 4);


          // ----- Short break
          Thread.Sleep(10);
        }

        _UpdateThreadExit = true;
        Terminate();
      }
      catch (ThreadAbortException)
      {
      }

    }


    private byte MapKeyIndex(byte index)
    {
      if (index == 1 ||
          (_Orientation != OptimusMiniOrientation.Left && _Orientation != OptimusMiniOrientation.Up))
      {
        return index;
      }

      if (index == 0) { return 2; } else { return 0; }
    }


    private void RotateImage(Bitmap bitmap)
    {
      switch (_Orientation)
      {
        case OptimusMiniOrientation.Left:
          bitmap.RotateFlip(RotateFlipType.RotateNoneFlipXY);
          break;

        case OptimusMiniOrientation.Down:
          bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
          break;

        case OptimusMiniOrientation.Up:
          bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
          break;

      }
    }


    internal void RaiseConnectionStateChanged(bool connected)
    {
      if (OnConnectionStateChanged != null) { OnConnectionStateChanged(this, connected); }
    }


    internal void RaiseKeyDown(byte index)
    {
      if (_PluginManager != null) { _PluginManager.KeyDown(MapKeyIndex(index)); }
      if (OnKeyDown != null) { OnKeyDown(this, index); }
    }


    internal void RaiseKeyUp(byte index)
    {
      if (_PluginManager != null) { _PluginManager.KeyUp(MapKeyIndex(index)); }
      if (OnKeyUp != null) { OnKeyUp(this, index); }
    }


    internal void RaiseKeyHold(byte index)
    {
      if (_PluginManager != null) { _PluginManager.KeyHold(MapKeyIndex(index)); }
      if (OnKeyHold != null) { OnKeyHold(this, index); }
    }


    internal void RaiseKeyRelease(byte index)
    {
      if (_PluginManager != null) { _PluginManager.KeyRelease(MapKeyIndex(index)); }
      if (OnKeyRelease != null) { OnKeyRelease(this, index); }
    }


    internal void RaiseKeyPress(byte index)
    {
      if (_PluginManager != null) { _PluginManager.KeyPress(MapKeyIndex(index)); }
      if (OnKeyPress != null) { OnKeyPress(this, index); }
    }


    internal void RaiseKeyDoublePress(byte index)
    {
      if (_PluginManager != null) { _PluginManager.KeyDoublePress(MapKeyIndex(index)); }
      if (OnKeyDoublePress != null) { OnKeyDoublePress(this, index); }
    }


    internal void RaiseNotification(OptimusMiniEventLog notification)
    {
      if (OnNotification != null) { OnNotification(this, notification); }
    }


    private void PowerModeChanged(object sender, PowerModeChangedEventArgs e)
    {
      if (e.Mode == PowerModes.Resume)
      {
        PowerModeChanged_Resume();
      }
      else if (e.Mode == PowerModes.Suspend)
      {
        PowerModeChanged_Suspend();
      }
    }


    public void PowerModeChanged_Resume()
    {
      _IsSuspending = false;

      // If it was connected try to reconnect and show last images
      if (_ConnectedBeforeSuspend)
      {
        _ConnectedBeforeSuspend = false;

        if (Init(false, false) != 0)
        {
          RaiseConnectionStateChanged(false);
          return;
        }

        //for (byte i = 0; i <= 2; i++)
        //{
        //  ShowImage(i, _LastImage[i]);
        //}
      }

    }


    public void PowerModeChanged_Suspend()
    {
      _IsSuspending = true;

      // If connected shut down
      if (_IsConnected)
      {
        Terminate(false, true);
        _ConnectedBeforeSuspend = true;
      }

    }

  }

}