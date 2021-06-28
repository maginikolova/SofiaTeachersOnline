using SofiaTeachersOnline.Database.Models.Contracts;
using System;

namespace SofiaTeachersOnline.Database.Models
{
    public class Video : IEntity, IModifiable
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public AppUser ModifiedByUser { get; set; }
    }
}
