
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeDAL.DataAccess;
using DepartmentDAL.Models;
using DeptDAL.Models;
using DepartmentDAL.DataAccess;

namespace EmployeeDAL.DataAccess
{
    public class DepartmentDataRepo : IDepartmentDataRepo<Department>
    {
        public Department SaveDepartment(Department dept)
        {
            try
            {
                using (DeptContext dbContext = new DeptContext())
                {
                    dbContext.Departments.Add(dept);//This method change track of your entity (Added)
                    dbContext.SaveChanges();//This method observes changed track and build t-sql (insert into...)

                    return dept;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public Department DeleteDepartment(int id)
        {
            try
            {
                using (DeptContext dbContext = new DeptContext())
                {
                    var existingDept = dbContext.Departments.Where(x=>x.DeptCode.Equals(id)).FirstOrDefault();
                    dbContext.Departments.Remove(existingDept);//This method change track of your entity (Removed)
                    dbContext.SaveChanges();//This method observes changed track and build t-sql (delete from...)
                    return existingDept;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Department UpdateDepartment(Department dept)
        {
            try
            {
                using (DeptContext dbContext = new DeptContext())
                {
                    var existingDept = dbContext.Departments.Where(x => x.DeptCode == dept.DeptCode).FirstOrDefault();
                    if (existingDept != null)
                    {
                        existingDept.DeptName = dept.DeptName;
                      
                       existingDept.DeptName=dept.DeptName;

                        dbContext.SaveChanges();//This method observes changed track and build t-sql (update EmpProfile set...)
                        return dept;
                    }
                    else
                    {
                        return null;
                    }
                }


            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            try
            {
                using (DeptContext dbContext = new DeptContext())
                {
                    var department = dbContext.Departments.ToList();
                    return department;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Department GetDeptByCode(int? deptCode)
        {
            try
            {
                using (DeptContext dbContext = new DeptContext())
                {
                    var deptByCode = dbContext.Departments.Where(x => x.DeptCode == deptCode).FirstOrDefault();
                    return deptByCode;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
