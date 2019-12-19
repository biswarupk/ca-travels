namespace CatTravels.ValueObject
{
    public class Rate
    {
        /// <summary>
        /// Holds the rate type informartion (Per Night,Stay)
        /// </summary>
        public string RateType { get; set; }
        /// <summary>
        /// Holds the board Type data (No Meal,Half Board,Full Board)
        /// </summary>
        public string BoardType { get; set; }
        /// <summary>
        /// Holds the base value as per the rate type of the property
        /// </summary>
        public double Value { get; set; }
    }
}
