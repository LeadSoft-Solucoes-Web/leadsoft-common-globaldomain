namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// Page request DTO methods.
    /// </summary>

    public partial class DTOPagedRequest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DTOPagedRequest()
        {
            IsPaged = true;
        }

        /// <summary>
        /// Is paged based Constructor
        /// </summary>
        public DTOPagedRequest(bool aIsPaged)
        {
            IsPaged = aIsPaged;
        }

        /// <summary>
        /// Calculates Skip value
        /// </summary>
        /// <returns>int skip value</returns>
        public int TakeSkip()
            => (CurrentPage - 1) * PageSize;
    }
}
