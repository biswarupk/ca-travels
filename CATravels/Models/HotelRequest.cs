namespace CATravels.Models
{
    using System.ComponentModel.DataAnnotations;
    public class HotelSearchRequest
    {
        /// <summary>
        /// Holds the destination id where the property needs to searched
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Please select destination")]
        public int DestinationId { get; set; }
        /// <summary>
        /// stores the number of nights of stay
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a non-zero positve integer")]
        public int Nights { get; set; }
    }
}
