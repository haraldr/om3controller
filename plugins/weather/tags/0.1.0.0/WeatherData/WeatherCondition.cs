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

namespace WeatherPlugin
{

  /// <summary>
  /// Contains weather conditions for a date.
  /// </summary>
  public class WeatherCondition
  {
    private DateTime _Date;
    private int _TemperatureHigh;
    private int _TemperatureLow;
    private int _ConditionIcon;
    private string _ConditionText;
    private bool _IsNight;


    /// <summary>
    /// Creates a new instance of the <see cref="WeatherCondition" /> class and returns it.
    /// </summary>
    public WeatherCondition()
    {
    }


    /// <summary>
    /// Gets or sets date.
    /// </summary>
    public DateTime Date
    {
      get { return _Date; }
      set { _Date = value; }
    }


    /// <summary>
    /// Gets or sets max temperature.
    /// </summary>
    /// <remarks>
    /// Set to max value for n/a.
    /// </remarks>
    public int TemperatureHigh
    {
      get { return _TemperatureHigh; }
      set { _TemperatureHigh = value; }
    }


    /// <summary>
    /// Gets or sets min temperature.
    /// </summary>
    /// <remarks>
    /// Set to min value for n/a.
    /// </remarks>
    public int TemperatureLow
    {
      get { return _TemperatureLow; }
      set { _TemperatureLow = value; }
    }


    /// <summary>
    /// Gets or sets internal number of condition icon to use.
    /// </summary>
    /// <remarks>
    /// Set to min value for n/a.
    /// </remarks>
    public int ConditionIcon
    {
      get { return _ConditionIcon; }
      set { _ConditionIcon = value; }
    }


    /// <summary>
    /// Gets or sets description of condition.
    /// </summary>
    public string ConditionText
    {
      get { return _ConditionText; }
      set { _ConditionText = value; }
    }


    /// <summary>
    /// Gets or sets boolean flag determining whether data is for day or night.
    /// </summary>
    /// <remarks>
    /// This flag is only set for today to differentiate between today/tonight.
    /// </remarks>
    public bool IsNight
    {
      get { return _IsNight; }
      set { _IsNight = value; }
    }


    /// <summary>
    /// Creates a new instance and sets the values from the passed config.
    /// </summary>
    /// <param name="config">Configuration string.</param>
    /// <returns>A new instance.</returns>
    public static WeatherCondition ReadFromConfig(string config)
    {
      string[] lValues = config.Split(';');

      WeatherCondition lResult = new WeatherCondition();
      lResult._Date = DateTime.Parse("yyyyMMdd");
      lResult._TemperatureHigh = int.Parse(lValues[1]);
      lResult._TemperatureLow = int.Parse(lValues[2]);
      lResult._ConditionIcon = int.Parse(lValues[3]);
      lResult._ConditionText = lValues[4];

      return lResult;

    }


    /// <summary>
    /// Returns configuration string from the passed instance.
    /// </summary>
    /// <param name="instance">Instance to get configuration string for.</param>
    /// <returns>Configuration string.</returns>
    public static string WriteToConfig(WeatherCondition instance)
    {
      string lResult = string.Join(";", new string[]{
        instance._Date.ToString("yyyyMMdd"),
        instance._TemperatureHigh.ToString(),
        instance._TemperatureLow.ToString(),
        instance._ConditionIcon.ToString(),
        instance.ConditionText});
      return lResult;
    }


    /// <summary>
    /// Creates an n/a instance.
    /// </summary>
    /// <param name="date">Date to set.</param>
    /// <returns>Instance with values set to n/a.</returns>
    public static WeatherCondition CreateNotAvailable(DateTime date)
    {
      WeatherCondition lResult = new WeatherCondition();

      lResult._ConditionIcon = int.MinValue;
      lResult._ConditionText = "";
      lResult._Date = date;
      lResult._TemperatureHigh = int.MaxValue;
      lResult._TemperatureLow = int.MinValue;

      return lResult;
    }

  }

}