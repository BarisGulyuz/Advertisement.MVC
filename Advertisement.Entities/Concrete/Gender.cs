using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Entities.Concrete
{
    public class Gender : BaseEntity
    {
        public string Description { get; set; }
        public List<User> Users { get; set; }
    }
}
