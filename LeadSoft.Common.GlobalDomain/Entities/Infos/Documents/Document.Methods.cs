using LeadSoft.Common.GlobalDomain.Entities.Infos.Documents;
using LeadSoft.Common.Library;
using LeadSoft.Common.Library.Enumerators;
using LeadSoft.Common.Library.Exceptions;
using LeadSoft.Common.Library.Extensions;

using static LeadSoft.Common.GlobalDomain.Entities.Enums;
using static LeadSoft.Common.Library.Enumerators.Enums;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Document methods
    /// </summary>
    public partial class Document
    {
        public const string RegexCPF = @"(\d{3})(\d{3})(\d{3})(\d{2})";
        public const string RegexCNPJ = @"(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})";
        public const string RegexCNPJCPF = @"(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})|(\d{3})(\d{3})(\d{3})(\d{2})";

        public const string RegexPonctuatedCPF = @"(\d{3}).(\d{3}).(\d{3})-(\d{2})";
        public const string RegexPonctuatedCNPJ = @"(\d{2}).(\d{3}).(\d{3})/(\d{4})-(\d{2})";
        public const string RegexPonctuatedCNPJCPF = @"(\d{2}).(\d{3}).(\d{3})/(\d{4})-(\d{2})|(\d{3}).(\d{3}).(\d{3})-(\d{2})";

        /// <summary>
        /// Base constructor
        /// </summary>
        public Document()
        {
        }

        /// <summary>
        /// For Document creation, you must set it's type before!
        /// </summary>
        /// <param name="aNumber">Document number</param>
        public Document(string aNumber)
        {
            Type = aNumber.IsCnpj()
                    ? DocumentType.CNPJ
                    : aNumber.IsCpf()
                        ? DocumentType.CPF
                        : throw new BadRequestAppException("Failed to check document type");

            SetNumber(aNumber);
        }

        /// <summary>
        /// For Document creation, you must set it's type before!
        /// </summary>
        /// <param name="aDocumentType">Document Type enum</param>
        /// <param name="aNumber">Document number</param>
        public Document(DocumentType aDocumentType, string aNumber)
        {
            Type = aDocumentType;
            SetNumber(aNumber);
        }

        /// <summary>
        /// Method that creates a new Inscrição Estadual Isento object
        /// </summary>
        /// <returns>Document</returns>
        public static Document CreateInscricaoEstadualIsento()
            => new Document().SetIsentoInscricaoEstadual();

        /// <summary>
        /// Method that sets sets this document as Incrição Estadual Isenta
        /// </summary>
        /// <returns>Document</returns>
        private Document SetIsentoInscricaoEstadual()
        {
            Type = DocumentType.IE;
            Number = "ISENTO";

            return this;
        }

        /// <summary>
        /// Method that creates a new Inscrição Municipal Isento object
        /// </summary>
        /// <returns>Document</returns>
        public static Document CreateInscricaoMunicipalIsento()
            => new Document().SetIsentoInscricaoMunicipal();

        /// <summary>
        /// Method that sets sets this document as Incrição Municipal Isenta
        /// </summary>
        /// <returns>Document</returns>
        private Document SetIsentoInscricaoMunicipal()
        {
            Type = DocumentType.IM;
            Number = "ISENTO";

            return this;
        }

        /// <summary>
        /// Gets formatted CPF or CNPJ Document number
        /// </summary>
        /// <returns>Formatted CPF or CNPJ</returns>
        public string GetFormattedCPForCNPJ() => Number.IsSomething() ? Number.FormatCPForCNPJ() : string.Empty;

        /// <summary>
        /// Sets document number, if valid
        /// </summary>
        /// <param name="aNumber">Document number</param>
        public Document SetNumber(string aNumber)
        {
            if ((Type.Equals(DocumentType.CPF) || Type.Equals(DocumentType.CNPJ)) && !VerifyCPForCNPJ(aNumber))
                throw new OperationCanceledException(string.Format(ApplicationStatusMessage.InvalidDocumentNumber, Type.GetDescription()));

            Number = aNumber?.OnlyNumeric();
            return this;
        }

        /// <summary>
        /// Generate document's file name
        /// -> Document Type description _ Alphanumeric number _ Name Generation Date and Time (Optional file extension)
        /// "CNH_1234569876_2020_05_12_12_23_47.pdf" or "CNH_1234569876_2020-05-12_12-23-47"
        /// </summary>
        /// <param name="aFileExtension">File extension to be concatenated. Default: None. Then File extension will be blank</param>
        /// <param name="aPrintDateTime">Prints current datetime. Default: False</param>
        /// <returns>Document's file name</returns>
        public string GetFileName(FileExtension aFileExtension = FileExtension.None, bool aPrintDateTime = false)
        {
            string extension = aFileExtension.Equals(FileExtension.None) ? string.Empty : aFileExtension.GetDescription();
            string datetime = aPrintDateTime ? $"_{DateTime.Now:yyyy-MM-dd_hh-mm-ss}" : string.Empty;

            return string.Concat(Type.GetDescription().ToUpper(), "_", Number.OnlyAlphanumeric(), datetime, extension);
        }

        /// <summary>
        /// Set expiration date
        /// </summary>
        /// <param name="aExpiration">Expiration date</param>
        public Document SetExpiration(DateTime aExpiration)
        {
            Expiration = aExpiration;
            return this;
        }

        /// <summary>
        /// Set Expiration date to null
        /// </summary>
        public Document ClearExpiration()
        {
            Expiration = null;
            return this;
        }

        /// <summary>
        /// Check if a CPF or a CNPJ is Valid
        /// </summary>
        /// <returns>True if valid.</returns>
        public bool IsValid()
        {
            if (Number.IsNothing())
                return false;

            return (Number.IsCpf() || Number.IsCnpj());
        }

        /// <summary>
        /// Method that tries to create a Document by CPF or CNPJ number
        /// </summary>
        /// <param name="aCpfCnpj">CPF or CNPJ</param>
        /// <returns>A Document or null in case of failure</returns>
        public static Document TryCreateCPForCNPJ(string aCpfCnpj)
        {
            aCpfCnpj = aCpfCnpj.OnlyNumeric();

            if (aCpfCnpj.PadLeft(11, '0').IsCpf())
                return new(aCpfCnpj.PadLeft(11, '0'));

            if (aCpfCnpj.PadLeft(14, '0').IsCnpj())
                return new(aCpfCnpj.PadLeft(14, '0'));

            return null;
        }

        /// <summary>
        /// Check if given CPF or CNPJ is Valid
        /// </summary>
        /// <param name="aCpfCnpj">CPF or CNPJ to validate</param>
        /// <returns>Valid or Invalid (Boolean)</returns>
        public static bool VerifyCPForCNPJ(string aCpfCnpj)
        {
            if (aCpfCnpj.IsNothing())
                return false;

            return (aCpfCnpj.IsCpf() || aCpfCnpj.IsCnpj());
        }

        /// <summary>
        /// Gets a document number and returns a document type for CPF or CNPJ
        /// </summary>
        /// <param name="aDocumentNumber">Document number</param>
        /// <returns>Document type</returns>
        /// <exception cref="OperationCanceledException"></exception>
        public static DocumentType GetDocumentTypeCPForCNPJ(string aDocumentNumber)
        {
            if (aDocumentNumber.IsNothing())
                throw new OperationCanceledException("Document number cannot be empty.");

            return aDocumentNumber.IsCpf() ? DocumentType.CPF
                   : aDocumentNumber.IsCnpj() ? DocumentType.CNPJ
                   : throw new OperationCanceledException("Document is not CNPJ or CPF.");
        }
    }
}
