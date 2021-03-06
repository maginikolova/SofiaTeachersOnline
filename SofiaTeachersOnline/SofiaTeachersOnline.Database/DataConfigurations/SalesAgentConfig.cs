using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SofiaTeachersOnline.Database.Models;

namespace SofiaTeachersOnline.Database.DataConfigurations
{
    public class SalesAgentConfig : IEntityTypeConfiguration<SalesAgent>
    {
        public void Configure(EntityTypeBuilder<SalesAgent> builder)
        {
            //builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasMany(e => e.GeneratedLinks);
        }
    }
}
