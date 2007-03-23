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
using System.Xml;
using System.Net;
using System.IO;

using Toolz.OptimusMini;


namespace GoogleReaderNotifierPlugin
{

  public class GoogleReaderNotifierPluginWorker : OptimusMiniPluginWorkerBase
  {

    private Bitmap _Bitmap;
    private Graphics _Graphic;
    private Font _TitleFont;
    private Font _DefaultFont;
    private Font _SmallFont;

    private string _User;
    private string _Password;
    private string _UserId;
    private string _Execute;
    private List<Item> _FeedItems;
    private bool _EvenMoreFeedItems;

    private int _CheckIntervalSeconds;
    private DateTime _LastCheck;

    private int _ItemIntervalSeconds;
    private int _CurrentItem;

    private OptimusMiniSettingsList _Settings;


    public override void Initialize(OptimusMiniSettingsList currentSettings)
    {
      _Bitmap = new Bitmap(96, 96, PixelFormat.Format16bppRgb565);
      _Graphic = Graphics.FromImage(_Bitmap);

      _TitleFont = new Font("Tahoma", 12f, FontStyle.Bold, GraphicsUnit.Pixel);
      _DefaultFont = new Font("Tahoma", 11f, GraphicsUnit.Pixel);
      _SmallFont = new Font("Tahoma", 10f, FontStyle.Bold, GraphicsUnit.Pixel);

      _Settings = currentSettings;

      _User = _Settings["User"];
      if (!string.IsNullOrEmpty(_User)) { _User += "@gmail.com"; }
      _Password = _Settings["Password"];
      _UserId = _Settings["UserId"];
      _Execute = _Settings["Execute"];

      _CheckIntervalSeconds = 60;
      if (_Settings["CheckInterval"] != "")
      {
        _CheckIntervalSeconds = int.Parse(_Settings["CheckInterval"]);
      }

      _ItemIntervalSeconds = 5;
      if (_Settings["ItemInterval"] != "")
      {
        _ItemIntervalSeconds = int.Parse(_Settings["ItemInterval"]);
      }

      _FeedItems = new List<Item>();
      _CurrentItem = -1;

      RequestNextUpdate(new TimeSpan(0, 0, 0));
    }


    public override void Repaint()
    {
      if (_FeedItems.Count > 0)
      {
        Repaint_New();
      }
      else
      {
        Repaint_None();
      }
    }


    private void Repaint_New()
    {
      Item lItem = _FeedItems[_CurrentItem];

      string lCountText = "";
      if (_FeedItems.Count == 1)
      {
        lCountText = "1 item";
      }
      else if (_EvenMoreFeedItems)
      {
        lCountText = "20+ items";
      }
      else
      {
        lCountText = _FeedItems.Count.ToString() + " items";
      }

      lock (_Graphic)
      {
        _Graphic.FillRectangle(Brushes.Black, 0, 0, 96, 96);

        _Graphic.DrawImage(Properties.Resources.feed, 0, 0);
        _Graphic.DrawString(lCountText, _TitleFont, Brushes.CadetBlue, 18, 1);
        _Graphic.DrawString(lItem.Source, _SmallFont, Brushes.White, 0, 19);
        _Graphic.DrawString(lItem.Title, _DefaultFont, Brushes.White, new Rectangle(0, 32, 96, 64));

        UpdateImage(_Bitmap);
      }

    }


    private void Repaint_None()
    {
      lock (_Graphic)
      {
        _Graphic.FillRectangle(Brushes.Black, 0, 0, 96, 96);
        _Graphic.DrawImage(Properties.Resources.feed, 0, 0);
        _Graphic.DrawString("No news", _TitleFont, Brushes.CadetBlue, 18, 1);
        UpdateImage(_Bitmap);
      }
    }


    public override void Terminate()
    {
      _Graphic.Dispose();
      _Bitmap.Dispose();
      _TitleFont.Dispose();
      _DefaultFont.Dispose();
      _SmallFont.Dispose();
    }


    public override void Update()
    {
      if (DateTime.Now.Subtract(_LastCheck).TotalSeconds > _CheckIntervalSeconds &&
          !string.IsNullOrEmpty(_User) &&
          !string.IsNullOrEmpty(_Password) &&
          !string.IsNullOrEmpty(_UserId))
      {
        List<Item> lItems = GetNewFeedItems();
        if (lItems != null)
        {
          _FeedItems.Clear();
          _FeedItems.AddRange(lItems);
          if (lItems.Count > 20)
          {
            // We get max 21 items, so we can display "20+ items"
            _EvenMoreFeedItems = true;
            _FeedItems.RemoveAt(20);
          }
          else
          {
            _EvenMoreFeedItems = false;
          }
        }
        _LastCheck = DateTime.Now;
      }

      if (_FeedItems.Count > 0)
      {
        _CurrentItem += 1;
        if (_CurrentItem < 0 || _CurrentItem > (_FeedItems.Count - 1)) { _CurrentItem = 0; }
      }

      Repaint();

      if (_FeedItems.Count > 1)
      {
        RequestNextUpdate(new TimeSpan(0, 0, _ItemIntervalSeconds));
      }
      else
      {
        RequestNextUpdate(new TimeSpan(0, 0, _CheckIntervalSeconds));
      }
    }


    public override void OnKeyDoublePress()
    {
      base.OnKeyDoublePress();
      if (!string.IsNullOrEmpty(_Execute))
      {
        System.Diagnostics.Process.Start(_Execute);
      }
      _FeedItems.Clear();
      Repaint();
    }


    private List<Item> GetNewFeedItems()
    {
      // ----- Get feed xml
      // TODO: notify user of errors
      string lSessionId = GoogleAuthentication.GetSessionId(_User, _Password);
      if (string.IsNullOrEmpty(lSessionId)) { return null; }
      XmlDocument lXml = GoogleReaderFeed.GetFeed(lSessionId, _UserId);
      if (lXml == null) { return null; }


      // ----- Parse feed
      // TODO: there's something going wrong when using namespaces and i've not figured
      //       out what, so i'm using some dumb parsing here
      List<Item> lResult = new List<Item>();

      foreach (XmlElement lChild in lXml.DocumentElement.GetElementsByTagName("entry"))
      {
        Item lItem = new Item();
        lItem.Title = lChild.GetElementsByTagName("title")[0].InnerText;
        lItem.Id = lChild.GetElementsByTagName("id")[0].InnerText;
        lItem.Source = (lChild.GetElementsByTagName("source")[0] as XmlElement).GetElementsByTagName("title")[0].InnerText;
        lResult.Add(lItem);
      }

      return lResult;
    }

  }

}