using Assignment_Web_APIs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Assignment_Web_APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarksController : ControllerBase
    {
        private readonly Database _context;

        public MarksController(Database context)
        {
            _context = context;
        }

        // GET: api/marks
        [HttpGet]
        public IActionResult GetAllMarks()
        {
            var marks = _context.Marks.ToList();
            return Ok(marks);
        }

        // GET: api/marks/{marksId}
        [HttpGet("{marksId}")]
        public IActionResult GetMarksById(int marksId)
        {
            var marks = _context.Marks.Find(marksId);
            if (marks == null)
                return NotFound();

            return Ok(marks);
        }

        // POST: api/marks
        [HttpPost]
        public IActionResult RecordMarks([FromBody] Marks marks)
        {
            if (marks == null)
                return BadRequest("Invalid marks data.");

            _context.Marks.Add(marks);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMarksById), new { marksId = marks.MarksId }, marks);
        }

        // PUT: api/marks/{marksId}
        [HttpPut("{marksId}")]
        public IActionResult UpdateMarks(int marksId, [FromBody] Marks updatedMarks)
        {
            if (updatedMarks == null)
                return BadRequest("Invalid updated marks data.");

            var existingMarks = _context.Marks.Find(marksId);
            if (existingMarks == null)
                return NotFound();

            // Update marks details if needed
            existingMarks.ObtainedMarks = updatedMarks.ObtainedMarks;

            _context.SaveChanges();
            return Ok(existingMarks);
        }

        // DELETE: api/marks/{marksId}
        [HttpDelete("{marksId}")]
        public IActionResult DeleteMarks(int marksId)
        {
            var marks = _context.Marks.Find(marksId);
            if (marks == null)
                return NotFound();

            _context.Marks.Remove(marks);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
