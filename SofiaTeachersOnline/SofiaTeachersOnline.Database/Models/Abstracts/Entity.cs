using SofiaTeachersOnline.Database.Models.Contracts;
using System;

namespace SofiaTeachersOnline.Database.Models.Abstracts
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
        
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedOn { get; set; }   
        public bool IsDeleted { get; set; }      // TODO: Should isDeleted stay or just DateTime? ?
    }
}
