using LeadSoft.Common.GlobalDomain.DTOs.Pricing;
using LeadSoft.Common.Library;
using LeadSoft.Common.Library.Extensions;

namespace LeadSoft.Common.GlobalDomain.Entities.Pricing
{
    /// <summary>
    /// Prices class
    /// </summary>
    public partial class Prices
    {
        /// <summary>
        /// Constructor builds this list
        /// </summary>
        public Prices()
        {
            This = new List<Price>();
        }

        /// <summary>
        /// Price list based constructor
        /// </summary>
        /// <param name="aPrices">Prices array</param>
        public Prices(params Price[] aPrices)
        {
            This = aPrices.ToList();
        }

        /// <summary>
        /// Create Prices and set list from informed one
        /// </summary>
        /// <param name="aList">List of DTOPrice</param>
        public Prices(IList<DTOPrice> aList)
        {
            if (This.IsNull())
                This = new List<Price>();

            if (aList.IsNotNull())
                This.AddRange(aList.Select(l => (Price)l));
        }

        /// <summary>
        /// Gets a price by vicency
        /// </summary>
        /// <param name="aVigency">Optional Vigency. If null, brings current</param>
        /// <returns>Price object</returns>
        public Price GetValue(DateTime? aVigency = null)
            => aVigency.HasValue ? This.FirstOrDefault(p => p.Vigency == aVigency.Value)
                                 : This.Any() ? This.Count == 1 ? This[0]
                                              : This.Where(t => t.GetDistanceFromNow() > 0)
                                                    .OrderBy(t => t.GetDistanceFromNow()).First() : Price.Zero();

        /// <summary>
        /// List all price
        /// </summary>
        /// <returns>List of Price objects</returns>
        public IList<Price> List() => This.OrderByDescending(t => t.Vigency).ToList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aTake"></param>
        /// <returns></returns>
        public IList<Price> Last(int aTake = 5)
            => This.OrderByDescending(t => t.Vigency)
                   .Skip(0)
                   .Take(aTake)
                   .ToList();

        /// <summary>
        /// Includes a price in list
        /// Price vigency cannot be duplicated
        /// </summary>
        /// <param name="aPrice">Price to be added</param>
        /// <returns>Self for Chain Call</returns>
        public Prices Add(Price aPrice)
        {
            This.Add(aPrice);

            return this;
        }

        /// <summary>
        /// Includes a price in list
        /// Price vigency cannot be duplicated
        /// </summary>
        /// <param name="aValue">Price value to be added</param>
        /// <param name="aCost">Optional Cost value</param>
        /// <returns>Self for Chain Call</returns>
        public Prices Add(decimal aValue, decimal aCost = 0)
        {
            if (This.Any(d => d.Vigency == DateTime.UtcNow.Truncate(TimeSpan.FromSeconds(0))))
                throw new OperationCanceledException(ApplicationStatusMessage.DuplicatedVigency);

            This.Add(new(aValue, aCost));

            return this;
        }

        /// <summary>
        /// Includes a Double price in list
        /// Price vigency cannot be duplicated
        /// </summary>
        /// <param name="aValue">Price Double value to be added</param>
        /// <param name="aCost">Optional Cost Double value</param>
        /// <returns>Self for Chain Call</returns>
        public Prices Add(double aValue, double aCost = 0)
            => Add((decimal)aValue, (decimal)aCost);

        /// <summary>
        /// Includes a price on informed vigency in list
        /// Price vigency cannot be duplicated
        /// </summary>
        /// <param name="aVigency">Vigency</param>
        /// <param name="aValue">Price value to be added</param>
        /// <param name="aCost">Optional Cost value</param>
        /// <returns>Self for Chain Call</returns>
        public Prices Add(DateTime aVigency, decimal aValue, decimal aCost = 0)
        {
            if (This.Any(d => d.Vigency == aVigency.Truncate(TimeSpan.FromSeconds(0))))
                throw new OperationCanceledException(ApplicationStatusMessage.DuplicatedVigency);

            This.Add(new(aVigency, aValue, aCost));

            return this;
        }

        /// <summary>
        /// Includes a double price on informed vigency in list
        /// Price vigency cannot be duplicated
        /// </summary>
        /// <param name="aVigency">Vigency</param>
        /// <param name="aValue">Price double value to be added</param>
        /// <param name="aCost">Optional Cost double value</param>
        /// <returns>Self for Chain Call</returns>
        public Prices Add(DateTime aVigency, double aValue, double aCost = 0)
            => Add(aVigency, (decimal)aValue, (decimal)aCost);

        /// <summary>
        /// Removes a price from list by Vigency
        /// </summary>
        /// <param name="aVigency">Price type to be removed from list</param>
        /// <returns>Self for Chain Call</returns>
        public Prices Remove(DateTime aVigency)
        {
            Price price = This.FirstOrDefault(d => d.Vigency == aVigency);

            if (price.IsNotNull())
                This.Remove(price);

            return this;
        }
    }

}
