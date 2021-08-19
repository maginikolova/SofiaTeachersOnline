using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SofiaTeachersOnline.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SofiaTeachersOnline.Database.DataConfigurations
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
