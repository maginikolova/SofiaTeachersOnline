using SofiaTeachersOnline.Models.Abstracts;
using System.Collections.Generic;

namespace SofiaTeachersOnline.Models
{
    public class Teacher : UserBase
    {
       public ICollection<Course> Courses { get; set; }
       public ICollection<Grade> Grades { get; set; }
       public ICollection<Rating> RatingsReceived { get; set; }
    }
}
