using System;
using System.Collections.Generic;
using System.Text;

namespace Toolz.OptimusMini
{

  public enum OptimusMiniEventLogType
  {
    Information,
    Warning,
    Error
  }


  public class OptimusMiniEventLog
  {
    public DateTime Time;
    public OptimusMiniEventLogType Type;
    public string Summary;
    public string Description;

    public OptimusMiniEventLog(
      OptimusMiniEventLogType type,
      string summary,
      string description)
    {
      Time = DateTime.Now;
      Type = type;
      Summary = summary;
      Description = description;
    }

  }

}