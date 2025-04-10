using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Models;
using SchoolApi.Services;
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

        
    }
}