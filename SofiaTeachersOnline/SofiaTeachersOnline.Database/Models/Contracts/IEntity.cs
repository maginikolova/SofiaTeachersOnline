using System;

namespace SofiaTeachersOnline.Database.Models.Contracts
{
    public interface IEntity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
