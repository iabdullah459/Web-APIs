namespace Assignment_Web_APIs.Models
{
    public class Subject
    {
        public int? SubjectId { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }

        // Navigation property for student-subject assignments
        public List<StudentSubjectAssignment>? Assignments { get; set; }
        // Navigation property for subject marks
        public List<Marks>? Marks { get; set; }
    }

}
