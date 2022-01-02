using AdvertisementApp_DTOs.AdvertisementDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_Bussiness.Validation.FluentValidation.AdvertisementValidator
{
    public class AdvertisementCreateValidator : AbstractValidator<AdvertisementCreateDto>
    {
        public AdvertisementCreateValidator()
        {
            RuleFor(x => x.Title).MinimumLength(5).NotEmpty();
            RuleFor(x => x.Description).MaximumLength(300).NotEmpty();
        }
    }
}
