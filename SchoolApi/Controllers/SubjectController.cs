using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolApi.Models;
using SchoolApi.Services;
using SchoolApi.Dtos;
namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("SchoolApi/Subjects")]
    public class SubjectController : ControllerBase
    {
        private readonly SubjectsService _service;

        public SubjectController(SubjectsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubjectsDto>>> GetSubjects(){
            List<SubjectsDto> subjects = await _service.GetSubjectsAsync();
            return subjects;
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubjectsDto obj){
            await _service.InsertAsync(obj);
            return Ok();
        }
    }
}