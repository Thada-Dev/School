using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using School.Database.Entities;
using School.DTOs.Student;
using School.Services;

namespace School.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<StudentResponse>>> GetStudentAll()
        {
           var students = await studentService.FindAll();
        
            return students.Adapt<List<StudentResponse>>();
        }

        [HttpGet("[action]/{guid}")]
        public async Task<ActionResult<StudentResponse>> GetStudentById(Guid guid)
        {
            var students = await studentService.FindById(guid);

            if(students == null) return NotFound();
        
            return students.Adapt<StudentResponse>();
        }
        

        [HttpPost("[action]")]
        public async Task<ActionResult<StudentResponse>> AddStudent([FromBody] StudentRequest studentRequest)
        {
            var student = studentRequest.Adapt<Student>();

            student.StudentGUID = Guid.NewGuid();

            var result = await studentService.Create(student);

            if(result == 0) return BadRequest( new { message = "Insert Error" });
        
            return StatusCode((int)HttpStatusCode.Created);
        }
        
        [HttpPut("[action]/{guid}")]
        public async Task<IActionResult> UpdateStudent(Guid guid,[FromBody] StudentRequest studentRequest)
        {
            var student = await studentService.FindById(guid);

            if(student == null) return NotFound();

            studentRequest.Adapt(student);

            var result = await studentService.Update(student);

            if(result == 0) return BadRequest( new { message = "Update Error" });
        
            return NoContent();
        }

        [HttpDelete("[action]/{guid}")]
        public async Task<ActionResult> DeleteTModelById(Guid guid)
        {
            var student = await studentService.FindById(guid);

            if(student == null) return NotFound();

            var result = await studentService.Delete(student);

            if(result == 0) return BadRequest( new { message = "Delete Error" });
        
            return NoContent();
        }  
        
    }
}