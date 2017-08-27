using Domain.DatabaseContext;
using Domain.Entieties;

namespace Domain.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }
    }
}