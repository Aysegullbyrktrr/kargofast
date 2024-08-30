using MongoDB.Bson;

namespace CargoFast.Bussines.Abstract;

public interface IGenericService<T> where T : class
{
    Task TCreateAsync(T entity);
    Task TUpdateAsync(T entity);
    Task TDeleteAsync(string id);
    Task<List<T>> TGetListAsync();
    Task<T> TGetByIdAsync(string id);
}