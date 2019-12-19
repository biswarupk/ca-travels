namespace CatTravels.ValueObject
{
    public class Hotel
    {
        /// <summary>
        /// Holds the property Id data
        /// </summary>
        public int PropertyID { get; set; }
        /// <summary>
        /// Holds the Hotel Name or Property Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Holds the Geo Id for the property
        /// </summary>
        public int GeoId { get; set; }
        /// <summary>
        /// Holds the rating data for the hotel
        /// </summary>
        public int Rating { get; set; }
    }
}
