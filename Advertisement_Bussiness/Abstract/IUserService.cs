using AdvertisementApp.Entities.Concrete;
using AdvertisementApp_Bussiness.BaseResponseType;
using AdvertisementApp_Bussiness.Enums;
using AdvertisementApp_DTOs.RoleDto;
using AdvertisementApp_DTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_Bussiness.Abstract
{
    public interface IUserService : IService<UserCreateDto, UserUpdateDto, UserListDto, User>
    {
        Task<DataResponse<UserCreateDto>> CreateUserRoleAsync(UserCreateDto userCreateDto, int roleId);
        Task<DataResponse<UserListDto>> CheckUser(UserLoginDto userLoginDto);
        Task<DataResponse<List<RoleListDto>>> GetRolesAsync(int userId);
      
    }
}
