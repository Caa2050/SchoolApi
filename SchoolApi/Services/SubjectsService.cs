using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApi.Models;
using SchoolApi.Date;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Dtos;

namespace SchoolApi.Services
{
    public class SubjectsService
    {
        private readonly DataContext _context;
        public SubjectsService(DataContext context){
            _context = context;
        }

        public async Task<List<SubjectsDto>> GetSubjectsAsync(){
            List<subjects> subject =  await _context.Subjects.ToListAsync();
            List<SubjectsDto> subjectsDto = new List<SubjectsDto>();
            foreach (subjects item in subject)
            {
                subjectsDto.Add(ConvertToDto(item));
            }
            return subjectsDto;
        }
        public async Task InsertAsync(SubjectsDto obj){
            subjects subject = ConvertoToNormal(obj);
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
        }
        public subjects ConvertoToNormal(SubjectsDto obj){
            return new subjects {Name = obj.Name};
        }
        public SubjectsDto ConvertToDto(subjects obj){
            return new SubjectsDto{Id =obj.Id,Name = obj.Name};
        }
    }
}