using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC_TechSolutions.model;

namespace ABC_TechSolutions.dao
{
    public class PartTimeEmployee : IPartTimeEmployee
    {
        public double Basic { get; set; }
        public double Da { get; set; }
        public double NetSalary { get; set; }

        public double CalculateSalary()
        {
            Da = 0.05 * Basic;
            NetSalary = Basic + Da;
            return NetSalary;
        }

        public string PrintEmployeeDetails(Employee employee)
        {
            return $"[Part-Time] Code: {employee.EmpCode}, Name: {employee.EmpName}, Email: {employee.Email}, Dept: {employee.DeptName}, Location: {employee.Location}";
        }
    }

}
