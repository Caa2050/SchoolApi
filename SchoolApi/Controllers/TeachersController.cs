using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Models;
using SchoolApi.Services;
using SchoolApi.Dtos;
using SchoolApi.Services.Exceptions;
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
        public async Task<ActionResult<List<TeachersDto>>> GetTeachers(){
            List<TeachersDto> teachers = await _service.GetTeachersAsync();
            return teachers;
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeachersDto teacher){
            await _service.InsertAsync(teacher);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, TeachersDto teacher){
            try{
                await _service.UpdateAsync(id,teacher);
                return Ok();
            }
            catch(NotFoundException){
                return NotFound();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id){
            try{
                await _service.DeleteAsync(id);
                return Ok();
            }
            catch(NotFoundException){
                return NotFound();
            }
        }
    }
}