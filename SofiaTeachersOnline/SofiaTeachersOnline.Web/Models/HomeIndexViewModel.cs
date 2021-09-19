using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;
using System.Collections.Generic;

namespace SofiaTeachersOnline.Web.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Course> Courses { get; set; }  // TODO: Change to CourseViewModel
    }
}
