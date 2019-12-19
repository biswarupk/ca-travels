namespace CATravels.Models
{
    public class ErrorViewModel
    {
        /// <summary>
        /// Stores the request id of the exception
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// Stores boolean value whether RequestId stores empty value or null value
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        /// <summary>
        /// Store the exception message
        /// </summary>
        public string ExceptionMessage { get; set; }
    }
}