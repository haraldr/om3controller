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
using Toolz.OptimusMini;


namespace StopWatch
{

  public class StopWatchPlugin : OptimusMiniPluginBase
  {

    public StopWatchPlugin()
      : base()
    {
      _Id = "6CD84378-EFDE-4457-A4A2-4993F904FB0B";
      _Name = "Stopwatch";
      _Description = "Simple stop watch plugin.";
      _Author = "Harald Röxeisen";
      _IsConfigurable = false;
    }


    public override OptimusMiniPluginWorkerBase CreateWorker()
    {
      return new StopWatchPluginWorker();
    }
  }


  public class StopWatchPluginWorker : OptimusMiniPluginWorkerBase
  {

    private Bitmap _Bitmap;
    private Graphics _Graphic;
    private Stopwatch _StopWatch;
    private bool _Running;
    private bool _AlternateFrame;


    public StopWatchPluginWorker()
      : base()
    {
      _Bitmap = new Bitmap(96, 96, PixelFormat.Format16bppRgb565);
      _Graphic = Graphics.FromImage(_Bitmap);
      _StopWatch = new Stopwatch();
    }

    public override void Initialize(OptimusMiniSettingsList currentSettings)
    {
      RequestNextUpdate(TimeSpan.MinValue);
    }


    public override void Terminate()
    {
    }


    public override void Repaint()
    {
      lock (_Graphic)
      {
        _Graphic.FillRectangle(Brushes.Black, 0, 0, 96, 96);

        if (_Running)
        {
          // Current time
          TimeSpan lSpan = _StopWatch.Elapsed;
          string lText;
          if (_AlternateFrame)
          {
            lText = lSpan.Hours.ToString("00") + ":" + lSpan.Minutes.ToString("00") + ":" + lSpan.Seconds.ToString("00");
          }
          else
          {
            lText = lSpan.Hours.ToString("00") + " " + lSpan.Minutes.ToString("00") + " " + lSpan.Seconds.ToString("00");
          }
          _AlternateFrame = !_AlternateFrame;
          int lWidth = _Graphic.MeasureString(lText, SystemFonts.DefaultFont).ToSize().Width;
          _Graphic.DrawString(lText, SystemFonts.DefaultFont, Brushes.White, (96 - lWidth) / 2, 10);

          // Instructions
          _Graphic.DrawString("Press to stop.", SystemFonts.DefaultFont, Brushes.White, 0, 50);
          _Graphic.DrawString("Hold to reset.", SystemFonts.DefaultFont, Brushes.White, 0, 70);
        }
        else
        {
          TimeSpan lSpan = _StopWatch.Elapsed;
          string lText = lSpan.Hours.ToString("00") + ":" + lSpan.Minutes.ToString("00") + ":" + lSpan.Seconds.ToString("00");
          int lWidth = _Graphic.MeasureString(lText, SystemFonts.DefaultFont).ToSize().Width;
          _Graphic.DrawString(lText, SystemFonts.DefaultFont, Brushes.White, (96 - lWidth) / 2, 10);
          if (lSpan.TotalMilliseconds == 0)
          {
            _Graphic.DrawString("Press to start.", SystemFonts.DefaultFont, Brushes.White, 0, 50);
          }
          else
          {
            _Graphic.DrawString("Press to continue.", SystemFonts.DefaultFont, Brushes.White, 0, 50);
          }
          _Graphic.DrawString("Hold to reset.", SystemFonts.DefaultFont, Brushes.White, 0, 70);
        }

        _Graphic.Flush();
        UpdateImage(_Bitmap);
      }
    }


    public override void Update()
    {
      Repaint();
    }


    public override void OnKeyHold()
    {
      base.OnKeyHold();
      _Running = false;
      _StopWatch.Reset();
      Repaint();
      RequestNextUpdate(TimeSpan.MinValue);
    }


    public override void OnKeyPress()
    {
      base.OnKeyPress();
      if (_Running)
      {
        _Running = false;
        _StopWatch.Stop();
        Repaint();
        RequestNextUpdate(TimeSpan.MinValue);
      }
      else
      {
        _Running = true;
        _StopWatch.Start();
        Repaint();
        RequestNextUpdate(new TimeSpan(0, 0, 1));
      }

    }

  }

}