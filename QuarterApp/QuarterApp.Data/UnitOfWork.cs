using QuarterApp.Core;
using QuarterApp.Core.Repositories;
using QuarterApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuarterApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private ICategoryRepository _categoryRepository;
        private IProperyRepository _properyRepository;
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public ICategoryRepository CategoryRepository => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public IProperyRepository ProperyRepository => _properyRepository = _properyRepository ?? new PropertyRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
