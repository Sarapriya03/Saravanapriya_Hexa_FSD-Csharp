using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL.DataAccess
{
    public interface IEmpProfileDataRepo<T>
    {
        T SaveEmployee(T empProfile);
        T DeleteEmployee(T empProfile);

        T UpdateEmployee(T empProfile);

        T GetEmpByCode(int? empCode);

        IEnumerable<T> GetAllEmployees();


    }
}
