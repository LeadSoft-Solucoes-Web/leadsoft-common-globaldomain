using static LeadSoft.Common.Library.Enumerators.Enums;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    public partial class DTODocumentFileInfo
    {
        public DTODocumentFileInfo(FileExtension aFileExtension, long aSize)
        {
            Extension = aFileExtension;
            Size = aSize;
        }
    }
}
