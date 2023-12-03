using Assignment_Web_APIs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Assignment_Web_APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentSubjectAssignmentController : ControllerBase
    {
        private readonly Database _context;

        public StudentSubjectAssignmentController(Database context)
        {
            _context = context;
        }

        // GET: api/student-subject-assignment
        [HttpGet]
        public IActionResult GetAllAssignments()
        {
            var assignments = _context.StudentSubjectAssignments.ToList();
            return Ok(assignments);
        }

        // GET: api/student-subject-assignment/{studentId}/{subjectId}
        [HttpGet("{studentId}/{subjectId}")]
        public IActionResult GetAssignment(int studentId, int subjectId)
        {
            var assignment = _context.StudentSubjectAssignments
                .FirstOrDefault(ssa => ssa.StudentId == studentId && ssa.SubjectId == subjectId);

            if (assignment == null)
                return NotFound();

            return Ok(assignment);
        }

        // POST: api/student-subject-assignment
        [HttpPost]
        public IActionResult AssignSubjectToStudent([FromBody] StudentSubjectAssignment assignment)
        {
            if (assignment == null)
                return BadRequest("Invalid assignment data.");

            _context.StudentSubjectAssignments.Add(assignment);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAssignment), new { studentId = assignment.StudentId, subjectId = assignment.SubjectId }, assignment);
        }

        // PUT: api/student-subject-assignment/{assignmentId}
        [HttpPut("{assignmentId}")]
        public IActionResult UpdateAssignment(int assignmentId, [FromBody] StudentSubjectAssignment updatedAssignment)
        {
            if (updatedAssignment == null)
                return BadRequest("Invalid updated assignment data.");

            var existingAssignment = _context.StudentSubjectAssignments.Find(assignmentId);
            if (existingAssignment == null)
                return NotFound();

            // Update assignment details if needed

            _context.SaveChanges();
            return Ok(existingAssignment);
        }

        // DELETE: api/student-subject-assignment/{assignmentId}
        [HttpDelete("{assignmentId}")]
        public IActionResult DeleteAssignment(int assignmentId)
        {
            var assignment = _context.StudentSubjectAssignments.Find(assignmentId);
            if (assignment == null)
                return NotFound();

            _context.StudentSubjectAssignments.Remove(assignment);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
