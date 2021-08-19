using System;

namespace SofiaTeachersOnline.Database.Models.Contracts
{
    public interface IModifiable
    {
        public DateTime? ModifiedOn { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public AppUser ModifiedByUser { get; set; }
    }
}
