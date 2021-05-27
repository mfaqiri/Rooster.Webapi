using System;
using System.Collections;
using System.Collections.Generic;
using Rooster.Domain.Abstracts;

namespace Rooster.Domain.Models
{
  public class Errand : AModel
  {
    public DateTime ErrandStart { get; private set; }
    public DateTime ErrandEnd { get; private set; }
    public TimeSpan Duration { get; private set; }
    public User User { get; private set; }
    public string Descr { get; set; }
    public string Title { get; set; }

    public Errand(DateTime errandStart, string title, string descr = null)
    {

      ErrandStart = errandStart;
      Title = title;
      Descr = descr;
    }

    public void SetUser(User inUser)
    {
      User = inUser;
    }

    public bool SetEnd(DateTime errandEnd)
    {
      if (errandEnd < ErrandStart)
      {
        return false;
      }
      ErrandEnd = errandEnd;
      Duration = errandEnd - ErrandStart;
      return true;
    }

  }
}