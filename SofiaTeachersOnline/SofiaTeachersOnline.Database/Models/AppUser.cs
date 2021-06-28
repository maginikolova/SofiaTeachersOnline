using Microsoft.AspNetCore.Identity;
using SofiaTeachersOnline.Database.Models.Contracts;
using System;
using System.Collections.Generic;

namespace SofiaTeachersOnline.Database.Models
{
    public class AppUser : IdentityUser<Guid>, IUserBase, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime LastOnline { get; set; }
        public string ProfilePic { get; set; }

        public ICollection<Course> ModifiedCourses { get; set; }
        public ICollection<Exercise> ModifiedExercises { get; set; }
        public ICollection<Video> ModifiedVideos { get; set; }

        //public ICollection<Message> MessagesSent { get; set; }
        //public ICollection<Message> MessagesReceived { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
