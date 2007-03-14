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
  /// Contains weather data for the next 7 days (including today/tonight).
  /// </summary>
  /// <remarks>
  /// For today/tonight the weather data provider will decide if it's time
  /// to take day or night part. For the other days always takes the day part.
  /// </remarks>
  public class WeatherData
  {

    private Dictionary<DateTime, WeatherCondition> _Forecast;


    /// <summary>
    /// Creates a new instance of the <see cref="WeatherData" /> class and returns it.
    /// </summary>
    public WeatherData()
    {
      _Forecast = new Dictionary<DateTime, WeatherCondition>();
    }


    /// <summary>
    /// Clears all data.
    /// </summary>
    public void ClearData()
    {
      _Forecast.Clear();
    }


    /// <summary>
    /// Gets data for specified date.
    /// </summary>
    /// <param name="date">Date to get condition for.</param>
    /// <returns>Weather condition or if data not available an n/a condition is returned.</returns>
    public WeatherCondition GetData(DateTime date)
    {
      if (_Forecast.ContainsKey(date.Date))
      {
        return _Forecast[date.Date];
      }
      else
      {
        return WeatherCondition.CreateNotAvailable(date.Date);
      }
    }


    /// <summary>
    /// Adds passed condition, date is taken from passed object.
    /// </summary>
    /// <param name="condition">Condition to add.</param>
    public void SetData(WeatherCondition condition)
    {
      _Forecast[condition.Date] = condition;
    }

  }

}