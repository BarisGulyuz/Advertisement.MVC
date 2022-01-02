using AdvertisementApp.Entities.Concrete;
using AdvertisementApp_Bussiness.Abstract;
using AdvertisementApp_Bussiness.BaseResponseType;
using AdvertisementApp_DataAccess.Abstract;
using AdvertisementApp_DTOs.Intefaces.ServicesDto;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_Bussiness.Concrete
{
    public class ServicesManager : GenericManager<ServicesCreateDto, ServicesUpdateDto, ServicesListDto, Services>, IServicesService
    {
        public ServicesManager(IMapper mapper, IValidator<ServicesCreateDto> createValidator, IValidator<ServicesUpdateDto> updateValidator, IUoW uoW) : base(mapper, createValidator, updateValidator, uoW)
        {

        }
    }
}
