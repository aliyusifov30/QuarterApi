using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Service.DTOs
{
    public class PagenatedListDto<T>
    {
        public PagenatedListDto(IEnumerable<T> items , int pageSize , int pageIndex)
        {
            Items = items;
            PageIndex = pageIndex;
            TotalCount = (int)Math.Ceiling(TotalCount / (double)pageSize);

            HasPrev = 1 > TotalCount;
            HasNext = TotalCount > PageIndex;
        }
        public IEnumerable<T> Items { get;}
        public int PageIndex { get; }
        public int TotalCount { get; set; }
        public bool HasPrev { get;}
        public bool HasNext { get; }
    }
}
