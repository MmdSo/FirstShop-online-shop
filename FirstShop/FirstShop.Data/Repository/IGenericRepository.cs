using FirstShop.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Repository
{
    public interface IGenericRepository <TEntity> : IAsyncDisposable where TEntity : BaseEntities
    {
        IEnumerable<TEntity> GetAll();
        IAsyncEnumerable<TEntity> GetAllAsync();
        Task<TEntity> GetEntityByIdAsync(long? Id);
        TEntity GetEntityById(long? id);
        Task<long> AddEntity(TEntity entity);
        void DeleteEntity(TEntity entity);
        void EditEntity(TEntity entity);
        Task SaveChanges();
    }
}
