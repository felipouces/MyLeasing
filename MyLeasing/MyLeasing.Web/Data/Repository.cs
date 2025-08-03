using MyLeasing.Common.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        // I have to build a method that connects all owners.
        public IEnumerable<Owner> GetOwners()
        {
            return _context.Owners.OrderBy(p => p.FirstName);
        }

        // I have to build a method that connects an owner by id.
        public Owner GetOwner(int id)
        {
            return _context.Owners.Find(id);
        }

        // Now build a method to add
        public void AddOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            //_context.SaveChanges();
        }

        // Now build a method to update
        public void UpdateOwner(Owner owner)
        {
            _context.Owners.Update(owner);
            //_context.SaveChanges();
        }

        // Now build a method to delete
        public void RemoveOwner(Owner owner)
        {
            _context.Owners.Remove(owner);
        }

        // Asynchronous method to save
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
            // If the number of changes is greater than 0, it means that the save was successful.
        }

        // Method to check if an owner exists by id
        public bool OwnerExists(int id)
        {
            return _context.Owners.Any(p => p.Id == id);
        }


    }
}
