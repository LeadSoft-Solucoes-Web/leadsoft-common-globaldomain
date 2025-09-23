using LeadSoft.Common.Library.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    /// <summary>
    /// Collection base abstract class means that this class contains basic properties for all entity that will be saved as Collection on database.
    /// </summary>
    public abstract partial class CollectionsBase
    {
        /// <summary>
        /// RavenDB TimeSerie representative type to easy read TimeSeries feature in entity runtime.
        /// </summary>       
        /// <see cref="https://ravendb.net/docs/article-page/7.0/csharp/studio/database/document-extensions/time-series"/>
        public class TimeSerie
        {
            /// <summary>
            /// TimeSerie constructor to create a new TimeSerie without Id.
            /// </summary>
            public TimeSerie()
            {
            }

            /// <summary>
            /// TimeSerie constructor to create a new TimeSerie with a specific Id.
            /// </summary>
            /// <param name="aId">Document Id relation</param>
            /// <param name="aIsIncremental">Defines the type of TimeSeries. False by default.</param>
            public TimeSerie(Guid aId, bool aIsIncremental = false)
            {
                Id = aId;
                IsIncremental = aIsIncremental;
            }

            private const string _IncrementalPrefix = "INC:";

            [NotMapped]
            public Guid Id { get; private set; } = System.Guid.Empty;

            [NotMapped]
            public bool IsIncremental { get; private set; }

            [NotMapped]
            public string SeriesName { get; private set; } = string.Empty;

            [NotMapped]
            public DateTime Timestamp { get; private set; } = DateTime.UtcNow;

            [NotMapped]
            public string Tag { get; private set; } = string.Empty;

            [NotMapped]
            public IDictionary<string, double> Values { get; private set; } = new Dictionary<string, double>();

            #region [ Getters and Setters ]

            ///<summary>
            /// Sets the Name for this TimeSerie.
            ///</summary>            
            ///<remarks>
            /// Follows the naming convention on RavenDB documentation
            /// </remarks>
            /// <see cref="https://ravendb.net/docs/article-page/7.0/csharp/studio/database/document-extensions/time-series#create-new-time-series-by-creating-its-first-entry"/>
            public TimeSerie SetName(string aName)
            {
                string name = aName.IsNothing()
                                ? DateTime.UtcNow.Ticks.ToString()
                                : aName.RemoveDiactricsAndSpaces().ToTitleCase();

                SeriesName = IsIncremental
                                ? $"{_IncrementalPrefix}{name}"
                                : name.Replace(_IncrementalPrefix, string.Empty);
                return this;
            }

            #endregion
        }
    }
}
