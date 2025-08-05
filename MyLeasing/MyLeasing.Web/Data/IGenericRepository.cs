using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    // The standard letter is T but we can use any letter we want, such as U, V, W, etc.
    public interface IGenericRepository<T> where T : class
        // This interface defines the basic CRUD operations for a generic repository.
    {

        IQueryable<T> GetAll();
        // This method retrieves all entities of type T from the repository.

        Task<T> GetByIdAsync(int id);
        // This method retrieves an entity of type T by its ID asynchronously.

        Task CreateAsync(T entity);
        // This method creates a new entity of type T in the repository asynchronously.

        Task UpdateAsync(T entity);
        // This method updates an existing entity of type T in the repository asynchronously.

        // This method deletes an entity of type T from the repository asynchronously.
        Task DeleteAsync(T entity);

        Task<bool> ExistAsync(int id);


    }
}
