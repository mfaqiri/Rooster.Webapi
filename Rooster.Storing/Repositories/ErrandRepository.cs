using System;
using System.Collections.Generic;
using System.Linq;
using Rooster.Domain.Interfaces;
using Rooster.Domain.Abstracts;

namespace Rooster.Storing.Repositories
{
  public class ErrandRepository : IRepository<Errand>
  {
    private readonly RoosterContext _context;

    public ErrandRepository(RoosterContext context)
    {
      _context = context;
    }

    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(Errand entry)
    {
      var result = _context.Errand.Add(entry);
      if (result != null)
      {
        return true;
      }
      return false;
    }

    public IEnumerable<Errand> Select(Func<Errand, bool> filter)
    {
      return _context.Errand.Where(filter);
    }

    public Errand Update()
    {
      throw new System.NotImplementedException();
    }
  }
}
