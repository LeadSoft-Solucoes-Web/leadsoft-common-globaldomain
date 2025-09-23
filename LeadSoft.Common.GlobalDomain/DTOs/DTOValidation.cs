

using LeadSoft.Common.GlobalDomain.Entities.Validations;
using LeadSoft.Common.Library.Extensions;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    [Serializable]
    [DataContract]
    public partial class DTOValidation
    {
        [DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> MemberNames { get; private set; } = [];

        [DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? ErrorMessage { get; private set; } = string.Empty;

        /// <summary>
        /// Permite a conversão implícita de um objeto validation para DTOValidation.
        /// </summary>
        /// <param name="validation">Objeto Validation original.</param>
        /// <remarks>
        /// Retorna nulo caso o parâmetro fornecido seja nulo.
        /// </remarks>
        public static implicit operator DTOValidation(Validation validation)
        {
            if (validation is null)
                return null;

            return new()
            {
                MemberNames = validation.MemberNames,
                ErrorMessage = validation.ErrorMessage,
            };
        }

        public DTOValidation()
        {
        }

        public static IList<DTOValidation> From(IList<Validation>? validations)
            => validations.IsNotNull() && validations.Any()
                ? [.. validations.Select(vr => (DTOValidation)vr)]
                : null;


        public static DTOValidation ToDto(Validation validations)
            => validations;
    }
}
