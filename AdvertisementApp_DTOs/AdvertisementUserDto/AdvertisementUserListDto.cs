using AdvertisementApp_DTOs.Intefaces;
using AdvertisementApp_DTOs.AdvertisementDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvertisementApp_DTOs.UserDto;
using AdvertisementApp_DTOs.AdvertisementUserStatusDto;
using AdvertisementApp_DTOs.MilitaryStatusDto;

namespace AdvertisementApp_DTOs.AdvertisementUserDto
{
    public class AdvertisementUserListDto : IDto
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public AdvertisementListDto Advertisement { get; set; }
        public int UserId { get; set; }
        public UserListDto User { get; set; }
        public int AdvetisementUserStatusId { get; set; }
        public AdvertisementUserStatusListDto AdvertisementUserStatus { get; set; }
        public int MilitaryStatusId { get; set; }
        public MilitaryStatusListDto MilitaryStatus { get; set; }
        public DateTime? MilitaryEndDate { get; set; }
        public int WorkExperience { get; set; }
        public string CvPath { get; set; }
    }
}
