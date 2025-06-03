using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC_TechSolutions.model;

namespace ABC_TechSolutions.dao
{
    public interface IEmployee<T> where T : Employee
    {
        string PrintEmployeeDetails(T employee);
    }
    
}
