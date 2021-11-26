using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Helpers
{
    public class PageInfo
    {
        public int PageNum { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
    }
}
