using LeadSoft.Common.GlobalDomain.DTOs;
using LeadSoft.Common.Library;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Account phones list methods
    /// </summary>
    public partial class Phones
    {
        /// <summary>
        /// Create Phones and set list from informed one
        /// </summary>
        /// <param name="aList">List of PhoneContact</param>
        public Phones(IList<DTOPhoneContact> aList)
        {
            if (This.IsNull())
                This = [];

            if (aList.IsNotNull())
                This.AddRange(aList.Select(l => (PhoneContact)l));
        }

        public bool IsPrimary(string aNumber) => Primary.Equals(aNumber);

        /// <summary>
        /// Insert a phone number and make it primary
        /// </summary>
        /// <param name="aPhoneContact">Phone contact to add as primary</param>
        public Phones SetPrimary(PhoneContact aPhoneContact)
        {
            Add(aPhoneContact);

            Primary = aPhoneContact.Number;
            return this;
        }

        /// <summary>
        /// Get primary Phone Contact
        /// </summary>
        /// <returns>Primary Phone Contact object from list</returns>
        public PhoneContact GetPrimary() => GetPhone(Primary);

        /// <summary>
        /// Get Phone Contact by description
        /// </summary>
        /// <param name="aNumber">Phone Number</param>
        /// <returns>Phone Contact object from list found by description</returns>
        public PhoneContact GetPhone(string aNumber) => This.FirstOrDefault(e => e.Number.Equals(aNumber.OnlyNumeric()));

        /// <summary>
        /// List all phones
        /// </summary>
        /// <returns>List of Phone Contact objects</returns>
        public IList<PhoneContact> List() => This;

        /// <summary>
        /// Checks if there are any registry
        /// </summary>
        /// <returns><see langword="true"/> or <see langword="false"/></returns>
        public bool Any() => (bool)(This?.Any());

        /// <summary>
        /// Make existing phone number as primary
        /// </summary>
        /// <param name="aPhoneNumber">Phone Number</param>
        /// <returns>Self for Chain Call</returns>
        public Phones MakePrimary(string aPhoneNumber)
        {
            if (aPhoneNumber.IsNothing())
                return this;

            PhoneContact phoneContact = GetPhone(aPhoneNumber);

            if (phoneContact.IsNull())
                throw new OperationCanceledException(ApplicationStatusMessage.PhoneNumberNotFound);

            Primary = phoneContact.Number;
            return this;
        }

        /// <summary>
        /// Includes a phone in list
        /// Phones cannot have duplicated number
        /// </summary>
        /// <param name="aPhone">Phone contect class to be added to list</param>
        /// <returns>Self for Chain Call</returns>
        public Phones Add(PhoneContact aPhone)
        {
            PhoneContact phone = GetPhone(aPhone.Number);

            if (phone.IsNotNull())
                throw new OperationCanceledException(ApplicationStatusMessage.PhoneNumberAlreadyExists);

            This.Add(aPhone);

            return this;
        }

        /// <summary>
        /// Modify a phone in list. It is found by number
        /// </summary>
        /// <param name="aNumber">Phone Contact class to be added to list</param>
        /// <returns>Self for Chain Call</returns>
        public Phones Modify(string aNumber, PhoneContact aNewPhone)
        {
            PhoneContact phone = GetPhone(aNumber);

            if (phone.IsNull())
                throw new OperationCanceledException(ApplicationStatusMessage.ObjectNotFound);

            This.Remove(phone);
            This.Add(aNewPhone);

            return this;
        }

        /// <summary>
        /// Removes a phone number from list by Number
        /// </summary>
        /// <param name="aNumber">Phone number to find</param>
        /// <returns>Self for Chain Call</returns>
        public Phones Remove(string aNumber)
        {
            PhoneContact phone = GetPhone(aNumber);

            if (phone.IsNotNull())
                This.Remove(phone);

            return this;
        }
    }
}