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
using System.Net;
using System.IO;
using Toolz.OptimusMini;


namespace OldSchoolHitCounter
{

  public class OldSchoolHitCounterPlugin : OptimusMiniPluginBase
  {

    public OldSchoolHitCounterPlugin()
      : base()
    {
      _Id = "1A6C9BE9-CD8B-4f35-8F56-383998E4A9D5";
      _Name = "Old school hit counter";
      _Description = "Loads a file containing the hits from a website and displays them in an old school way.";
      _Author = "Harald Röxeisen";
      _IsConfigurable = true;
    }


    public override OptimusMiniPluginWorkerBase CreateWorker()
    {
      return new OldSchoolHitCounterPluginWorker();
    }


    public override System.Windows.Forms.Form CreateConfiguration(OptimusMiniSettingsList currentSettings)
    {
      return new OldSchoolHitCounterConfig(currentSettings);
    }
  }


  public class OldSchoolHitCounterPluginWorker : OptimusMiniPluginWorkerBase
  {

    private Bitmap _Bitmap;
    private Graphics _Graphic;
    private Bitmap[] _Digits;
    private int _Count = 0;
    private string _Url;


    public OldSchoolHitCounterPluginWorker()
      : base()
    {
      _Bitmap = new Bitmap(96, 96, PixelFormat.Format16bppRgb565);
      _Graphic = Graphics.FromImage(_Bitmap);
    }


    public override void Initialize(OptimusMiniSettingsList currentSettings)
    {
      // Url from settings
      _Url = currentSettings["Url"];
      if (_Url == "") { _Url = "http://optimus.toolz.at/count.txt"; }

      // Prepare image
      _Digits = new Bitmap[10];
      for (int i = 0; i < 10; i++)
      {
        _Digits[i] = Properties.Resources.counter.Clone(new Rectangle(i * 15, 0, 15, 43), PixelFormat.Format24bppRgb);
      }

      // Update immediately
      RequestNextUpdate(new TimeSpan(0, 0, 0));
    }


    public override void Terminate()
    {
    }


    public override void Repaint()
    {
      string lCount = _Count.ToString("000000");
      if (lCount.Length > 6) { lCount = lCount.Substring(lCount.Length - 6, 6); }

      lock (_Graphic)
      {
        _Graphic.FillRectangle(Brushes.Black, 0, 0, 96, 96);
        for (int i = 5; i >= 0; i--)
        {
          int lDigit = int.Parse(lCount.Substring(i, 1));
          _Graphic.DrawImageUnscaled(_Digits[lDigit], 3 + i * 15, 26);
          _Graphic.Flush();
          UpdateImage(_Bitmap);
        }
      }
    }


    public override void Update()
    {

      StringBuilder lResult = new StringBuilder();


      // ----- Get count from web site
      try
      {
        WebRequest lRequest = WebRequest.Create(_Url);
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


      // ----- Read counter
      int lNewCount;

      try
      {
        lNewCount = int.Parse(lResult.ToString());
        if (lNewCount != _Count)
        {
          _Count = lNewCount;
          Repaint();
        }
      }
      catch (FormatException)
      {
        // TODO: notify user of error
      }
      catch (OverflowException)
      {
        // TODO: notify user that this website seems to be popular :)
        if (_Count != int.MaxValue)
        {
          _Count = int.MaxValue;
          Repaint();
        }
      }


      // ----- Next update
      RequestNextUpdate(new TimeSpan(0, 0, 60));
    }

  }

}