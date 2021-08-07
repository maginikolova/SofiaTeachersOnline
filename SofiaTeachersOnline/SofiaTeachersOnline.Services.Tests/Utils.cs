using Microsoft.EntityFrameworkCore;
using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Database.Models.Enums;
using System;
using System.Collections.Generic;

namespace SofiaTeachersOnline.Services.Tests
{
    public static class Utils
    {
        public static DbContextOptions<SofiaTeachersOnlineDbContext> GetOptions(string databaseName)
            => new DbContextOptionsBuilder<SofiaTeachersOnlineDbContext>()
            .UseInMemoryDatabase(databaseName)
            .Options;

        public static IEnumerable<Grade> GetGrades()
            => new List<Grade>()
            {
                new Grade
                {
                    StudentId = Guid.Parse("1d6e3bae-451f-4201-8b43-cecc2d404270"),
                    TeacherId =  Guid.Parse("71c88bb4-b6b6-45e8-9ea1-ba1912c1a845"),
                    ExerciseId = 2,
                    Mark = Mark.C
                   // Grades = new List<Grade> {new Grade(), new Grade()},
                },
                new Grade
                {
                    StudentId = Guid.Parse("1d6e3bae-451f-4201-8b43-cecc2d404270"),
                    TeacherId =  Guid.Parse("71c88bb4-b6b6-45e8-9ea1-ba1912c1a845"),
                    ExerciseId = 1,
                    Mark = Mark.A
                   // Grades = new List<Grade> {new Grade()},
                }
            };

        // TODO: Write Memory tests with dotMemoryUnit?
    }
}
