using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SofiaTeachersOnline.Database.Models;

namespace SofiaTeachersOnline.Database.DataConfigurations
{
    public class CourseProgressConfig : IEntityTypeConfiguration<CourseProgress>
    {
        public void Configure(EntityTypeBuilder<CourseProgress> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);  // TODO: Not working!!!
        }
    }
}
