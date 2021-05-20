using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rooster.Domain.Models;

namespace Rooster.Storing
{
  public class RoosterContext : DbContext
  {
    public DbSet<User> Users {get;set;}
    public DbSet<Event> Events {get;set;}

    public RoosterContext(DbContextOptions options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().HasKey(e => e.EntityId);
      modelBuilder.Entity<Event>().HasKey(e => e.EntityId);

      modelBuilder.Entity<User>().HasMany<Event>(u => u.schedule).WithOne(e => e.user);
    }

  }

}