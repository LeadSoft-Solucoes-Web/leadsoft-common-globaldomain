using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    public static class DocumentExtensions
    {
        /// <summary>
        /// Determines whether the specified string is a valid CPF (Cadastro de Pessoas Físicas) number.
        /// </summary>
        /// <remarks>A CPF number is considered valid if it consists of 11 digits and passes the CPF
        /// validation algorithm. This method removes any non-numeric characters from the input string before
        /// validation.</remarks>
        /// <param name="aCPF">The string representing the CPF number to validate. It should contain only numeric characters.</param>
        /// <returns><see langword="true"/> if the specified string is a valid CPF number; otherwise, <see langword="false"/>.</returns>
        public static bool IsCpf(this string aCPF)
        {
            int[] multiplicador1 = [10, 9, 8, 7, 6, 5, 4, 3, 2];
            int[] multiplicador2 = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];

            aCPF = aCPF.OnlyNumeric();
            if (aCPF.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == aCPF)
                    return false;

            string tempCpf = aCPF.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            resto = (resto < 2) ? 0 : 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            resto = (resto < 2) ? 0 : 11 - resto;

            digito += resto.ToString();

            return aCPF.EndsWith(digito);
        }

        /// <summary>
        /// Determines whether the specified string is a valid CNPJ (Cadastro Nacional da Pessoa Jurídica) number.
        /// </summary>
        /// <remarks>A CNPJ is a 14-digit number used to identify Brazilian companies. This method checks the validity of
        /// the CNPJ by verifying its check digits according to the official algorithm.</remarks>
        /// <param name="aCNPJ">The string to validate as a CNPJ number. It must contain only numeric characters.</param>
        /// <returns><see langword="true"/> if the specified string is a valid CNPJ number; otherwise, <see langword="false"/>.</returns>
        public static bool IsCnpj(this string aCNPJ)
        {
            int[] multiplicador1 = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
            int[] multiplicador2 = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];

            aCNPJ = aCNPJ.OnlyNumeric();

            if (aCNPJ.Length != 14)
                return false;

            string tempCnpj = aCNPJ.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            resto = (resto < 2) ? 0 : 11 - resto;

            string digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            resto = (resto < 2) ? 0 : 11 - resto;

            digito += resto.ToString();

            return aCNPJ.EndsWith(digito);
        }

        public static string FormatCPForCNPJ(this string aDocumentNumber)
            => IsCpf(aDocumentNumber) ? FormatCPF(aDocumentNumber)
                      : IsCnpj(aDocumentNumber) ? FormatCNPJ(aDocumentNumber)
                      : throw new OperationCanceledException("Document is not CNPJ or CPF.");

        /// <summary>
        /// Formats a given CPF (Cadastro de Pessoas Físicas) string by inserting standard punctuation.
        /// </summary>
        /// <remarks>This method assumes the input string contains only digits and no existing
        /// punctuation.</remarks>
        /// <param name="aCpf">The CPF string to format. Must be exactly 11 digits long.</param>
        /// <returns>A formatted CPF string with periods and a hyphen inserted.  If the input string is not 11 digits long, the
        /// original string is returned unmodified.</returns>
        public static string FormatCPF(this string aCpf)
        {
            string response = aCpf.Trim();
            if (response.Length == 11)
            {
                response = response.Insert(9, "-");
                response = response.Insert(6, ".");
                response = response.Insert(3, ".");
            }
            return response;
        }

        /// <summary>
        /// Formats a CNPJ (Cadastro Nacional da Pessoa Jurídica) string by adding standard punctuation.
        /// </summary>
        /// <param name="aCnpj">The CNPJ string to format. Must be exactly 14 digits long.</param>
        /// <returns>A formatted CNPJ string with periods, a slash, and a hyphen added in the standard positions. If the input
        /// string is not 14 digits long, the original string is returned unmodified.</returns>
        public static string FormatCNPJ(this string aCnpj)
        {
            string response = aCnpj.Trim();
            if (response.Length == 14)
            {
                response = response.Insert(12, "-");
                response = response.Insert(8, "/");
                response = response.Insert(5, ".");
                response = response.Insert(2, ".");
            }
            return response;
        }
    }
}
