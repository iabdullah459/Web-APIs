namespace Assignment_Web_APIs.Models
{
    public class StudentSubjectAssignment
    {
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        // Navigation properties
        public Student? Student { get; set; }
        public Subject? Subject { get; set; }
    }

}
