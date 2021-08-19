using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SofiaTeachersOnline.Database.Models;

namespace SofiaTeachersOnline.Database.DataConfigurations
{
    public class ExerciseConfig : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);  // TODO: Can it be moved somewhere else to not be repeated?
        }
    }
}
