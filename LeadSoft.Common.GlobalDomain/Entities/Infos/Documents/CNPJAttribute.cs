using System.ComponentModel.DataAnnotations;

namespace LeadSoft.Common.GlobalDomain.Entities.Infos.Documents
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class CNPJAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is null)
                return true;

            string str = value.ToString()!;

            if (str.IsCpf())
                return true;

            ErrorMessage ??= "CPF inválido.";
            return false;
        }
    }
}
