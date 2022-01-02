using AdvertisementApp_DTOs.Intefaces.ServicesDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_Bussiness.Validation.FluentValidation.ServicesValidator
{
    public class ServicesCreateValidator : AbstractValidator<ServicesCreateDto>
    {
        public ServicesCreateValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Description).MinimumLength(2);
            RuleFor(x => x.Description).MaximumLength(200);
            RuleFor(x => x.Title).MinimumLength(2).NotEmpty();
        }
    }
}
