using AdvertisementApp.Entities.Concrete;
using AdvertisementApp_Bussiness.Abstract;
using AdvertisementApp_Bussiness.BaseResponseType;
using AdvertisementApp_Bussiness.Extensions;
using AdvertisementApp_Bussiness.ResponseType;
using AdvertisementApp_DataAccess.Abstract;
using AdvertisementApp_DTOs.Intefaces;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_Bussiness.Concrete
{
    public class GenericManager<CreateDto, UpdateDto, ListDto, T> : IService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity

    {
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _createDtoValidator;
        private readonly IValidator<UpdateDto> _updateDtoValidator;
        private readonly IUoW _uoW;
        public GenericManager(IMapper mapper, IValidator<CreateDto> createDtoValidator, IValidator<UpdateDto> updateDtoValidator, IUoW uoW)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _uoW = uoW;
        }

        public async Task<IDataResponse<CreateDto>> CreateAsync(CreateDto createDto)
        {
            var result = _createDtoValidator.Validate(createDto);
            if (result.IsValid)
            {
                var createdEntity = _mapper.Map<T>(createDto);
                await _uoW.GetRepository<T>().CreateAsync(createdEntity);
                await _uoW.SaveChangesAsync();
                return new DataResponse<CreateDto>(ResponType.Success, createDto);
            }
            return new DataResponse<CreateDto>(createDto, result.ConvertToCustomValidationErrors());
        }

        public async Task<IDataResponse<List<ListDto>>> GetAllAsync()
        {
            var data = await _uoW.GetRepository<T>().GetAllAsync();
            var dto = _mapper.Map<List<ListDto>>(data);
            return new DataResponse<List<ListDto>>(ResponType.Success, dto);
        }

        public async Task<IDataResponse<IDto>> GetByIdAsync<IDto>(int id)
        {
            var data = await _uoW.GetRepository<T>().GetByFilterAsync(x => x.Id == id);
            if (data == null)
                return new DataResponse<IDto>(ResponType.NotFound, $"{id}" + "Numaralı Id'e Sahip Data Bulunumadı");
            var dto = _mapper.Map<IDto>(data);
            return new DataResponse<IDto>(ResponType.Success, dto);
        }

        public async Task<IResponse> RemoveAsync(int id)
        {
            var data = await _uoW.GetRepository<T>().FindAsync(id);
            if (data == null)
                return new Response(ResponType.NotFound, $"{id}" + "Sahip Data Bulunumadı");
            _uoW.GetRepository<T>().Remove(data);
            await _uoW.SaveChangesAsync();
            return new Response(ResponType.Success);
        }

        public async Task<IDataResponse<UpdateDto>> UpdateAsync(UpdateDto updateDto)
        {
            var result = _updateDtoValidator.Validate(updateDto);
            if (result.IsValid)
            {
                var unchangedData = await _uoW.GetRepository<T>().FindAsync(updateDto.Id);
                if (unchangedData == null)
                    return new DataResponse<UpdateDto>(ResponType.NotFound, $"{updateDto.Id}" + "Numaralı Id'e Sahip Data Bulunumadı");
                var dto = _mapper.Map<T>(updateDto);
                _uoW.GetRepository<T>().Update(dto, unchangedData);
                await _uoW.SaveChangesAsync();
                return new DataResponse<UpdateDto>(ResponType.Success, updateDto);
            }
            return new DataResponse<UpdateDto>(updateDto, result.ConvertToCustomValidationErrors());

        }
    }
}
