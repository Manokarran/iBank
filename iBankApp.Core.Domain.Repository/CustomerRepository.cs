using iBankApp.Core.Data.Model;
using iBankApp.Infrastructure.Data;

namespace iBankApp.Core.Domain.Repository
{
    public class CustomerRepository<TEntity> : GenericRepository<TEntity> where TEntity : class
    {
        private readonly iBankAppContext _dbContext;

        public CustomerRepository(iBankAppContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}