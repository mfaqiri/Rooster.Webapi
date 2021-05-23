using Rooster.Domain.Abstracts;
using System.Collections.Generic;
using Rooster.Domain.Models;

namespace Rooster.Domain.Models
{
  public class User : AModel
  {
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Event> schedule { get; }

    public User(string email, string password)
    {
      Email = email;
      Password = password;
      schedule = new List<Event>();
    }

    public bool addEvent(Event newEvent)
    {

      if (schedule.Contains(newEvent))
        return false;

      foreach (Event parse in schedule)
      {
        if (newEvent.EventStart > parse.EventStart ||
            newEvent.EventStart < parse.EventEnd)
          return false;
      }
      newEvent.userId = EntityId;
      schedule.Add(newEvent);

      return true;
    }

  }
}