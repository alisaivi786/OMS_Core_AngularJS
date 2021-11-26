using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Helpers
{
    public static class Pagination
    {
        public static PageData<T> PagedResult<T>(this IQueryable<T> list, int PageNumber, int PageSize) where T : class
        {
            var result = new PageData<T>();
            result.Data = list.Skip(PageSize * (PageNumber - 1)).Take(PageSize).AsQueryable();
            result.TotalPages = Convert.ToInt32(Math.Ceiling((double)list.Count() / PageSize));
            result.CurrentPage = PageNumber;
            result.PageSize = PageSize;
            return result;
        }
    }
}
