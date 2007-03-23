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

using Toolz.OptimusMini;


namespace GoogleReaderNotifierPlugin
{

  public partial class Config : Form
  {

    private OptimusMiniSettingsList _Settings;


    public Config(OptimusMiniSettingsList currentSettings)
    {
      InitializeComponent();

      _Settings = currentSettings;

      textUser.Text = _Settings["User"];
      textPassword.Text = _Settings["Password"];
      textExecute.Text = _Settings["Execute"];

      int lCheckInterval = 300;
      if (_Settings["CheckInterval"] != "")
      {
        lCheckInterval = int.Parse(_Settings["CheckInterval"]);
      }
      textCheckInterval.Text = lCheckInterval.ToString();

      int lItemInterval = 5;
      if (_Settings["ItemInterval"] != "")
      {
        lItemInterval = int.Parse(_Settings["ItemInterval"]);
      }
      textItemInterval.Text = lItemInterval.ToString();
    }


    private void buttonOk_Click(object sender, EventArgs e)
    {
      int i;

      // Validate
      if (!int.TryParse(textCheckInterval.Text, out i))
      {
        MessageBox.Show("Enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        textCheckInterval.Focus();
        return;
      }

      if (!int.TryParse(textItemInterval.Text, out i))
      {
        MessageBox.Show("Enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        textItemInterval.Focus();
        return;
      }

      if (int.Parse(textCheckInterval.Text) < 60)
      {
        MessageBox.Show("Minimum is 60.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        textCheckInterval.Focus();
        return;
      }

      if (int.Parse(textItemInterval.Text) < 1)
      {
        MessageBox.Show("Minimum is 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        textItemInterval.Focus();
        return;
      }

      // Save
      _Settings["User"] = textUser.Text;
      _Settings["Password"] = textPassword.Text;
      _Settings["Execute"] = textExecute.Text;
      _Settings["CheckInterval"] = textCheckInterval.Text;
      _Settings["ItemInterval"] = textItemInterval.Text;

      DialogResult = DialogResult.OK;
    }
  }

}