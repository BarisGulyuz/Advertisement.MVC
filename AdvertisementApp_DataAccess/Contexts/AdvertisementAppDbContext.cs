using AdvertisementApp.Entities.Concrete;
using AdvertisementApp_DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_DataAccess.Contexts
{
    public class AdvertisementAppDbContext : DbContext
    {
        public AdvertisementAppDbContext(DbContextOptions<AdvertisementAppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdvertisementConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisementUserConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisementUserStatusConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new MilitaryStatusConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<AdvertisementUser> AdvertisementUsers { get; set; }
        public DbSet<AdvertisementUserStatus> AdvertisementUserStatuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<MilitaryStatus> MilitaryStatuses { get; set; }
        public DbSet<Services> Services { get; set; }
    }
}
