using AdvertisementApp_Bussiness.ResponseType;

namespace AdvertisementApp_Bussiness.BaseResponseType
{
    public interface IResponse
    {
        string Message { get; set; }
        ResponType ResponType { get; set; }
    }
}
