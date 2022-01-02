using AdvertisementApp_DTOs.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_DTOs.AdvertisementUserDto
{
    public class AdvertisementUserUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public int UserId { get; set; }
        public int AdvetisementUserStatusId { get; set; }
        public int MilitaryStatusId { get; set; }
        public DateTime? MilitaryEndDate { get; set; }
        public int WorkExperience { get; set; }
        public string CvPath { get; set; }
    }
}
