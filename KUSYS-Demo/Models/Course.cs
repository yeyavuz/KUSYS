namespace KUSYS_Demo.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public List<StudentCourses> StudentCourses { get; set; }
    }
}
