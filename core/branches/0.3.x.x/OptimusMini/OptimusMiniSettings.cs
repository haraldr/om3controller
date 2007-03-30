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
using System.IO;
using System.Xml;


namespace Toolz.OptimusMini
{

  /// <summary>
  /// Provides settings (name/value) by section, stored in an xml file.
  /// </summary>
  public class OptimusMiniSettings
  {

    private string _Path;
    private Dictionary<string, OptimusMiniSettingsSection> _Sections;


    /// <summary>
    /// Creates a new instance of the <see cref="OptimusMiniSettings" /> class and returns it.
    /// </summary>
    public OptimusMiniSettings()
    {
      _Path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.xml");
      _Sections = new Dictionary<string, OptimusMiniSettingsSection>();
      Load();
    }


    /// <summary>
    /// Creates a new instance of the <see cref="OptimusMiniSettings" /> class and returns it.
    /// </summary>
    /// <param name="path">The file path of the settings file.</param>
    public OptimusMiniSettings(string path)
    {
      _Path = path;
      Load();
    }


    /// <summary>
    /// Loads settings from xml file.
    /// </summary>
    public void Load()
    {
      if (!File.Exists(_Path)) { return; }

      XmlDocument lXml = new XmlDocument();
      lXml.Load(_Path);

      foreach (XmlElement lXmlSection in lXml.DocumentElement.ChildNodes)
      {
        OptimusMiniSettingsSection lSection = new OptimusMiniSettingsSection(lXmlSection.Attributes["Name"].Value);
        _Sections.Add(lSection.Name, lSection);

        foreach (XmlElement lXmlValue in lXmlSection.ChildNodes)
        {
          lSection.List[lXmlValue.Attributes["Name"].Value] = lXmlValue.InnerText;
        }
      }

    }


    /// <summary>
    /// Saves settings to xml file.
    /// </summary>
    public void Save()
    {
      XmlDocument lXml = new XmlDocument();
      XmlElement lRoot = lXml.CreateElement("Settings");
      lXml.AppendChild(lRoot);

      foreach (OptimusMiniSettingsSection lSection in _Sections.Values)
      {
        XmlElement lXmlSection = (XmlElement)lRoot.AppendChild(lXml.CreateElement("Section"));
        lXmlSection.Attributes.Append(lXml.CreateAttribute("Name")).Value = lSection.Name;

        foreach (string lKey in lSection.List._Values.Keys)
        {
          string lValue = lSection.List[lKey];
          XmlElement lXmlValue = (XmlElement)lXmlSection.AppendChild(lXml.CreateElement("Setting"));
          lXmlValue.Attributes.Append(lXml.CreateAttribute("Name")).Value = lKey;
          lXmlValue.InnerText = lValue;
        }
      }

      lXml.Save(_Path);

    }


    /// <summary>
    /// Gets settings section by name.
    /// </summary>
    /// <param name="sectionName">Section name.</param>
    /// <returns>Settings section.</returns>
    public OptimusMiniSettingsSection this[string sectionName]
    {
      get
      {
        if (_Sections.ContainsKey(sectionName))
        {
          return _Sections[sectionName];
        }
        else
        {
          OptimusMiniSettingsSection lSection = new OptimusMiniSettingsSection(sectionName);
          _Sections.Add(sectionName, lSection);
          return lSection;
        }
      }
    }

  }


  /// <summary>
  /// Settings section containing name/value collection.
  /// </summary>
  public class OptimusMiniSettingsSection
  {

    private string _Name;
    private OptimusMiniSettingsList _List;


    /// <summary>
    /// Creates a new instance of the <see cref="OptimusMiniSettingsSection" /> class and returns it.
    /// </summary>
    /// <param name="name"></param>
    public OptimusMiniSettingsSection(string name)
    {
      _Name = name;
      _List = new OptimusMiniSettingsList();
    }


    /// <summary>
    /// Gets name of the section.
    /// </summary>
    public string Name
    {
      get { return _Name; }
    }


    /// <summary>
    /// Gets name/value collection of the section.
    /// </summary>
    public OptimusMiniSettingsList List
    {
      get { return _List; }
    }

  }


  /// <summary>
  /// Name/value collection of a settings section.
  /// </summary>
  public class OptimusMiniSettingsList
  {

    internal Dictionary<string, string> _Values;


    /// <summary>
    /// Creates a new instance of the <see cref="OptimusMiniSettingsList" /> class and returns it.
    /// </summary>
    public OptimusMiniSettingsList()
    {
      _Values = new Dictionary<string, string>();
    }


    /// <summary>
    /// Gets or sets a value.
    /// </summary>
    /// <param name="settingName">Name of the setting.</param>
    /// <returns>Value or an empty string if it doesn't exist.</returns>
    public string this[string settingName]
    {
      get
      {
        if (_Values.ContainsKey(settingName))
        {
          return _Values[settingName];
        }
        else
        {
          return string.Empty;
        }
      }
      set
      {
        _Values[settingName] = value;
      }
    }

  }

}