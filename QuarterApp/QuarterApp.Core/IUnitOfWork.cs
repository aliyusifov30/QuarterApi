using QuarterApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuarterApp.Core
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }
        public IProperyRepository ProperyRepository { get; }

        Task<int> CommitAsync();
    }
}
