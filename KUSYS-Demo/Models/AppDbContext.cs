using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace KUSYS_Demo.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>()
                .HasKey(s => s.StudentId);
            modelBuilder.Entity<Student>()
                .Property(s => s.FirstName)
                .HasMaxLength(50);
            modelBuilder.Entity<Student>()
                .Property(s => s.LastName)
                .HasMaxLength(50);

            modelBuilder.Entity<Course>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Course>()
                .Property(c => c.CourseId)
                .HasMaxLength(50);
            modelBuilder.Entity<Course>()
                .Property(c => c.CourseName)
                .HasMaxLength(50);

            modelBuilder.Entity<StudentCourses>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourses>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourses>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(c => c.CourseId);

            modelBuilder.Entity<Course>().HasData(
            new Course { Id = 1, CourseId = "CSI101", CourseName = "Introduction to Computer Science" },
            new Course { Id = 2, CourseId = "CSI102", CourseName = "Algorithms" },
            new Course { Id = 3, CourseId = "MAT101", CourseName = "Calculus" },
            new Course { Id = 4, CourseId = "PHY101", CourseName = "Physics" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
