using LeadSoft.Common.Library.Extensions;
using System.Globalization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{
    public partial class DTOLatLong
    {
        /// <summary>
        /// Returns a string representation of the coordinates.
        /// </summary>
        /// <returns>A string in the format "Latitude,Longitude" representing the coordinates.</returns>
        public string ToStr()
            => $"{Latidute},{Longidute}";

        /// <summary>
        /// Creates a new instance of <see cref="DTOLatLong"/> from a string representation of latitude and longitude.
        /// </summary>
        /// <remarks>The method expects the input string to be in the format "latitude,longitude" with
        /// optional whitespace. It uses the invariant culture for parsing the numeric values.</remarks>
        /// <param name="latlong">A string containing the latitude and longitude values separated by a comma.  The latitude must be between
        /// -90 and 90, and the longitude must be between -180 and 180.</param>
        /// <returns>A <see cref="DTOLatLong"/> object initialized with the parsed latitude and longitude values. Returns a
        /// default <see cref="DTOLatLong"/> if the input string is null, empty, or cannot be parsed into valid latitude
        /// and longitude values.</returns>
        public static DTOLatLong FromString(string latlong)
        {
            if (latlong.IsNothing())
                return new();

            latlong = latlong.Trim();

            string[] lat_long = latlong.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            if (lat_long.Length != 2)
                return new();

            if (!double.TryParse(lat_long[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double lat) ||
                !double.TryParse(lat_long[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double lng))
                return new();

            if (lat is < -90 or > 90 || lng is < -180 or > 180)
                return new();

            return new(lat_long[0].ToDoubleOrDefault(), lat_long[1].ToDoubleOrDefault());
        }
    }
}
