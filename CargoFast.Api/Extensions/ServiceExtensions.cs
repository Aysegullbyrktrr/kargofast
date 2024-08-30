using CargoFast.Bussines.Abstract;
using CargoFast.Bussines.Concrete;
using CargoFast.DataAccess.Abstract;
using CargoFast.DataAccess.EntityFramework;
using CargoFast.DataAccess.Repository;

namespace CargoFast.Api.Extensions;

public static class ServiceExtensions
{
    public static void AddServiceExtension(this IServiceCollection services)
    {
        services.AddScoped<ICustomerDal, EfCustomerDal>();
        services.AddScoped<ICustomerService, CustomerManager>();
 

        services.AddScoped<IShippingDal, EfShippingDal>();
        services.AddScoped<IShippingService, ShippingManager>();


        services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
        services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
    }
}