using System;

namespace OneSolutionV3.Common.Paging
{
    public class PaginationViewModel
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int ItemCount { get; set; }
        public string SortByColumnName { get; set; }
        public string SortByOrder { get; set; }

        public int Index
        {
            get
            {
                return (this.CurrentPage - 1) * this.PageSize;
            }
        }

        public int PageCount
        {
            get
            {
                return (this.PageSize > 0) ? (int)Math.Ceiling((double)this.ItemCount / (double)this.PageSize) : 0;
            }
        }

        
    }
}