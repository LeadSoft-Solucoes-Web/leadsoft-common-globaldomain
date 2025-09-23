namespace LeadSoft.Common.GlobalDomain.Entities.Fiscal
{
    /// <summary>
    /// CEST Class
    /// 
    /// O Código Especificador da Substituição Tributária, mais conhecido como CEST,
    /// estabelece uma forma de identificar e uniformizar mercadorias e bens sujeitos
    /// ao regime de substituição tributária, assim como a antecipação de recolhimento
    /// do imposto referente às operações subsequentes.
    /// </summary>
    public partial class CEST : CollectionsBase
    {
        /// <summary>
        /// CEST Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// CEST Description
        /// </summary>
        public string Description { get; set; }
    }
}
