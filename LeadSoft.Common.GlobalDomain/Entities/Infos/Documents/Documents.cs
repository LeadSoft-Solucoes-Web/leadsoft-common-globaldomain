using System.Collections.Generic;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Documents list object
    /// </summary>
    public partial class Documents
    {
        /// <summary>
        /// List of document type
        /// </summary>
        public List<Document> This { get; private set; }
    }
}
