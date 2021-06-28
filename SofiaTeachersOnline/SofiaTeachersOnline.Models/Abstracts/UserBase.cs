﻿using Microsoft.AspNetCore.Identity;
using SofiaTeachersOnline.Models.Contracts;
using System;
using System.Collections.Generic;

namespace SofiaTeachersOnline.Models.Abstracts
{
    public abstract class UserBase : IdentityUser<Guid>, IUserBase, IEntity
    {
        //public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime LastOnline { get; set; }
        public string ProfilePic { get; set; }

        public ICollection<Course> ModifiedCourses { get; set; }
        public ICollection<Exercise> ModifiedExercises { get; set; }
        public ICollection<Video> ModifiedVideos { get; set; }

        //public ICollection<Message> MessagesSent { get; set; }
        //public ICollection<Message> MessagesReceived { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
