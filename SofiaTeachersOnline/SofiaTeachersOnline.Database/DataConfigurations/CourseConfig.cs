using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SofiaTeachersOnline.Database.Models;

namespace SofiaTeachersOnline.Database.DataConfigurations
{
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasMany(c => c.Students);

            builder.HasOne(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.ModifiedByUser)
                .WithMany(u => u.ModifiedCourses)
                .HasForeignKey(c => c.ModifiedByUserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
