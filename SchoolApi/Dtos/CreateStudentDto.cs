using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApi.Dtos
{
    public class CreateStudentDto
    {
            public string Name{get;set;}
            public DateTime BirthDate{get;set;}
            public string Email{get;set;}
            public List<int> SubjectsId{get;set;}
    }
}