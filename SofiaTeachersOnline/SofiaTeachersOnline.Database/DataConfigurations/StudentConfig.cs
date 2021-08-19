using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SofiaTeachersOnline.Database.Models;

namespace SofiaTeachersOnline.Database.DataConfigurations
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            //builder.HasQueryFilter(x => !x.IsDeleted);  // TODO: Can it be moved somewhere else to not be repeated?

            builder.HasMany(c => c.Courses);
        }
    }
}
