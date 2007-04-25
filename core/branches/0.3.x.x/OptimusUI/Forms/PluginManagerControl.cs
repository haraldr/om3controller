using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Toolz.OptimusMini;
using Toolz.OptimusMini.Plugins;


namespace OptimusUI.Forms
{
  public partial class PluginManagerControl : UserControl
  {

    private PluginManager _PluginManager;
    private OptimusMiniPluginBrowser _Browser;
    private OptimusMiniPluginBase _SelectedPlugin;
    private PluginInstance _SelectedAssignedPlugin;
    private OptimusMiniSettings _Settings;


    public PluginManagerControl()
    {
      InitializeComponent();

      labelPluginNameValue.Text = "";
      labelPluginAuthorValue.Text = "";
      labelPluginDescriptionValue.Text = "";
    }


    public void Init(
      PluginManager pluginManager,
      OptimusMiniPluginBrowser pluginBrowser,
      OptimusMiniSettings settings)
    {
      _PluginManager = pluginManager;
      _Browser = pluginBrowser;
      _Settings = settings;


      // ----- Available plugins
      listAvailablePlugins.Items.Clear();
      for (int i = 0; i < _Browser.Count; i++)
      {
        listAvailablePlugins.Items.Add(_Browser[i].Name);
      }
      if (_Browser.Count > 0)
      {
        listAvailablePlugins.Items[0].Selected = true;
      }


      // ----- Available layouts
      // TODO: available layouts
      listLayouts.Items.Clear();
      listLayouts.Items.Add("Default");
      listLayouts.Items[0].Selected = true;


      // ----- Update actions
      UpdateActions();
    }


    #region "UI events"

    private void listAvailablePlugins_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (listAvailablePlugins.SelectedIndices.Count > 0)
      {
        UpdateSelectedPlugin(_Browser[listAvailablePlugins.SelectedIndices[0]]);
      }
      else
      {
        UpdateSelectedPlugin(null);
      }
    }


    private void listAvailablePlugins_DoubleClick(object sender, EventArgs e)
    {
      AssignPlugin();
    }


    private void buttonPluginAssign_Click(object sender, EventArgs e)
    {
      AssignPlugin();
    }


    private void menuListAvailablePluginsAssign_Click(object sender, EventArgs e)
    {
      AssignPlugin();
    }


    private void buttonPluginConfig_Click(object sender, EventArgs e)
    {
      ConfigurePlugin();
    }


    private void menuListAvailablePluginsConfigure_Click(object sender, EventArgs e)
    {
      ConfigurePlugin();
    }


    private void listAssignedPlugins_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (listAssignedPlugins.SelectedIndices.Count > 0)
      {
        UpdateSelectedAssignedPlugin(_PluginManager._DefaultLayout._PluginInstances[listAssignedPlugins.SelectedIndices[0]]);
      }
      else
      {
        UpdateSelectedAssignedPlugin(null);
      }
    }


    private void buttonPluginUp_Click(object sender, EventArgs e)
    {
      MoveAssignedPluginUp();
    }


    private void buttonPluginDown_Click(object sender, EventArgs e)
    {
      MoveAssignedPluginDown();
    }


    private void buttonAssignedPluginConfig_Click(object sender, EventArgs e)
    {
      ConfigureAssignedPlugin();
    }


    private void menuListAssignedPluginsMoveUp_Click(object sender, EventArgs e)
    {
      MoveAssignedPluginUp();
    }


    private void menuListAssignedPluginsMoveDown_Click(object sender, EventArgs e)
    {
      MoveAssignedPluginDown();
    }


    private void menuListAssignedPluginsConfigure_Click(object sender, EventArgs e)
    {
      ConfigureAssignedPlugin();
    }


    private void menuListAssignedPluginsUnassign_Click(object sender, EventArgs e)
    {
      UnassignPlugin();
    }


    private void listAssignedPlugins_DoubleClick(object sender, EventArgs e)
    {
      ConfigureAssignedPlugin();
    }


    private void buttonPluginUnassign_Click(object sender, EventArgs e)
    {
      UnassignPlugin();
    }

    #endregion


    #region "UI logic"

    private void UpdateSelectedPlugin(OptimusMiniPluginBase plugin)
    {
      if (plugin == null)
      {
        _SelectedPlugin = null;
        labelPluginNameValue.Text = "";
        labelPluginAuthorValue.Text = "";
        labelPluginDescriptionValue.Text = "";
        picturePluginLogo.Image = null;
      }
      else
      {
        _SelectedPlugin = plugin;
        labelPluginNameValue.Text = _SelectedPlugin.Name;
        labelPluginAuthorValue.Text = _SelectedPlugin.Author;
        labelPluginDescriptionValue.Text = _SelectedPlugin.Description;
        picturePluginLogo.Image = Properties.Resources.plugin; // TODO plugin logo
      }

      UpdateActions();
    }


    private void AssignPlugin()
    {
      bool lPluginSelected = (_SelectedPlugin != null);
      bool lLayoutSelected = true; // TODO: selected layout

      if (!lPluginSelected || !lLayoutSelected) { return; }

      _PluginManager.AssignPlugin(_SelectedPlugin.Id, "", _Settings[_SelectedPlugin.Id].List);
      listAssignedPlugins.Items.Add(_SelectedPlugin.Name);

      UpdateActions();
    }


    private void ConfigurePlugin()
    {
      bool lPluginSelected = (_SelectedPlugin != null);

      if (!lPluginSelected) { return; }

      Form lForm = _SelectedPlugin.CreateConfiguration(_Settings[_SelectedPlugin.Id].List);
      DialogResult lFormResult = lForm.ShowDialog(this);
      lForm.Close();
      lForm.Dispose();

      if (lFormResult == DialogResult.OK)
      {
        _Settings.Save();
      }
    }


    private void UpdateSelectedAssignedPlugin(PluginInstance plugin)
    {
      if (plugin == null)
      {
        _SelectedAssignedPlugin = null;
      }
      else
      {
        _SelectedAssignedPlugin = plugin;
      }

      UpdateActions();
    }


    private void MoveAssignedPluginUp()
    {
    }


    private void MoveAssignedPluginDown()
    {
    }


    private void UnassignPlugin()
    {
      bool lPluginSelected = (_SelectedAssignedPlugin != null);

      if (!lPluginSelected) { return; }

      _PluginManager.UnassignPlugin(_SelectedAssignedPlugin._Plugin.Id, "", _Settings[_SelectedAssignedPlugin._Plugin.Id].List);
      listAssignedPlugins.SelectedItems[0].Remove();

      UpdateActions();
    }


    private void ConfigureAssignedPlugin()
    {
      bool lPluginSelected = (_SelectedAssignedPlugin != null);

      if (!lPluginSelected) { return; }

      Form lForm = _SelectedAssignedPlugin._Plugin.CreateConfiguration(_Settings[_SelectedAssignedPlugin._Plugin.Id].List);
      DialogResult lFormResult = lForm.ShowDialog(this);
      lForm.Close();
      lForm.Dispose();

      if (lFormResult == DialogResult.OK)
      {
        _Settings.Save();
      }
    }


    private void UpdateActions()
    {
      bool lPluginSelected = (_SelectedPlugin != null);
      bool lAssignedPluginSelected = (_SelectedAssignedPlugin != null);
      bool lLayoutSelected = true; // TODO: selected layout


      // ----- Configure plugin
      buttonPluginConfig.Enabled = menuListAvailablePluginsConfigure.Enabled =
        lPluginSelected && (_SelectedPlugin.IsConfigurable);


      // ----- Assign plugin
      buttonPluginAssign.Enabled = menuListAvailablePluginsAssign.Enabled =
        lPluginSelected && lLayoutSelected;


      // ----- Configure assigned plugin
      buttonAssignedPluginConfig.Enabled = menuListAssignedPluginsConfigure.Enabled =
        lAssignedPluginSelected && (_SelectedAssignedPlugin._Plugin.IsConfigurable);


      // ----- Move up/down
      if (lAssignedPluginSelected)
      {
        int lIndex = _PluginManager._DefaultLayout._PluginInstances.IndexOf(_SelectedAssignedPlugin);
        buttonPluginUp.Enabled = menuListAssignedPluginsMoveUp.Enabled =
          (lIndex > 0);
        buttonPluginDown.Enabled = menuListAssignedPluginsMoveDown.Enabled =
          (lIndex < (_PluginManager._DefaultLayout._PluginInstances.Count - 1));
      }
      else
      {
        buttonPluginUp.Enabled = menuListAssignedPluginsMoveUp.Enabled = false;
        buttonPluginDown.Enabled = menuListAssignedPluginsMoveDown.Enabled = false;
      }


      // ----- Unassign plugin
      buttonPluginUnassign.Enabled = menuListAssignedPluginsUnassign.Enabled =
        lAssignedPluginSelected;
    }

    #endregion

  }

}