using LeadSoft.Common.GlobalDomain.Entities;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    public partial class DTOLatLong
    {
        /// <summary>
        /// Converts a string representation of latitude and longitude into a <see cref="DTOLatLong"/> object.
        /// </summary>
        /// <param name="latlong">A string containing the latitude and longitude, typically in a comma-separated format.</param>
        public static implicit operator DTOLatLong(string latlong)
            => FromString(latlong);

        /// <summary>
        /// Converts a <see cref="DTOLatLong"/> instance to a <see cref="LatLong"/> instance.
        /// </summary>
        /// <param name="dto">The <see cref="DTOLatLong"/> object to convert. Must not be null.</param>
        public static implicit operator LatLong(DTOLatLong dto)
            => new(dto.Latidute, dto.Longidute);

        /// <summary>
        /// Converts a <see cref="LatLong"/> instance to a <see cref="DTOLatLong"/> instance.
        /// </summary>
        /// <param name="latlong">The <see cref="LatLong"/> instance to convert. Must not be null.</param>
        public static implicit operator DTOLatLong(LatLong latlong)
            => new(latlong.Latidute, latlong.Longidute);
    }
}
