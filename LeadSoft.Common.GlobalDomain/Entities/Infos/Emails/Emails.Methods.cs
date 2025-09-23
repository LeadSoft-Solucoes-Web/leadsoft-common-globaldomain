using LeadSoft.Common.GlobalDomain.DTOs;
using LeadSoft.Common.Library;
using LeadSoft.Common.Library.Exceptions;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Account emails list methods
    /// </summary>
    public partial class Emails
    {
        /// <summary>
        /// Create Emails and set list from informed one
        /// </summary>
        /// <param name="aList">List of DTOEmailContact</param>
        public Emails(IList<DTOEmailContact> aList)
        {
            if (This.IsNull())
                This = [];

            if (aList.IsNotNull())
                This.AddRange(aList.Select(l => (EmailContact)l));
        }

        public bool IsPrimary(string aAddress) => Primary.Equals(aAddress);

        /// <summary>
        /// Insert an email and make it primary
        /// </summary>
        /// <param name="aEmailContact">E-mail address to add as primary</param>
        public Emails SetPrimary(EmailContact aEmailContact)
        {
            Add(aEmailContact);
            Primary = aEmailContact.Address;

            return this;
        }

        /// <summary>
        /// Get primary Email Contact
        /// </summary>
        /// <returns>Primary E-mail Contact object from list</returns>
        public EmailContact GetPrimary() => GetEmail(Primary);

        /// <summary>
        /// Get E-mail Contact by address
        /// </summary>
        /// <param name="aAddress">E-mail Address</param>
        /// <returns>E-mail Contact object from list found by address</returns>
        public EmailContact GetEmail(string aAddress) => This.FirstOrDefault(e => e.Address.Equals(aAddress));

        /// <summary>
        /// List all e-mails
        /// </summary>
        /// <returns>List of E-mail Contact objects</returns>
        public IList<EmailContact> List() => This;

        /// <summary>
        /// Checks if there are any registry
        /// </summary>
        /// <returns><see langword="true"/> or <see langword="false"/></returns>
        public bool Any() => (bool)(This?.Any());

        /// <summary>
        /// Make existing e-mail as primary
        /// </summary>
        /// <param name="aEmailAddress">E-mail Address</param>
        /// <returns>Self for Chain Call</returns>
        public Emails MakePrimary(string aEmailAddress)
        {
            if (aEmailAddress.IsNothing())
                return this;

            EmailContact emailContact = GetEmail(aEmailAddress);

            if (emailContact.IsNull())
                throw new NotFoundAppException(ApplicationStatusMessage.EmailAddressNotFound);

            Primary = emailContact.Address;

            return this;
        }

        /// <summary>
        /// Includes an email in list
        /// Emails cannot have duplicated address
        /// </summary>
        /// <param name="aEmail">Email contect class to be added to list</param>
        /// <param name="aHalfIfError">Flag that halts execution if error. Default: true</param>
        /// <returns>Self for Chain Call</returns>
        public Emails Add(EmailContact aEmail, bool aHalfIfError = true)
        {
            EmailContact email = GetEmail(aEmail.Address);

            if (email.IsNotNull())
                if (aHalfIfError)
                    throw new ConflictAppException(ApplicationStatusMessage.EmailAddressAlreadyExists);

            This.Add(aEmail);

            if (This.Count == 1)
                MakePrimary(aEmail.Address);

            return this;
        }

        /// <summary>
        /// Modify an E-mail Contact in list. It is found by address
        /// </summary>
        /// <param name="aEmail">Old Email Address</param>
        /// <param name="aNewEmail">New Email Address</param>
        /// <returns>Self for Chain Call</returns>
        public Emails Modify(string aEmail, EmailContact aNewEmail)
        {
            EmailContact email = GetEmail(aEmail);

            if (email.IsNull())
                throw new NotFoundAppException(ApplicationStatusMessage.EmailAddressNotFound);

            This.Remove(email);
            This.Add(aNewEmail);

            return this;
        }

        /// <summary>
        /// Removes an email number from list by Address
        /// </summary>
        /// <param name="aNumber">Email address to find</param>
        /// <returns>Self for Chain Call</returns>
        public Emails Remove(string aNumber)
        {
            EmailContact email = GetEmail(aNumber);

            if (email.IsNotNull())
                This.Remove(email);

            return this;
        }
    }
}
