namespace CA_UnitTest.TestData
{
    using CatTravels.ValueObject;
    public class HotelDetailsList_MockData
    {
        /// <summary>
        /// Stores the mockData that needs to be returned when called from GetHotelDetailsList(int,int) in mock environment.
        /// </summary>
        public FindBargainResponseMessage MockData { get; private set; }
        public HotelDetailsList_MockData()
        {
            MockData = new FindBargainResponseMessage();
            MockData.HotelDetails.Add(new HotelDetails()
            {
                HotelName = "Hotel2",
                ActualPrice = 19.00,
                BasePrice = 10,
                BoardType = "Full Meals",
                RateType = "Pernight"
            });
            MockData.HotelDetails.Add(new HotelDetails()
            {
                HotelName = "Hotel3",
                ActualPrice = 20.00,
                BasePrice = 10,
                BoardType = "Full Meals",
                RateType = "Pernight"
            });
            MockData.HotelDetails.Add(new HotelDetails()
            {
                HotelName = "Hotel4",
                ActualPrice = 10.00,
                BasePrice = 10,
                BoardType = "Full Meals",
                RateType = "Pernight"
            });
        }
    }
}
