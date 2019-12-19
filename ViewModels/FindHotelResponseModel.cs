namespace CatTravels.ValueObject
{
    using System.Collections.Generic;
    public class FindHotelResponseModel
    {
        /// <summary>
        /// Holds the Hotels details data
        /// </summary>
        public Hotel Hotel { get; set; }
        /// <summary>
        /// Holds the list of Rate Object
        /// </summary>
        public List<Rate> Rates { get; set; }
    }
    
}
