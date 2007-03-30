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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;

using Toolz.OptimusMini;


namespace OptimusUI
{
  public partial class Form1 : Form
  {

    private OptimusMiniController _Device;
    private OptimusMiniPluginBrowser _Plugins;
    private OptimusMiniSettings _Settings;
    private ConnectionStateChangedDelegate _ConnectionStateChanged;
    private KeyEventDelegate _KeyDown;
    private KeyEventDelegate _KeyUp;
    private KeyEventDelegate _KeyHold;
    private KeyEventDelegate _KeyRelease;
    private KeyEventDelegate _KeyPress;
    private KeyEventDelegate _KeyDoublePress;


    public Form1()
    {
      InitializeComponent();

      _Device = new OptimusMiniController();
      _Plugins = new OptimusMiniPluginBrowser();
      _Settings = new OptimusMiniSettings();

      _ConnectionStateChanged = new ConnectionStateChangedDelegate(ConnectionStateChangedMethod);
      _Device.OnConnectionStateChanged += ConnectionStateChangedEventHandler;

      _KeyDown = new KeyEventDelegate(KeyDownMethod);
      _Device.OnKeyDown += KeyDownEventHandler;

      _KeyUp = new KeyEventDelegate(KeyUpMethod);
      _Device.OnKeyUp += KeyUpEventHandler;

      _KeyHold = new KeyEventDelegate(KeyHoldMethod);
      _Device.OnKeyHold += KeyHoldEventHandler;

      _KeyRelease = new KeyEventDelegate(KeyReleaseMethod);
      _Device.OnKeyRelease += KeyReleaseEventHandler;

      _KeyPress = new KeyEventDelegate(KeyPressMethod);
      _Device.OnKeyPress += KeyPressEventHandler;

      _KeyDoublePress = new KeyEventDelegate(KeyDoublePressMethod);
      _Device.OnKeyDoublePress += KeyDoublePressEventHandler;

      selectPlugin0.Items.Add("");
      selectPlugin1.Items.Add("");
      selectPlugin2.Items.Add("");

      for (int i = 0; i < _Plugins.Count; i++)
      {
        selectPlugin0.Items.Add(_Plugins[i].Name);
        selectPlugin1.Items.Add(_Plugins[i].Name);
        selectPlugin2.Items.Add(_Plugins[i].Name);
      }

      LoadSettings();
    }


    private void LoadSettings()
    {
      OptimusMiniSettingsList lSettings = _Settings["Main"].List;


      // ----- Device settings
      // Brightness
      if (lSettings["Brightness"] != "")
      {
        _Device.SetBrightness((OptimusMiniBrightness)int.Parse(lSettings["Brightness"]));
        switch (_Device.Brightness)
        {
          case OptimusMiniBrightness.Low: fieldBrightnessLow.Checked = true; break;
          case OptimusMiniBrightness.Normal: fieldBrightnessNormal.Checked = true; break;
          case OptimusMiniBrightness.High: fieldBrightnessHigh.Checked = true; break;
        }
      }

      // Layout
      if (lSettings["Layout"] != "")
      {
        _Device.SetLayout((OptimusMiniLayout)int.Parse(lSettings["Layout"]));
        switch (_Device.Layout)
        {
          case OptimusMiniLayout.Down: fieldLayoutDown.Checked = true; break;
          case OptimusMiniLayout.Left: fieldLayoutLeft.Checked = true; break;
          case OptimusMiniLayout.Right: fieldLayoutRight.Checked = true; break;
          case OptimusMiniLayout.Up: fieldLayoutUp.Checked = true; break;
        }
      }

      // Gamma
      if (lSettings["Gamma"] != "")
      {
        _Device.SetGamma(float.Parse(lSettings["Gamma"]));
        trackbarGamma.Value = (int)Math.Round(_Device.Gamma * 100f, 0);
        labelGammaValue.Text = _Device.Gamma.ToString("0.00");
      }

      // Idle
      if (lSettings["IdleTime"] != "")
      {
        _Device.SetIdleTime(int.Parse(lSettings["IdleTime"]));
        trackbarIdle.Value = _Device.IdleTime;
        if (_Device.IdleTime == 0)
        {
          labelIdleValue.Text = "Never";
        }
        else
        {
          labelIdleValue.Text = string.Format("{0} sec", _Device.IdleTime);
        }
      }


      // ----- Plugins
      OptimusMiniPluginBase lPlugin;

      lPlugin = _Plugins.GetPluginById(lSettings["Plugin0"]);
      if (lPlugin != null)
      {
        _Device.AddPlugin(0, lPlugin.CreateWorker(), _Settings[lPlugin.Id].List);
        selectPlugin0.SelectedIndex = _Plugins.GetIndexById(lPlugin.Id) + 1;
      }

      lPlugin = _Plugins.GetPluginById(lSettings["Plugin1"]);
      if (lPlugin != null)
      {
        _Device.AddPlugin(1, lPlugin.CreateWorker(), _Settings[lPlugin.Id].List);
        selectPlugin1.SelectedIndex = _Plugins.GetIndexById(lPlugin.Id) + 1;
      }

      lPlugin = _Plugins.GetPluginById(lSettings["Plugin2"]);
      if (lPlugin != null)
      {
        _Device.AddPlugin(2, lPlugin.CreateWorker(), _Settings[lPlugin.Id].List);
        selectPlugin2.SelectedIndex = _Plugins.GetIndexById(lPlugin.Id) + 1;
      }

    }


    private void SaveSettings()
    {

      OptimusMiniSettingsList lSettings = _Settings["Main"].List;


      // ----- Device settings
      lSettings["Brightness"] = ((int)_Device.Brightness).ToString();
      lSettings["Layout"] = ((int)_Device.Layout).ToString();
      lSettings["Gamma"] = _Device.Gamma.ToString();
      lSettings["IdleTime"] = _Device.IdleTime.ToString();


      // ----- Plugins
      if (selectPlugin0.SelectedIndex > 0) { lSettings["Plugin0"] = _Plugins[selectPlugin0.SelectedIndex - 1].Id; }
      else { lSettings["Plugin0"] = ""; }

      if (selectPlugin1.SelectedIndex > 0) { lSettings["Plugin1"] = _Plugins[selectPlugin1.SelectedIndex - 1].Id; }
      else { lSettings["Plugin1"] = ""; }

      if (selectPlugin2.SelectedIndex > 0) { lSettings["Plugin2"] = _Plugins[selectPlugin2.SelectedIndex - 1].Id; }
      else { lSettings["Plugin2"] = ""; }


      // ----- Save
      _Settings.Save();

    }


    #region "Device event handlers"

    private delegate void ConnectionStateChangedDelegate(bool Connected);
    private void ConnectionStateChangedEventHandler(OptimusMiniController sender, bool connected)
    {
      this.Invoke(_ConnectionStateChanged, connected);
    }
    private void ConnectionStateChangedMethod(bool connected)
    {
      if (connected)
      {
        buttonConnect.Text = "Disconnect";
        labelConnectionState.Text = "Connected";
        //groupPlugins.Enabled = true;
        _Device.ShowCalibrate(0);
        _Device.ShowVersion(1);
        _Device.ClearImage(2);
      }
      else
      {
        buttonConnect.Text = "Connect";
        labelConnectionState.Text = "Disconnected";
        //groupPlugins.Enabled = false;
        //_Device.RemovePlugin();
        //selectPlugin0.SelectedIndex = 0;
        //selectPlugin1.SelectedIndex = 0;
        //selectPlugin2.SelectedIndex = 0;
        ShowForm();
      }
    }


    private delegate void KeyEventDelegate(byte index);

    private void KeyDownEventHandler(OptimusMiniController sender, byte index)
    {
      this.Invoke(_KeyDown, index);
    }
    private void KeyDownMethod(byte index)
    {
      SetKeyEventLabel(index, "down");
    }

    private void KeyUpEventHandler(OptimusMiniController sender, byte index)
    {
      this.Invoke(_KeyUp, index);
    }
    private void KeyUpMethod(byte index)
    {
      SetKeyEventLabel(index, "up");
    }

    private void KeyHoldEventHandler(OptimusMiniController sender, byte index)
    {
      this.Invoke(_KeyHold, index);
    }
    private void KeyHoldMethod(byte index)
    {
      SetKeyEventLabel(index, "hold");
    }

    private void KeyReleaseEventHandler(OptimusMiniController sender, byte index)
    {
      this.Invoke(_KeyRelease, index);
    }
    private void KeyReleaseMethod(byte index)
    {
      SetKeyEventLabel(index, "release");
    }

    private void KeyPressEventHandler(OptimusMiniController sender, byte index)
    {
      this.Invoke(_KeyPress, index);
    }
    private void KeyPressMethod(byte index)
    {
      SetKeyEventLabel(index, "press");
    }

    private void KeyDoublePressEventHandler(OptimusMiniController sender, byte index)
    {
      this.Invoke(_KeyDoublePress, index);
    }
    private void KeyDoublePressMethod(byte index)
    {
      SetKeyEventLabel(index, "double press");
    }

    private void SetKeyEventLabel(byte index, string text)
    {
      switch (index)
      {
        case 0: labelKey0.Text = text; break;
        case 1: labelKey1.Text = text; break;
        case 2: labelKey2.Text = text; break;
      }
    }

    #endregion


    #region "UI stuff"

    private void buttonConnect_Click(object sender, EventArgs e)
    {
      buttonConnect.Enabled = false;
      this.UseWaitCursor = true;

      try
      {
        if (_Device.IsConnected)
        {
          _Device.Terminate();
        }
        else
        {
          if (_Device.Init() != 0)
          {
            MessageBox.Show("Failed to connect.");
          }
        }
      }
      finally
      {
        buttonConnect.Enabled = true;
        this.UseWaitCursor = false;
      }
    }

    private void fieldBrightnessLow_CheckedChanged(object sender, EventArgs e)
    {
      _Device.SetBrightness(OptimusMiniBrightness.Low);
    }

    private void fieldBrightnessNormal_CheckedChanged(object sender, EventArgs e)
    {
      _Device.SetBrightness(OptimusMiniBrightness.Normal);
    }

    private void fieldBrightnessHigh_CheckedChanged(object sender, EventArgs e)
    {
      _Device.SetBrightness(OptimusMiniBrightness.High);
    }

    private void fieldLayoutRight_CheckedChanged(object sender, EventArgs e)
    {
      _Device.SetLayout(OptimusMiniLayout.Right);
    }

    private void fieldLayoutLeft_CheckedChanged(object sender, EventArgs e)
    {
      _Device.SetLayout(OptimusMiniLayout.Left);
    }

    private void fieldLayoutUp_CheckedChanged(object sender, EventArgs e)
    {
      _Device.SetLayout(OptimusMiniLayout.Up);
    }

    private void fieldLayoutDown_CheckedChanged(object sender, EventArgs e)
    {
      _Device.SetLayout(OptimusMiniLayout.Down);
    }

    private void trackbarGamma_Scroll(object sender, EventArgs e)
    {
      labelGammaValue.Text = (trackbarGamma.Value / 100f).ToString("0.00");
      _Device.SetGamma(trackbarGamma.Value / 100f);
    }

    private void trackbarIdle_Scroll(object sender, EventArgs e)
    {
      if (trackbarIdle.Value == 0)
      {
        labelIdleValue.Text = "Never";
      }
      else
      {
        labelIdleValue.Text = string.Format("{0} sec", trackbarIdle.Value);
      }
      _Device.SetIdleTime(trackbarIdle.Value);
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      SaveSettings();
      if (_Device.IsConnected) { _Device.Terminate(); }
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
      if (WindowState == FormWindowState.Minimized)
      {
        HideForm();
      }
    }

    private void ShowForm()
    {
      taskbarIcon.Visible = false;
      WindowState = FormWindowState.Normal;
      ShowInTaskbar = true;
      Show();
      BringToFront();
      Activate();
    }

    private void HideForm()
    {
      WindowState = FormWindowState.Minimized;
      ShowInTaskbar = false;
      Hide();
      taskbarIcon.Visible = true;
    }

    private void taskbarIcon_Click(object sender, EventArgs e)
    {
      ShowForm();
    }

    private void selectPlugin0_SelectedIndexChanged(object sender, EventArgs e)
    {
      buttonConfig0.Enabled = ChangePlugin(0, selectPlugin0.SelectedIndex - 1);
    }

    private void selectPlugin1_SelectedIndexChanged(object sender, EventArgs e)
    {
      buttonConfig1.Enabled = ChangePlugin(1, selectPlugin1.SelectedIndex - 1);
    }

    private void selectPlugin2_SelectedIndexChanged(object sender, EventArgs e)
    {
      buttonConfig2.Enabled = ChangePlugin(2, selectPlugin2.SelectedIndex - 1);
    }

    private bool ChangePlugin(byte keyIndex, int pluginIndex)
    {
      if (pluginIndex == -1)
      {
        _Device.RemovePlugin(keyIndex);
        _Device.ClearImage(keyIndex);
        _Settings.Save();
        return false;
      }
      else
      {
        OptimusMiniPluginBase lPlugin = _Plugins[pluginIndex];
        _Device.AddPlugin(keyIndex, lPlugin.CreateWorker(), _Settings[lPlugin.Id].List);
        _Settings.Save();
        return lPlugin.IsConfigurable;
      }
    }

    private void buttonConfig0_Click(object sender, EventArgs e)
    {
      ShowPluginConfig(0, selectPlugin0.SelectedIndex - 1);
    }

    private void buttonConfig1_Click(object sender, EventArgs e)
    {
      ShowPluginConfig(1, selectPlugin1.SelectedIndex - 1);
    }

    private void buttonConfig2_Click(object sender, EventArgs e)
    {
      ShowPluginConfig(2, selectPlugin2.SelectedIndex - 1);
    }

    private void ShowPluginConfig(byte keyIndex, int pluginIndex)
    {
      OptimusMiniPluginBase lPlugin = _Plugins[pluginIndex];

      Form lForm = _Plugins[pluginIndex].CreateConfiguration(_Settings[lPlugin.Id].List);
      if (lForm.ShowDialog(this) == DialogResult.OK)
      {
        _Settings.Save();
        _Device.AddPlugin(keyIndex, lPlugin.CreateWorker(), _Settings[lPlugin.Id].List);
      }
    }

    #endregion

  }
}