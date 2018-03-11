using iBankApp.Core.Data.Model;
using iBankApp.Infrastructure.Data;

namespace iBankApp.Core.Domain.Repository
{
    public class AccountRepository<TEntity> : GenericRepository<TEntity> where TEntity : class
    {
        private readonly iBankAppContext _dbContext;

        public AccountRepository(iBankAppContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}