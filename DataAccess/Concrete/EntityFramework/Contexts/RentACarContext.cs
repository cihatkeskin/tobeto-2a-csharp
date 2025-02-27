﻿using Core.Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace DataAccess.Concrete.EntityFramework.Contexts;

public class RentACarContext : DbContext
{
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Fuel> Fuels { get; set; }
    public DbSet<Transmission> Transmissions { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    public RentACarContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Brand>().HasKey(i=> i.Id); // EF Core Naming Convention BrandId
        modelBuilder.Entity<Brand>(e =>
        {
            e.HasKey(i => i.Id);
            e.Property(i=>i.Premium).HasDefaultValue(true);
        });

        modelBuilder.Entity<RoleUser>()
            .HasKey(ru => new { ru.UserId, ru.RoleId });

        base.OnModelCreating(modelBuilder); // Normalde yaptığı işlemleri sürdürür.
    }
}
// Update-Database migrationIsmi
// Remove-Migration

// 17:45