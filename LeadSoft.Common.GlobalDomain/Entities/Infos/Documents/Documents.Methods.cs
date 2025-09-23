using LeadSoft.Common.GlobalDomain.DTOs;
using LeadSoft.Common.Library;
using LeadSoft.Common.Library.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using static LeadSoft.Common.GlobalDomain.Entities.Enums;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Documents Methods
    /// </summary>
    public partial class Documents
    {
        /// <summary>
        /// Constructor builds this list
        /// </summary>
        public Documents()
        {
            This = new List<Document>();
        }

        /// <summary>
        /// Create Documents and set list from informed one
        /// </summary>
        /// <param name="aList">List of DTODocument</param>
        public Documents(IList<DTODocument> aList)
        {
            if (This.IsNull())
                This = new List<Document>();

            if (aList.IsNotNull())
                This.AddRange(aList.Select(l => (Document)l));
        }

        /// <summary>
        /// Gets a document by number
        /// </summary>
        /// <param name="aNumber">Document Number</param>
        /// <returns>Document object</returns>
        public Document GetDocument(string aNumber)
        {
            return This.FirstOrDefault(d => d.Number.Equals(aNumber));
        }

        /// <summary>
        /// Gets a document by type
        /// </summary>
        /// <param name="aDocumentType">Document Type</param>
        /// <returns>Document object</returns>
        public Document GetDocument(DocumentType aDocumentType)
        {
            return This.FirstOrDefault(d => d.Type.Equals(aDocumentType));
        }

        /// <summary>
        /// List all documents
        /// </summary>
        /// <returns>List of Document objects</returns>
        public IList<Document> List() => This;

        /// <summary>
        /// Checks if there are any registry
        /// </summary>
        /// <returns><see langword="true"/> or <see langword="false"/></returns>
        public bool Any() => (bool)(This?.Any());

        /// <summary>
        /// Includes a document in list
        /// Document number cannot be duplicated on same expiration date
        /// </summary>
        /// <param name="aDocument">Document class to be added to list</param>
        /// <returns>Self for Chain Call</returns>
        public Documents Add(Document aDocument)
        {
            Document doc = This.FirstOrDefault(d => d.Type.Equals(aDocument.Type) || d.Number.Equals(aDocument.Number));

            if (doc.IsNotNull())
                if (doc.Expiration.HasValue || aDocument.Expiration.HasValue)
                {
                    if (doc.Expiration == aDocument.Expiration)
                        throw new OperationCanceledException(ApplicationStatusMessage.DuplicatedDocument);
                    else
                        Remove(aDocument.Type);
                }
                else
                    throw new OperationCanceledException(ApplicationStatusMessage.DuplicatedDocument);

            This.Add(aDocument);

            return this;
        }

        /// <summary>
        /// Removes a document from list by Document Type
        /// </summary>
        /// <param name="aDocumentType">Document type to be removed from list</param>
        /// <returns>Self for Chain Call</returns>
        public Documents Remove(DocumentType aDocumentType)
        {
            Document doc = This.FirstOrDefault(d => d.Type.Equals(aDocumentType));

            if (doc.IsNotNull())
                This.Remove(doc);

            return this;
        }
    }
}
