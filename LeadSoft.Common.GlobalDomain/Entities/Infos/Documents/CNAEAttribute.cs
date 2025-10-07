using System.ComponentModel.DataAnnotations;

namespace LeadSoft.Common.GlobalDomain.Entities.Infos.Documents
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class CNAEAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is null)
                return true;

            string str = value.ToString()!;

            if (str.IsCnae())
                return true;

            ErrorMessage ??= "CNAE inválido.";
            return false;
        }
    }
}
