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

using Toolz.OptimusMini;


namespace EmailNotifierPlugin
{

  public class EmailPluginWorker : OptimusMiniPluginWorkerBase
  {

    private Bitmap _Bitmap;
    private Graphics _Graphic;
    private Font _TitleFont;
    private Font _SmallFont;

    private List<AccountPop3> _Accounts;
    private List<Message> _NewMessages;

    private int _CheckIntervalSeconds;
    private DateTime _LastCheck;

    private int _MessageIntervalSeconds;
    private int _CurrentMessage;

    private OptimusMiniSettingsList _Settings;


    public override void Initialize(OptimusMiniSettingsList currentSettings)
    {
      _Bitmap = new Bitmap(96, 96, PixelFormat.Format16bppRgb565);
      _Graphic = Graphics.FromImage(_Bitmap);

      _TitleFont = new Font("Tahoma", 12f, FontStyle.Bold, GraphicsUnit.Pixel);
      _SmallFont = SystemFonts.DefaultFont;

      _Settings = currentSettings;
      _Accounts = new List<AccountPop3>();

      int lAccountsCounts = 0;
      if (_Settings["AccountsCount"] != "")
      {
        lAccountsCounts = int.Parse(_Settings["AccountsCount"]);
      }

      for (int i = 0; i < lAccountsCounts; i++)
      {
        string lAccountConfig = _Settings["Account" + i.ToString()];
        string[] lAccountConfigValues = lAccountConfig.Split(';');
        AccountPop3 lAccount = new AccountPop3();
        lAccount.Server = lAccountConfigValues[0];
        lAccount.User = lAccountConfigValues[1];
        lAccount.Password = lAccountConfigValues[2];
        lAccount.Secure = (lAccountConfigValues[3] == "1");
        lAccount.Execute = lAccountConfigValues[4];
        _Accounts.Add(lAccount);

        string lAccountKnownIds = _Settings["AccountKnownIds" + i.ToString()];
        string[] lAccountKnownIdsValues = lAccountKnownIds.Split(';');
        foreach (string lId in lAccountKnownIdsValues)
        {
          lAccount._KnownMessages.Add(lId);
        }
      }

      _CheckIntervalSeconds = 60;
      if (_Settings["CheckInterval"] != "")
      {
        _CheckIntervalSeconds = int.Parse(_Settings["CheckInterval"]);
      }

      _MessageIntervalSeconds = 5;
      if (_Settings["MessageInterval"] != "")
      {
        _MessageIntervalSeconds = int.Parse(_Settings["MessageInterval"]);
      }

      _NewMessages = new List<Message>();
      _CurrentMessage = -1;

      RequestNextUpdate(new TimeSpan(0, 0, 0));
    }


    public override void Repaint()
    {
      if (_NewMessages.Count > 0)
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
      string lText = "You've got mail";
      int lTextX = (96 - _Graphic.MeasureString(lText, _TitleFont).ToSize().Width) / 2;

      Message lMessage = _NewMessages[_CurrentMessage];

      lock (_Graphic)
      {
        _Graphic.FillRectangle(Brushes.Black, 0, 0, 96, 96);
        _Graphic.DrawString(lText, _TitleFont, Brushes.CadetBlue, lTextX, 0);

        _Graphic.DrawImage(Properties.Resources.email, 0, 20);
        _Graphic.DrawString(_NewMessages.Count.ToString() + " new", _SmallFont, Brushes.White, 20, 20);

        _Graphic.DrawString(lMessage.From, _SmallFont, Brushes.White, 0, 40);
        //_Graphic.DrawString(lMessage.Subject, _SmallFont, Brushes.White, 0, 55);
        _Graphic.DrawString(lMessage.Subject, _SmallFont, Brushes.White, new RectangleF(0, 55, 96, 41));

        UpdateImage(_Bitmap);
      }

    }


    private void Repaint_None()
    {
      string lText = "No new mail";
      int lTextX = (96 - _Graphic.MeasureString(lText, _TitleFont).ToSize().Width) / 2;

      lock (_Graphic)
      {
        _Graphic.FillRectangle(Brushes.Black, 0, 0, 96, 96);
        _Graphic.DrawString(lText, _TitleFont, Brushes.CadetBlue, lTextX, 0);
        UpdateImage(_Bitmap);
      }
    }


    public override void Terminate()
    {
      _Graphic.Dispose();
      _Bitmap.Dispose();
      _TitleFont.Dispose();
      _SmallFont.Dispose();

      int lIndex = 0;
      foreach (AccountPop3 lAccount in _Accounts)
      {
        string lIds = "";
        foreach (string lId in lAccount._KnownMessages)
        {
          if (lIds != "") { lIds += ";"; }
          lIds += lId;
        }
        _Settings["AccountKnownIds" + lIndex.ToString()] = lIds;
        lIndex += 1;
      }
    }


    public override void Update()
    {
      if (DateTime.Now.Subtract(_LastCheck).TotalSeconds > _CheckIntervalSeconds)
      {
        List<Message> lMessages;

        foreach (AccountBase lAccount in _Accounts)
        {
          lMessages = lAccount.GetNewMessages();
          if (lMessages != null)
          {
            lAccount.MessageCount += lMessages.Count;
            _NewMessages.AddRange(lMessages);
          }
        }

        _LastCheck = DateTime.Now;
      }

      if (_NewMessages.Count > 0)
      {
        _CurrentMessage += 1;
        if (_CurrentMessage < 0 || _CurrentMessage > (_NewMessages.Count - 1)) { _CurrentMessage = 0; }
      }

      Repaint();

      if (_NewMessages.Count > 1)
      {
        RequestNextUpdate(new TimeSpan(0, 0, _MessageIntervalSeconds));
      }
      else
      {
        RequestNextUpdate(new TimeSpan(0, 0, _CheckIntervalSeconds));
      }

    }


    public override void OnKeyDoublePress()
    {
      base.OnKeyDoublePress();

      foreach (AccountBase lAccount in _Accounts)
      {
        if (!string.IsNullOrEmpty(lAccount.Execute) && lAccount.MessageCount > 0)
        {
          System.Diagnostics.Process.Start(lAccount.Execute);
        }
        lAccount.MessageCount = 0;
      }

      _NewMessages.Clear();

      Repaint();      

    }


    public override void OnKeyHold()
    {
      base.OnKeyHold();

      foreach (AccountBase lAccount in _Accounts)
      {
        lAccount.MessageCount = 0;
      }

      _NewMessages.Clear();

      Repaint();
    }
  }

}