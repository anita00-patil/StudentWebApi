using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentWebApi.Models;

namespace StudentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly WebDbContext _dbContext;
        public StudentController(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get :api/students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _dbContext.Students.ToListAsync();
        }


        //GET:api/students/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _dbContext.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        //POST:api/students/
        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction("GetStudentss", new { id = student.Id }, student);
        }


        //Put:api/students/2
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(student).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (IsStudentExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetStudents", new { id = student.Id }, student);
        }

        //GET:api/students
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student = await _dbContext.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }
            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();

            return student; 
        }


        private bool IsStudentExist(int id)
        {
            return _dbContext.Students.Any(e => e.Id == id);
        }

    }
}

