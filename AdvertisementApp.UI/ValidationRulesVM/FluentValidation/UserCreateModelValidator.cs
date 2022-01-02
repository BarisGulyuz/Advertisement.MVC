using AdvertisementApp.UI.Models.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementApp.UI.ValidationRulesVM.FluentValidation
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
        //[Obsolete]
        public UserCreateModelValidator()
        {
            //CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(8).MaximumLength(25);
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword);
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => new
            {
                x.Password,
                x.UserName
            }).Must(x => CanNotContainsFistName(x.Password, x.UserName)).When(x=> x.FirstName != null && x.Password != null);
            RuleFor(x => x.Password).Must(x => !x.StartsWith(1234.ToString())).When(x=> x.Password != null);
            RuleFor(x => x.Password).Must(x => !x.EndsWith(1234.ToString())).When(x => x.Password != null);
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.GenderId).NotEmpty();

        }

        private bool CanNotContainsFistName(string password, string userName)
        {
            return !password.Contains(userName);
        }
    }
}
