using SofiaTeachersOnline.Database.Models;
using System;
using System.Collections.Generic;

namespace SofiaTeachersOnline.Services.DTOs
{
    public class CourseDTO
    {
        // TODO: string Name?

        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        //bool isLatest?
        //coureVersion?

        public ICollection<CourseProgress> CourseProgress { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Video> Videos { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}
