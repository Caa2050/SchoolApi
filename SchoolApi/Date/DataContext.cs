using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Models;
namespace SchoolApi.Date
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options){}

        public DbSet<Student> Students { get; set; }
        public DbSet<subjects> Subjects { get; set; }
        public DbSet<Teachers> Teachers {get;set;}
        
    }
}