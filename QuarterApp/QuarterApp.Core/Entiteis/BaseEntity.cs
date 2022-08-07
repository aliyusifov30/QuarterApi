using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Core.Entiteis
{
    public class BaseEntity
    {

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(4);
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow.AddHours(4);
        public bool IsDeleted { get; set; }

    }
}
