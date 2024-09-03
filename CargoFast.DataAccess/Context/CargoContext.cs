using CargoFast.Entity;
using Microsoft.EntityFrameworkCore;

namespace CargoFast.DataAccess.Context;

public class CargoContext : DbContext
{
    public CargoContext(DbContextOptions options) : base(options)
    {
        Console.WriteLine(options);
    }

    public DbSet<ShippingCode> ShippingCodes { get; set; }
    public DbSet<Customer> Customers { get; set; }

   
}