using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuarterApp.Core.Repositories
{
    public interface IRepository<TEntity>
    {

        Task InsertAsync(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity,bool>> exp , params string[] includes);
        Task<IEnumerable<TEntity>> GetPagenatedAsync(int pageIndex , int pageSize , Expression<Func<TEntity,bool>> exp , params string[] includes);
        Task<TEntity> GetAsync(Expression<Func<TEntity,bool>> exp , params string[] includes);
        Task<int> GetCountAsync(Expression<Func<TEntity,bool>> exp , params string[] includes);
        Task<bool> IsExistAsync(Expression<Func<TEntity,bool>> exp , params string[] includes);
        void RemoveAsync(TEntity entity);
    }
}
