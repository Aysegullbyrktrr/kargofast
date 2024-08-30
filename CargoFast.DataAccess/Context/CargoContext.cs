using CargoFast.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace CargoFast.DataAccess.Context;

public class CargoContext : DbContext
{
    public CargoContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ShippingCode> ShippingCodes { get; set; }
    public DbSet<Customer> Custumers { get; set; }

   
}

