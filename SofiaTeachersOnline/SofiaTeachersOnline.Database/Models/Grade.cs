using SofiaTeachersOnline.Database.Models.Abstracts;
using SofiaTeachersOnline.Database.Models.Contracts;
using SofiaTeachersOnline.Database.Models.Enums;
using System;

namespace SofiaTeachersOnline.Database.Models
{
    public class Grade : Entity, IModifiable
    {
        public Mark Mark { get; set; }

        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        
        public DateTime? ModifiedOn { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public AppUser ModifiedByUser { get; set; }
    }
}
