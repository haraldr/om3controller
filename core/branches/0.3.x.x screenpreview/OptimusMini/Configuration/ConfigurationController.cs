using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml;


namespace Toolz.OptimusMini.Configuration
{

  public class ConfigurationController : ConfigurationSection
  {

    private int _IdleTime;
    private OptimusMiniBrightness _Brightness;
    private float _Gamma;
    private OptimusMiniOrientation _Orientation;
    private int _RotationInterval;
    private bool _PluginsGetAhead;
    private Color _PreferredBackgroundColor;
    private Color _PreferredTextColor;
    private Color _PreferredTitleColor;


    public ConfigurationController(ConfigurationManager owner, XmlElement node)
      : base(owner, node)
    {
      // Default values
      _IdleTime = 300;
      _Brightness = OptimusMiniBrightness.Low;
      _Gamma = 0.65f;
      _Orientation = OptimusMiniOrientation.Right;
      _RotationInterval = 30;
      _PluginsGetAhead = true;
      _PreferredBackgroundColor = Color.Black;
      _PreferredTextColor = Color.White;
      _PreferredTitleColor = Color.CadetBlue;
    }


    internal override void ReadXml(XmlElement node)
    {
      base.ReadXml(node);

      //_IdleTime = int.Parse(node.Attributes["idletime"]);
      //_Brightness = (OptimusMiniBrightness)int.Parse(node.Attributes["brightness"]);



    }


    public int IdleTime
    {
      get { return _IdleTime; }
      set { _IdleTime = value; }
    }


    public OptimusMiniBrightness Brightness
    {
      get { return _Brightness; }
      set { _Brightness = value; }
    }


    public float Gamma
    {
      get { return _Gamma; }
      set { _Gamma = value; }
    }


    public OptimusMiniOrientation Orientation
    {
      get { return _Orientation; }
      set { _Orientation = value; }
    }


    public int RotationInterval
    {
      get { return _RotationInterval; }
      set { _RotationInterval = value; }
    }


    public bool PluginsGetAhead
    {
      get { return _PluginsGetAhead; }
      set { _PluginsGetAhead = value; }
    }


    public Color PreferredBackgroundColor
    {
      get { return _PreferredBackgroundColor; }
      set { _PreferredBackgroundColor = value; }
    }


    public Color PreferredTextColor
    {
      get { return _PreferredTextColor; }
      set { _PreferredTextColor = value; }
    }


    public Color PreferredTitleColor
    {
      get { return _PreferredTitleColor; }
      set { _PreferredTitleColor = value; }
    }

  }

}