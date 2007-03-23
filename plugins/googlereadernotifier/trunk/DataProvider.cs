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
using System.Web;
using System.Xml;


namespace GoogleReaderNotifierPlugin
{

  /// <summary>
  /// Handles login to google to get session id.
  /// </summary>
  internal class GoogleAuthentication
  {
    private const string URL = "https://www.google.com/accounts/ClientLogin";
    private const string EMAIL = "Email";
    private const string PASSWORD = "Passwd";
    private const string SOURCE = "source=om3controller";
    private const string SERVICE = "service=reader";
    private const string SESSIONID = "SID";
    private const string ACCOUNT_TYPE = "accountType=HOSTED_OR_GOOGLE";


    /// <summary>
    /// Logs in and if successful returns session id for further requests, otherwise null.
    /// </summary>
    /// <param name="user">Google user (full, with @gmail.com).</param>
    /// <param name="password">Google password.</param>
    /// <returns>Session id if successful, otherwise null.</returns>
    public static string GetSessionId(string user, string password)
    {

      // ----- Create request
      Uri lUrl = new Uri(URL);
      WebRequest lRequest = null;
      HttpWebRequest lHttpRequest = null;

      try
      {
        lRequest = WebRequest.Create(lUrl);
        lHttpRequest = (lRequest as HttpWebRequest);
        lHttpRequest.KeepAlive = true;
        lRequest.ContentType = "application/x-www-form-urlencoded";
        lRequest.Method = "POST";

        // Login data and other required parameters
        string lPostData =
          EMAIL + "=" + HttpUtility.UrlEncode(user) + "&" +
          PASSWORD + "=" + HttpUtility.UrlEncode(password) + "&" +
          SOURCE + "&" +
          SERVICE + "&" +
          ACCOUNT_TYPE;
        ASCIIEncoding lEncoder = new ASCIIEncoding();
        byte[] lPostDataAscii = lEncoder.GetBytes(lPostData);

        // Write data to request stream
        lRequest.ContentLength = lPostDataAscii.Length;
        Stream lRequestStream = lRequest.GetRequestStream();
        lRequestStream.Write(lPostDataAscii, 0, lPostDataAscii.Length);
        lRequestStream.Close();
      }
      catch (WebException)
      {
        return null;
      }


      // ----- Get response
      WebResponse lResponse = null;
      HttpWebResponse lHttpResponse = null;
      try
      {
        lResponse = lRequest.GetResponse();
        if (lResponse == null) { return null; }
        lHttpResponse = (lResponse as HttpWebResponse);
        if (lHttpResponse.StatusCode != HttpStatusCode.OK)
        {
          // TODO: check here if user/password was invalid
          lResponse.Close();
          return null;
        }
      }
      catch (WebException)
      {
        if (lResponse != null) { lResponse.Close(); }
        return null;
      }


      // ----- Parse response
      string lSessionId = null;
      lSessionId = ParseValue(lResponse.GetResponseStream(), SESSIONID);
      lResponse.Close();
      return lSessionId;

    }


    /// <summary>
    /// Parses the passed stream for key=value pairs and returns the value of the specified key.
    /// </summary>
    /// <param name="stream">Stream to parse.</param>
    /// <param name="key">Key to look for.</param>
    /// <returns>Value or null if not found.</returns>
    private static string ParseValue(Stream stream, string key)
    {
      string lResult = null;

      StreamReader lReader = new StreamReader(stream, Encoding.ASCII);
      string lContent = lReader.ReadToEnd();
      lReader.Close();

      bool lGetNext = false;
      foreach (string lValue in lContent.Split(new char[] { '=', '\n' }))
      {
        if (lGetNext)
        {
          lResult = lValue;
          break;
        }

        lGetNext = (key == lValue);
      }

      return lResult;
    }

  }


  /// <summary>
  /// Gets feed data.
  /// </summary>
  internal class GoogleReaderFeed
  {

    private const string URL = "http://www.google.com/reader/atom/user/{0}/state/com.google/reading-list?n=21&xt=user/{0}/state/com.google/read";
    private const string COOKIE_SESSIONID = "SID";


    /// <summary>
    /// Gets aggregated feed for specified user id.
    /// </summary>
    /// <param name="sessionId">Google session id.</param>
    /// <param name="userId">Google reader's user id.</param>
    /// <returns>Feed as xml or null if not successful.</returns>
    public static XmlDocument GetFeed(string sessionId)
    {

      // ----- Create request
      Uri lUrl = new Uri(string.Format(URL, "-"));
      WebRequest lRequest = null;
      HttpWebRequest lHttpRequest = null;

      try
      {
        lRequest = WebRequest.Create(lUrl);
        lHttpRequest = (lRequest as HttpWebRequest);
        lHttpRequest.KeepAlive = true;
        lRequest.ContentType = "text/html";
        lRequest.Method = "GET";

        // Add session id as cookie
        lHttpRequest.CookieContainer = new CookieContainer();
        lHttpRequest.CookieContainer.Add(lUrl, new Cookie(COOKIE_SESSIONID, sessionId));
      }
      catch (WebException)
      {
        return null;
      }


      // ----- Get response
      HttpWebResponse lResponse = null;
      string lContent = null;

      try
      {
        lResponse = (lRequest.GetResponse() as HttpWebResponse);
        if (lResponse == null) { return null; }
        if (lResponse.StatusCode != HttpStatusCode.OK)
        {
          lResponse.Close();
          return null;
        }
        StreamReader lReader = new StreamReader(lResponse.GetResponseStream());
        lContent = lReader.ReadToEnd();
        lReader.Close();
      }
      catch (WebException)
      {
        if (lResponse != null) { lResponse.Close(); }
        return null;
      }


      // ----- Parse the response as xml
      XmlDocument lResult = new XmlDocument();
      try
      {
        lResult.LoadXml(lContent);
      }
      catch (XmlException)
      {
        return null;
      }


      // ----- Success
      return lResult;

    }

  }

}