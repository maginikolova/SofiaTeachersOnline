using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs.Contracts;
using System;
using System.Collections.Generic;

namespace SofiaTeachersOnline.Services.DTOs
{
    public class CourseDTO : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        // TODO: string Description?

        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        //bool isLatest?
        //coureVersion?

        public ICollection<CourseProgressDTO> CourseProgress { get; set; }
        public ICollection<LessonDTO> Lessons { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
