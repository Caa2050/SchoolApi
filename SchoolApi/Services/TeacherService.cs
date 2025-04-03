using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApi.Models;
using SchoolApi.Date;
using Microsoft.EntityFrameworkCore;
namespace SchoolApi.Services
{
    public class TeacherService
    {
        private readonly DataContext _context;
        public TeacherService(DataContext context){
            _context = context;
        }
        public async Task<List<Teachers>> GetTeachersAsync(){
            List<Teachers> teachers = await _context.Teachers.ToListAsync();
            return teachers;
        }
    }
}