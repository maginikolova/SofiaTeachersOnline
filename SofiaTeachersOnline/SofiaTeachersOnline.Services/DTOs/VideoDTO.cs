using SofiaTeachersOnline.Services.DTOs.Contracts;

namespace SofiaTeachersOnline.Services.DTOs
{
    public class VideoDTO : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public int LessonId { get; set; }
        public LessonDTO Lesson { get; set; }
    }
}
