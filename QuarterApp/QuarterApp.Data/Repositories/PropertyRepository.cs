using QuarterApp.Core.Entiteis;
using QuarterApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Data.Repositories
{
    public class PropertyRepository : Repository<Property> , IProperyRepository
    {

        private readonly DataContext _context;
        public PropertyRepository(DataContext context):base(context)
        {
            _context = context;
        }

    }
}
