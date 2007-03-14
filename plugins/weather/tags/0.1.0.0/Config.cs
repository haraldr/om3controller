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


namespace WeatherPlugin
{
  public partial class Config : Form
  {

    OptimusMiniSettingsList _Settings;
    LocationDataProvider _LocationDataProvider;


    public Config(OptimusMiniSettingsList currentSettings)
    {
      InitializeComponent();
      _Settings = currentSettings;
      _LocationDataProvider = new LocationDataProvider();

      // Unit
      if (_Settings["Unit"] != "")
      {
        if (_Settings["Unit"] == "m") { radioMetricUnit.Checked = true; }
          else { radioEnglishUnit.Checked = true; }
      }

      // Show
      if (currentSettings["ShowToday"] != "") { checkToday.Checked = (currentSettings["ShowToday"] == "1"); }
      if (currentSettings["ShowTomorrow"] != "") { checkTomorrow.Checked = (currentSettings["ShowTomorrow"] == "1"); }
      if (currentSettings["ShowDayAfterTomorrow"] != "") { checkDayAfterTomorrow.Checked = (currentSettings["ShowDayAfterTomorrow"] == "1"); }
      if (currentSettings["ShowWeekend"] != "") { checkWeekend.Checked = (currentSettings["ShowWeekend"] == "1"); }

      // Wait
      if (currentSettings["Wait"] != "") { textWait.Text = currentSettings["Wait"]; }

      // Location
      if (currentSettings["LocationCode"] != "")
      {
        labelCurrentLocation.Text = currentSettings["LocationCode"];
      }
      else
      {
        labelCurrentLocation.Text = "not set";
      }

    }

    private void buttonSearch_Click(object sender, EventArgs e)
    {
      try
      {
        this.UseWaitCursor = true;
        this.Enabled = false;

        _LocationDataProvider.Search(textSearchCriteria.Text);
        selectLocations.Items.Clear();
        if (_LocationDataProvider.Locations.Count == 0)
        {
          selectLocations.Enabled = false;
          buttonSelect.Enabled = false;
          selectLocations.Items.Add("No location found.");
          selectLocations.SelectedIndex = 0;
        }
        else
        {
          for (int i = 0; i < _LocationDataProvider.Locations.Count; i++)
          {
            selectLocations.Items.Add(_LocationDataProvider.Locations[i].Name);
          }
          selectLocations.Enabled = true;
          selectLocations.SelectedIndex = 0;
          buttonSelect.Enabled = true;
        }
      }
      finally
      {
        this.UseWaitCursor = false;
        this.Enabled = true;
      }

    }

    private void textSearchCriteria_TextChanged(object sender, EventArgs e)
    {
      buttonSearch.Enabled = (textSearchCriteria.Text.Length > 0);
    }

    private void buttonSelect_Click(object sender, EventArgs e)
    {
      if (selectLocations.SelectedIndex > -1)
      {
        labelCurrentLocation.Text = _LocationDataProvider.Locations[selectLocations.SelectedIndex].Code;
      }
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {

      // Validate
      if (labelCurrentLocation.Text == "not set")
      {
        MessageBox.Show("Location required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        textSearchCriteria.Focus();
        return;
      }
      if (!checkToday.Checked && !checkTomorrow.Checked && !checkDayAfterTomorrow.Checked && !checkWeekend.Checked)
      {
        MessageBox.Show("At last one display data item required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        checkToday.Focus();
        return;
      }
      try
      {
        int.Parse(textWait.Text);
      }
      catch (Exception)
      {
        MessageBox.Show("Enter valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        textWait.Focus();
        return;
      }

      // Unit
      if (radioEnglishUnit.Checked)
      {
        _Settings["Unit"] = "s";
      }
      else
      {
        _Settings["Unit"] = "m";
      }

      // Show
      _Settings["ShowToday"] = checkToday.Checked ? "1" : "0";
      _Settings["ShowTomorrow"] = checkTomorrow.Checked ? "1" : "0";
      _Settings["ShowDayAfterTomorrow"] = checkDayAfterTomorrow.Checked ? "1" : "0";
      _Settings["ShowWeekend"] = checkWeekend.Checked ? "1" : "0";

      // Wait
      _Settings["Wait"] = int.Parse(textWait.Text).ToString();

      // Location
      _Settings["LocationCode"] = labelCurrentLocation.Text;


      DialogResult = DialogResult.OK;

    }

  }
}