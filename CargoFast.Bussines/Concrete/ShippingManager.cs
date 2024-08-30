using CargoFast.Bussines.Abstract;
using CargoFast.DataAccess.Abstract;
using CargoFast.Entity;

namespace CargoFast.Bussines.Concrete;

public class ShippingManager : GenericManager<ShippingCode>, IShippingService
{
    public ShippingManager(IGenericDal<ShippingCode> genericDal) : base(genericDal)
    {
    }
}

