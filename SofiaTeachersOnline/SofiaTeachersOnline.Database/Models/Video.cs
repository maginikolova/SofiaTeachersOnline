using SofiaTeachersOnline.Database.Models.Abstracts;
using SofiaTeachersOnline.Database.Models.Contracts;
using System;

namespace SofiaTeachersOnline.Database.Models
{
    public class Video : Entity, IModifiable
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public AppUser ModifiedByUser { get; set; }
    }
}
