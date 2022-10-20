using Microsoft.EntityFrameworkCore;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.Entities;

namespace OVB.Demos.Ecommerce.Microsservices.User.Infrascructure.Data;

public class DataContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
