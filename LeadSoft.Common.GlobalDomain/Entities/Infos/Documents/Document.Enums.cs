using System.ComponentModel;

using static LeadSoft.Common.Library.Enumerators.Enums;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Document enumerators
    /// </summary>
    public partial class Enums
    {
        [Structured(100)]
        public enum DocumentType
        {
            [Node]
            [Description("Natural")]
            Natural = 00001,
            [Description("Passport")]
            Passport = 00100,
            [Description("Identification")]
            Identification = 00101,
            [Description("DriverLicence")]
            DriverLicence = 00102,
            [Description("CPF")]
            CPF = 00103,

            [Node]
            [Description("Legal")]
            Legal = 00002,
            [Description("CNPJ")]
            CNPJ = 00200,
            [Description("Inscrição Municipal")]
            IM = 00201,
            [Description("Inscrição Estadual")]
            IE = 00202,
            [Description("Business ID")]
            BusinessID = 00203
        }
    }
}
