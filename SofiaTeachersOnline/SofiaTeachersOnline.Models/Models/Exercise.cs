using SofiaTeachersOnline.Models.Abstracts;
using SofiaTeachersOnline.Models.Contracts;
using System;
using System.Collections.Generic;

namespace SofiaTeachersOnline.Models
{
    public class Exercise : IEntity, IModifiable, IExercise
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        
        public ICollection<Grade> Grades { get; set; }

        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public UserBase ModifiedByUser { get; set; }
    }
}
