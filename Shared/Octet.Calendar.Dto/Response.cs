
using Octet.Calendar.Enums;

namespace Octet.Calendar.Dto
{
    public class Response<T>
    {
        public Response() { }

        public Response(StatusCode statusCode, string message, T data)
        {
            StatusCode = statusCode;
            Message = message;
            this.Data = data;
        }

        /// <summary>
        /// Gets or Sets StatusCode of the Response.
        /// </summary>
        public StatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or Sets StatusMessage of the Response.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or Sets Result of the Response.
        /// </summary>
        public T Data { get; set; }
    }
}
