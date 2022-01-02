using AdvertisementApp.Entities.Concrete;
using AdvertisementApp_Bussiness.Abstract;
using AdvertisementApp_Bussiness.BaseResponseType;
using AdvertisementApp_DataAccess.Abstract;
using AdvertisementApp_DTOs.AdvertisementDto;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_Bussiness.Concrete
{
    public class AdvertisementManager : GenericManager<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>, IAdvertisementService
    {
        private readonly IUoW _uoW;
        private readonly IMapper _mapper;
        public AdvertisementManager(IMapper mapper, IValidator<AdvertisementCreateDto> createValidator, IValidator<AdvertisementUpdateDto> updateValidator, IUoW uoW) : base(mapper, createValidator, updateValidator, uoW)
        {
            _uoW = uoW;
            _mapper = mapper;
        }

        public async Task<IDataResponse<List<AdvertisementListDto>>> GetActiveAdvertisements()
        {
            var data = await _uoW.GetRepository<Advertisement>().GetAllAsync(x => x.Status == true, x => x.CreatedDate, AdvertisementApp_DataAccess.Enums.OrderByType.DESC);
            var dto = _mapper.Map<List<AdvertisementListDto>>(data);
            return new DataResponse<List<AdvertisementListDto>>(ResponseType.ResponType.Success, dto);

        }

        public async Task<IDataResponse<List<AdvertisementListDto>>> GetPassiveAdvertisements()
        {
            var data = await _uoW.GetRepository<Advertisement>().GetAllAsync(x => x.Status == false, x => x.CreatedDate, AdvertisementApp_DataAccess.Enums.OrderByType.ASC);
            var dto = _mapper.Map<List<AdvertisementListDto>>(data);
            return new DataResponse<List<AdvertisementListDto>>(ResponseType.ResponType.Success, dto);
        }
    }
}
