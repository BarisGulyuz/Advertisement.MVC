using AdvertisementApp_Bussiness.Mappings.AutoMapper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_Bussiness.Mappings
{
    public class MappingHelper
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
                   new ServicesProfile(),
                   new AdvertisementProfile(),
                   new UserProfile(),
                   new GenderProfile(),
                   new RoleProfile(),
                   new AdvertisementUserProfile(),
                   new AdvertisementUserStatusProfile(),
                   new MilitaryStatusProfile()

            };
        }
    }
}
