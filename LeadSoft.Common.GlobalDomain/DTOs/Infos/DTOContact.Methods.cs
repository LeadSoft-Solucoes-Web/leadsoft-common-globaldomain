namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// DTO Contact methods
    /// </summary>
    public abstract partial class DTOContact
    {
        /// <summary>
        /// Set current contact to primary.
        /// </summary>
        public void SetPrimary() => IsPrimary = true;
    }
}
