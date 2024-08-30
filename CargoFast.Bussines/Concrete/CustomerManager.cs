using CargoFast.Bussines.Abstract;
using CargoFast.DataAccess.Abstract;
using CargoFast.Entity;

namespace CargoFast.Bussines.Concrete;

public class CustomerManager : GenericManager<Customer>,ICustomerService
{
    public CustomerManager(IGenericDal<Customer> genericDal) : base(genericDal)
    {
    }
}

