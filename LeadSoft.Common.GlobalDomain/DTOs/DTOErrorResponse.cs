using LeadSoft.Common.Library.EnvUtils;
using LeadSoft.Common.Library.Exceptions;

using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.Serialization;

namespace LeadSoft.Common.GlobalDomain.DTOs
{

    [Serializable]
    [DataContract]
    public partial class DTOErrorResponse
    {
        [DataMember]
        public HttpStatusCode Status { get; set; }

        [DataMember]
        public IEnumerable<string> Messages { get; set; } = new List<string>();

        [DataMember]
        public int ErrorCount { get => Messages.Count(); }

        [DataMember]
        [DataType(DataType.DateTime)]
        public DateTime At { get => DateTime.UtcNow; }

        public DTOErrorResponse(HttpStatusCode aStatus, params string[] aMessages)
        {
            Status = aStatus;
            Messages = aMessages;
        }

        public void HandleException(Exception exception)
        {
            if (exception is AppException appException)
            {
                Status = appException.Status;
                Messages = appException.Messages;
            }
            else if (EnvUtil.IsDevelopment())
                Messages =
                [
                    exception?.Message ?? string.Empty,
                    exception?.StackTrace ?? string.Empty
                ];
        }
    }
}
