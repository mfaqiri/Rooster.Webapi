using Rooster.Domain.Abstracts;
using System;

namespace Rooster.Domain.Models
{
  public class Event : AModel
  {
    public string Name { get; set; }
    public DateTime EventStart { get; private set; }
    public DateTime EventEnd { get; private set; }
    public TimeSpan Duration { get; private set; }
    public bool Completion { get; private set; }
    public int userId { get; set; }
    public string Descr { get; set; }

    public Event(DateTime eventStart, string descr = null)
    {

      EventStart = eventStart;
      Descr = descr;
    }

    public bool SetEnd(DateTime eventEnd)
    {
      if (eventEnd < EventStart)
      {
        return false;
      }
      EventEnd = eventEnd;
      Duration = eventEnd - EventStart;
      return true;
    }
    public override string ToString()
    {
      return $"{Name}";
    }
  }
}