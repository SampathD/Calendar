
namespace Octet.Calendar.Enums
{
    /// <summary>
    /// Status codes for the response message
    /// </summary>
    public enum StatusCode
    {
        #region Success Codes : 1000-4999

        /// <summary>
        /// General success code
        /// </summary>
        Success = 1000,

        #endregion


        #region Error Codes 5000 - 9999

        /// <summary>
        /// General error code.
        /// </summary>
        Error = 5000,

        /// <summary>
        /// Invalid page number.
        /// </summary>
        InvalidPageNumber = 5001,

        /// <summary>
        /// Invalid page size.
        /// </summary>
        InvalidPageSize = 5002

        #endregion
    }
}
