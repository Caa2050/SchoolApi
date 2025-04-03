using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApi.Date;
using SchoolApi.Models;
namespace SchoolApi
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context){
            _context = context;
        }
        public void SeedDataContext(){
            if(!_context.Subjects.Any()){
                var subjects = new List<subjects>(){
                    new subjects(){
                   Name = "Math",
                   Students = new List<Student>(){
                        new Student{Name="Jason",BirthDate=new DateTime(2000,1,1),Email="jason@gmail.com",},
                        new Student{Name="Carl",BirthDate=new DateTime(2000,2,20),Email="carl@gmail.com"},
                   },
                   Teachers = new List<Teachers>() {
                        new Teachers{Name="Jessica",BirthDate=new DateTime(1970,6,25),Email="jessica@gmail.com",Graduation="Math"},
                        new Teachers{Name="Rick",BirthDate=new DateTime(1972,3,24),Email="rick@gmail.com",Graduation="Math"},
                   }
                },
                new subjects(){
                   Name = "English",
                   Students = new List<Student>(){
                        new Student{Name="Jason",BirthDate=new DateTime(2000,1,1),Email="jason@gmail.com"},
                        new Student{Name="Carl",BirthDate=new DateTime(2000,2,20),Email="carl@gmail.com"},
                   },
                   Teachers = new List<Teachers>() {
                        new Teachers{Name="Michelle",BirthDate=new DateTime(1973,2,1),Email="michelle@gmail.com",Graduation="English"},
                        new Teachers{Name="Rose",BirthDate=new DateTime(1972,7,2),Email="rose@gmail.com",Graduation="English"},
                   }
                }
                };
                _context.Subjects.AddRange(subjects);
                _context.SaveChanges();
            }
        }
    }
}