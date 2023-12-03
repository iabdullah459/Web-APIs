using Assignment_Web_APIs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Assignment_Web_APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly Database _context;

        public SubjectController(Database context)
        {
            _context = context;
        }

        // GET: api/subject
        [HttpGet]
        public IActionResult GetAllSubjects()
        {
            var subjects = _context.Subjects.ToList();
            return Ok(subjects);
        }

        // GET: api/subject/{subjectId}
        [HttpGet("{subjectId}")]
        public IActionResult GetSubjectById(int subjectId)
        {
            var subject = _context.Subjects.Find(subjectId);
            if (subject == null)
                return NotFound();

            return Ok(subject);
        }

        // POST: api/subject
        [HttpPost]
        public IActionResult CreateSubject([FromBody] Subject subject)
        {
            if (subject == null)
                return BadRequest("Invalid subject data.");

            _context.Subjects.Add(subject);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSubjectById), new { subjectId = subject.SubjectId }, subject);
        }

        // PUT: api/subject/{subjectId}
        [HttpPut("{subjectId}")]
        public IActionResult UpdateSubject(int subjectId, [FromBody] Subject updatedSubject)
        {
            if (updatedSubject == null)
                return BadRequest("Invalid updated subject data.");

            var existingSubject = _context.Subjects.Find(subjectId);
            if (existingSubject == null)
                return NotFound();

            existingSubject.Name = updatedSubject.Name;
            existingSubject.Code = updatedSubject.Code;

            _context.SaveChanges();
            return Ok(existingSubject);
        }

        // DELETE: api/subject/{subjectId}
        [HttpDelete("{subjectId}")]
        public IActionResult DeleteSubject(int subjectId)
        {
            var subject = _context.Subjects.Find(subjectId);
            if (subject == null)
                return NotFound();

            _context.Subjects.Remove(subject);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
