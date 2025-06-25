using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentDAL.DataAccess
{
    public interface IDepartmentDataRepo<T>
    {
        T SaveDepartment(T dept);
        T DeleteDepartment(int id);

        T UpdateDepartment(T dept);

        T GetDeptByCode(int? dept);

        IEnumerable<T> GetAllDepartments();

    }
}
