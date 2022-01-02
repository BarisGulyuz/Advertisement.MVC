using AdvertisementApp.Entities.Concrete;
using AdvertisementApp_DTOs.Intefaces.ServicesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_Bussiness.Abstract
{
    public interface IServicesService : IService<ServicesCreateDto, ServicesUpdateDto, ServicesListDto, Services>
    {
    }
}
