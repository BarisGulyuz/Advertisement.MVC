using AdvertisementApp.Entities.Concrete;
using AdvertisementApp_Bussiness.Abstract;
using AdvertisementApp_DataAccess.Abstract;
using AdvertisementApp_DTOs.Gender;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_Bussiness.Concrete
{
    public class GenderManager : GenericManager<GenderCreateDto, GenderUpdateDto, GenderListDto, Gender>, IGenderService
    {

        public GenderManager(IMapper mapper, IValidator<GenderCreateDto> createValidator, IValidator<GenderUpdateDto> updateValidator, IUoW uoW) : base(mapper, createValidator, updateValidator, uoW)
        {

        }

    }
}
