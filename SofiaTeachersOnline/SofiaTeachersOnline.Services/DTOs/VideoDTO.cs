namespace SofiaTeachersOnline.Services.DTOs
{
    public class VideoDTO
    {
        public string Url { get; set; }

        public int CourseId { get; set; }
        public CourseDTO Course { get; set; }  // TODO: Add CourseName here instead of Course?
    }
}
