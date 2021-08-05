using SofiaTeachersOnline.Database.Models.Abstracts;
using SofiaTeachersOnline.Database.Models.Contracts;
using System;
using System.Collections.Generic;

namespace SofiaTeachersOnline.Database.Models
{
    public class Exercise : Entity, IModifiable, IExercise
    {
        public string Content { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<Grade> Grades { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public AppUser ModifiedByUser { get; set; }
    }
}
