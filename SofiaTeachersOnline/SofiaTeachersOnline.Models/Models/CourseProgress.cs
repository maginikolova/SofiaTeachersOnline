using SofiaTeachersOnline.Models.Contracts;
using System;

namespace SofiaTeachersOnline.Models
{
    public class CourseProgress : IEntity
    {
        public int Id { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public double Progress { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
