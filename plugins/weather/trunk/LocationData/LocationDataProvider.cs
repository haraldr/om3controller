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
using System.Net;
using System.IO;
using System.Xml;


namespace WeatherPlugin
{

  public class LocationDataProvider
  {

    private const string URL = "http://xoap.weather.com/search/search?where={0}";

    private List<LocationData> _Locations;


    /// <summary>
    /// Creates a new instance of the <see cref="LocationDataProvider" /> class and returns it.
    /// </summary>
    public LocationDataProvider()
    {
      _Locations = new List<LocationData>();
    }


    /// <summary>
    /// Gets locations found with last search.
    /// </summary>
    public List<LocationData> Locations
    {
      get { return _Locations; }
    }


    /// <summary>
    /// Makes a search, result is provided through <see cref="Locations" /> property.
    /// </summary>
    public void Search(string criteria)
    {
      XmlDocument lXml = GetXml(criteria);

      _Locations.Clear();
      foreach (XmlElement lChild in lXml.DocumentElement.SelectNodes("loc"))
      {
        LocationData lLocation = new LocationData();
        lLocation.Code = lChild.Attributes["id"].Value;
        lLocation.Name = lChild.InnerText;
        _Locations.Add(lLocation);
      }

    }


    private XmlDocument GetXml(string criteria)
    {
      XmlDocument lXml = new XmlDocument();
      StringBuilder lResult = new StringBuilder();

      try
      {
        WebRequest lRequest = WebRequest.Create(string.Format(URL, criteria));
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

  }

}