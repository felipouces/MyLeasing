using MyLeasing.Common.Entities;

namespace MyLeasing.Web.Data
{
    public class OwnerRepository : GenericRepository<Owner>, IOwnersRepository
    {
        public OwnerRepository(DataContext context) : base(context)
        {
            // This base(context) call is essential for the OwnerRepository to inherit the functionality of GenericRepository.
            // The constructor initializes the base class with the provided DataContext.
            // This allows the OwnerRepository to use the methods defined in GenericRepository.
        }
    }
}
