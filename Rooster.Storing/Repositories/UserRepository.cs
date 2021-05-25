using System;
using System.Collections.Generic;
using System.Linq;
using Rooster.Domain.Interfaces;
using Rooster.Domain.Abstracts;
using Rooster.Domain.Models;

namespace Rooster.Storing.Repositories
{
  public class UserRepository : IRepository<User>
  {
    private readonly RoosterContext _context;

    public UserRepository(RoosterContext context)
    {
      _context = context;
    }

    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(User entry)
    {
      var result = _context.User.Add(entry);
      if (result != null)
      {
        return true;
      }
      return false;
    }

    public IEnumerable<User> Select(Func<User, bool> filter)
    {
      return _context.User.Where(filter);
    }

    public User Update()
    {
      throw new System.NotImplementedException();
    }
  }
}
