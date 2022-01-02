using AdvertisementApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_DataAccess.Configurations
{
    public class AdvertisementUserConfiguration : IEntityTypeConfiguration<AdvertisementUser>
    {
        public void Configure(EntityTypeBuilder<AdvertisementUser> builder)
        {
            builder.HasIndex(x => new
            {
                x.AdvertisementId,
                x.UserId
            }).IsUnique();
            builder.Property(x => x.WorkExperience).IsRequired();
            builder.Property(x => x.CvPath).IsRequired();

            builder.HasOne(x => x.Advertisement).WithMany(x => x.AdvertisementUsers).HasForeignKey(x => x.AdvertisementId);
            builder.HasOne(x => x.User).WithMany(x => x.AdvertisementUsers).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.AdvertisementUserStatus).WithMany(x => x.AdvertisementUsers).HasForeignKey(x => x.AdvetisementUserStatusId);
            builder.HasOne(x => x.MilitaryStatus).WithMany(x => x.AdvertisementUsers).HasForeignKey(x => x.MilitaryStatusId);
            
        }
    }
}
