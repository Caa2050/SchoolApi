using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApi.Models;
using SchoolApi.Date;
using Microsoft.EntityFrameworkCore;
namespace SchoolApi.Services
{
    public class StudentsService
    {
        public readonly DataContext _context;
        public StudentsService(DataContext context){
            _context = context;
        }

        public async Task<List<Student>> GetStudentsAsync(){
            List<Student> students = await _context.Students.ToListAsync();
            return students;
        }
    }
}