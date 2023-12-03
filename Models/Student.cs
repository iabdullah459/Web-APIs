namespace Assignment_Web_APIs.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public string? RollNumber { get; set; }

        // Navigation property for student-subject assignments
        public List<StudentSubjectAssignment>? Assignments { get; set; }

        // Navigation property for student marks
        public List<Marks>? Marks { get; set; }
    }
}

