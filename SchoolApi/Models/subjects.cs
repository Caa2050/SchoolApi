using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApi.Models
{
    public class subjects
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public ICollection<Student> Students{get;set;} = new List<Student>();
        public ICollection<Teachers> Teachers{get;set;} = new List<Teachers>();

        public subjects(){}
        public subjects(int id, string name){
            Id = id;
            Name = name;
        }
    }
}