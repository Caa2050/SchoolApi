using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApi.Models;
using SchoolApi.Date;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Services.Exceptions;
using SchoolApi.Dtos;
namespace SchoolApi.Services
{
    public class StudentsService
    {
        public readonly DataContext _context;
        public StudentsService(DataContext context){
            _context = context;
        }

        public async Task<List<Student>> GetStudentsAsync(){
           var result = from obj in _context.Students select obj;
           return await result.Include(x => x.Subjects).ToListAsync();
        }

        public async Task DeleteAsync(int id){
            bool hasAny = await _context.Students.AnyAsync(x => x.Id == id);
            if(!hasAny){
                throw new NotFoundException("Id not Found");
            }
            Student student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(CreateStudentDto studentDto){
            var subjects = await _context.Subjects.Where(m => studentDto.SubjectsId.Contains(m.Id)).ToListAsync();
            Student student = ConvertToNormalWhenCreate(studentDto,subjects);
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(int id, CreateStudentDto studentDto){
            bool hasAny = await _context.Students.AnyAsync(student => student.Id == id);
            if(!hasAny){
                throw new NotFoundException("Id not found");
            }
             var subjects = await _context.Subjects.Where(m => studentDto.SubjectsId.Contains(m.Id)).ToListAsync();
            Student student = ConvertToNormalWhenUpdate(id,studentDto,subjects);
            _context.Update(student);
            await _context.SaveChangesAsync();
        }

        public Student ConvertToNormalWhenUpdate(int id,CreateStudentDto studentDto, List<subjects> subjects){
            return new Student{Id = id, Name = studentDto.Name, BirthDate = studentDto.BirthDate, Email = studentDto.Email, Subjects = subjects};
        }

        public Student ConvertToNormalWhenCreate(CreateStudentDto studentDto,List<subjects> subjects){
            return new Student{Name = studentDto.Name, BirthDate = studentDto.BirthDate, Email = studentDto.Email, Subjects = subjects};
        }
    }
}