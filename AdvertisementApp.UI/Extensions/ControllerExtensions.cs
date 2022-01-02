using AdvertisementApp_Bussiness.BaseResponseType;
using AdvertisementApp_Bussiness.ResponseType;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementApp.UI.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ResponseRedirectAction<T>(this Controller controller, IDataResponse<T> dataResponse, string actionName)
        {
            if (dataResponse.ResponType == ResponType.NotFound)
                return controller.NotFound();

            if (dataResponse.ResponType == ResponType.ValidationError)
            {
                foreach (var errors in dataResponse.ValidationErrors)
                {
                    controller.ModelState.AddModelError(errors.PropertyName, errors.ErrorMessage);
                }
                return controller.View(dataResponse.Data);
            }
            return controller.RedirectToAction(actionName);
        }

        public static IActionResult ResponseView<T>(this Controller controller, IDataResponse<T> dataResponse)
        {
            if (dataResponse.ResponType == ResponType.NotFound)
                return controller.NotFound();
            return controller.View(dataResponse.Data);
        }

        public static IActionResult ResponseView(this Controller controller, Response dataResponse, string actionName)
        {
            if (dataResponse.ResponType == ResponType.NotFound)
                return controller.NotFound();
            return controller.RedirectToAction(actionName);
        }
    }
}
