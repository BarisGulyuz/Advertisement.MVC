using AdvertisementApp.UI.Models.User;
using AdvertisementApp_DTOs.UserDto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementApp.UI.Mappings.AutoMapper
{
    public class UserCreateModelProfile: Profile
    {
        public UserCreateModelProfile()
        {
            CreateMap<UserCreateModel, UserCreateDto>().ReverseMap();
        }
    }
}
