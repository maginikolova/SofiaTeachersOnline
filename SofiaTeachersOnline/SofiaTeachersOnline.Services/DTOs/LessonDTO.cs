using SofiaTeachersOnline.Database.Models;
using System;
using System.Collections.Generic;

namespace SofiaTeachersOnline.Services.DTOs
{
    public class LessonDTO
    {
        public int NumberOfLesson { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

        public int CourseId { get; set; }
        public CourseDTO Course { get; set; }

        public ICollection<VideoDTO> Videos { get; set; }
        public ICollection<ExerciseDTO> Exercises { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public AppUser ModifiedByUser { get; set; }
    }
}
