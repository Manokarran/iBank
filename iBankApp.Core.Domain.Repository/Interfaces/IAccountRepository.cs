using iBankApp.Core.Domain.Model;
using iBankApp.Interfaces.Data;

namespace iBankApp.Core.Domain.Repository.Interfaces
{
    public interface IAccountRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Account
    {
    }
}