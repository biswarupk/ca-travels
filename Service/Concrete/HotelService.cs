namespace CatTravels.Service.Concrete
{
    using Repository.Abstract;
    using CatTravels.Service.Abstract;
    using System.Linq;
    using System.Threading.Tasks;
    using CatTravels.ValueObject;
    public class HotelService : IHotelService
    {
        private IHotelRepository apiRepository;
        public HotelService(IHotelRepository apiRepository)
        {
            this.apiRepository = apiRepository;
        }

        /// <summary>
        /// Get the list of hotel from the end point that is stored to apiUrl. Also this method recieves number of nights data in nights variable to calculate the actual price.
        /// </summary>
        /// <param name="nights">Number of nights of occupancy</param>
        /// <param name="ApiUrl">APi url with the parameters destinationId,nights and auth code</param>
        /// <returns>Returns FindBargainResponseMessage object that consist of search results returned from api with respect to destinationId and nights</returns>
        public async Task<FindBargainResponseMessage> GetHotelDetailsList(int destinationId, int nights)
        {
            var result = await this.apiRepository.GetHotelDetailsList(destinationId, nights);
            FindBargainResponseMessage responseMessage = new FindBargainResponseMessage();
            if (result != null && result.Count > 0)
            {
                var data = (from hotel in result
                            from rate in hotel.Rates
                            where hotel.Rates.Count > 0 && hotel.Rates != null
                            select new HotelDetails
                            {
                                BoardType = rate.BoardType,
                                HotelName = hotel.Hotel.Name,
                                BasePrice = rate.Value,
                                ActualPrice = rate.RateType == "PerNight" ? rate.Value * nights : rate.Value,
                                RateType = rate.RateType
                            }).ToList();
                responseMessage.HotelDetails = data;
            }
            return responseMessage;
        }
    }
}
