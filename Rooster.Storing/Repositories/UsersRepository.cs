using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Rooster.Domain.Abstracts;
using Rooster.Domain.Interfaces;
using Rooster.Domain.Models;

namespace Rooster.Storing.Repositories
{
  public class UsersRepository : IRepository<User>
  {
    private readonly RoosterContext _context;

    public UsersRepository(RoosterContext context)
    {
      _context = context;
    }

    public bool Delete(User entry)
    {
      if(_context.Users.Contains(entry))
      {
        _context.Users.Remove(entry);

        if(!_context.Users.Contains(entry))
          return true;
      }
      return false;
    }

    public bool Insert(User entry)
    {
      var result = _context.Users.Add(entry);
      if (result != null)
      {
        return true;
      }
      return false;
    }

    public IEnumerable<User> Select(Func<User, bool> filter)
    {
      var users = _context.Users
        .Include(u => u.schedule);
      return users.Where(filter);
    }

    public User Update()
    {
      throw new System.NotImplementedException();
    }
  }
}
