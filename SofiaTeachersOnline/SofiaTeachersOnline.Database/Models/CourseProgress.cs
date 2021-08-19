using SofiaTeachersOnline.Database.Models.Abstracts;
using System;

namespace SofiaTeachersOnline.Database.Models
{
    public class CourseProgress : Entity
    {
        // TODO: EntityController not working with this entity because it's not IModifiable
        public float Progress { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
