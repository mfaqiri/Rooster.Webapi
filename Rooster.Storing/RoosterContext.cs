using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rooster.Domain.Models;

namespace Rooster.Storing
{
  public class RoosterContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Errand> Errands { get; set; }

    public RoosterContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().HasKey(e => e.EntityId);
      modelBuilder.Entity<Errand>().HasKey(e => e.EntityId);

      modelBuilder.Entity<User>().HasMany<Errand>(u => u.schedule).WithOne(e => e.User);
      modelBuilder.Entity<Errand>().HasOne<User>(e => e.User).WithMany(u => u.schedule);

      modelBuilder.Entity<User>().HasData(new User("johndoe@example.com")
      {
        EntityId = 1
      });

      modelBuilder.Entity<Errand>().HasData(new Errand(DateTime.Now, "Meeting")
      {
        EntityId = 1
      });
    }

  }

}