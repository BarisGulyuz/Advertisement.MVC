using AdvertisementApp_DTOs.AdvertisementUserDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_Bussiness.Validation.FluentValidation.AdvertisementUserValidator
{
    public class AdvertisementUserUpdateValidator : AbstractValidator<AdvertisementUserUpdateDto>
    {
        public AdvertisementUserUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
