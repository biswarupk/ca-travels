namespace CatTravels.ValueObject
{
    using System.Collections.Generic;
    public class FindBargainResponseMessage
    {
        /// <summary>
        /// Holds the list of HotelDetails Object
        /// </summary>
        public List<HotelDetails> HotelDetails { get; set; }
        public FindBargainResponseMessage()
        {
            HotelDetails = new List<HotelDetails>();
        }
    }
}
