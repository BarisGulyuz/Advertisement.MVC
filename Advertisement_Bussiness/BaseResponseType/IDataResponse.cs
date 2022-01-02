using System.Collections.Generic;

namespace AdvertisementApp_Bussiness.BaseResponseType
{
    public interface IDataResponse<T> : IResponse
    {
         T Data { get; set; }
         List<CustomValidationError> ValidationErrors { get; set; }
    }
}
