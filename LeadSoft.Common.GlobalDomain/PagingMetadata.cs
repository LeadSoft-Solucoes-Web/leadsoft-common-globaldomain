using LeadSoft.Common.Library.Extensions;
using Newtonsoft.Json;

namespace LeadSoft.Common.GlobalDomain
{

    /// <summary>
    /// Represents metadata for paginated results, including information about the current page, total number of pages,
    /// and navigation links for previous, current, and next pages.
    /// </summary>
    /// <remarks>This class provides properties to manage and navigate paginated data. It includes details
    /// such as the current page number, the size of each page, the total number of results, and the total number of
    /// pages. Additionally, it offers navigation links to facilitate moving between pages.</remarks>
    public class PagingMetadata(int currentPage, int pageSize, long totalResults, long totalPages)
    {
        /// <summary>
        /// Gets or sets the current page number in a paginated list.
        /// </summary>
        public virtual int CurrentPage { get; init; } = Math.Abs(currentPage);

        /// <summary>
        /// Gets or sets the number of items to display per page.
        /// </summary>
        public virtual int PageSize { get; init; } = Math.Abs(pageSize);

        /// <summary>
        /// Gets or sets the total number of results available.
        /// </summary>
        public virtual long TotalResults { get; init; } = Math.Abs(totalResults);

        /// <summary>
        /// Gets or sets the total number of pages available.
        /// </summary>
        public virtual long TotalPages { get; init; } = Math.Abs(totalPages);

        /// <summary>
        /// Gets or sets the URL of the previous page in a paginated list.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual string? PreviousPageLink { get; private set; } = null;

        /// <summary>
        /// Gets or sets the link to the current page in a paginated list.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual string? CurrentPageLink { get; private set; } = null;

        /// <summary>
        /// Gets or sets the URL for the next page of results in a paginated response.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual string? NextPageLink { get; private set; } = null;

        /// <summary>
        /// Sets the link to the previous page in the pagination sequence.
        /// </summary>
        /// <param name="link">The URL of the previous page. Can be <see langword="null"/> if there is no previous page.</param>
        /// <returns>The current instance of <see cref="PagingMetadata"/> with the updated previous page link.</returns>
        public PagingMetadata SetPreviousPageLink(string? link)
        {
            PreviousPageLink = link.SanitizeUrl() ?? null;
            return this;
        }

        /// <summary>
        /// Sets the link for the current page and returns the updated <see cref="PagingMetadata"/> instance.
        /// </summary>
        /// <param name="link">The URL of the current page. Can be <see langword="null"/> to indicate no link is set.</param>
        /// <returns>The updated <see cref="PagingMetadata"/> instance with the current page link set.</returns>
        public PagingMetadata SetCurrentPageLink(string? link)
        {
            CurrentPageLink = link.SanitizeUrl() ?? null;
            return this;
        }

        /// <summary>
        /// Sets the link to the next page of results and returns the updated <see cref="PagingMetadata"/> instance.
        /// </summary>
        /// <param name="link">The URL of the next page. Can be <see langword="null"/> if there is no subsequent page.</param>
        /// <returns>The current <see cref="PagingMetadata"/> instance with the updated next page link.</returns>
        public PagingMetadata SetNextPageLink(string? link)
        {
            NextPageLink = link.SanitizeUrl() ?? null;
            return this;
        }
    }
}
