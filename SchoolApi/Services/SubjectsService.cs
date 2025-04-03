using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApi.Models;
using SchoolApi.Date;
using Microsoft.EntityFrameworkCore;
namespace SchoolApi.Services
{
    public class SubjectsService
    {
        private readonly DataContext _context;
        public SubjectsService(DataContext context){
            _context = context;
        }

        public async Task<List<subjects>> GetSubjectsAsync(){
            List<subjects> subjects =  await _context.Subjects.ToListAsync();
            return subjects;
        }
    }
}