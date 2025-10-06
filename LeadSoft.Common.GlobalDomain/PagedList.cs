using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain
{
    public class PagedList<T> : List<T> where T : class
    {
        public virtual int CurrentPage { get; set; }
        public virtual int PageSize { get; set; }
        public virtual long TotalResults { get; set; }
        public virtual int TotalPages { get; set; }
        public virtual bool HasPreviousPage => CurrentPage > 1;
        public virtual bool HasNextPage => CurrentPage < TotalPages;

        public PagedList()
        {
        }

        public PagedList(PagedList<T> aPagedList)
        {
            PageSize = aPagedList.PageSize;
            CurrentPage = aPagedList.CurrentPage;
            TotalResults = aPagedList.TotalResults;
            TotalPages = (int)Math.Ceiling(TotalResults / (double)aPagedList.PageSize);

            if (!aPagedList.IsNull())
                AddRange(aPagedList);
        }

        public PagedList(IEnumerable<T> aList, PagedRequest pagedRequest, long aTotalResults)
        {
            PageSize = pagedRequest.PageSize;
            CurrentPage = pagedRequest.CurrentPage;
            TotalResults = aTotalResults;
            TotalPages = (int)Math.Ceiling(TotalResults / (double)pagedRequest.PageSize);

            if (!aList.IsNull())
                AddRange(aList);
        }

        public PagedList(IEnumerable<T> aList, int aPageSize, int aCurrentPage, long aTotalResults)
        {
            PageSize = aPageSize;
            CurrentPage = aCurrentPage;
            TotalResults = aTotalResults;
            TotalPages = (int)Math.Ceiling(TotalResults / (double)aPageSize);

            if (!aList.IsNull())
                AddRange(aList);
        }

        public PagedList<D> ToNew<D>(IEnumerable<D> aList) where D : class
        {
            PagedList<D> pagedList = new()
            {
                PageSize = PageSize,
                CurrentPage = CurrentPage,
                TotalResults = TotalResults,
                TotalPages = (int)Math.Ceiling(TotalResults / (double)PageSize)
            };

            if (!aList.IsNull())
                pagedList.AddRange(aList);

            return pagedList;
        }

        /// <summary>
        /// Method that checks if list is empty
        /// </summary>
        /// <returns>True if empty</returns>
        public bool IsEmpty() => !this.Any();
    }
}
