using AdvertisementApp_DTOs.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_DTOs.RoleDto
{
    public class RoleCreateDto : IDto
    {
        public string Description { get; set; }
    }
}
