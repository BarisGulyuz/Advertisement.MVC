using AdvertisementApp_Bussiness.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementApp.UI.Models.Advertisement
{
    public class AdvertisementApplyDto
    {
        public int AdvertisementId { get; set; }
        public int UserId { get; set; }
        public int AdvetisementUserStatusId { get; set; } = (int)AdvertisementUserStatusType.Başvuruldu;
        public int MilitaryStatusId { get; set; }
        public DateTime? MilitaryEndDate { get; set; }
        public int WorkExperience { get; set; }
        public IFormFile CvPath { get; set; }
    }
}
