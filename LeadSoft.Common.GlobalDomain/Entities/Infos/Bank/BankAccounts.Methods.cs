using LeadSoft.Common.GlobalDomain.DTOs.Infos.Bank;
using LeadSoft.Common.Library.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeadSoft.Common.GlobalDomain.Entities.Infos.Bank
{
    /// <summary>
    /// Bank Accounts Methods
    /// </summary>
    public partial class BankAccounts
    {
        /// <summary>
        /// Constructor builds this list
        /// </summary>
        public BankAccounts()
        {
            This = new List<BankAccount>();
        }

        /// <summary>
        /// Create BankAccounts and set list from informed one
        /// </summary>
        /// <param name="aList">List of DTOAddress</param>
        public BankAccounts(IList<DTOBankAccount> aList)
        {
            if (This.IsNull())
                This = new List<BankAccount>();

            if (aList.IsNotNull())
                This.AddRange(aList.Select(l => (BankAccount)l));
        }

        /// <summary>
        /// List all Bank Accounts
        /// </summary>
        /// <returns>List of Accounts objects</returns>
        public IList<BankAccount> List() => This;

        /// <summary>
        /// Checks if there are any registry
        /// </summary>
        /// <returns><see langword="true"/> or <see langword="false"/></returns>
        public bool Any() => (bool)(This?.Any());

        /// <summary>
        /// Get Address by description
        /// </summary>
        /// <param name="aAccountNumber">Account Number</param>
        /// <param name="aAgencyNumber">Agency Number</param>
        /// <param name="aCode">Bank Code</param>
        /// <returns>Accounts object from list found by description</returns>
        public BankAccount GetBankAccount(string aCode, string aAgencyNumber, string aAccountNumber) => This.FirstOrDefault(e => e.Code == aCode && e.AgencyNumber == aAgencyNumber && e.AccountNumber == aAccountNumber);

        /// <summary>
        /// Includes an Accounts in list
        /// Account cannot have duplicated Description
        /// </summary>
        /// <param name="aAccount">Bank Account class to be added to list</param>
        /// <returns>Self for Chain Call</returns>
        public BankAccounts Add(BankAccount aAccount)
        {
            BankAccount account = GetBankAccount(aAccount.Code, aAccount.AgencyNumber, aAccount.AccountNumber);

            if (account.IsNotNull())
                throw new OperationCanceledException("Bank Account Already exists");

            This.Add(aAccount);

            return this;
        }

        /// <summary>
        /// Modify an Bank Account in list. It is found by description
        /// </summary>
        /// <param name="aAccount">Bank Account class to be added to list</param>
        /// <returns>Self for Chain Call</returns>
        public BankAccounts Modify(BankAccount aAccount)
        {
            BankAccount account = GetBankAccount(aAccount.Code, aAccount.AgencyNumber, aAccount.AccountNumber);

            if (account.IsNull())
                throw new OperationCanceledException("Bank Account Not Found");

            This.Remove(account);
            This.Add(aAccount);

            return this;
        }

        /// <summary>
        /// Removes an Bank Account from list by Parameters
        /// </summary>
        /// <param name="aAccount">Account parameters to find</param>
        /// <returns>Self for Chain Call</returns>
        public BankAccounts Remove(BankAccount aAccount)
        {
            BankAccount account = GetBankAccount(aAccount.Code, aAccount.AgencyNumber, aAccount.AccountNumber);

            if (account.IsNotNull())
                This.Remove(account);

            return this;
        }
    }
}
