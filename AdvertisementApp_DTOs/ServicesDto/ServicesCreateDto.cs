using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_DTOs.Intefaces.ServicesDto
{
    public class ServicesCreateDto : IDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
