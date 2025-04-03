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
    [Route("SchoolApi/Teachers")]
    public class TeachersController : ControllerBase
    {
        private readonly TeacherService _service;
        public TeachersController(TeacherService service){
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Teachers>>> GetTeachers(){
            List<Teachers> teachers = await _service.GetTeachersAsync();
            return teachers;
        }
    }
}