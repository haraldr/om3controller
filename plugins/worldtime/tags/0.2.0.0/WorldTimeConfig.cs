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


namespace Worldtime
{
  public partial class WorldTimeConfig : Form
  {

    private OptimusMiniSettingsList _Settings;
    private List<TimeZoneInformation> _Timezones;
    private List<TimezoneItem> _Items;


    public WorldTimeConfig(OptimusMiniSettingsList currentSettings)
    {
      InitializeComponent();

      _Settings = currentSettings;
      _Items = new List<TimezoneItem>();


      // ----- Fill select box with all timezones
      foreach (TimeZoneInformation lTimezone in TimeZoneInformation.TimeZones)
      {
        selectTimezone.Items.Add(lTimezone.DisplayName);
      }
      selectTimezone.SelectedIndex = 0;


      // ----- Add stored timezones
      for (int i = 0; i < 5; i++)
      {
        string lTimezone = _Settings["Timezone" + i.ToString()];
        if (TimeZoneInformation.ContainsTimeZone(lTimezone))
        {
          TimezoneItem lItem = new TimezoneItem(TimeZoneInformation.GetTimeZone(lTimezone), _Settings["Label" + i.ToString()]);
          _Items.Add(lItem);
          listTimezones.Items.Add(string.Format("{0}: {1}", lItem.Label, lItem.Timezone.DisplayName));
        }
      }
      if (_Items.Count > 0) { listTimezones.Items[0].Selected = true; }


      // ----- Update controls
      UpdateActions();

    }


    private void UpdateActions()
    {
      buttonAdd.Enabled = (_Items.Count < 5);
      labelMaxReached.Visible = (_Items.Count == 5);

      if (listTimezones.SelectedItems.Count > 0)
      {
        int lIndex = listTimezones.SelectedItems[0].Index;
        int lMax = _Items.Count - 1;

        buttonDelete.Enabled = true;
        buttonUp.Enabled = (lIndex > 0);
        buttonDown.Enabled = (lIndex < lMax);
      }
      else
      {
        buttonDelete.Enabled = false;
        buttonUp.Enabled = false;
        buttonDown.Enabled = false;
      }

    }


    private void buttonOK_Click(object sender, EventArgs e)
    {

      for (int i = 0; i < 5; i++)
      {
        if (i <= (_Items.Count - 1))
        {
          TimezoneItem lItem = _Items[i];
          _Settings["Timezone" + i.ToString()] = lItem.Timezone.StandardName;
          _Settings["Label" + i.ToString()] = lItem.Label;
        }
        else
        {
          _Settings["Timezone" + i.ToString()] = "";
          _Settings["Label" + i.ToString()] = "";
        }
      }

      this.DialogResult = DialogResult.OK;
    }


    private void buttonAdd_Click(object sender, EventArgs e)
    {
      TimezoneItem lItem = new TimezoneItem(TimeZoneInformation.TimeZones[selectTimezone.SelectedIndex], fieldLabel.Text);
      _Items.Add(lItem);
      listTimezones.Items.Add(string.Format("{0}: {1}", lItem.Label, lItem.Timezone.DisplayName));
      UpdateActions();
    }


    private void buttonDelete_Click(object sender, EventArgs e)
    {
      int lIndex = listTimezones.SelectedItems[0].Index;
      _Items.RemoveAt(lIndex);
      listTimezones.Items.RemoveAt(lIndex);
      UpdateActions();
    }


    private void buttonUp_Click(object sender, EventArgs e)
    {
      int lIndex = listTimezones.SelectedItems[0].Index;
      
      TimezoneItem lItem = _Items[lIndex - 1];
      _Items.RemoveAt(lIndex - 1);
      _Items.Insert(lIndex, lItem);

      ListViewItem lListItem = listTimezones.Items[lIndex - 1];
      listTimezones.Items.RemoveAt(lIndex - 1);
      listTimezones.Items.Insert(lIndex, lListItem);

      listTimezones.Items[lIndex - 1].Selected = true;
      listTimezones.Items[lIndex - 1].Focused = true;
      UpdateActions();
    }


    private void buttonDown_Click(object sender, EventArgs e)
    {
      int lIndex = listTimezones.SelectedItems[0].Index;

      TimezoneItem lItem = _Items[lIndex + 1];
      _Items.RemoveAt(lIndex + 1);
      _Items.Insert(lIndex, lItem);

      ListViewItem lListItem = listTimezones.Items[lIndex + 1];
      listTimezones.Items.RemoveAt(lIndex + 1);
      listTimezones.Items.Insert(lIndex, lListItem);

      listTimezones.Items[lIndex + 1].Selected = true;
      listTimezones.Items[lIndex + 1].Focused = true;
      UpdateActions();
    }


    private void listTimezones_SelectedIndexChanged(object sender, EventArgs e)
    {
      UpdateActions();
    }

  }
}