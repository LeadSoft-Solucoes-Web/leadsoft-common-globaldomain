using LeadSoft.Common.Library;
using LeadSoft.Common.Library.Extensions;
using System.Text.RegularExpressions;
using static LeadSoft.Common.GlobalDomain.Entities.Enums;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Phone contact methods
    /// </summary>
    public partial class PhoneContact
    {
        /// <summary>
        /// Base Constructor requires a Contact type
        /// </summary>
        /// <param name="aContactType">Contact type enum</param>
        /// <param name="aDDD">DDD number</param>
        /// <param name="aNumber">Phone number</param>
        public PhoneContact(ContactType aContactType, string aDDD, string aNumber) : base(aContactType)
        {
            DDD = aDDD.OnlyNumeric();
            Number = aNumber.OnlyNumeric();
        }

        /// <summary>
        /// Base Constructor requires a Contact type
        /// </summary>
        /// <param name="aContactType">Contact type enum</param>
        /// <param name="aNumber">Phone number (ddnnnnnnnnn)</param>
        public PhoneContact(ContactType aContactType, string aNumber, bool aHaltOnError = true) : base(aContactType)
        {
            if (!aNumber.Length.IsWithin(10, 11))
                if (aHaltOnError)
                    throw new OperationCanceledException($"{ApplicationStatusMessage.InvalidPhoneNumber} -> {aNumber}");
                else
                {
                    DDD = "??";
                    Number = aNumber;
                    return;
                }

            DDD = aNumber.OnlyNumeric()[..2];
            Number = aNumber.OnlyNumeric()[2..];
        }

        /// <summary>
        /// Sets DDI number
        /// </summary>
        /// <param name="aDDI">DDI Number</param>
        public PhoneContact SetDDI(string aDDI)
        {
            if (!aDDI.IsNothing())
                DDI = aDDI.OnlyNumeric();

            return this;
        }

        /// <summary>
        /// Gets phone number, DDI and DDD in a simple format
        /// </summary>
        /// <returns>5511978969876</returns>
        public string GetPlain()
        {
            return string.Concat(DDI, DDD, Number);
        }

        /// <summary>
        /// Gets phone number, DDI and DDD on standard format
        /// </summary>
        /// <returns>+5511978969876</returns>
        public string GetStandard()
        {
            return string.Concat("+", DDI, DDD, Number);
        }

        /// <summary>
        /// Gets phone number and DDD in a pretty format
        /// </summary>
        /// <returns>(11) 9-7896-9876</returns>
        public string GetPretty()
            => string.Format("{0:(##) #####-####}", string.Concat(DDD, Number));

        /// <summary>
        /// Mask phone function
        /// </summary>
        /// <param name="aPhone"></param>
        /// <returns></returns>
        public static string MaskPhone(string aPhone)
        {
            string clearedNumber = aPhone.OnlyNumeric();

            if (clearedNumber.Length == 10)
                return Convert.ToDouble(clearedNumber).ToString("(##) ####-####");
            else
                return Convert.ToDouble(clearedNumber).ToString("(##) #####-####");
        }

        /// <summary>
        /// Validate Phone Contact. Pattern: (xx) xxxxx-xxxx
        /// </summary>
        public static bool IsValidPhone(string phone)
        {
            Regex regex = new(@"^\(?[1-9]{2}\)? ?(?:[2-9]|9[1-9])[0-9]{3}\-?[0-9]{4}$");//(@"^\([1-9]{2}\) (?:[2-9]|9[1-9])[0-9]{3}\-[0-9]{4}$");

            try
            {
                return regex.IsMatch(phone.Trim());
            }
            catch
            {
                return false;
            }
        }
    }
}
