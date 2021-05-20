using Rooster.Domain.Abstracts;
using System;

namespace Rooster.Domain.Models
{
  public class Event : AModel
  {
    public DateTime EventStart {get; private set;}
    public DateTime EventEnd {get; private set;}
    public TimeSpan Duration {get; private set;}
    public User user{get; private set;}
    public string Descr{get;set;}

    public Event(DateTime eventStart, string descr = null)
    {

      EventStart = eventStart;
      Descr = descr;
    }

    public void setUser(User inUser)
    {
        user = inUser;
    }

    public bool SetEnd(DateTime eventEnd)
    {
      if(eventEnd < EventStart)
      {
        return false;
      }
      EventEnd = eventEnd;
      Duration = eventEnd - EventStart;
      return true;
    }

  }
}