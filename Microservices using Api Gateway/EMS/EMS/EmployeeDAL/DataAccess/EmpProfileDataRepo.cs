
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeDAL.Models;
using EmployeeDAL.DataAccess;

namespace EmployeeDAL.DataAccess
{
    public class EmpProfileDataRepo : IEmpProfileDataRepo<EmpProfile>
    {
        public EmpProfile SaveEmployee(EmpProfile empProfile)
        {
            try
            {
                using (EmpContext dbContext = new EmpContext())
                {
                    dbContext.EmpProfiles.Add(empProfile);//This method change track of your entity (Added)
                    dbContext.SaveChanges();//This method observes changed track and build t-sql (insert into...)

                    return empProfile;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public EmpProfile DeleteEmployee(EmpProfile empProfile)
        {
            try
            {
                using (EmpContext dbContext = new EmpContext())
                {
                    dbContext.EmpProfiles.Remove(empProfile);//This method change track of your entity (Removed)
                    dbContext.SaveChanges();//This method observes changed track and build t-sql (delete from...)
                    return empProfile;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public EmpProfile UpdateEmployee(EmpProfile empProfile)
        {
            try
            {
                using (EmpContext dbContext = new EmpContext())
                {
                    var existingEmp = dbContext.EmpProfiles.Where(x => x.EmpCode == empProfile.EmpCode).FirstOrDefault();
                    if (existingEmp != null)
                    {
                        existingEmp.EmpName = empProfile.EmpName;
                      
                        existingEmp.Email = empProfile.Email;
                        existingEmp.DeptCode = empProfile.DeptCode;

                        dbContext.SaveChanges();//This method observes changed track and build t-sql (update EmpProfile set...)
                        return empProfile;
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
        public IEnumerable<EmpProfile> GetAllEmployees()
        {
            try
            {
                using (EmpContext dbContext = new EmpContext())
                {
                    var employees = dbContext.EmpProfiles.ToList();
                    return employees;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public EmpProfile GetEmpByCode(int? empCode)
        {
            try
            {
                using (EmpContext dbContext = new EmpContext())
                {
                    var empByCode = dbContext.EmpProfiles.Where(x => x.EmpCode == empCode).FirstOrDefault();
                    return empByCode;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
