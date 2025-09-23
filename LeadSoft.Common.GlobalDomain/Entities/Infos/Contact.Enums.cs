using System.ComponentModel;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Contact enumerators
    /// </summary>
    public partial class Enums
    {
        public enum ContactType
        {
            [Description("Comercial")]
            Commercial,
            [Description("Emergência")]
            Emergency,
            [Description("Residencial")]
            Home,
            [Description("Celular")]
            Mobile,
            [Description("Pessoal")]
            Personal,
            [Description("Profissional")]
            Professional,
            [Description("Fixo")]
            Landline,
            [Description("WhatsApp")]
            WhatsApp,
            [Description("Other")]
            Other
        }
    }
}
