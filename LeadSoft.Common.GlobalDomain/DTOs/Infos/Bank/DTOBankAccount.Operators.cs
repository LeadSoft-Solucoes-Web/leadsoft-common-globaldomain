using LeadSoft.Common.GlobalDomain.Entities;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.DTOs.Infos.Bank
{
    public partial class DTOBankAccount
    {
        public static explicit operator DTOBankAccount(BankAccount aBankAccount)
        {
            if (aBankAccount.IsNull())
                return new DTOBankAccount();

            return new DTOBankAccount()
            {
                Code = aBankAccount.Code,
                LegalName = aBankAccount.LegalName,
                DocumentNumber = aBankAccount.DocumentNumber,
                AgencyNumber = aBankAccount.AgencyNumber,
                AgencyVc = aBankAccount.AgencyVc,
                AccountNumber = aBankAccount.AccountNumber,
                AccountVc = aBankAccount.AccountVc,
                Pix = aBankAccount.Pix
            };
        }

        public static explicit operator BankAccount(DTOBankAccount aDto)
        {
            if (aDto.IsNull())
                return new BankAccount();

            return new BankAccount()
            {
                Code = aDto.Code,
                LegalName = aDto.LegalName,
                DocumentNumber = aDto.DocumentNumber,
                AgencyNumber = aDto.AgencyNumber,
                AgencyVc = aDto.AgencyVc,
                AccountNumber = aDto.AccountNumber,
                AccountVc = aDto.AccountVc,
                Pix = aDto.Pix
            };
        }
    }
}
