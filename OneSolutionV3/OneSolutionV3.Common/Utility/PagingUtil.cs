using System.Collections.Generic;
using System.Linq;
using OneSolutionV3.Common.Paging;
namespace OneSolutionV3.Common.Utility
{
    public static class PagingUtil<T> where T: class
    {
        public static ObjectListViewModel<T> CreateObjectList(IQueryable<T> list, int currentPage, int pageSize, string sortByColumnName, string sortByOrder, string redirectUrl)
        {
            PaginationViewModel pagination = new PaginationViewModel
            {
                CurrentPage = currentPage,
                ItemCount = list.Count(),
                PageSize = pageSize
            };

            ObjectListViewModel<T> viewModel = new ObjectListViewModel<T>()
            {
                ObjectList = list.OrderBy(string.Format("{0} {1}", sortByColumnName, sortByOrder))
                             .Skip(pagination.Index)
                             .Take(pageSize).ToList(),
                PaginationViewModel = pagination,
                RedirectUrl = redirectUrl
            };

            return viewModel;
        }
    }
}
