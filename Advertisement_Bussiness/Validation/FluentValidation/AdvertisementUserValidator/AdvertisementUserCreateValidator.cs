using AdvertisementApp_Bussiness.Enums;
using AdvertisementApp_DTOs.AdvertisementUserDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_Bussiness.Validation.FluentValidation.AdvertisementUserValidator
{
    public class AdvertisementUserCreateValidator : AbstractValidator<AdvertisementUserCreateDto>
    {
        public AdvertisementUserCreateValidator()
        {
            RuleFor(x => x.AdvetisementUserStatusId).NotEmpty();
            RuleFor(x => x.AdvertisementId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.CvPath).NotEmpty();
            RuleFor(x => x.MilitaryEndDate).NotEmpty().When(x=> x.MilitaryStatusId == (int)MilitaryStatusType.Tecilli);
            RuleFor(x => x.WorkExperience).NotEmpty();
        }
    }
}
