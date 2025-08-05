using Microsoft.EntityFrameworkCore;
using MyLeasing.Common.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace MyLeasing.Web.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
               _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
            // Set<T> is the table for the entity type T in the database.
            // AsNoTracking() is used to improve performance by not tracking changes to the entities.
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().
                AsNoTracking().
                FirstOrDefaultAsync(e => e.Id == id);
            // This method retrieves an entity of type T by its ID asynchronously.
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            // This method creates a new entity of type T in the repository asynchronously.
            await SaveAllAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            // This method updates an existing entity of type T in the repository asynchronously.
            await SaveAllAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            // This method deletes an entity of type T from the repository asynchronously.
            await SaveAllAsync();
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _context.Set<T>().AnyAsync(e => e.Id == id);
            // This method checks if an entity of type T exists in the repository by its ID asynchronously.
        }

        private async Task<bool>SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
