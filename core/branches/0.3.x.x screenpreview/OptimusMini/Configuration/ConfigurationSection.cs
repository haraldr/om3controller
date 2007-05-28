using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Configuration;


namespace Toolz.OptimusMini.Configuration
{

  public enum ConfigurationSectionType
  {
    Controller,
    Layout,
    PluginInstance,
    Custom
  }


  public abstract class ConfigurationSection
  {

    private ConfigurationManager _Owner;
    private ConfigurationSectionType _Type;
    private string _Id;
    private int _Version;
    private bool _IsModified;


    public ConfigurationSection(ConfigurationManager owner, XmlElement node)
    {
      _Owner = owner;
    }


    public void Save()
    {
      _Owner.Save();
    }


    protected bool IsModified
    {
      get { return _IsModified; }
      set { _IsModified = value; }
    }


    internal virtual void ReadXml(XmlElement node)
    {
      switch (node.Attributes["type"].Value)
      {
        case "controller": _Type = ConfigurationSectionType.Controller; break;
        case "layout": _Type = ConfigurationSectionType.Layout; break;
        case "plugininstance": _Type = ConfigurationSectionType.PluginInstance; break;
        case "custom": _Type = ConfigurationSectionType.Custom; break;
        default:
          throw new Exception("Unknown configuration section type " + node.Attributes["type"] + ".");
      }

      _Id = node.Attributes["id"].Value;
      _Version = int.Parse(node.Attributes["Version"].Value);
    }

  }

}