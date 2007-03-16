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


namespace OldSchoolHitCounter
{
  public partial class OldSchoolHitCounterConfig : Form
  {

    OptimusMiniSettingsList _Settings;


    public OldSchoolHitCounterConfig(OptimusMiniSettingsList settings)
    {
      InitializeComponent();

      _Settings = settings;
      if (_Settings["Url"] != "")
      {
        fieldUrl.Text = _Settings["Url"];
      }
      else
      {
        fieldUrl.Text = "http://optimus.toolz.at/count.txt";
      }

    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
      _Settings["Url"] = fieldUrl.Text;
      this.DialogResult = DialogResult.OK;
      //this.Close();
    }
  }
}