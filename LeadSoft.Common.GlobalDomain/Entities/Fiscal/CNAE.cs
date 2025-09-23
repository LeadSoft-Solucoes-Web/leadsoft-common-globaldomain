namespace LeadSoft.Common.GlobalDomain.Entities.Fiscal
{
    /// <summary>
    /// CNAE Class
    /// 
    /// A Classificação Nacional de Atividades Econômicas - CNAE é a classificação oficial
    /// adotada pelo Sistema Estatístico Nacional do Brasil e pelos órgãos federais,
    /// estaduais e municipais gestores de registros administrativos e demais instituições do Brasil.
    /// </summary>
    public partial class CNAE : CollectionsBase
    {
        /// <summary>
        /// CNAE Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// CNAE Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// CNAE Structure
        /// </summary>
        public string Structure { get; set; }
    }
}
