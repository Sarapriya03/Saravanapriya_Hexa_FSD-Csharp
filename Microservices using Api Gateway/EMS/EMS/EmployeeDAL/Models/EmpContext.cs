using EmployeeDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Microsoft.EntityFrameworkCore
//Microsoft.EntityFrameworkCore.SqlServer
//Microsoft.EntityFrameworkCore.Tools
namespace EmployeeDAL.Models
{
    public class EmpContext:DbContext
    {
     
        public DbSet<EmpProfile> EmpProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseHelper.GetConnectionString());
            }
        }

        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            //Adding Seed Data
            modelBuilder.Entity<EmpProfile>().HasData(
                new EmpProfile { EmpCode = 100, EmpName = "Scott",Email="scott@gmail.com",DeptCode=1 },
                new EmpProfile { EmpCode = 101, EmpName = "Tiger", Email = "tiger@gmail.com",DeptCode=2 }
                );


        }
    }
}
