using AdvertisementApp.Entities.Concrete;
using AdvertisementApp_DTOs.Intefaces.ServicesDto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_Bussiness.Mappings.AutoMapper
{
    public class ServicesProfile : Profile
    {
        public ServicesProfile()
        {
            CreateMap<ServicesCreateDto, Services>().ReverseMap();
            CreateMap<ServicesListDto, Services>().ReverseMap();
            CreateMap<ServicesUpdateDto, Services>().ReverseMap();
        }
    }
}
