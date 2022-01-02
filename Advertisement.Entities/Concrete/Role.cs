using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Entities.Concrete
{
    public class Role : BaseEntity
    {
        public string Description { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
