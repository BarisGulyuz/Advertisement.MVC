using AdvertisementApp_Bussiness.Abstract;
using AdvertisementApp_Bussiness.Enums;
using AdvertisementApp_DTOs.AdvertisementDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementApp.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdvertisementController : Controller
    {
        private readonly IAdvertisementService _advertisementService;
        private readonly IAdvertisementUserService _advertisementUserService;

        public AdvertisementController(IAdvertisementService advertisementService, IAdvertisementUserService advertisementUserService)
        {
            _advertisementService = advertisementService;
            _advertisementUserService = advertisementUserService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _advertisementService.GetActiveAdvertisements();

            var passiveValues = await _advertisementService.GetPassiveAdvertisements();
            ViewBag.advertisementPassiveDataCount = passiveValues.Data.Count();

            return View(values.Data);
        }

        public async Task<IActionResult> AdvertisementApplications(int advertisementId)
        {
            if (advertisementId == 0)
            {
                var values = await _advertisementUserService.GetListAsync(AdvertisementUserStatusType.Başvuruldu);
                return View(values);
            }

            var filteredValues = await _advertisementUserService.GetListByAdvertisementAsync(advertisementId, AdvertisementUserStatusType.Başvuruldu);
            ViewBag.AdvertisementTitle = filteredValues.Select(x => x.Advertisement.Title).FirstOrDefault();

            return View(filteredValues);
        }

        public async Task<IActionResult> SetStatus(int advertisementId, AdvertisementUserStatusType advertisementUserStatusType)
        {
            await _advertisementUserService.SetStatusAsync(advertisementId, advertisementUserStatusType);
            return RedirectToAction("AdvertisementApplications");
        }

        public IActionResult Create()
        {
            return View(new AdvertisementCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdvertisementCreateDto advertisementCreateDto)
        {

            var advertisementData = await _advertisementService.CreateAsync(advertisementCreateDto);
            if(advertisementData.ResponType == AdvertisementApp_Bussiness.ResponseType.ResponType.ValidationError)
            {
                foreach (var errors in advertisementData.ValidationErrors)
                {
                    ModelState.AddModelError(errors.PropertyName, errors.ErrorMessage);
                    return View();
                }
            }
          
            return RedirectToAction("Index", advertisementData.Data);

        }

        public async Task<IActionResult> Delete(int id)
        {
            await _advertisementService.RemoveAsync(id);
            return RedirectToAction("Index");
        }
    }
}
