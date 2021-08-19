using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Database.Models.Enums;
using System;
using System.Collections.Generic;

namespace SofiaTeachersOnline.Database.Seeder
{
    public static class Seeder
    {
        public static void Seed(this ModelBuilder builder)
        {
            // Students
            var students = new List<Student>()
            {
                new Student()  // Admin
                {
                    Id = Guid.Parse("1d6e3bae-451f-4201-8b43-cecc2d404270"),
                    UserName = "magi@mail.com",
                    NormalizedUserName = "MAGI@MAIL.COM",
                    Email = "magi@mail.com",
                    NormalizedEmail = "MAGI@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "0886868686"
                },
                new Student()  // Admin
                {
                    Id = Guid.Parse("71c88aa4-b6b6-45e8-0ea1-ba1912c1a845"),
                    UserName = "phresli@mail.com",
                    NormalizedUserName = "PHRESLI@MAIL.COM",
                    Email = "phresli@mail.com",
                    NormalizedEmail = "PHRESLI@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "0886868688"
                }
            };
            var hasher = new PasswordHasher<Student>();
            students[0].PasswordHash = hasher.HashPassword(students[0], "magi123");
            students[1].PasswordHash = hasher.HashPassword(students[1], "phresli123");
            builder.Entity<Student>().HasData(students);

            // Teachers
            var teachers = new List<Teacher>()
            {
                new Teacher()
                {
                    Id = Guid.Parse("71c88bb4-b6b6-45e8-9ea1-ba1912c1a845"),
                    UserName = "magin@mail.com",
                    NormalizedUserName = "MAGIN@MAIL.COM",
                    Email = "magin@mail.com",
                    NormalizedEmail = "MAGINMAIL@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "0889868686"
                },
                new Teacher()
                {
                    Id = Guid.Parse("71c88cc4-b6b6-45e8-9ea1-ba1912c1a845"),
                    UserName = "phreslip@mail.com",
                    NormalizedUserName = "PHRESLIP@MAIL.COM",
                    Email = "phreslip@mail.com",
                    NormalizedEmail = "PHRESLIP@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "0812868688"
                }
            };
            var hasher1 = new PasswordHasher<Teacher>();
            teachers[0].PasswordHash = hasher1.HashPassword(teachers[0], "magi1234");
            teachers[1].PasswordHash = hasher1.HashPassword(teachers[1], "phresli1234");
            builder.Entity<Teacher>().HasData(teachers);

            // Courses
            var courses = new List<Course>()
            {
                new Course
                {
                    Id = 1,
                    TeacherId = Guid.Parse("71c88bb4-b6b6-45e8-9ea1-ba1912c1a845")
                },
                new Course
                {
                    Id = 2,
                    TeacherId = Guid.Parse("71c88cc4-b6b6-45e8-9ea1-ba1912c1a845")
                }
            };
            builder.Entity<Course>().HasData(courses);

            // CourseProgresses
            var courseProgresses = new List<CourseProgress>()
            {
                new CourseProgress
                {
                    Id = 1,
                    StudentId = Guid.Parse("1d6e3bae-451f-4201-8b43-cecc2d404270"),
                    CourseId = 1,
                    Progress = 10.0f
                },
                new CourseProgress
                {
                    Id = 2,
                    StudentId = Guid.Parse("71c88aa4-b6b6-45e8-0ea1-ba1912c1a845"),
                    CourseId = 2,
                    Progress = 20.0f
                }
            };
            builder.Entity<CourseProgress>().HasData(courseProgresses);

            // Exercises
            var exercises = new List<Exercise>()
            {
                new Exercise
                {
                    Id = 1,
                    CourseId = 1,
                    Content = "some content",
                   // Grades = new List<Grade> {new Grade(), new Grade()},
                },
                new Exercise
                {
                    Id = 2,
                    CourseId = 2,
                    Content = "some content2",
                   // Grades = new List<Grade> {new Grade()},
                }
            };
            builder.Entity<Exercise>().HasData(exercises);

            // Grades
            var grades = new List<Grade>()
            {
                new Grade
                {
                    Id = 1,
                    StudentId = Guid.Parse("1d6e3bae-451f-4201-8b43-cecc2d404270"),
                    TeacherId =  Guid.Parse("71c88bb4-b6b6-45e8-9ea1-ba1912c1a845"),
                    ExerciseId = 2,
                    Mark = Mark.C
                   // Grades = new List<Grade> {new Grade(), new Grade()},
                },
                new Grade
                {
                    Id = 2,
                    StudentId = Guid.Parse("1d6e3bae-451f-4201-8b43-cecc2d404270"),
                    TeacherId =  Guid.Parse("71c88bb4-b6b6-45e8-9ea1-ba1912c1a845"),
                    ExerciseId = 1,
                    Mark = Mark.A
                   // Grades = new List<Grade> {new Grade()},
                }
            };
            builder.Entity<Grade>().HasData(grades);
        }
    }
}
