using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotnetWebApi.Models;
using DotnetWebApi.Contexts;

namespace DotnetWebApi.Controllers
{
    [ApiController]
    [Route("api/student")]
    public class StudentController : Controller
    {
        private readonly StudentContext _context;
        public StudentController(StudentContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public List<Student> GetStudents()
        {
            var students = _context.Students.ToList();

            return students;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(long id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(long id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutStudent(long id, Student student)
        {
            if (id != student.Id)
                return BadRequest();
            _context.Entry(student).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }catch(DbUpdateConcurrencyException)
            {
                if ((await _context.Students.FindAsync(id)) == null)
                    return NotFound();
                throw;
            }
            return NoContent();
        }
    }
}
