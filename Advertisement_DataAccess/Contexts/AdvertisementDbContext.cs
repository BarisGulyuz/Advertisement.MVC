using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_DataAccess.Contexts
{
   public class AdvertisementDbContext : DbContext
    {
        public AdvertisementDbContext(DbContextOptions<AdvertisementDbContext> options) : base(options)
        {

        }
        public DbSet<Advertisement> MyProperty { get; set; }
    }
}
