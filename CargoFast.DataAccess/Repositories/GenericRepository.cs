using CargoFast.DataAccess.Abstract;
using CargoFast.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CargoFast.DataAccess.Repository;

public class GenericRepository<T> : IGenericDal<T> where T :class
{
     private readonly CargoContext _context;
        

     public GenericRepository(CargoContext context)
     {
         _context = context;
     }
  
        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        
        public async Task DeleteAsync(string id)
        {
            var value = await GetByIdAsync(id);
            
            if (value == null)
            {
                throw new KeyNotFoundException("Belirtilen ID'ye sahip öğe bulunamadı.");
            }

            _context.Remove(value);
            await _context.SaveChangesAsync();
        }


        public async Task<List<T>> GetListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

}