using LeadSoft.Common.GlobalDomain.Helpers;
using LeadSoft.Common.Library;
using LeadSoft.Common.Library.Extensions;

using Microsoft.AspNetCore.Mvc;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// Generic paged list response Methods
    /// </summary>
    public partial class DTOPagedListResponse<T>
    {

        /// <summary>
        /// Paged list constructor.
        /// Sets inner constructor with paged list.
        /// </summary>
        /// <param name="aPagedList">Paged list of objects to be set</param>
        public DTOPagedListResponse(PagedList<T> aPagedList) : base(aPagedList)
        {
        }

        /// <summary>
        /// Constructor based on an existing list, that sets inner base constructor with informed data.
        /// </summary>
        /// <param name="aList">List of objects</param>
        /// <param name="aPageSize">Page size number</param>
        /// <param name="aCurrentPage">Current page number</param>
        /// <param name="aTotalResults">Count of total results</param>
        public DTOPagedListResponse(IEnumerable<T> aList, int aPageSize, int aCurrentPage, long aTotalResults) : base(aList, aPageSize, aCurrentPage, aTotalResults)
        {
        }

        /// <summary>
        /// Gets header paging intomation serialized object in Json string
        /// </summary>
        /// <typeparam name="TRequest">Request type</typeparam>
        /// <param name="aUrl">Method Url</param>
        /// <param name="aRouteName">Name of current route</param>
        /// <param name="aDtoPagedRequestInheritance">DTO paged request inheritance to keep original params on query</param>
        /// <returns></returns>
        [Obsolete("This method is obsolete and insecure. Use GetSanitizedPagingHeader instead.")]
        public string GetPagingHeader<TRequest>(IUrlHelper aUrl, string aRouteName, TRequest aDtoPagedRequestInheritance) where TRequest : PagedRequest
        {
            if (!typeof(TRequest).IsSubclassOf(typeof(PagedRequest)))
                throw new ArgumentException(string.Format(ApplicationStatusMessage.ArgumentMustInheritFromDTOPagedRequest, nameof(aDtoPagedRequestInheritance)));

            PagingMetadata metadata = new(CurrentPage, PageSize, TotalResults, TotalPages);

            if (HasPreviousPage)
                metadata.SetPreviousPageLink(aUrl.Link(aRouteName, aDtoPagedRequestInheritance.GetPrevious()));

            if (HasNextPage)
                metadata.SetNextPageLink(aUrl.Link(aRouteName, aDtoPagedRequestInheritance.GetNext()));

            return metadata.SetCurrentPageLink(aUrl.Link(aRouteName, aDtoPagedRequestInheritance))
                           .ToJson();
        }

        /// <summary>
        /// Gets sanitized header paging intomation serialized object in Json string
        /// </summary>
        /// <typeparam name="TRequest">Request type</typeparam>
        /// <param name="aUrl">Method Url</param>
        /// <param name="aRouteName">Name of current route</param>
        /// <param name="aDtoPagedRequestInheritance">DTO paged request inheritance to keep original params on query</param>
        /// <returns></returns>
        public string GetSanitizedPagingHeader<TRequest>(IUrlHelper aUrl, string aRouteName, TRequest aDtoPagedRequestInheritance) where TRequest : PagedRequest
        {
            if (!typeof(TRequest).IsSubclassOf(typeof(PagedRequest)))
                throw new ArgumentException(string.Format(ApplicationStatusMessage.ArgumentMustInheritFromDTOPagedRequest, nameof(aDtoPagedRequestInheritance)));

            PagingMetadata metadata = new(CurrentPage, PageSize, TotalResults, TotalPages);

            if (HasPreviousPage)
                metadata.SetPreviousPageLink(aUrl.Link(aRouteName, aDtoPagedRequestInheritance.GetPrevious()));

            if (HasNextPage)
                metadata.SetNextPageLink(aUrl.Link(aRouteName, aDtoPagedRequestInheritance.GetNext()));

            return metadata.SetCurrentPageLink(aUrl.Link(aRouteName, aDtoPagedRequestInheritance))
                           .ToJson();
        }
    }
}