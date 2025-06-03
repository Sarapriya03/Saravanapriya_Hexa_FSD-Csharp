using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC_TechSolutions.model;

namespace ABC_TechSolutions.dao
{
    public interface IFullTimeEmployee : IEmployee<Employee>
    {
        double Basic { get; set; }
        double Hra { get; set; }
        double Da { get; set; }
        double NetSalary { get; set; }
        double CalculateSalary();
    }
}
