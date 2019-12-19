namespace CatTravels.ValueObject
{
    public class HotelDetails
    {
        /// <summary>
        /// Holds the board Type data (No Meal,Half Board,Full Board)
        /// </summary>
        public string BoardType { get; set; }
        /// <summary>
        /// Holds the hotel name
        /// </summary>
        public string HotelName { get; set; }
        /// <summary>
        /// Holds the rate type informartion (Per Night,Stay)
        /// </summary>
        public string RateType { get; set; }
        /// <summary>
        /// Holds the base price for the hotel
        /// </summary>
        public double BasePrice { get; set; }
        /// <summary>
        /// Holds the calculated price on basis of rate value and number of nights of stay
        /// </summary>
        public double ActualPrice { get; set; }
    }
}
