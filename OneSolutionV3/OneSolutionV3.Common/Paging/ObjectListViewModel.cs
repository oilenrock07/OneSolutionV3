using System.Collections.Generic;

namespace OneSolutionV3.Common.Paging
{
    public class ObjectListViewModel<T> where T : class
    {
        public List<T> ObjectList { get; set; }
        public string SearchKeyWord { get; set; }
        public string RedirectUrl { get; set; }

        public PaginationViewModel PaginationViewModel { get; set; }
    }
}