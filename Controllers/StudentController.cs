using Assignment_Web_APIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_Web_APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly Database _context;

        public StudentController(Database context)
        {
            _context = context;
        }

        // GET: api/student
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _context.Students.ToList();
            return Ok(students);
        }

        // GET: api/student/{studentId}
        [HttpGet("{studentId}")]
        public IActionResult GetStudentById(int studentId)
        {
            var student = _context.Students.Find(studentId);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        // POST: api/student
        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            if (student == null)
                return BadRequest("Invalid student data.");

            _context.Students.Add(student);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetStudentById), new { studentId = student.StudentId }, student);
        }

        // PUT: api/student/{studentId}
        [HttpPut("{studentId}")]
        public IActionResult UpdateStudent(int studentId, [FromBody] Student updatedStudent)
        {
            if (updatedStudent == null)
                return BadRequest("Invalid updated student data.");

            var existingStudent = _context.Students.Find(studentId);
            if (existingStudent == null)
                return NotFound();

            existingStudent.Name = updatedStudent.Name;
            existingStudent.RollNumber = updatedStudent.RollNumber;

            _context.SaveChanges();
            return Ok(existingStudent);
        }

        // DELETE: api/student/{studentId}
        [HttpDelete("{studentId}")]
        public IActionResult DeleteStudent(int studentId)
        {
            var student = _context.Students.Find(studentId);
            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
