using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Rooster.Domain.Abstracts;
using Rooster.Domain.Interfaces;
using Rooster.Domain.Models;

namespace Rooster.Storing.Repositories
{
  public class ErrandsRepository : IRepository<Errand>
  {
    private readonly RoosterContext _context;

    public ErrandsRepository(RoosterContext context)
    {
      _context = context;
    }

    public bool Delete(Errand entry)
    {
      //throw new System.NotImplementedException();
      if(_context.Errands.Contains(entry))
      {
        _context.Errands.Remove(entry);

        if(!_context.Errands.Contains(entry))
          return true;
      }
      return false;
    }

    public bool Insert(Errand entry)
    {
      var result = _context.Errands.Add(entry);
      if (result != null)
      {
        return true;
      }
      return false;
    }

    public IEnumerable<Errand> Select(Func<Errand, bool> filter)
    {
      var errands = _context.Errands
        .Include(e => e.User);
      return errands.Where(filter);
    }

    public Errand Update(Errand existing, Errand entry)
    {
      Delete(existing);
      if(Insert(entry))
        return entry;
      
      return null;
    }
  }
}
