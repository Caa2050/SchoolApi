using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Models;
using SchoolApi.Services;
using SchoolApi.Services.Exceptions;
using SchoolApi.Dtos;
namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("SchoolApi/Student")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsService _service;
        public StudentsController(StudentsService service){
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents(){
            List<Student> students = await _service.GetStudentsAsync();
            return students;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id){
           try{
                 await _service.DeleteAsync(id);
                 return Ok();
           }
            catch(NotFoundException){
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentDto student){
            await _service.CreateAsync(student);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(int id, CreateStudentDto student){
            try{
                await _service.UpdateStudentAsync(id,student); 
                return Ok();
            }
            catch(NotFoundException){
                return NotFound();
            }
        }
    }
}