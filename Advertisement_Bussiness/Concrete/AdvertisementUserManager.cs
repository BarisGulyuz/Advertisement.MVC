using AdvertisementApp.Entities.Concrete;
using AdvertisementApp_Bussiness.Abstract;
using AdvertisementApp_Bussiness.BaseResponseType;
using AdvertisementApp_Bussiness.Enums;
using AdvertisementApp_Bussiness.Extensions;
using AdvertisementApp_DataAccess.Abstract;
using AdvertisementApp_DTOs.AdvertisementDto;
using AdvertisementApp_DTOs.AdvertisementUserDto;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_Bussiness.Concrete
{
    public class AdvertisementUserManager : IAdvertisementUserService
    {
        private readonly IUoW _uoW;
        private readonly IValidator<AdvertisementUserCreateDto> _validator;
        private readonly IMapper _mapper;

        //private readonly IValidator<AdvertisementUserUpdateDto> _validator;

        public AdvertisementUserManager(IUoW uoW, IValidator<AdvertisementUserCreateDto> validator, IMapper mapper)
        {
            _uoW = uoW;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<DataResponse<AdvertisementUserCreateDto>> CreateAsync(AdvertisementUserCreateDto advertisementUserCreateDto)
        {
            var result = _validator.Validate(advertisementUserCreateDto);
            if (result.IsValid)
            {
                var userApplyControl = await _uoW.GetRepository<AdvertisementUser>().GetByFilterAsync(x => x.UserId == advertisementUserCreateDto.UserId && x.AdvertisementId == advertisementUserCreateDto.AdvertisementId);
                if (userApplyControl == null)
                {
                    var userDto = _mapper.Map<AdvertisementUser>(advertisementUserCreateDto);
                    await _uoW.GetRepository<AdvertisementUser>().CreateAsync(userDto);
                    await _uoW.SaveChangesAsync();
                    return new DataResponse<AdvertisementUserCreateDto>(ResponseType.ResponType.Success, advertisementUserCreateDto);
                }


                return new DataResponse<AdvertisementUserCreateDto>(advertisementUserCreateDto, errors: new List<CustomValidationError> { new CustomValidationError { ErrorMessage = "Bu ilana başvuru sağladınız", PropertyName = "" } });

            }

            return new DataResponse<AdvertisementUserCreateDto>(advertisementUserCreateDto, result.ConvertToCustomValidationErrors());
        }

        public async Task<List<AdvertisementUserListDto>> GetListAsync(AdvertisementUserStatusType statusType)
        {
            var query = _uoW.GetRepository<AdvertisementUser>().GetQuery();
            var list = await query.Include(x => x.Advertisement).Include(x => x.User).Include(x => x.MilitaryStatus).Include(x => x.AdvertisementUserStatus).Where(x => x.AdvetisementUserStatusId == (int)statusType).ToListAsync();
            var dto = _mapper.Map<List<AdvertisementUserListDto>>(list);
            return dto;
        }

        public async Task<List<AdvertisementUserListDto>> GetListByAdvertisementAsync(int advertisementId, AdvertisementUserStatusType advertisementuserStatusType)
        {
            var query = _uoW.GetRepository<AdvertisementUser>().GetQuery();
            var list = await query.Include(x => x.Advertisement).Include(x => x.User).Include(x => x.MilitaryStatus).Include(x => x.AdvertisementUserStatus).Where(x => x.AdvertisementId == advertisementId && x.AdvetisementUserStatusId == (int)advertisementuserStatusType).ToListAsync();
            var dto = _mapper.Map<List<AdvertisementUserListDto>>(list);
            return dto;
        }

        public async Task<List<AdvertisementUserListDto>> GetListByUsertAsync(int userId)
        {
            var query = _uoW.GetRepository<AdvertisementUser>().GetQuery();
            var list = await query.Include(x => x.Advertisement).Include(x => x.User).Include(x => x.MilitaryStatus).Include(x => x.AdvertisementUserStatus).Where(x => x.UserId == userId).ToListAsync();
            var dto = _mapper.Map<List<AdvertisementUserListDto>>(list);
            return dto;
        }

        public async Task  SetStatusAsync(int advertisementId, AdvertisementUserStatusType advertisementuserStatusType)
        {
            var unchangedEntity = await _uoW.GetRepository<AdvertisementUser>().FindAsync(advertisementId);
            AdvertisementUser advertisementUser = unchangedEntity;
            advertisementUser.AdvetisementUserStatusId = (int)advertisementuserStatusType;
            _uoW.GetRepository<AdvertisementUser>().Update(advertisementUser, unchangedEntity);
            await _uoW.SaveChangesAsync();
        }
    }
}
