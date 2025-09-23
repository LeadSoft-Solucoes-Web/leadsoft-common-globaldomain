using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Integration Class methods
    /// </summary>
    public partial class Integration
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public Integration()
        {
        }

        /// <summary>
        /// Sets App Secret with Crypt
        /// </summary>
        public Integration SetSecret(string aAppSecret)
        {
            AppSecret = aAppSecret.IsSomething() ? aAppSecret : string.Empty;
            return this;
        }

        /// <summary>
        /// Gets exposed App Secret
        /// </summary>
        public string ExposeSecret()
            => AppSecret.IsSomething() ? AppSecret : string.Empty;
    }
}
