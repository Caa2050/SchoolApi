using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApi.Models;
using SchoolApi.Date;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Dtos;
using SchoolApi.Services.Exceptions;
namespace SchoolApi.Services
{
    public class TeacherService
    {
        private readonly DataContext _context;
        public TeacherService(DataContext context){
            _context = context;
        }
        public async Task<List<TeachersDto>> GetTeachersAsync(){
            List<Teachers> teachers = await _context.Teachers.ToListAsync();
            List<TeachersDto> teachersDto = new List<TeachersDto>();
            foreach (Teachers item in teachers)
            {
                teachersDto.Add(ConvertToDto(item));
            }
            return teachersDto;
        }
        public async Task InsertAsync(TeachersDto teacherDto){
            Teachers teacher = ConvertToNormal(teacherDto);
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id,TeachersDto teacherDto){
            bool hasAny = await _context.Teachers.AnyAsync(teacher => teacher.Id == id);
            if(!hasAny){
                throw new NotFoundException("Id not Found");
            };
            Teachers teacher = ConvertToNormal(teacherDto);
            _context.Update(teacher);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id){
            bool hasAny = await _context.Teachers.AnyAsync(teacher => teacher.Id == id);
            if(!hasAny){
                throw new NotFoundException("Id not Found");
            }
            Teachers teacher = await _context.Teachers.FindAsync(id);
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }
        public Teachers ConvertToNormal(TeachersDto obj){
           return  new Teachers{Id = obj.Id, Name = obj.Name, BirthDate = obj.BirthDate, Email = obj.Email, Graduation = obj.Graduation, SubjectId = obj.SubjectId};
        }
        public TeachersDto ConvertToDto(Teachers obj){
           return  new TeachersDto{Id = obj.Id, Name = obj.Name, BirthDate = obj.BirthDate, Email = obj.Email, Graduation = obj.Graduation, SubjectId = obj.SubjectId};
        }
    }
}