using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolApi.Models;
using SchoolApi.Services;
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
        public async Task<ActionResult<List<subjects>>> GetSubjects(){
            List<subjects> subjects = await _service.GetSubjectsAsync();
            return subjects;
        }
    }
}