using LeadSoft.Common.GlobalDomain.Entities;

namespace LeadSoft.Common.GlobalDomain.DTOs.Infos.Bank
{
    /// <summary>
    /// DTO Bank Account Response
    /// </summary>
    public partial class DTOBankAccountResponse
    {
        /// <summary>
        /// Operator from Bank Account to DTOBankAccount
        /// </summary>
        /// <param name="aBankAccount">Bank Account</param>
        public static implicit operator DTOBankAccountResponse(BankAccount aBankAccount)
        {
            return new DTOBankAccountResponse()
            {
                AccountNumber = aBankAccount.AccountNumber,
                AccountVc = aBankAccount.AccountVc,
                AgencyNumber = aBankAccount.AgencyNumber,
                AgencyVc = aBankAccount.AgencyVc,
                Code = aBankAccount.Code,
                DocumentNumber = aBankAccount.DocumentNumber,
                LegalName = aBankAccount.LegalName,
                Pix = aBankAccount.Pix
            };
        }
    }
}
