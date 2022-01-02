using AdvertisementApp.UI.Extensions;
using AdvertisementApp.UI.Models.Advertisement;
using AdvertisementApp_Bussiness.Abstract;
using AdvertisementApp_Bussiness.Enums;
using AdvertisementApp_DTOs.AdvertisementDto;
using AdvertisementApp_DTOs.AdvertisementUserDto;
using AdvertisementApp_DTOs.MilitaryStatusDto;
using AdvertisementApp_DTOs.UserDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdvertisementApp.UI.Controllers
{
    public class AdvertisementsController : Controller
    {
        private readonly IAdvertisementService _advertisementService;
        private readonly IUserService _userService;
        private readonly IAdvertisementUserService _advertisementUserService;
        public AdvertisementsController(IAdvertisementService advertisementService, IUserService userService, IAdvertisementUserService advertisementUserService)
        {
            _advertisementService = advertisementService;
            _userService = userService;
            _advertisementUserService = advertisementUserService;
        }

        [Route("Advertisements/Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _advertisementService.GetActiveAdvertisements();
            return this.ResponseView(values);
        }

        [Authorize(Roles = "member")]
        public async Task<IActionResult> Apply(int advertisementId)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var userInfo = await _userService.GetByIdAsync<UserListDto>(userId);

            ViewBag.GenderId = userInfo.Data.GenderId;

            var militaryItems = Enum.GetValues(typeof(MilitaryStatusType));
            var militaryStatusList = new List<MilitaryStatusListDto>();
            foreach (int status in militaryItems) //int --> Id
            {
                militaryStatusList.Add(new MilitaryStatusListDto
                {
                    Id = status,
                    Description = Enum.GetName(typeof(MilitaryStatusType), status)
                });
            }
            ViewBag.MilitaryStatusId = new SelectList(militaryStatusList, "Id", "Description");

            var advertisementInfo = await _advertisementService.GetByIdAsync<AdvertisementListDto>(advertisementId);
            ViewBag.AdvertisementName = advertisementInfo.Data.Title;

            return View(new AdvertisementApplyDto()
            {
                AdvertisementId = advertisementId,
                UserId = userId,

            });
        }


        [HttpPost]
        [Authorize(Roles = "member")]
        public async Task<IActionResult> Apply(AdvertisementApplyDto advertisementApplyDto, int advertisementId)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var userInfo = await _userService.GetByIdAsync<UserListDto>(userId);

            ViewBag.GenderId = userInfo.Data.GenderId;

            var militaryItems = Enum.GetValues(typeof(MilitaryStatusType));
            var militaryStatusList = new List<MilitaryStatusListDto>();
            foreach (int status in militaryItems) //int --> Id
            {
                militaryStatusList.Add(new MilitaryStatusListDto
                {
                    Id = status,
                    Description = Enum.GetName(typeof(MilitaryStatusType), status)
                });
            }
            ViewBag.MilitaryStatusId = new SelectList(militaryStatusList, "Id", "Description");

            var advertisementInfo = await _advertisementService.GetByIdAsync<AdvertisementListDto>(advertisementId);
            ViewBag.AdvertisementName = advertisementInfo.Data.Title;

            AdvertisementUserCreateDto advertisementUserCreateDto = new();

            if (advertisementApplyDto.CvPath != null)
            {
                var fileName = Guid.NewGuid().ToString();
                var fileExName = Path.GetExtension(advertisementApplyDto.CvPath.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "CVUploads", fileName + fileExName);
                var stream = new FileStream(path, FileMode.Create);
                await advertisementApplyDto.CvPath.CopyToAsync(stream);
                advertisementUserCreateDto.CvPath = path;
            }

            advertisementUserCreateDto.AdvertisementId = advertisementApplyDto.AdvertisementId;
            advertisementUserCreateDto.AdvetisementUserStatusId = advertisementApplyDto.AdvetisementUserStatusId;
            advertisementUserCreateDto.UserId = advertisementApplyDto.UserId;
            advertisementUserCreateDto.MilitaryStatusId = advertisementApplyDto.MilitaryStatusId;
            advertisementUserCreateDto.MilitaryEndDate = advertisementApplyDto.MilitaryEndDate;
            advertisementUserCreateDto.WorkExperience = advertisementApplyDto.WorkExperience;

            var response = await _advertisementUserService.CreateAsync(advertisementUserCreateDto);
            if(response.ResponType == AdvertisementApp_Bussiness.ResponseType.ResponType.ValidationError)
            {
                foreach (var error in response.ValidationErrors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    return View();
                }
            }
            return RedirectToAction("Index", "Advertisements");
        }

        [Authorize(Roles = "member")]
        public async Task<IActionResult> UserApplications()
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var values = await _advertisementUserService.GetListByUsertAsync(userId);
            return View(values);
        }
    }
}
