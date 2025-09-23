namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Account phones list
    /// </summary>
    public partial class Phones
    {
        /// <summary>
        /// Primary phone number
        /// </summary>
        public virtual string Primary { get; private set; } = string.Empty;

        /// <summary>
        /// List of PhoneContact type
        /// </summary>
        protected List<PhoneContact> This { get; set; } = [];
    }
}