using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rooster.Domain.Models;

namespace Rooster.Storing
{
  public class RoosterContext : DbContext
  {
    public DbSet<User> Users {get;set;}
    public DbSet<Errand> Errands {get;set;}

    public RoosterContext(DbContextOptions options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().HasKey(e => e.EntityId);
      modelBuilder.Entity<Errand>().HasKey(e => e.EntityId);

      modelBuilder.Entity<User>().HasMany<Errand>(u => u.schedule).WithOne(e => e.user);
    }

  }

}