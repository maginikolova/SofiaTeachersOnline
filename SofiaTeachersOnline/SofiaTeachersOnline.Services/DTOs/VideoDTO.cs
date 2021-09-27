using SofiaTeachersOnline.Services.DTOs.Contracts;

namespace SofiaTeachersOnline.Services.DTOs
{
    public class VideoDTO : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public int CourseId { get; set; }
        public CourseDTO Course { get; set; }  // TODO: Add CourseName here instead of Course?
    }
}
