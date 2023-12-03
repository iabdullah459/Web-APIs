namespace Assignment_Web_APIs.Models
{
    public class Marks
    {
        public int? MarksId { get; set; }
        public int? StudentId { get; set; }
        public int? SubjectId { get; set; }
        public int? ObtainedMarks { get; set; }

        // Navigation properties
        public Student? Student { get; set; }
        public Subject? Subject { get; set; }
    }

}
