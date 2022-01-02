using AdvertisementApp.Entities.Concrete;
using AdvertisementApp_DTOs.RoleDto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_Bussiness.Mappings.AutoMapper
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleListDto>().ReverseMap();
            CreateMap<Role, RoleCreateDto>();
            CreateMap<Role, RoleUpdateDto>();
        }
    }
}
