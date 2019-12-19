namespace CatTravels.Repository.Concrete
{
    using Newtonsoft.Json;
    using Repository.Abstract;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using CatTravels.ValueObject;
    public class HotelRepository : IHotelRepository
    {
        private string apiUrl;
        private readonly string authCode;
        public HotelRepository(string apiUrl, string authCode)
        {
            this.apiUrl = apiUrl;
            this.authCode = authCode;
        }

        /// <summary>
        /// Get the list of hotel from the end point that is stored in apiUrl with the querystring parameters destinationId,nights and authCode. 
        /// </summary>
        /// <param name="apiUrl">Returns API url with parameters destinationId,nights and auth code</param>
        /// <returns>Returns list of FindHotelResponseModel object from the api endpoint and returned json result that is mapped to FindHotelResponseModel object</returns>
        public async Task<List<FindHotelResponseModel>> GetHotelDetailsList(int destinationId, int nights)
        {
            var apiResponse = string.Empty;
            /// Calling the API through HttpClient
            using (var httpClient = new HttpClient())
            {
                apiUrl += $"findBargain?destinationId={destinationId}&nights={nights}&code={authCode}";
                using (var response = await httpClient.GetAsync(apiUrl))
                {
                    //get response from the endpoint in form of JSON string
                    apiResponse = await response.Content.ReadAsStringAsync();

                    //deserialize the json string to FindHotelResponseModel data object
                    var result = JsonConvert.DeserializeObject<List<FindHotelResponseModel>>(apiResponse);
                    return result;
                }
            }
        }
    }
}
