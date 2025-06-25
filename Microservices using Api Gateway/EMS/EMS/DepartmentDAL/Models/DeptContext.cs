using DepartmentDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Microsoft.EntityFrameworkCore
//Microsoft.EntityFrameworkCore.SqlServer
//Microsoft.EntityFrameworkCore.Tools
namespace DeptDAL.Models
{
    public class DeptContext:DbContext
    {
     
        public DbSet<Department> Departments { get; set; }

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
            modelBuilder.Entity<Department>().HasData(
                new Department { DeptCode=1,DeptName="Hr" },
                new Department { DeptCode=2,DeptName="Accounts" }
                );


        }
    }
}
