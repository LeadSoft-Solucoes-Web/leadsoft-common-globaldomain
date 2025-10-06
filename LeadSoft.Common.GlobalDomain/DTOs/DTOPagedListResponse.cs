using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// Generic paged list response DTO
    /// </summary>
    /// <typeparam name="T">Any DTOResponse inherited object type</typeparam>

    [Serializable]
    [DataContract]
    public partial class DTOPagedListResponse<T> : PagedList<T> where T : DTOResponse
    {
        /// <summary>
        /// Current page value
        /// </summary>
        [DataMember]
        public override int CurrentPage { get => base.CurrentPage; set => base.CurrentPage = Math.Abs(value); }

        /// <summary>
        /// Page maximum size
        /// </summary>
        [DataMember]
        public override int PageSize { get => base.PageSize; set => base.PageSize = Math.Abs(value); }

        /// <summary>
        /// Total count of results, ignore pagging
        /// </summary>
        [DataMember]
        public override long TotalResults { get => base.TotalResults; set => base.TotalResults = Math.Abs(value); }

        /// <summary>
        /// Number of pages, based on total result and page size.
        /// </summary>
        [DataMember]
        public override long TotalPages { get => base.TotalPages; set => base.TotalPages = Math.Abs(value); }

        /// <summary>
        /// Informs if there is any previous page
        /// </summary>
        [DataMember]
        public override bool HasPreviousPage { get => base.HasPreviousPage; }

        /// <summary>
        /// Informs if there are next pages
        /// </summary>
        [DataMember]
        public override bool HasNextPage { get => base.HasNextPage; }
    }
}