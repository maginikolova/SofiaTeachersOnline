using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs.Contracts;
using System;
using System.Collections.Generic;

namespace SofiaTeachersOnline.Services.DTOs
{
    public class ExerciseDTO : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public int CourseId { get; set; }
        public CourseDTO Course { get; set; }  // TODO: Add CourseName here instead of Course?
        public ICollection<GradeDTO> Grades { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public AppUser ModifiedByUser { get; set; }
    }
}
