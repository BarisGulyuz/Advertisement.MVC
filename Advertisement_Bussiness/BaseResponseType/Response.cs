using AdvertisementApp_Bussiness.BaseResponseType;

namespace AdvertisementApp_Bussiness.ResponseType
{
    public class Response : IResponse
    {
        public Response(ResponType responType)
        {
            ResponType = responType;
        }

        public Response(ResponType responType, string message)
        {
            ResponType = responType;
            Message = message;
        }

        public string Message { get; set; }
        public ResponType ResponType { get; set; }
    }

    public enum ResponType
    {
        Success,
        ValidationError,
        NotFound, 
        Error
    }
}
