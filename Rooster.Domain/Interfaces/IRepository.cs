using System;
using System.Collections.Generic;

namespace Rooster.Domain.Interfaces
{
  public interface IRepository<T> where T : class
  {
    IEnumerable<T> Select(Func<T, bool> filter);
    bool Insert(T entry);
    T Update(T existing, T entry);
    bool Delete(T entry);
  }
}