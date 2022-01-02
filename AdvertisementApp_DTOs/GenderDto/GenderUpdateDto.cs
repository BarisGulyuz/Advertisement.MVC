using AdvertisementApp_DTOs.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_DTOs.Gender
{
    public class GenderUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
