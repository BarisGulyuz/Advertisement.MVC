using AdvertisementApp.Entities.Concrete;
using AdvertisementApp_DTOs.AdvertisementUserStatusDto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_Bussiness.Mappings.AutoMapper
{
   public class AdvertisementUserStatusProfile : Profile
    {
        public AdvertisementUserStatusProfile()
        {
            CreateMap<AdvertisementUserStatusListDto, AdvertisementUserStatus>().ReverseMap();
        }
    }
}
