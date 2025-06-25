using EmployeeDAL.DataAccess;
using EmployeeDAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmpProfileDataRepo<EmpProfile> _empProfileDataRepo;
        public EmployeeController(IEmpProfileDataRepo<EmpProfile> empProfileDataRepo)
        {
            this._empProfileDataRepo = empProfileDataRepo;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var empprofiles = _empProfileDataRepo.GetAllEmployees();
            return Ok(empprofiles);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var empProfile = _empProfileDataRepo.GetEmpByCode(id);
            return Ok(empProfile);
        }

        [HttpPost]
        [Route("SaveEmp")]
        public IActionResult Post([FromBody] EmpProfile newEmp)
        {
            _empProfileDataRepo.SaveEmployee(newEmp);
            return Created(HttpContext.Request.Path, newEmp);
        }

        [HttpDelete("DeleteEmp/{id}")]
        public IActionResult Delete(int id)
        {
            var emp = _empProfileDataRepo.GetEmpByCode(id);
            if (emp is not null)
            {
                _empProfileDataRepo.DeleteEmployee(emp);
                return Ok(emp);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateEmp")]
        public IActionResult Put([FromBody] EmpProfile updatedEmp)
        {
            var existEmp = _empProfileDataRepo.GetEmpByCode(updatedEmp.EmpCode);
            if (existEmp is not null)
            {
                _empProfileDataRepo.UpdateEmployee(existEmp);

                return Accepted(updatedEmp);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
