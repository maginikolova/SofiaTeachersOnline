using SofiaTeachersOnline.Database.Models.Abstracts;
using SofiaTeachersOnline.Database.Models.Contracts;
using System;
using System.Collections.Generic;

namespace SofiaTeachersOnline.Database.Models
{
    public class Course : Entity, IModifiable, ICourse
    {
        public int Id { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        //bool isLatest?
        //coureVersion?

        public ICollection<CourseProgress> CourseProgress { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Video> Videos { get; set; }
        public ICollection<Exercise> Exercises { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public AppUser ModifiedByUser { get; set; }
    }
}
