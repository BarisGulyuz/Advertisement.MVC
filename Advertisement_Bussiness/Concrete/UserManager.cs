using AdvertisementApp.Entities.Concrete;
using AdvertisementApp_Bussiness.Abstract;
using AdvertisementApp_Bussiness.BaseResponseType;
using AdvertisementApp_Bussiness.Extensions;
using AdvertisementApp_DataAccess.Abstract;
using AdvertisementApp_DTOs.RoleDto;
using AdvertisementApp_DTOs.UserDto;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_Bussiness.Concrete
{
    public class UserManager : GenericManager<UserCreateDto, UserUpdateDto, UserListDto, User>, IUserService
    {
        private readonly IUoW _uoW;
        private readonly IMapper _mapper;
        private readonly IValidator<UserCreateDto> _createValidator;

        public UserManager(IMapper mapper, IValidator<UserCreateDto> createValidator, IValidator<UserUpdateDto> updateValidator, IUoW uoW) : base(mapper, createValidator, updateValidator, uoW)
        {
            _uoW = uoW;
            _mapper = mapper;
            _createValidator = createValidator;
        }

        public async Task<DataResponse<UserCreateDto>> CreateUserRoleAsync(UserCreateDto userCreateDto, int roleId)
        {
            var result = _createValidator.Validate(userCreateDto);
            if (result.IsValid)
            {
                var user = _mapper.Map<User>(userCreateDto);
                user.UserRoles = new List<UserRole>();
                user.UserRoles.Add(new UserRole
                {
                    User = user,
                    RoleId = roleId
                }); ;
                await _uoW.GetRepository<User>().CreateAsync(user);
                await _uoW.SaveChangesAsync();
                return new DataResponse<UserCreateDto>(ResponseType.ResponType.Success, userCreateDto);

            }
            return new DataResponse<UserCreateDto>(userCreateDto, result.ConvertToCustomValidationErrors());
        }

        public async Task<DataResponse<UserListDto>> CheckUser(UserLoginDto userLoginDto)
        {
            //validation
            var userInfo = await _uoW.GetRepository<User>().GetByFilterAsync(x => x.UserName == userLoginDto.UserName && x.Password == userLoginDto.Password);
            if (userInfo != null)
            {
                var dto = _mapper.Map<UserListDto>(userInfo);
                return new DataResponse<UserListDto>(ResponseType.ResponType.Success, dto);
            }
            return new DataResponse<UserListDto>(ResponseType.ResponType.NotFound, "Kullanıcı Bulunamadı, Giriş İşlemi Hatası");
        }

        public async Task<DataResponse<List<RoleListDto>>> GetRolesAsync(int userId)
        {
            var userRoles = await _uoW.GetRepository<Role>().GetAllAsync(x => x.UserRoles.Any(x => x.UserId == userId));
            if (userRoles == null)
            {
                return new DataResponse<List<RoleListDto>>(ResponseType.ResponType.NotFound, "Kullanıcı Bulunamadı, Kullanıcı Rol Hatası");
            }
            var userDto = _mapper.Map<List<RoleListDto>>(userRoles);
            return new DataResponse<List<RoleListDto>>(ResponseType.ResponType.Success, userDto);
        }

    }
}
