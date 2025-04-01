using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApi.Models
{
    public class Teachers 
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public DateTime BirthDate{get;set;}
        public string Email{get;set;}
        public string Graduation{get;set;}
        public subjects Subject{get;set;}

        public Teachers(){}
        public Teachers(int id,string name,DateTime birthDate,string email,string graduation,subjects subject){
            Id = id;
            Name = name;
            BirthDate = birthDate;
            Email = email;
            Graduation = graduation;
            Subject = subject;
        }
    }
}