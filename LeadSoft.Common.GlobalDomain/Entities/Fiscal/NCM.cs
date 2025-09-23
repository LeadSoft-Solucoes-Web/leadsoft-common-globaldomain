namespace LeadSoft.Common.GlobalDomain.Entities.Fiscal
{
    /// <summary>
    /// NCM Class
    /// 
    /// Um código de oito dígitos, chamado de Nomeclatura Comum do Mercosul (NCM),
    /// está presente em todas as notas fiscais emitidas de produtos nacionais ou importados.
    /// A NCM identifica a natureza das mercadorias registradas naquele documento seguindo
    /// uma ordem lógica e internacional.
    /// </summary>
    public partial class NCM : CollectionsBase
    {
        /// <summary>
        /// NCM Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// NCM EX
        /// </summary>
        public string Ex { get; set; }

        /// <summary>
        /// NCM Description
        /// </summary>
        public string Description { get; set; }
    }
}
