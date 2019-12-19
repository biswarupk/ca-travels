namespace CatTravels.Repository.Abstract
{
    using CatTravels.ValueObject;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IHotelRepository
    {
        Task<List<FindHotelResponseModel>> GetHotelDetailsList(int destinationId, int nights);
    }
}
