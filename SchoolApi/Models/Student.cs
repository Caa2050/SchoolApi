using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApi.Models
{
    public class Student 
    {
            public int Id{get;set;}
            public string Name{get;set;}
            public DateTime BirthDate{get;set;}
            public string Email{get;set;}
            public ICollection<subjects> Subjects{get;set;}  = new List<subjects>();
            public Student(){}
            public Student(int id,string name,DateTime birthDate,string email){
                Id = id;
                Name = name;
                BirthDate = birthDate;
                Email = email;
            }
    }
}