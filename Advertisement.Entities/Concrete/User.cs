using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Entities.Concrete
{
    public class User: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public List<AdvertisementUser> AdvertisementUsers { get; set; }
    }
}
