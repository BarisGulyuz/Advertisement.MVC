using AdvertisementApp_Bussiness.ResponseType;
using System.Collections.Generic;

namespace AdvertisementApp_Bussiness.BaseResponseType
{
    public class DataResponse<T> : Response, IDataResponse<T>
    {
        public T Data { get; set; }
        public List<CustomValidationError> ValidationErrors { get; set; }
        public DataResponse(ResponType respon, string message) : base(respon, message)
        {

        }

        public DataResponse(ResponType responType, T data) : base(responType)
        {
            Data = data;
        }

        public DataResponse(T data, List<CustomValidationError> errors) : base(ResponType.ValidationError)
        {
            Data = data;
            ValidationErrors = errors;
        }
    }
}
