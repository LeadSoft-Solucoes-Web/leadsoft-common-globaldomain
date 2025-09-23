using LeadSoft.Common.Library.Extensions;

using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{

    [Serializable]
    [DataContract]
    public class DTOList<T> : List<T> where T : DTOResponse
    {
        /// <summary>
        /// Items Count
        /// </summary>
        [DataMember]
        public int RecordCount { get => Count; }

        public DTOList(IEnumerable<T> aList)
        {
            if (!aList.IsNull())
                AddRange(aList);
        }

        public DTOList(IList<T> aList)
        {
            if (!aList.IsNull())
                AddRange(aList);
        }

        public DTOList(T aT)
        {
            Add(aT);
        }

        public DTOList()
        {
        }

        public bool IsEmpty() => Count <= 0;
    }
}
