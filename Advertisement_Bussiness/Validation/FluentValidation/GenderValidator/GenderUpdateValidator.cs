using AdvertisementApp_DTOs.Gender;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_Bussiness.Validation.FluentValidation.GenderValidator
{
    public class GenderUpdateValidator  : AbstractValidator<GenderUpdateDto>
    {
        public GenderUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
