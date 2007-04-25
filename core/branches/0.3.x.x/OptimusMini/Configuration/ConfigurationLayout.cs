using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;


namespace Toolz.OptimusMini.Configuration
{

  public enum ConfigurationLayoutApplicationType
  {
    WindowTitle,
    ProcessName
  }


  public class ConfigurationLayoutApplication
  {
    private ConfigurationLayoutApplicationType _Type;
    private string _Name;


    public ConfigurationLayoutApplicationType Type
    {
      get { return _Type; }
      set { _Type = value; }
    }


    public string Name
    {
      get { return _Name; }
      set { _Name = value; }
    }

  }


  public class ConfigurationLayout : ConfigurationSection
  {

    private string _Name;
    private Keys _Shortcut;
    private List<ConfigurationLayoutApplication> _Applications;
    private bool _Permanent;


    public ConfigurationLayout(ConfigurationManager owner, XmlElement node)
      : base(owner, node)
    {
      _Applications = new List<ConfigurationLayoutApplication>();
    }

    internal override void ReadXml(XmlElement node)
    {
      base.ReadXml(node);
    }


    public string Name
    {
      get { return _Name; }
      set { _Name = value; }
    }


    public Keys ShortCut
    {
      get { return _Shortcut; }
      set { _Shortcut = value; }
    }


    public List<ConfigurationLayoutApplication> Applications
    {
      get { return _Applications; }
    }


    public bool Permanent
    {
      get { return _Permanent; }
      set { _Permanent = value; }
    }

  }

}