using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Database.Seeder;
using System;

namespace SofiaTeachersOnline.Database
{
    public class SofiaTeachersOnlineDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public SofiaTeachersOnlineDbContext(DbContextOptions options)
           : base(options)
        {
        }

        public DbSet<WannaBeUser> WannaBeUsers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseProgress> CourseProgresses { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Grade> Grades { get; set; }
        //public DbSet<Message> Messages { get; set; }
        public DbSet<Notebook> Notebooks { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<SalesAgent> SalesAgents { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<SuperUser> SuperUsers { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<SalesAgent>(entity =>
            {
                entity.HasMany(e => e.GeneratedLinks);
            });

            builder.Entity<Course>(entity =>
            {
                entity.HasMany(c => c.Students);

                entity.HasOne(c => c.Teacher)
                    .WithMany(t => t.Courses)
                    .HasForeignKey(c => c.TeacherId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(c => c.ModifiedByUser)
                    .WithMany(u => u.ModifiedCourses)
                    .HasForeignKey(c => c.ModifiedByUserId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<Student>(entity =>
            {
                entity.HasMany(c => c.Courses);
            });

            builder.Entity<Rating>(entity =>
            {
                entity.HasOne(c => c.GivenTo)
                    .WithMany(t => t.RatingsReceived)
                    .HasForeignKey(c => c.GivenToId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<Grade>(entity =>
            {
                entity.HasOne(c => c.Student)
                    .WithMany(s => s.Grades)
                    .HasForeignKey(c => c.StudentId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(c => c.Teacher)
                    .WithMany(t => t.Grades)
                    .HasForeignKey(c => c.TeacherId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Seed();
        }
    }
}
