using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;


namespace Toolz.OptimusMini.Configuration
{

  /// <summary>
  /// Main class to read and write configuration.
  /// </summary>
  public class ConfigurationManager
  {

    private string _Path;
    private List<ConfigurationSection> _Sections;


    public ConfigurationManager()
    {
      _Path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml");
      _Sections = new List<ConfigurationSection>();
      Load();
    }


    /// <summary>
    /// Loads configuration.
    /// </summary>
    public void Load()
    {
      _Sections.Clear();

      if (!File.Exists(_Path)) { return; }

      XmlDocument lXml = new XmlDocument();
      lXml.Load(_Path);

      foreach (XmlElement lXmlSection in lXml.DocumentElement.ChildNodes)
      {
        switch (lXmlSection.Attributes["type"].Value)
        {
          case "controller":
            ConfigurationController lSectionController = new ConfigurationController(this, lXmlSection);
            _Sections.Add(lSectionController);
            break;

          case "layout":
            ConfigurationLayout lSectionLayout = new ConfigurationLayout(this, lXmlSection);
            _Sections.Add(lSectionLayout);
            break;

          case "plugininstance":
          case "custom":
          default:
            throw new Exception("Unknown configuration section type " + lXmlSection.Attributes["type"].Value + ".");
        }
      }

    }


    /// <summary>
    /// Saves configuration.
    /// </summary>
    public void Save()
    {
      //XmlDocument lXml = new XmlDocument();
      //XmlElement lRoot = lXml.CreateElement("Settings");
      //lXml.AppendChild(lRoot);

      //foreach (OptimusMiniSettingsSection lSection in _Sections.Values)
      //{
      //  XmlElement lXmlSection = (XmlElement)lRoot.AppendChild(lXml.CreateElement("Section"));
      //  lXmlSection.Attributes.Append(lXml.CreateAttribute("Name")).Value = lSection.Name;

      //  foreach (string lKey in lSection.List._Values.Keys)
      //  {
      //    string lValue = lSection.List[lKey];
      //    XmlElement lXmlValue = (XmlElement)lXmlSection.AppendChild(lXml.CreateElement("Setting"));
      //    lXmlValue.Attributes.Append(lXml.CreateAttribute("Name")).Value = lKey;
      //    lXmlValue.InnerText = lValue;
      //  }
      //}

      //lXml.Save(_Path);

    }


  }

}