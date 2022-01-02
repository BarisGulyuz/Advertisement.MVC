using AdvertisementApp_Bussiness.BaseResponseType;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_Bussiness.Extensions
{
    public static class ValidationResultExtension
    {
        public static List<CustomValidationError> ConvertToCustomValidationErrors(this ValidationResult validationResult)
        {
            List<CustomValidationError> customValidationErrors = new();
            foreach (var error in validationResult.Errors)
            {
                customValidationErrors.Add(new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                });
            }
            return customValidationErrors;
        }
    }
}
