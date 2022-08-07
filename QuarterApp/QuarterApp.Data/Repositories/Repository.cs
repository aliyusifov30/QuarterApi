using Microsoft.EntityFrameworkCore;
using QuarterApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuarterApp.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> exp, params string[] includes)
        {
            return await GetInclude(includes).Where(exp).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> exp, params string[] includes)
        {
            return await GetInclude(includes).FirstOrDefaultAsync(exp);
        }

        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> exp, params string[] includes)
        {
            return await GetInclude(includes).Where(exp).CountAsync();
        }

        public async Task<IEnumerable<TEntity>> GetPagenatedAsync(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> exp, params string[] includes)
        {
            return await GetInclude(includes).Where(exp).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> exp, params string[] includes)
        {
            return await GetInclude(includes).AnyAsync(exp);
        }

        public void RemoveAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        private IQueryable<TEntity> SetInclude(ref IQueryable<TEntity> query,string[] includes)
        {
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }

        private IQueryable<TEntity> GetInclude(string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            
            SetInclude(ref query,includes);
            
            return query;
        }

    }
}
