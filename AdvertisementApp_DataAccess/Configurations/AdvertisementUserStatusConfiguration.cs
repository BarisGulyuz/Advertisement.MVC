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
    public class AdvertisementUserStatusConfiguration : IEntityTypeConfiguration<AdvertisementUserStatus>
    {
        public void Configure(EntityTypeBuilder<AdvertisementUserStatus> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(300).IsRequired();
        }
    }
}
