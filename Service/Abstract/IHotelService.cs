namespace CatTravels.Service.Abstract
{
    using System.Threading.Tasks;
    using CatTravels.ValueObject;
    public interface IHotelService
    {
        Task<FindBargainResponseMessage> GetHotelDetailsList(int destinationId, int nights);
    }
}
