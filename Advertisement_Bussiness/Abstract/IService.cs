using AdvertisementApp.Entities.Concrete;
using AdvertisementApp_Bussiness.BaseResponseType;
using AdvertisementApp_DTOs.Intefaces;
using AdvertisementApp_DTOs.Intefaces.ServicesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_Bussiness.Abstract
{
    public interface IService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, IDto, new ()
        where UpdateDto : class, IUpdateDto, new ()
        where ListDto : class, IDto, new ()
        where T : BaseEntity
    {
        Task<IDataResponse<CreateDto>> CreateAsync(CreateDto createDto);
        Task<IDataResponse<UpdateDto>> UpdateAsync(UpdateDto updateDto);
        Task<IDataResponse<IDto>> GetByIdAsync<IDto>(int id);
        Task<IResponse> RemoveAsync(int id);
        Task<IDataResponse<List<ListDto>>> GetAllAsync();

    }
}
