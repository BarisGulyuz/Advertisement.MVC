using AdvertisementApp.UI.Extensions;
using AdvertisementApp.UI.Models.User;
using AdvertisementApp_Bussiness.Abstract;
using AdvertisementApp_DTOs.UserDto;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdvertisementApp.UI.Controllers
{
    public class UserAccountController : Controller
    {
        IUserService _userService;
        IGenderService _genderService;
        private readonly IValidator<UserCreateModel> _validator;
        private readonly IMapper _mapper;

        public UserAccountController(IUserService userService, IGenderService genderService, IValidator<UserCreateModel> validator, IMapper mapper)
        {
            _userService = userService;
            _genderService = genderService;
            _validator = validator;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto logindDto)
        {
            if (ModelState.IsValid)
            {
                var userCheck = await _userService.CheckUser(logindDto);
                if (userCheck.ResponType == AdvertisementApp_Bussiness.ResponseType.ResponType.Success)
                {

                    //user-roles

                    var userRole = await _userService.GetRolesAsync(userCheck.Data.Id);

                    var claims = new List<Claim>();

                    if (userRole.ResponType == AdvertisementApp_Bussiness.ResponseType.ResponType.Success)
                    {
                        foreach (var role in userRole.Data)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role.Description));
                        }
                    }

                    claims.Add(new Claim(ClaimTypes.NameIdentifier, userCheck.Data.Id.ToString()));

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = logindDto.RememberMe
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                    return RedirectToAction("Index", "Services");

                }
                else if (userCheck.ResponType == AdvertisementApp_Bussiness.ResponseType.ResponType.NotFound)
                {
                    ModelState.AddModelError("", userCheck.Message);
                }
            }
            return View(logindDto);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Services");
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var genders = await _genderService.GetAllAsync();
            var model = new UserCreateModel();
            model.Genders = new SelectList(genders.Data, "Id", "Description");

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserCreateModel user)
        {
            var genders = await _genderService.GetAllAsync();
            user.Genders = new SelectList(genders.Data, "Id", "Description", user.GenderId);

            var result = _validator.Validate(user);
            if (result.IsValid)
            {
                var userDto = _mapper.Map<UserCreateDto>(user);
                var userData = await _userService.CreateUserRoleAsync(userDto, 2); //2 is Member. Use Enum
                return this.ResponseRedirectAction(userData, "Login");
            }
            else
            {
                foreach (var errors in result.Errors)
                {
                    ModelState.AddModelError(errors.PropertyName, errors.ErrorMessage);
                }
            }
            return View(user);
        }
    }
}
