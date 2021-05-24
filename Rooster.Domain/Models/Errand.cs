using Rooster.Domain.Abstracts;
using System;

namespace Rooster.Domain.Models
{
  public class Errand : AModel
  {
    public DateTime ErrandStart {get; private set;}
    public DateTime ErrandEnd {get; private set;}
    public TimeSpan Duration {get; private set;}
    public User user{get; private set;}
    public string Descr{get;set;}

    public Errand(DateTime errandStart, string descr = null)
    {

      ErrandStart = errandStart;
      Descr = descr;
    }

    public void setUser(User inUser)
    {
        user = inUser;
    }

    public bool SetEnd(DateTime errandEnd)
    {
      if(errandEnd < ErrandStart)
      {
        return false;
      }
      ErrandEnd = errandEnd;
      Duration = errandEnd - ErrandStart;
      return true;
    }

  }
}