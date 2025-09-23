using LeadSoft.Common.GlobalDomain.Entities;

namespace LeadSoft.Common.GlobalDomain.Helpers
{
    public static class PagedRequestExtensions
    {
        public static T GetPrevious<T>(this T t) where T : PagedRequest
        {
            T previous = t;
            previous.CurrentPage--;

            return previous;
        }

        public static T GetNext<T>(this T t) where T : PagedRequest
        {
            T next = t;
            next.CurrentPage++;

            return next;
        }
    }
}
