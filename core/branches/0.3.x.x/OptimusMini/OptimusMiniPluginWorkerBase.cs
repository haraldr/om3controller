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
using System.Diagnostics;


namespace Toolz.OptimusMini
{

  /// <summary>
  /// Base class to implement the working part of a plugin.
  /// </summary>
  public abstract class OptimusMiniPluginWorkerBase
  {

    internal Bitmap _Bitmap;
    internal bool _UpdateRunning;
    internal Stopwatch _NextUpdateTimer;
    internal TimeSpan _NextUpdate;


    protected OptimusMiniPluginWorkerBase()
    {
      _NextUpdateTimer = new Stopwatch();
      _NextUpdate = TimeSpan.MinValue;
    }


    internal bool IsNextUpdateDue()
    {
      if (!_UpdateRunning &&
          _NextUpdate != TimeSpan.MinValue &&
          _NextUpdateTimer.ElapsedMilliseconds > _NextUpdate.TotalMilliseconds)
      {
        return true;
      }
      else
      {
        return false;
      }
    }


    /// <summary>
    /// Called before plugin is added.
    /// </summary>
    /// <param name="currentSettings">Current settings.</param>
    /// <remarks>
    /// This is the place to do necessary initialization, e.g. loading
    /// settings and requesting call of Update method.
    /// </remarks>
    public abstract void Initialize(OptimusMiniSettingsList currentSettings);


    /// <summary>
    /// Called before plugin is removed.
    /// </summary>
    /// <remarks>
    /// This is the place to do necessary clean up work.
    /// </remarks>
    public abstract void Terminate();


    /// <summary>
    /// Request to update the image.
    /// </summary>
    public abstract void Repaint();


    /// <summary>
    /// Adds passed image to the command queue to show it.
    /// </summary>
    public void UpdateImage(Bitmap image)
    {
      _Bitmap = image.Clone(new Rectangle(0, 0, 96, 96), PixelFormat.Format24bppRgb);
    }


    /// <summary>
    /// Requests next call to update method.
    /// </summary>
    /// <param name="interval">When to call the update method. Pass min value to stop calls.</param>
    public void RequestNextUpdate(TimeSpan interval)
    {
      _NextUpdate = interval;
      _NextUpdateTimer.Reset();
      _NextUpdateTimer.Start();
    }


    internal void Update(object p)
    {
      _UpdateRunning = true;
      Update();
      _UpdateRunning = false;
      _NextUpdateTimer.Reset();
      _NextUpdateTimer.Start();
    }


    /// <summary>
    /// Method is called repeatedly using specified interval.
    /// </summary>
    public abstract void Update();


    internal void OnKeyDown(object p)
    {
      OnKeyDown();
    }


    /// <summary>
    /// Called when button was pressed down.
    /// </summary>
    public virtual void OnKeyDown()
    {
    }


    internal void OnKeyUp(object p)
    {
      OnKeyUp();
    }


    /// <summary>
    /// Called when button was released.
    /// </summary>
    public virtual void OnKeyUp()
    {
    }


    internal void OnKeyPress(object p)
    {
      OnKeyPress();
    }


    /// <summary>
    /// Called when button was pressed.
    /// </summary>
    public virtual void OnKeyPress()
    {
    }


    internal void OnKeyDoublePress(object p)
    {
      OnKeyDoublePress();
    }


    /// <summary>
    /// Called when button was pressed two times repeatedly.
    /// </summary>
    public virtual void OnKeyDoublePress()
    {
    }


    internal void OnKeyHold(object p)
    {
      OnKeyHold();
    }


    /// <summary>
    /// Called when button is held down.
    /// </summary>
    public virtual void OnKeyHold()
    {
    }


    internal void OnKeyRelease(object p)
    {
      OnKeyRelease();
    }


    /// <summary>
    /// Called when button was held down and then released.
    /// </summary>
    public virtual void OnKeyRelease()
    {
    }

  }

}