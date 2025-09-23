using System.Collections.Generic;
using System.Linq;
using static LeadSoft.Common.Library.Enumerators.Enums;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    public partial class Integrations
    {
        /// <summary>
        /// Constructor builds this list
        /// </summary>
        public Integrations()
        {
            This = new List<Integration>();
        }

        public Integration Get(IntegrationServiceType aIntegrationServiceType)
            => This.FirstOrDefault(i => i.IntegrationServiceType == aIntegrationServiceType);

        public bool ExistsIntegration(IntegrationServiceType aIntegrationServiceType)
            => This.Any(i => i.IntegrationServiceType == aIntegrationServiceType);

        public Integrations Add(Integration aIntegration)
        {
            if (ExistsIntegration(aIntegration.IntegrationServiceType))
                Remove(aIntegration.IntegrationServiceType);

            This.Add(aIntegration);

            return this;
        }

        public bool Remove(IntegrationServiceType aIntegrationServiceType)
        {
            if (!ExistsIntegration(aIntegrationServiceType))
                return false;

            Integration integration = Get(aIntegrationServiceType);

            This.Remove(integration);

            return true;
        }

        public bool Clear()
        {
            This.Clear();

            return true;
        }
    }
}
