using Rooster.Storing.Repositories;

namespace Rooster.Storing
{
  public class UnitOfWork
  {
    private readonly RoosterContext _context;

    public ErrandsRepository Errands { get; }
    public UsersRepository Users { get; }
    
    public UnitOfWork(RoosterContext context)
    {
      _context = context;

      Errands = new ErrandsRepository(_context);
      Users = new UsersRepository(_context);
    }

    public void Save()
    {
      _context.SaveChanges();
    }
  }
}