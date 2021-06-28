using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SofiaTeachersOnline.Database.Models;

namespace SofiaTeachersOnline.Database.DataConfigurations
{
    public class RatingConfig : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasOne(c => c.GivenTo)
                .WithMany(t => t.RatingsReceived)
                .HasForeignKey(c => c.GivenToId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
