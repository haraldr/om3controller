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
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using Microsoft.Win32;


namespace Toolz.OptimusMini
{

  /// <summary>
  /// Handles the communication with the optimus mini device.
  /// </summary>
  internal class OptimusMiniConnection
  {

    internal const int COMMAND_LENGTH = 197;
    internal const int SCREEN_SIZE = 96;

    internal byte[] _GammaTable;

    private bool _Connected;
    private bool _On;
    private SerialPort _Port;
    private AutoResetEvent _CommandWaitHandle;

    private Thread _CommandThread;
    private bool _CommandThreadExit;

    private bool _CommandSwitchOn;
    private bool _CommandSwitchOff;

    private bool[] _CommandShow;
    private bool[] _CommandImage;
    private OptimusMiniConnectionImage[] _CommandImageValue;

    private bool _CommandBrightness;
    private OptimusMiniBrightness _CommandBrightnessValue;

    private bool _CommandGamma;
    private float _CommandGammaValue;
    
    private byte _LastCommandResponse;
    private byte _LastKeyDown;

    private bool _IsTerminating;

    internal string[] _LastLinesCheckSum = new string[288];
    internal System.Security.Cryptography.MD5CryptoServiceProvider _Md5 = new MD5CryptoServiceProvider();


    /// <summary>
    /// Creates a new instance of the <see cref="OptimusMiniConnection" /> class and returns it.
    /// </summary>
    public OptimusMiniConnection()
    {
      _CommandShow = new bool[] { false, false, false };
      _CommandImage = new bool[] { false, false, false };
      _CommandImageValue = new OptimusMiniConnectionImage[] { null, null, null };

      FillGammaTable(0.65F);
    }


    /// <summary>
    /// Opens connection to device and initializes class.
    /// </summary>
    /// <returns>0 if successful, otherwise an error code.</returns>
    /// <remarks>
    /// Error codes: 0=successful, 1=device not found, 2=device not responding,
    /// 3=access to port denied
    /// </remarks>
    public int Init()
    {

      // ----- Open serial port connection
      string lPort = GetPort();
      if (string.IsNullOrEmpty(lPort)) { return 1; }
      _Port = new SerialPort(lPort);
      _Port.BaudRate = 1000000;
      _Port.DataBits = 8;
      try
      {
        _Port.Open();
      }
      catch (UnauthorizedAccessException e)
      {
        // Access to port denied, most likely has already a connection
        return 3;
      }


      // ----- Ping device to check if it's working
      if (!Reset())
      {
        _Port.Close();
        return 2;
      }


      // ----- Successfully initialized
      _Port.DataReceived += PortDataReceived;
      _Connected = true;
      _CommandWaitHandle = new AutoResetEvent(false);
      _CommandThread = new Thread(ProcessCommands);
      _CommandThread.Start();
      return 0;

    }


    /// <summary>
    /// Closes connection to device and resets class.
    /// </summary>
    /// <returns>Boolean whether termination was successful or not.</returns>
    public bool Terminate()
    {

      if (!_Connected) { return true; }
      if (_IsTerminating) { return true; }

      try
      {
        _IsTerminating = true;


        // ----- Stop command thread
        if (!_CommandThreadExit)
        {
          _CommandThread.Abort();
          _CommandThread.Join(1000);
        }


        // ----- Switch off device
        byte[] lCommand = new byte[COMMAND_LENGTH];
        lCommand[0] = 3;
        lCommand[COMMAND_LENGTH - 1] = 3;
        SendCommand(lCommand);


        // -----  Close connection
        _Port.DataReceived -= PortDataReceived;
        try
        {
          _Port.Close();
        }
        catch (UnauthorizedAccessException)
        {
          // This exception happens if connection was lost (when plugged out
          // for example), can be ignored
        }


        // ----- Reset class
        _Connected = false;
        _On = false;
        _Port = null;
        _CommandWaitHandle = null;

        _CommandSwitchOn = false;
        _CommandSwitchOff = false;
        _CommandThread = null;
        _CommandShow = new bool[] { false, false, false };
        _CommandImage = new bool[] { false, false, false };
        _CommandBrightness = false;
        _CommandGamma = false;

        _LastCommandResponse = 0;
        _LastKeyDown = 0;


        // ----- Result
        return true;
      }
      finally
      {
        _IsTerminating = false;
      }

    }


    /// <summary>
    /// Returns key down states.
    /// </summary>
    public byte GetKeyState()
    {
      byte lResult = _LastKeyDown;
      _LastKeyDown = 0;
      return lResult;
    }


    /// <summary>
    /// Returns connection state.
    /// </summary>
    public bool GetConnectionState()
    {
      return _Connected;
    }


    /// <summary>
    /// Pings device to check if it's working.
    /// </summary>
    /// <returns>Boolean determining whether device is working or not.</returns>
    private bool Reset()
    {

      bool lSuccess = false;


      // ----- Remove event handler to not interfere
      _Port.DataReceived -= PortDataReceived;


      // ----- Send 1 byte repeatedly until device responds
      for (int i = 0; i < 300; i++)
      {
        _Port.Write(new byte[] { 0 }, 0, 1);

        // After ~190 bytes we'll most likely get a response, add a break
        // to not miss it
        if (i > 190) { Thread.Sleep(1); }

        if (_Port.BytesToRead > 0)
        {
          byte[] pResponse = new byte[_Port.BytesToRead];
          _Port.Read(pResponse, 0, pResponse.Length);
          _Port.DiscardInBuffer();
          lSuccess = true;
          break;
        }
      }


      // ----- Add event handler again
      _Port.DataReceived += PortDataReceived;


      // ----- Result
      return lSuccess;

    }


    /// <summary>
    /// Sends command to device and waits for successful confirmation.
    /// </summary>
    /// <param name="command">Command to send.</param>
    /// <returns>Boolean determining whether sending was successful or not.</returns>
    private bool SendCommand(byte[] command)
    {

      //if (command[0] == 1) { return SendCommandLine(command); }
      try
      {
        bool lSuccess = false;
        int lTriesLeft = 10;

        while (!lSuccess && lTriesLeft > 0)
        {
          _Port.Write(command, 0, COMMAND_LENGTH);
          _CommandWaitHandle.Reset();
          if (_CommandWaitHandle.WaitOne(1000, false))
          {
            if (_LastCommandResponse == command[COMMAND_LENGTH - 1])
            {
              // Successful
              lSuccess = true;
              break;
            }
            else
            {
              // Not successful
              lTriesLeft -= 1;
              Thread.Sleep(1);
            }
          }
        }

        return lSuccess;
      }
      catch (UnauthorizedAccessException) // Happens when device is suddendly lost
      {
        return false;
      }

    }


    /// <summary>
    /// Sends command to device and waits for successful confirmation.
    /// </summary>
    /// <param name="command">Command to send.</param>
    /// <returns>Boolean determining whether sending was successful or not.</returns>
    /// <remarks>
    /// Copy&paste of the SendCommand method for line commands with a lower
    /// wait time on the handle. Seems to work faster, but that could be also
    /// wrong.
    /// </remarks>
    private bool SendCommandLine(byte[] command)
    {

      try
      {
        bool lSuccess = false;
        int lTriesLeft = 10;

        while (!lSuccess && lTriesLeft > 0)
        {
          _Port.Write(command, 0, COMMAND_LENGTH);
          _CommandWaitHandle.Reset();
          if (_CommandWaitHandle.WaitOne(1000, false))
          {
            if (_LastCommandResponse == command[COMMAND_LENGTH - 1])
            {
              // Successful
              lSuccess = true;
              break;
            }
            else
            {
              // Not successful
              lTriesLeft -= 1;
              Thread.Sleep(1);
            }
          }
        }

        return lSuccess;
      }
      catch (UnauthorizedAccessException) // Happens when device is shut off
      {
        return false;
      }

    }


    /// <summary>
    /// Handles incoming data from serial port.
    /// </summary>
    private void PortDataReceived(object sender, SerialDataReceivedEventArgs args)
    {

      try
      {
        // ----- At least 2 bytes must be present to make sure that a
        //       command confirmation is not skipped
        int lLength = _Port.BytesToRead;
        if (lLength < 2) { return; }


        // ----- Read received data into array - we're only expecting 
        //       2 byte pairs, single byte at the end is left in buffer
        int lPairs = lLength / 2;
        byte[] lData = new byte[lPairs * 2];
        _Port.Read(lData, 0, lPairs * 2);


        // ----- Command confirmation is a 0 followed by the checksum,
        //       key events are 1 followed by the key number - the device
        //       id response with 3 bytes is not used
        bool lCommandReceived = false;

        for (int i = 0; i < lPairs; i++)
        {
          byte lByte = lData[i];
          if (lByte == 0)
          {
            // Command confirmation
            _LastCommandResponse = lData[i * 2 + 1];
            lCommandReceived = true;
          }
          else if (lByte == 1)
          {
            // Key down
            byte lKey = lData[i * 2 + 1];
            if (lKey == 1) { _LastKeyDown |= 1; }
            else if (lKey == 2) { _LastKeyDown |= 2; }
            else if (lKey == 3) { _LastKeyDown |= 4; }
          }
        }


        // ----- If command confirmation was received notify wait handle
        if (lCommandReceived && _CommandWaitHandle != null) { _CommandWaitHandle.Set(); }
      }
      catch (UnauthorizedAccessException) // Happens when device is shut off
      {
        Terminate();
      }

    }


    /// <summary>
    /// Fills gamma tables.
    /// </summary>
    /// <param name="gamma">Gamma value, should be between 0 and 1.</param>
    private void FillGammaTable(float gamma)
    {

      _GammaTable = new byte[256];

      for (int i = 0; i < 256; i++)
      {
        _GammaTable[i] = (byte)Math.Floor(Math.Pow(i / 255.0F, 1 / gamma) * 255 + 0.5F);
      }

    }


    /// <summary>
    /// Gets the port the device is connected to.
    /// </summary>
    /// <returns>Port name or null if not found.</returns>
    /// <remarks>
    /// Does not work for windows 98 where the information is stored in
    /// different registry keys.
    /// </remarks>
    private static string GetPort()
    {

      string lResult = null;

      List<string> lPorts = new List<string>();
      lPorts.AddRange(SerialPort.GetPortNames());
      if (lPorts.Count == 0) { return null; }


      // ----- Get root
      string lRootName = "SYSTEM\\CurrentControlSet\\Enum\\USB\\Vid_067b&Pid_2303";
      RegistryKey lRoot = Registry.LocalMachine.OpenSubKey(lRootName);
      if (lRoot == null) { return null; }


      // ----- Get all keys below root - there can be several of them if the
      //       device was connected to different usb ports
      string[] lDevices = lRoot.GetSubKeyNames();
      if (lDevices == null) { return null; }


      // ----- Loop through all devices and get active port where it is connected
      foreach (string lDeviceKey in lDevices)
      {
        RegistryKey lDevice = lRoot.OpenSubKey(lDeviceKey + "\\Device Parameters");
        if (lDevice == null) { continue; }

        object lPortValue = lDevice.GetValue("PortName");
        if (lPortValue == null) { continue; }

        // Check if that port is active
        string lPort = (string)lPortValue;
        if (lPorts.Contains(lPort))
        {
          lResult = lPort;
          break;
        }
      }


      // ----- Result
      return lResult;

    }


    #region "Commands"

    /// <summary>
    /// Switches device on.
    /// </summary>
    public void SwitchOn()
    {
      _CommandSwitchOn = true;
    }


    /// <summary>
    /// Switches device off.
    /// </summary>
    public void SwitchOff()
    {
      _CommandSwitchOff = true;
    }


    /// <summary>
    /// Shows all images.
    /// </summary>
    public void ShowAll()
    {
      _CommandShow[0] = true;
      _CommandShow[1] = true;
      _CommandShow[2] = true;
    }


    /// <summary>
    /// Sets image.
    /// </summary>
    public void SetImage(byte index, Bitmap image)
    {
      _CommandImageValue[index] = new OptimusMiniConnectionImage(index, image, this);
      _CommandImage[index] = true;
    }


    /// <summary>
    /// Sets brightness.
    /// </summary>
    public void SetBrightness(OptimusMiniBrightness brightness)
    {
      _CommandBrightnessValue = brightness;
      _CommandBrightness = true;
    }


    /// <summary>
    /// Sets gamma.
    /// </summary>
    public void SetGamma(float gamma)
    {
      _CommandGammaValue = gamma;
      _CommandGamma = true;
    }

    #endregion


    #region "Processing commands"

    private void ProcessCommands()
    {

      try
      {

        Queue<byte[]> lCommands = new Queue<byte[]>();
        int[] lLastShowCommandSentOn = new int[] { 0, 0, 0 };

        _CommandThreadExit = false;

        while (_Connected && !_CommandThreadExit)
        {
          // ----- Switch on/off
          if (_CommandSwitchOff)
          {
            EnqueueSwitchOffCommand(lCommands);
            _On = false;
          }
          else if (_CommandSwitchOn)
          {
            EnqueueSwitchOnCommand(lCommands);
            _On = true;
          }
          _CommandSwitchOn = false;
          _CommandSwitchOff = false;


          // ----- Image processing
          if (_CommandGamma)
          {
            // Update gamma table
            if (_CommandGamma)
            {
              _CommandGamma = false;
              FillGammaTable(_CommandGammaValue);
            }

            // Generate images
            for (byte i = 0; i <= 2; i++)
            {
              if (_CommandImageValue[i] != null)
              {
                _CommandImageValue[i].GenerateLines();
                _CommandImage[i] = true;
              }
            }

          }


          // ----- Images
          for (byte i = 0; i <= 2; i++)
          {
            if (_CommandImage[i])
            {
              // Only sent if device is on to save on cpu time
              if (_On) { _CommandImageValue[i].AddToQueue(lCommands); }
              _CommandShow[i] = true;
            }
            _CommandImage[i] = false;
          }


          // ----- Brightness
          if (_CommandBrightness)
          {
            // Only done if device is on to save on cpu time
            if (_On) { EnqueueBrightnessCommand(_CommandBrightnessValue, lCommands); }
            _CommandBrightness = false;
          }


          // ----- Show: only done if device is on to save on cpu time
          if (_On)
          {
            // Check if last show is more than 5 seconds ago and queue show command - if it's
            // even at least 10 seconds ago an additional switch on is sent
            bool lSwitchOn = false;
            for (byte i = 0; i <= 2; i++)
            {
              int lAgo = (Environment.TickCount - lLastShowCommandSentOn[i]);
              if (lAgo >= 10000) { lSwitchOn = true; }
              if (lAgo >= 5000) { _CommandShow[i] = true; }
            }

            // Switch on
            if (lSwitchOn) { EnqueueSwitchOnCommand(lCommands); }

            // Queue show commands
            for (byte i = 0; i <= 2; i++)
            {
              if (_CommandShow[i])
              {
                EnqueueShowCommand(i, lCommands);
                _CommandShow[i] = false;
                lLastShowCommandSentOn[i] = Environment.TickCount;
              }
            }
          }


          // ----- Execute commands or if none present sleep
          if (lCommands.Count > 0)
          {
            while (lCommands.Count > 0)
            {
              if (!SendCommand(lCommands.Dequeue()))
              {
                _CommandThreadExit = true;
                break;
              }
            }
          }
          else
          {
            Thread.Sleep(10);
          }
        }

        _CommandThreadExit = true;
        Terminate();

      }
      catch (ThreadAbortException)
      {
      }

    }


    private static void EnqueueSwitchOnCommand(Queue<byte[]> queue)
    {
      byte[] lCommand = new byte[COMMAND_LENGTH];
      lCommand[0] = 2;
      lCommand[COMMAND_LENGTH - 1] = 2;
      queue.Enqueue(lCommand);
    }


    private static void EnqueueSwitchOffCommand(Queue<byte[]> queue)
    {
      byte[] lCommand = new byte[COMMAND_LENGTH];
      lCommand[0] = 3;
      lCommand[COMMAND_LENGTH - 1] = 3;
      queue.Enqueue(lCommand);
    }


    private static void EnqueueShowAllCommand(Queue<byte[]> queue)
    {
      EnqueueShowCommand(0, queue);
      EnqueueShowCommand(1, queue);
      EnqueueShowCommand(2, queue);
    }


    private static void EnqueueShowCommand(byte index, Queue<byte[]> queue)
    {
      byte[] lCommand = new byte[COMMAND_LENGTH];
      lCommand[0] = 4;
      lCommand[1] = (byte)(index + 1);
      lCommand[COMMAND_LENGTH - 1] = (byte)(4 + index + 1);
      queue.Enqueue(lCommand);
    }


    private static void EnqueueBrightnessCommand(OptimusMiniBrightness brightness, Queue<byte[]> queue)
    {
      byte[] lCommand = new byte[COMMAND_LENGTH];
      lCommand[0] = 9;

      switch (brightness)
      {
        case OptimusMiniBrightness.Low:
          lCommand[1] = 20;
          break;
        case OptimusMiniBrightness.Normal:
          lCommand[1] = 40;
          break;
        case OptimusMiniBrightness.High:
          lCommand[1] = 60;
          break;
      }

      lCommand[COMMAND_LENGTH - 1] = (byte)(lCommand[0] + lCommand[1]);
      queue.Enqueue(lCommand);
    }

    #endregion

  }


  /// <summary>
  /// An image split into lines which is sent to the device.
  /// </summary>
  internal class OptimusMiniConnectionImage
  {

    private byte[][] _Lines;
    private int _BitmapRgbLength;
    private byte[] _BitmapRgb;
    private byte _KeyIndex;
    private OptimusMiniConnection _Connection;


    public OptimusMiniConnectionImage(byte index, Bitmap image, OptimusMiniConnection connection)
    {

      _KeyIndex = index;
      _Connection = connection;


      // ----- Copy bitmap into array for faster processing
      BitmapData lBitmapData = image.LockBits(new Rectangle(0, 0, OptimusMiniConnection.SCREEN_SIZE, OptimusMiniConnection.SCREEN_SIZE), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
      _BitmapRgbLength = OptimusMiniConnection.SCREEN_SIZE * OptimusMiniConnection.SCREEN_SIZE * 3;
      _BitmapRgb = new byte[_BitmapRgbLength];
      System.Runtime.InteropServices.Marshal.Copy(lBitmapData.Scan0, _BitmapRgb, 0, _BitmapRgbLength);
      image.UnlockBits(lBitmapData);


      // ----- Generate lines
      GenerateLines();

    }


    /// <summary>
    /// Called from constructor, but can be called again to re-generate lines (when e.g.
    /// gamma changed).
    /// </summary>
    public void GenerateLines()
    {

      byte lColor1R, lColor1G, lColor1B;
      byte lColor2R, lColor2G, lColor2B;
      int lIndex;
      byte[] lCommand;


      // ----- Setup array
      _Lines = new byte[96][];
      for (int i = 0; i < 96; i++)
      {
        _Lines[i] = new byte[197];
      }


      // ----- Convert image
      for (int y = 0; y < OptimusMiniConnection.SCREEN_SIZE; y += 1)
      {
        lCommand = _Lines[y];
        lCommand[0] = 1;
        lCommand[1] = (byte)(_KeyIndex + 1);
        lCommand[2] = (byte)((192 * y) >> 8); // high order
        lCommand[3] = (byte)((192 * y) - (lCommand[2] << 8)); // low order
        lCommand[OptimusMiniConnection.COMMAND_LENGTH - 1] += (byte)(lCommand[0] + lCommand[1] + lCommand[2] + lCommand[3]);

        for (int x = 0; x < OptimusMiniConnection.SCREEN_SIZE; x += 2)
        {
          lIndex = y * OptimusMiniConnection.SCREEN_SIZE * 3 + x * 3;

          lColor1R = _BitmapRgb[lIndex + 2];
          lColor1G = _BitmapRgb[lIndex + 1];
          lColor1B = _BitmapRgb[lIndex];
          lColor2R = _BitmapRgb[lIndex + 5];
          lColor2G = _BitmapRgb[lIndex + 4];
          lColor2B = _BitmapRgb[lIndex + 3];

          // Gamma
          lColor1R = _Connection._GammaTable[lColor1R];
          lColor1G = _Connection._GammaTable[lColor1G];
          lColor1B = _Connection._GammaTable[lColor1B];
          lColor2R = _Connection._GammaTable[lColor2R];
          lColor2G = _Connection._GammaTable[lColor2G];
          lColor2B = _Connection._GammaTable[lColor2B];

          // Fix because device is too green?
          if (lColor1G < 8) { lColor1G = 0; }
          if (lColor2G < 8) { lColor2G = 0; }

          // Append colors to command
          lCommand[4 + x * 2] = (byte)((lColor1R & 0xF8) + (lColor1G >> 5));
          lCommand[5 + x * 2] = (byte)((lColor1B >> 3) + ((lColor1G & 0xFC) << 3));

          lCommand[6 + x * 2] = (byte)((lColor2R & 0xF8) + (lColor2G >> 5));
          lCommand[7 + x * 2] = (byte)((lColor2B >> 3) + ((lColor2G & 0xFC) << 3));

          lCommand[OptimusMiniConnection.COMMAND_LENGTH - 1] += (byte)(lCommand[4 + x * 2] + lCommand[5 + x * 2] + lCommand[6 + x * 2] + lCommand[7 + x * 2]);
        }
      }

    }


    public void AddToQueue(Queue<byte[]> queue)
    {

      for (byte i = 0; i < OptimusMiniConnection.SCREEN_SIZE; i++)
      {
        //queue.Enqueue(_Lines[i]);
        string lCurrentHash = BitConverter.ToString(_Connection._Md5.ComputeHash(_Lines[i]));
        //int lCurrentHash = BitConverter.ToInt32(_Connection._Checksum.ComputeHash(_Lines[i]), 0);

        if (_Connection._LastLinesCheckSum[_KeyIndex * 96 + i] != lCurrentHash)
        {
          queue.Enqueue(_Lines[i]);
          _Connection._LastLinesCheckSum[_KeyIndex * 96 + i] = lCurrentHash;
        }
      }

    }

  }

}