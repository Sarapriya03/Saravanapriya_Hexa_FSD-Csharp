using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC_TechSolutions.model;

namespace ABC_TechSolutions.dao
{
    public class FullTimeEmployee : IFullTimeEmployee
    {
        public double Basic { get; set; }
        public double Hra { get; set; }
        public double Da { get; set; }
        public double NetSalary { get; set; }

        public double CalculateSalary()
        {
            Hra = 0.15 * Basic;
            Da = 0.10 * Basic;
            NetSalary = Basic + Hra + Da;
            return NetSalary;
        }

        public string PrintEmployeeDetails(Employee employee)
        {
            return $"[Full-Time] Code: {employee.EmpCode}, Name: {employee.EmpName}, Email: {employee.Email}, Dept: {employee.DeptName}, Location: {employee.Location}";
        }
    }

}
