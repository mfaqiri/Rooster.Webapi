using Rooster.Storing.Repositories;

namespace Rooster.Storing
{
  public class UnitOfWork
  {
    private readonly RoosterContext _context;

    public ErrandRepository Errand { get; }
    public UserRepository User { get; }
    
    public UnitOfWork(RoosterContext context)
    {
      _context = context;

      Errand = new CrustsRepository(_context);
      User = new UserRepository(_context);
    }

    public void Save()
    {
      _context.SaveChanges();
    }
  }
}