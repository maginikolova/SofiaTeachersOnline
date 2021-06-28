﻿using SofiaTeachersOnline.Database.Models.Enums;
using System;

namespace SofiaTeachersOnline.Services.DTOs
{
    public class GradeDTO
    {
        public int Id { get; set; }
        public Mark Mark { get; set; }

        //teachers
        public Guid TeacherId { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }

        //students
        public Guid StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }

        //excercise
        public int ExerciseId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
