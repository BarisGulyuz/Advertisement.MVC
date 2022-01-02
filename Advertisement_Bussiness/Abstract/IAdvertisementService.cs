using AdvertisementApp.Entities.Concrete;
using AdvertisementApp_Bussiness.BaseResponseType;
using AdvertisementApp_DTOs.AdvertisementDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_Bussiness.Abstract
{
   public interface IAdvertisementService : IService<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>
    {
        Task<IDataResponse<List<AdvertisementListDto>>> GetActiveAdvertisements();
        Task<IDataResponse<List<AdvertisementListDto>>> GetPassiveAdvertisements();
    }
}
