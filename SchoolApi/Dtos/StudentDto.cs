using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApi.Models;
namespace SchoolApi.Dtos
{
    public class StudentDto
    {
            public int Id{get;set;}
            public string Name{get;set;}
            public DateTime BirthDate{get;set;}
            public string Email{get;set;}
            public ICollection<subjects> Subjects{get;set;}  = new List<subjects>();
    }
}