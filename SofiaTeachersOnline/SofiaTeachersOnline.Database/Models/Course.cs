using SofiaTeachersOnline.Database.Models.Abstracts;
using SofiaTeachersOnline.Database.Models.Contracts;
using System;
using System.Collections.Generic;

namespace SofiaTeachersOnline.Database.Models
{
    public class Course : Entity, IModifiable, ICourse
    {
        public string Title { get; set; }
        // TODO: Add Course Description?

        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        //bool isLatest?
        //coureVersion?
        // TODO: Course thumbnail?

        // TODO: have interfaces instead of classes? IExercise/IVideo/...?
        public ICollection<CourseProgress> CourseProgress { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Video> Videos { get; set; }
        public ICollection<Exercise> Exercises { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public AppUser ModifiedByUser { get; set; }
    }
}
