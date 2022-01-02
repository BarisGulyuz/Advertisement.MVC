using AdvertisementApp_Bussiness.BaseResponseType;
using AdvertisementApp_Bussiness.Enums;
using AdvertisementApp_DTOs.AdvertisementUserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_Bussiness.Abstract
{
    public interface IAdvertisementUserService
    {
        Task<DataResponse<AdvertisementUserCreateDto>> CreateAsync(AdvertisementUserCreateDto advertisementUserCreateDto);
        Task<List<AdvertisementUserListDto>> GetListAsync(AdvertisementUserStatusType statusType);
        Task SetStatusAsync(int advertisementId, AdvertisementUserStatusType advertisementuserStatusType);
        Task<List<AdvertisementUserListDto>> GetListByAdvertisementAsync(int advertisementId, AdvertisementUserStatusType advertisementuserStatusType);
        Task<List<AdvertisementUserListDto>> GetListByUsertAsync(int userId);
    }
}
