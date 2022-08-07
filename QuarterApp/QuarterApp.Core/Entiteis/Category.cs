using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Core.Entiteis
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
}
