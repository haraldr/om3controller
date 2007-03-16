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


namespace EmailNotifierPlugin
{

  public partial class Config : Form
  {

    private OptimusMiniSettingsList _Settings;
    private List<AccountPop3> _Accounts;


    public Config(OptimusMiniSettingsList currentSettings)
    {
      InitializeComponent();

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
        listAccounts.Items.Add(lAccount.Server);
      }

      int lCheckInterval = 60;
      if (_Settings["CheckInterval"] != "")
      {
        lCheckInterval = int.Parse(_Settings["CheckInterval"]);
      }
      textCheckInterval.Text = lCheckInterval.ToString();

      int lMessageInterval = 5;
      if (_Settings["MessageInterval"] != "")
      {
        lMessageInterval = int.Parse(_Settings["MessageInterval"]);
      }
      textMessageInterval.Text = lMessageInterval.ToString();

      selectType.SelectedIndex = 0;
      UpdateActions();
    }


    private void UpdateActions()
    {
      buttonDelete.Enabled = (listAccounts.SelectedItems.Count > 0);
    }


    private void listAccounts_SelectedIndexChanged(object sender, EventArgs e)
    {
      UpdateActions();
    }


    private void buttonAdd_Click(object sender, EventArgs e)
    {
      if (textServer.Text == "" || textUsername.Text == "" || textPassword.Text == "")
      {
        MessageBox.Show("Server, username and password are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        textServer.Focus();
      }

      AccountPop3 lAccount = new AccountPop3();
      lAccount.Server = textServer.Text;
      lAccount.User = textUsername.Text;
      lAccount.Password = textPassword.Text;
      lAccount.Secure = checkSecure.Checked;
      lAccount.Execute = textExecute.Text;

      _Accounts.Add(lAccount);
      listAccounts.Items.Add(lAccount.Server);
      UpdateActions();
    }


    private void buttonDelete_Click(object sender, EventArgs e)
    {
      _Accounts.RemoveAt(listAccounts.SelectedItems[0].Index);
      listAccounts.SelectedItems[0].Remove();
      UpdateActions();
    }


    private void buttonOk_Click(object sender, EventArgs e)
    {
      _Settings["AccountsCount"] = _Accounts.Count.ToString();
      for (int i = 0; i < _Accounts.Count; i++)
      {
        AccountPop3 lAccount = _Accounts[i];
        _Settings["Account" + i.ToString()] =
          string.Join(";", new string[] {
            lAccount.Server,
            lAccount.User,
            lAccount.Password,
            (lAccount.Secure ? "1" : "0"),
            lAccount.Execute });
      }

      _Settings["CheckInterval"] = textCheckInterval.Text;
      _Settings["MessageInterval"] = textMessageInterval.Text;

      DialogResult = DialogResult.OK;
    }
  }

}