using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Core.Entiteis
{
    public class Property : BaseEntity
    {

        public string Name { get; set; }
        public double? Price { get; set; }
        public double? DaylyPrice { get; set; }
        public double? WeeklyPrice { get; set; }
        public double? MonthlyPrice { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public string PosterImage { get; set; }

        
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
