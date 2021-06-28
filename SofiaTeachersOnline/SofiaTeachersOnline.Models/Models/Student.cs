using SofiaTeachersOnline.Models.Abstracts;
using System.Collections.Generic;

namespace SofiaTeachersOnline.Models
{
    public class Student : AppUser
    {
        public Notebook Notebook { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public ICollection<CourseProgress> CourseProgress { get; set; }
        public ICollection<Rating> RatingsGiven { get; set; }
    }
}
