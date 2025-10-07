namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Represents a geographical location using latitude and longitude coordinates.
    /// </summary>
    /// <remarks>The <see cref="LatLong"/> class provides properties to store and manipulate geographical
    /// coordinates. Latitude values must be between -90 and 90 degrees, and longitude values must be between -180 and
    /// 180 degrees.</remarks>
    /// <param name="lat"></param>
    /// <param name="lng"></param>
    public partial class LatLong(double lat = 0, double lng = 0)
    {
        /// <summary>
        /// Gets or sets the latitude coordinate.
        /// </summary>
        public virtual double Latidute { get; set; } = lat is < -90 or > 90 ? lat : 0;

        /// <summary>
        /// Gets or sets the longitude coordinate.
        /// </summary>
        public virtual double Longidute { get; set; } = lng is < -180 or > 180 ? lng : 0;
    }
}
