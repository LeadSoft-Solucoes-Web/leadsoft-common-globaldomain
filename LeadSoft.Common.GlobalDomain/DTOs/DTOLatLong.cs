using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    /// <summary>
    /// Represents a data transfer object for geographical coordinates, specifically latitude and longitude.
    /// </summary>
    /// <remarks>This class is used to encapsulate latitude and longitude values, providing a simple way to
    /// pass geographical coordinates between different layers of an application. It is marked as serializable and can
    /// be used in data contracts for services.</remarks>
    /// <param name="lat"></param>
    /// <param name="lng"></param>
    [Serializable]
    [DataContract]
    public partial class DTOLatLong(double lat = 0, double lng = 0)
    {
        /// <summary>
        /// Gets or sets the latitude coordinate.
        /// </summary>
        [DataMember]
        public virtual double Latidute { get; set; } = lat is < -90 or > 90 ? lat : 0;

        /// <summary>
        /// Gets or sets the longitude coordinate.
        /// </summary>
        [DataMember]
        public virtual double Longidute { get; set; } = lng is < -180 or > 180 ? lng : 0;
    }
}
