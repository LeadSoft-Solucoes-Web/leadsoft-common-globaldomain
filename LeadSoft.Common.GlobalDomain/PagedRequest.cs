namespace LeadSoft.Common.GlobalDomain
{
    /// <summary>
    /// Represents a base class for paginated requests, providing properties and methods to manage pagination settings.
    /// </summary>
    /// <remarks>This class is designed to be inherited by other classes that require pagination
    /// functionality. It provides properties to specify the current page and the number of items per page, as well as a
    /// method to calculate the number of items to skip based on these settings.</remarks>
    /// <remarks>
    /// Initializes a new instance of the <see cref="PagedRequest"/> class with the specified page number and page
    /// size.
    /// </remarks>
    /// <remarks>The constructor ensures that both <paramref name="currentPage"/> and <paramref
    /// name="pageSize"/> are non-negative by taking their absolute values.</remarks>
    /// <param name="currentPage">The current page number. Must be a non-negative integer.</param>
    /// <param name="pageSize">The number of items per page. Must be a non-negative integer.</param>
    public abstract class PagedRequest(int currentPage = 1, int pageSize = 10)
    {
        /// <summary>
        /// Gets or sets the current page number in a paginated list.
        /// </summary>
        public virtual int CurrentPage { get; set; } = Math.Abs(currentPage);

        /// <summary>
        /// Gets or sets the number of items to display per page in a paginated list.
        /// </summary>
        public virtual int PageSize { get; set; } = Math.Abs(pageSize);

        /// <summary>
        /// Calculates the number of items to skip based on the current page and page size.
        /// </summary>
        /// <returns>The total number of items to skip, calculated as the product of the zero-based current page index and the
        /// page size.</returns>
        public int TakeSkip()
        {
            int currentPage = Math.Abs(CurrentPage);
            currentPage = currentPage <= 1 ? 0 : currentPage - 1;

            return currentPage * Math.Abs(PageSize);
        }
    }
}
