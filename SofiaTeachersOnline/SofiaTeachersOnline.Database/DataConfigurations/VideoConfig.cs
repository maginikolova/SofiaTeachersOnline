using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SofiaTeachersOnline.Database.Models;

namespace SofiaTeachersOnline.Database.DataConfigurations
{
    public class VideoConfig : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
