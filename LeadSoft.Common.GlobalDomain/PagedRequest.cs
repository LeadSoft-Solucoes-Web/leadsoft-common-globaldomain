namespace LeadSoft.Common.GlobalDomain
{
    public abstract class PagedRequest
    {
        public virtual int CurrentPage { get; set; }
        public virtual int PageSize { get; set; }

        public PagedRequest()
        {
            CurrentPage = 1;
            PageSize = 10;
        }
    }
}
