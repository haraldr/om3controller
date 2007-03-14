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
using System.Xml;
using System.Net;
using System.IO;


namespace WeatherPlugin
{

  public class WeatherDataProvider
  {

    private const string URL = "http://xoap.weather.com/weather/local/{0}?dayf=10&prod=xoap&par=1034275360&key=17d2a8cca1306efb&unit={1}";
    private DateTime _LastUpdate;


    private XmlDocument GetXml(string locationCode, string unit)
    {
      XmlDocument lXml = new XmlDocument();

      //lXml.LoadXml(Properties.Resources.WeatherXml);
      //return lXml;

      StringBuilder lResult = new StringBuilder();

      try
      {
        WebRequest lRequest = WebRequest.Create(string.Format(URL, locationCode, unit));
        lRequest.Timeout = 30000;

        WebResponse lResponse = lRequest.GetResponse();
        Stream lResponseStream = lResponse.GetResponseStream();

        byte[] lBytes = new byte[128];
        int lBytesRead = lResponseStream.Read(lBytes, 0, 128);
        Encoding lEncode = Encoding.GetEncoding("utf-8");

        while (lBytesRead > 0)
        {
          lResult.Append(lEncode.GetString(lBytes, 0, lBytesRead));
          lBytesRead = lResponseStream.Read(lBytes, 0, 128);
        }

        lResponseStream.Close();
      }
      catch (IOException)
      {
        lResult.Length = 0;
      }
      catch (WebException)
      {
        lResult.Length = 0;
      }

      lXml.LoadXml(lResult.ToString());
      return lXml;

    }


    private WeatherCondition ParseDay(XmlElement node, bool parseNight)
    {

      WeatherCondition lResult = new WeatherCondition();
      lResult.IsNight = parseNight;

      foreach (XmlElement lChild in node.ChildNodes)
      {
        switch (lChild.Name)
        {
          case "hi":
            if (lChild.InnerText != "N/A")
            {
              lResult.TemperatureHigh = int.Parse(lChild.InnerText);
            }
            else
            {
              lResult.TemperatureHigh = int.MaxValue;
            }
            break;

          case "low":
            if (lChild.InnerText != "N/A")
            {
              lResult.TemperatureLow = int.Parse(lChild.InnerText);
            }
            else
            {
              lResult.TemperatureLow = int.MinValue;
            }
            break;

          case "part":
            if (lChild.Attributes["p"].Value == "d" && !parseNight)
            {
              ParseDay_Part(lChild, lResult);
            }
            else if (lChild.Attributes["p"].Value == "n" && parseNight)
            {
              ParseDay_Part(lChild, lResult);
            }
            break;
        }
      }

      return lResult;

    }


    private void ParseDay_Part(XmlElement node, WeatherCondition data)
    {
      foreach (XmlElement lChild in node.ChildNodes)
      {
        switch (lChild.Name)
        {
          case "icon":
            data.ConditionIcon = int.Parse(lChild.InnerText);
            break;

          case "t":
            data.ConditionText = lChild.InnerText;
            break;
        }
      }
    }


    public void Update(WeatherData instance, string locationCode, string unit)
    {
      if (locationCode == "") { return; }
      if (DateTime.Now.Subtract(_LastUpdate).TotalMinutes <= 120) { return; }

      XmlDocument lXml = GetXml(locationCode, unit);


      // ----- Get local time of location
      string lLocalTimeValue = lXml.DocumentElement.SelectSingleNode("loc/tm").InnerText;
      DateTime lLocalTime;
      lLocalTime = DateTime.Parse(lLocalTimeValue, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat);


      // ----- Get date the forecasts are based on
      string lBaseDateValue = lXml.DocumentElement.SelectSingleNode("dayf/lsup").InnerText;
      if (lBaseDateValue.IndexOf("AM") >= 0)
      {
        lBaseDateValue = lBaseDateValue.Substring(0, lBaseDateValue.IndexOf("AM") + 2);
      }
      else if (lBaseDateValue.IndexOf("PM") >= 0)
      {
        lBaseDateValue = lBaseDateValue.Substring(0, lBaseDateValue.IndexOf("PM") + 2);
      }

      DateTime lBaseDate;
      lBaseDate = DateTime.Parse(lBaseDateValue, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat);


      // ----- Parse forecasts
      instance.ClearData();
      foreach (XmlElement lChild in lXml.DocumentElement.SelectNodes("dayf/day"))
      {
        int lIndex = int.Parse(lChild.Attributes["d"].Value);
        if (lIndex >= 0 && lIndex <= 9)
        {
          WeatherCondition lData;
          if (lIndex == 0)
          {
            // Starting with 17:00 (local time of location) the night's data is displayed
            lData = ParseDay(lChild, (lLocalTime.Hour >= 17));
          }
          else
          {
            lData = ParseDay(lChild, false);
          }
          
          lData.Date = lBaseDate.Date.AddDays(lIndex);
          instance.SetData(lData);
        }
      }

      _LastUpdate = DateTime.Now;

    }

  }

}