using SofiaTeachersOnline.Database.Models.Abstracts;
using SofiaTeachersOnline.Database.Models.Contracts;
using System;
using System.Collections.Generic;

namespace SofiaTeachersOnline.Database.Models
{
    public class Lesson : Entity, IModifiable
    {
        public int NumberOfLesson { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<Video> Videos { get; set; }
        public ICollection<Exercise> Exercises { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public AppUser ModifiedByUser { get; set; }
    }
}
