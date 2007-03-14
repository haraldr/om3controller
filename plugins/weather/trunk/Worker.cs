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


namespace WeatherPlugin
{

  public class WeatherPluginWorker : OptimusMiniPluginWorkerBase
  {

    private const int ICON_X = 16;
    private const int ICON_Y = 16;

    private Bitmap _Bitmap;
    private Graphics _Graphic;
    private Font _TitleFont;
    private Font _SmallFont;
    private WeatherData _Data;
    private WeatherDataProvider _DataProvider;

    private bool _ShowToday;
    private bool _ShowTomorrow;
    private bool _ShowDayAfterTomorrow;
    private bool _ShowWeekend;
    private int _Wait;
    private string _LocationCode;
    private string _Unit;
    private string _UnitSign;

    private int _DisplayType;
    private DateTime _CurrentDisplayDate;
    private int _CurrentDisplayNumberDays;
    private string _CurrentDisplayTitle;


    public WeatherPluginWorker()
      : base()
    {
    }


    public override void Initialize(OptimusMiniSettingsList currentSettings)
    {
      _Bitmap = new Bitmap(96, 96, PixelFormat.Format16bppRgb565);
      _Graphic = Graphics.FromImage(_Bitmap);
      _Data = new WeatherData();
      _DataProvider = new WeatherDataProvider();

      _TitleFont = new Font("Tahoma", 12f, FontStyle.Bold, GraphicsUnit.Pixel);
      _SmallFont = SystemFonts.DefaultFont;

      _DisplayType = -1;

      if (currentSettings["ShowToday"] == "") { _ShowToday = true; }
        else { _ShowToday = (currentSettings["ShowToday"] == "1"); }
      if (currentSettings["ShowTomorrow"] == "") { _ShowTomorrow = true; }
        else { _ShowTomorrow = (currentSettings["ShowTomorrow"] == "1"); }
      if (currentSettings["ShowDayAfterTomorrow"] == "") { _ShowDayAfterTomorrow = true; }
        else { _ShowDayAfterTomorrow = (currentSettings["ShowDayAfterTomorrow"] == "1"); }
      if (currentSettings["ShowWeekend"] == "") { _ShowWeekend = true; }
        else { _ShowWeekend = (currentSettings["ShowWeekend"] == "1"); }

      if (currentSettings["Wait"] != "") { _Wait = int.Parse(currentSettings["Wait"]); } else { _Wait = 30; }
      _LocationCode = currentSettings["LocationCode"];
      _Unit = currentSettings["Unit"];
      if (_Unit == "") { _Unit = "m"; }
      if (_Unit == "m") { _UnitSign = "°"; } else { _UnitSign = "°F"; }

      RequestNextUpdate(new TimeSpan(0, 0, 3)); // Slight delay to display logo once
    }


    public override void Terminate()
    {
      _Graphic.Dispose();
      _Bitmap.Dispose();
      _TitleFont.Dispose();
      _SmallFont.Dispose();
    }


    public override void Repaint()
    {

      // If no day set we display logo until we've up to date weather data
      if (_CurrentDisplayDate == DateTime.MinValue)
      {
        Repaint_Logo();
      }

      // Single day displayed
      else if (_CurrentDisplayNumberDays == 1)
      {
        Repaint_Day();
      }

      // 3 day period displayed
      else
      {
        Repaint_Period();
      }

    }


    private void Repaint_Logo()
    {
      lock (_Graphic)
      {
        _Graphic.FillRectangle(Brushes.Black, 0, 0, 96, 96);
        _Graphic.DrawImageUnscaled(Properties.Resources.logo, 16, 16);
        _Graphic.Flush();
        UpdateImage(_Bitmap);
      }
    }


    private void Repaint_Day()
    {

      DateTime lDate = DateTime.Now.Date;
      WeatherCondition lCondition = _Data.GetData(_CurrentDisplayDate);


      // ----- Title
      string lTitle = "";
      if (lCondition.Date.Date.Subtract(lDate).Days == 0)
      {
        lTitle = lCondition.IsNight ? "Tonight" : "Today";
      }
      else if (lCondition.Date.Date.Subtract(lDate).Days == 1)
      {
        lTitle = "Tomorrow";
      }
      else
      {
        lTitle = lCondition.Date.DayOfWeek.ToString();
      }


      // ----- Temperature
      string lTemperature = "";
      if (lCondition.TemperatureLow != int.MinValue && lCondition.TemperatureHigh != int.MaxValue)
      {
        // Both low and high available
        lTemperature = string.Format("{0}{1} to {2}{3}", lCondition.TemperatureLow, _UnitSign, lCondition.TemperatureHigh, _UnitSign);
      }
      else if (lCondition.TemperatureLow != int.MinValue)
      {
        // Only low available
        lTemperature = string.Format("{0}{1}", lCondition.TemperatureLow, _UnitSign);
      }
      else if (lCondition.TemperatureHigh != int.MaxValue)
      {
        // Only high available
        lTemperature = string.Format("{0}{1}", lCondition.TemperatureHigh, _UnitSign);
      }
      else
      {
        // None available
        lTemperature = "n/a";
      }


      // ----- Update image
      lock (_Graphic)
      {
        _Graphic.FillRectangle(Brushes.Black, 0, 0, 96, 96);

        // Title
        int lTitleX = (96 - _Graphic.MeasureString(lTitle, _TitleFont).ToSize().Width) / 2;
        _Graphic.DrawString(lTitle, _TitleFont, Brushes.CadetBlue, lTitleX, 0);

        // Icon
        if (lCondition.ConditionIcon != int.MinValue)
        {
          Bitmap lIcon = (Bitmap)Properties.Resources.ResourceManager.GetObject("wicon64_" + lCondition.ConditionIcon.ToString());
          _Graphic.DrawImage(lIcon, ICON_X, ICON_Y, 64, 64);
        }
        else
        {
          _Graphic.DrawImage(Properties.Resources.wicon64_na, ICON_X, ICON_Y, 64, 64);
        }

        // Temperature
        int lTemperatureX = (96 - _Graphic.MeasureString(lTemperature, _SmallFont).ToSize().Width) / 2;
        _Graphic.DrawString(lTemperature, _SmallFont, Brushes.White, lTemperatureX, 80);

        // Update
        _Graphic.Flush();
        UpdateImage(_Bitmap);
      }
    }


    private void Repaint_Period()
    {

      DateTime lDate = DateTime.Now.Date;
      WeatherCondition[] lConditions = new WeatherCondition[3];


      // ----- Get conditions
      for (int i = 0; i <= 2; i++)
      {
        lConditions[i] = _Data.GetData(_CurrentDisplayDate.AddDays(i));
      }


      // ----- Update image
      lock (_Graphic)
      {
        _Graphic.FillRectangle(Brushes.Black, 0, 0, 96, 96);

        // Title
        int lTitleX = (96 - _Graphic.MeasureString(_CurrentDisplayTitle, _TitleFont).ToSize().Width) / 2;
        _Graphic.DrawString(_CurrentDisplayTitle, _TitleFont, Brushes.CadetBlue, lTitleX, 0);

        // Conditions
        for (int i = 0; i <= 2; i++)
        {
          WeatherCondition lCondition = lConditions[i];

          // Icon
          if (lCondition.ConditionIcon != int.MinValue)
          {
            Bitmap lIcon = (Bitmap)Properties.Resources.ResourceManager.GetObject("wicon32_" + lCondition.ConditionIcon.ToString());
            _Graphic.DrawImage(lIcon, 32 * i, 38, 32, 32);
          }
          else
          {
            _Graphic.DrawImage(Properties.Resources.wicon32_na, 32 * i, 38, 32, 32);
          }

          // Day
          string lDay = lCondition.Date.DayOfWeek.ToString().Substring(0, 2);
          int lDayX = (32 - _Graphic.MeasureString(lDay, _SmallFont).ToSize().Width) / 2;
          _Graphic.DrawString(lDay, _SmallFont, Brushes.White, i * 32 + lDayX, 22);

          // Temperature
          string lTemperature = "n/a";
          if (lCondition.TemperatureHigh != int.MaxValue) { lTemperature = string.Format("{0}{1}", lCondition.TemperatureHigh, _UnitSign); }
          else if (lCondition.TemperatureLow != int.MinValue) { lTemperature = string.Format("{0}{1}", lCondition.TemperatureLow, _UnitSign); }
          int lTemperatureX = (32 - _Graphic.MeasureString(lTemperature, _SmallFont).ToSize().Width) / 2;
          _Graphic.DrawString(lTemperature, _SmallFont, Brushes.White, i * 32 + lTemperatureX, 74);
        }

        // Update
        _Graphic.Flush();
        UpdateImage(_Bitmap);
      }
    }


    public override void Update()
    {
      // ----- Update data if necessary
      _DataProvider.Update(_Data, _LocationCode, _Unit);


      // ----- Next cycle
      bool lWantedType = false;
      while (!lWantedType)
      {
        _DisplayType += 1;
        if (_DisplayType == 4) { _DisplayType = 0; }

        if ((_DisplayType == 0 && _ShowToday) ||
            (_DisplayType == 1 && _ShowTomorrow) ||
            (_DisplayType == 2 && _ShowDayAfterTomorrow) ||
            (_DisplayType == 3 && _ShowWeekend))
        {
          lWantedType = true;
          break;
        }
      }


      // ----- Set date(s) to display
      if (_DisplayType == 0)
      {
        // Today
        _CurrentDisplayDate = DateTime.Now.Date;
        _CurrentDisplayNumberDays = 1;
      }
      else if (_DisplayType == 1)
      {
        // Tomorrow
        _CurrentDisplayDate = DateTime.Now.AddDays(1);
        _CurrentDisplayNumberDays = 1;
      }
      else if (_DisplayType == 2)
      {
        // Day after tomorrow
        _CurrentDisplayDate = DateTime.Now.AddDays(2);
        _CurrentDisplayNumberDays = 1;
      }
      else if (_DisplayType == 3)
      {
        // 3 days forecast
        DayOfWeek lDay = DateTime.Now.DayOfWeek;
        if (lDay == DayOfWeek.Monday || lDay == DayOfWeek.Tuesday || lDay == DayOfWeek.Wednesday)
        {
          // Display following weekend
          if (lDay == DayOfWeek.Monday) { _CurrentDisplayDate = DateTime.Now.AddDays(4); }
          else if (lDay == DayOfWeek.Tuesday) { _CurrentDisplayDate = DateTime.Now.AddDays(3); }
          else { _CurrentDisplayDate = DateTime.Now.AddDays(2); }
          _CurrentDisplayNumberDays = 3;
          _CurrentDisplayTitle = "This weekend";
        }
        else if (lDay == DayOfWeek.Thursday)
        {
          // Except sunday weekend is already displayed, show following 3 days
          _CurrentDisplayDate = DateTime.Now.AddDays(3);
          _CurrentDisplayNumberDays = 3;
          _CurrentDisplayTitle = "Next week";
        }
        else if (lDay == DayOfWeek.Friday || lDay == DayOfWeek.Saturday || lDay == DayOfWeek.Sunday)
        {
          // Weekend already covered, show next
          _CurrentDisplayDate = DateTime.Now.AddDays(7);
          if (lDay == DayOfWeek.Saturday) { _CurrentDisplayDate = _CurrentDisplayDate.AddDays(-1); }
          if (lDay == DayOfWeek.Sunday) { _CurrentDisplayDate = _CurrentDisplayDate.AddDays(-2); }
          _CurrentDisplayNumberDays = 3;
          _CurrentDisplayTitle = "Next weekend";
        }
      }


      // ----- Repaint and request next update
      Repaint();
      RequestNextUpdate(new TimeSpan(0, 0, _Wait));
    }


    public override void OnKeyDoublePress()
    {
      base.OnKeyDoublePress();
      System.Diagnostics.Process.Start("http://www.weather.com/?prod=xoap&par=1034275360");
    }

  }

}