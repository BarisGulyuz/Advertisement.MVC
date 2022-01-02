using AdvertisementApp_DTOs.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_DTOs.UserDto
{
    public class UserCreateDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int GenderId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
