using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.Entities.Pricing
{
    /// <summary>
    /// Price class methods
    /// </summary>
    public partial class Price
    {
        /// <summary>
        /// Base constructor
        /// </summary>
        public Price()
        {
        }

        /// <summary>
        /// Double Value based constructor overload
        /// </summary>
        /// <param name="aValue">Double Price value</param>
        /// <param name="aCost">Double Cost value</param>
        public Price(double aValue, double aCost = 0) : this((decimal)aValue, (decimal)aCost)
        {
        }

        /// <summary>
        /// Double Value based constructor with vigency overload
        /// </summary>
        /// <param name="aVigency"></param>
        /// <param name="aValue"></param>
        /// <param name="aCost"></param>
        public Price(DateTime aVigency, double aValue, double aCost = 0) : this(aVigency, (decimal)aValue, (decimal)aCost)
        {
        }

        /// <summary>
        /// Value based constructor with vigency based constructor
        /// </summary>
        /// <param name="aValue">Price value</param>
        /// <param name="aCost">Cost value</param>
        public Price(decimal aValue, decimal aCost = 0)
        {
            Vigency = DateTime.UtcNow.Truncate(TimeSpan.FromMinutes(1));
            Value = Math.Abs(aValue);
            Cost = Math.Abs(aCost);
        }

        /// <summary>
        /// Value based constructor with vigency
        /// </summary>
        /// <param name="aVigency">Price vigency</param>
        /// <param name="aValue">Price value</param>
        /// <param name="aCost">Cost value</param>
        public Price(DateTime aVigency, decimal aValue, decimal aCost = 0)
        {
            Vigency = aVigency.Truncate(TimeSpan.FromMinutes(1));
            Value = Math.Abs(aValue);
            Cost = Math.Abs(aCost);
        }

        /// <summary>
        /// Method available to set Double cost to price overload
        /// </summary>
        /// <param name="aCost">Double Cost value</param>
        /// <returns>This for chain calls.</returns>
        public Price SetCost(double aCost) => SetCost((decimal)aCost);

        /// <summary>
        /// Method available to set cost to price
        /// </summary>
        /// <param name="aCost">Cost value</param>
        /// <returns>This for chain calls.</returns>
        public Price SetCost(decimal aCost)
        {
            Cost = Math.Abs(aCost);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double GetDistanceFromNow() => (DateTime.UtcNow - Vigency).TotalSeconds;

        /// <summary>
        /// Get zero price Value
        /// </summary>
        /// <returns></returns>
        public static Price Zero()
        => new()
        {
            Vigency = DateTime.UtcNow,
            Value = 0,
            Cost = 0
        };
    }

}
