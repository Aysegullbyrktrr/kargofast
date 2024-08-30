using CargoFast.Bussines.Abstract;
using CargoFast.DataAccess.Abstract;


namespace CargoFast.Bussines.Concrete;

public class GenericManager<T> : IGenericService<T> where T :class
{
    private readonly IGenericDal<T> _genericDal;

    public GenericManager(IGenericDal<T> genericDal)
    {
        _genericDal = genericDal;
    }

    public async Task TCreateAsync(T entity)
    {
        await _genericDal.CreateAsync(entity);
    }

    public async Task TUpdateAsync(T entity)
    {
        await _genericDal.UpdateAsync(entity);
    }

    public async Task TDeleteAsync(string id)
    {
        await _genericDal.DeleteAsync(id);
    }

    public async Task<List<T>> TGetListAsync()
    {
        return await _genericDal.GetListAsync();
    }

    public async Task<T> TGetByIdAsync(string id)
    {
        return await _genericDal.GetByIdAsync(id);
    }
}