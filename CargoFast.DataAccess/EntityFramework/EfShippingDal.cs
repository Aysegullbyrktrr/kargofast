using CargoFast.DataAccess.Abstract;
using CargoFast.DataAccess.Context;
using CargoFast.DataAccess.Repository;
using CargoFast.Entity;

namespace CargoFast.DataAccess.EntityFramework;

public class EfShippingDal : GenericRepository<ShippingCode>,IShippingDal
{
    public EfShippingDal(CargoContext context) : base(context)
    {
    }
}