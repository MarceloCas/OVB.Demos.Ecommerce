#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.

using Microsoft.EntityFrameworkCore;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Mappings;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.Entities;
using OVB.Demos.Ecommerce.Microsservices.User.Infrascructure.Data.Mappings;

namespace OVB.Demos.Ecommerce.Microsservices.User.Infrascructure.Data;

public class DataContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
      : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        IBaseMapping<UserEntity> userMapping = new UserMapping();
        userMapping.CreateMapping(modelBuilder.Entity<UserEntity>());

        base.OnModelCreating(modelBuilder);
    }
}

#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.