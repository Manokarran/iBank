using iBankApp.Core.Domain.Model;
using iBankApp.Interfaces.Data;

namespace iBankApp.Core.Domain.Repository.Interfaces
{
    public interface ICustomerRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Customer
    {
    }
}