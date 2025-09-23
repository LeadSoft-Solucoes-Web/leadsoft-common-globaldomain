using LeadSoft.Common.GlobalDomain.Entities;

namespace LeadSoft.Common.GlobalDomain.DTOs.Infos.Bank
{
    /// <summary>
    /// DTO Bank Account Update
    /// </summary>
    public partial class DTOBankAccountUpsert
    {

        /// <summary>
        /// Explicit Operator
        /// </summary>
        /// <param name="aAccount"></param>
        public static explicit operator BankAccount(DTOBankAccountUpsert aAccount)
        {
            return new BankAccount()
            {
                AccountNumber = aAccount.AccountNumber,
                AccountVc = aAccount.AccountVc,
                AgencyNumber = aAccount.AgencyNumber,
                AgencyVc = aAccount.AgencyVc,
                Code = aAccount.Code,
                DocumentNumber = aAccount.DocumentNumber,
                LegalName = aAccount.LegalName,
                Pix = aAccount.Pix
            };
        }
    }
}
