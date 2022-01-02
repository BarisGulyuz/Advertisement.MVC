using AdvertisementApp.Entities.Concrete;
using AdvertisementApp_DTOs.AdvertisementUserDto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_Bussiness.Mappings.AutoMapper
{
    public class AdvertisementUserProfile : Profile
    {
        public AdvertisementUserProfile()
        {
            CreateMap<AdvertisementUser, AdvertisementUserCreateDto>().ReverseMap();
            CreateMap<AdvertisementUserListDto, AdvertisementUser>().ReverseMap();
            CreateMap<AdvertisementUser, AdvertisementUserUpdateDto>().ReverseMap();
        }
    }
}
