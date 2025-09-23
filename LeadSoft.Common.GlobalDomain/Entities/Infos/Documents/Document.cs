
using System;
using static LeadSoft.Common.GlobalDomain.Entities.Enums;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Document informations
    /// </summary>
    public partial class Document
    {
        /// <summary>
        /// Document type enum
        ///  - Passport
        ///  - Driver license
        ///  - Others
        /// </summary>
        public DocumentType Type { get; private set; }

        /// <summary>
        /// Oficial number
        /// </summary>
        public string Number { get; private set; }

        /// <summary>
        /// Date when document was issued, if needed
        /// </summary>
        public DateTime? Issue { get; set; }

        /// <summary>
        /// Date when document expires, if needed
        /// </summary>
        public DateTime? Expiration { get; private set; }
    }
}
