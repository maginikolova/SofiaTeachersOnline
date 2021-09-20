using System;

namespace SofiaTeachersOnline.Services.DTOs
{
    public class CourseProgressDTO
    {
        public double Progress { get; set; }

        public Guid StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        // TODO: ProfilePic?

        public int CourseId { get; set; }
        public CourseDTO Course { get; set; }  // TODO: Add CourseName here instead of Course?
    }
}
