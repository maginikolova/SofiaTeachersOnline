using System.Collections.Generic;

namespace SofiaTeachersOnline.Database.Models
{
    public class Teacher : AppUser
    {
       public ICollection<Course> Courses { get; set; }
       public ICollection<Grade> Grades { get; set; }
       public ICollection<Rating> RatingsReceived { get; set; }
    }
}
