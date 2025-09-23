namespace LeadSoft.Common.GlobalDomain.Entities.Fiscal
{
    /// <summary>
    /// CFOP Class
    /// 
    /// Código Fiscal de Operações e de Prestações ou sob a sigla CFOP é um código
    /// do sistema tributarista brasileiro, determinado pelo governo.
    /// É indicado nas emissões de notas fiscais, declarações, guias e escrituração de livros.
    /// </summary>
    public partial class CFOP : CollectionsBase
    {
        /// <summary>
        /// CFOP Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// CFOP Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// CFOP Notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// CFOP Type
        /// </summary>
        public string Type { get; set; }
    }
}
