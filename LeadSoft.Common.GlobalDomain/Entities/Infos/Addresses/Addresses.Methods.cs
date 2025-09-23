using LeadSoft.Common.GlobalDomain.DTOs;
using LeadSoft.Common.Library;
using LeadSoft.Common.Library.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Addresses list methods
    /// </summary>
    public partial class Addresses
    {
        /// <summary>
        /// Constructor builds this list
        /// </summary>
        public Addresses()
        {
            This = new List<Address>();
        }

        /// <summary>
        /// Create Adresses and set list from informed one
        /// </summary>
        /// <param name="aList">List of DTOAddress</param>
        public Addresses(IList<DTOAddress> aList)
        {
            if (This.IsNull())
                This = new List<Address>();

            if (aList.IsNotNull())
                This.AddRange(aList.Select(l => (Address)l));
        }

        /// <summary>
        /// Insert an Address and make it primary
        /// </summary>
        /// <param name="aAddress">Address to add as primary</param>
        public Addresses SetPrimary(Address aAddress)
        {
            This.Add(aAddress);
            Primary = aAddress.Description;
            return this;
        }

        public bool IsPrimary(string Description) => Primary.Equals(Description);

        /// <summary>
        /// List all addresses
        /// </summary>
        /// <returns>List of Address objects</returns>
        public IList<Address> List() => This;

        /// <summary>
        /// Checks if there are any registry
        /// </summary>
        /// <returns><see langword="true"/> or <see langword="false"/></returns>
        public bool Any() => (bool)(This?.Any());

        /// <summary>
        /// Get primary Address
        /// </summary>
        /// <returns>Primary Address object from list</returns>
        public Address GetPrimary() => GetAddress(Primary);

        /// <summary>
        /// Get Address by description
        /// </summary>
        /// <param name="aDescription">Address Description</param>
        /// <returns>Address object from list found by description</returns>
        public Address GetAddress(string aDescription) => This.FirstOrDefault(e => e.Description == aDescription);

        /// <summary>
        /// Make existing address as primary
        /// </summary>
        /// <param name="aAddressDescription">Address description</param>
        /// <returns>Self for Chain Call</returns>
        public Addresses MakePrimary(string aAddressDescription)
        {
            if (aAddressDescription.IsNothing())
                return this;

            Address address = GetAddress(aAddressDescription);

            if (address.IsNull())
                throw new OperationCanceledException(ApplicationStatusMessage.AddressNotFound);

            Primary = address.Description;

            return this;
        }

        /// <summary>
        /// Includes an Address in list
        /// Address cannot have duplicated Description
        /// </summary>
        /// <param name="aAddress">Address class to be added to list</param>
        /// <returns>Self for Chain Call</returns>
        public Addresses Add(Address aAddress)
        {
            Address address = GetAddress(aAddress.Description);

            if (address.IsNotNull())
                throw new OperationCanceledException(ApplicationStatusMessage.AddressAlreadyExists);

            This.Add(aAddress);

            return this;
        }

        /// <summary>
        /// Modify an Address in list. It is found by description
        /// </summary>
        /// <param name="aAddress">Address class to be added to list</param>
        /// <returns>Self for Chain Call</returns>
        public Addresses Modify(Address aAddress)
        {
            Address address = GetAddress(aAddress.Description);

            if (address.IsNull())
                throw new OperationCanceledException(ApplicationStatusMessage.AddressNotFound);

            This.Remove(address);
            This.Add(aAddress);

            return this;
        }

        /// <summary>
        /// Removes an address from list by Description
        /// </summary>
        /// <param name="aDescription">Address description to find</param>
        /// <returns>Self for Chain Call</returns>
        public Addresses Remove(string aDescription)
        {
            Address address = GetAddress(aDescription);

            if (address.IsNotNull())
                This.Remove(address);

            return this;
        }
    }
}
