using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// DTO Image Data Upsert Operators
    /// </summary>
    public partial class DTOIntegration
    {
        /// <summary>
        /// Image Data class to DTO Image Data
        /// </summary>
        /// <param name="aDto">DTOImageDataUpsert</param>
        public static explicit operator LeadSoft.Common.GlobalDomain.Entities.Integration(DTOIntegration aDto)
        {
            if (aDto.IsNull())
                return null;

            return new LeadSoft.Common.GlobalDomain.Entities.Integration()
            {
                IntegrationServiceType = aDto.IntegrationServiceType,
                AppKey = aDto.AppKey,
            }.SetSecret(aDto.AppSecret);
        }
    }
}
