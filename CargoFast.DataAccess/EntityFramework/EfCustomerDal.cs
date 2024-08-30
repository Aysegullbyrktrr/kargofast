using CargoFast.DataAccess.Abstract;
using CargoFast.DataAccess.Context;
using CargoFast.DataAccess.Repository;
using CargoFast.Entity;

namespace CargoFast.DataAccess.EntityFramework;

public class EfCustomerDal: GenericRepository<Customer>,ICustomerDal
{
    public EfCustomerDal(CargoContext context) : base(context)
    {
    }
}