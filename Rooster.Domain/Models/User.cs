using System.Collections.Generic;
using Rooster.Domain.Abstracts;

namespace Rooster.Domain.Models
{
  public class User : AModel
  {
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Errand> schedule { get; }

    public User(string email, string password = null)
    {
      Email = email;
      Password = password;
      schedule = new List<Errand>();
    }

    public void addPassword(string password)
    {
      Password = password;
    }

    public bool addErrand(Errand newErrand)
    {

      if (schedule.Contains(newErrand))
        return false;

      foreach (Errand parse in schedule)
      {
        if (newErrand.ErrandStart > parse.ErrandStart ||
            newErrand.ErrandStart < parse.ErrandEnd)
          return false;
      }

      schedule.Add(newErrand);

      return true;
    }

  }
}