using SofiaTeachersOnline.Database.Models;
using System;
using System.Collections.Generic;

namespace SofiaTeachersOnline.Services.DTOs
{
    public class ExerciseDTO
    {
        public string Content { get; set; }

        public int CourseId { get; set; }
        public CourseDTO Course { get; set; }  // TODO: Add CourseName here instead of Course?
        public ICollection<Grade> Grades { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public AppUser ModifiedByUser { get; set; }
    }
}
