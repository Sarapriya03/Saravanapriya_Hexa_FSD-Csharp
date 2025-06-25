using DepartmentDAL.DataAccess;
using DepartmentDAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentDataRepo<Department> _deptRepo;
        public DepartmentController(IDepartmentDataRepo<Department> departmentDataRepo)
        {
            this._deptRepo = departmentDataRepo;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var depts = _deptRepo.GetAllDepartments();
            return Ok(depts);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            var dept = _deptRepo.GetDeptByCode(id);
            return Ok(dept);
        }

        [HttpPost]
        [Route("SaveDept")]
        public IActionResult Post([FromBody] Department newDept)
        {
            _deptRepo.SaveDepartment(newDept);
            return Created(HttpContext.Request.Path, newDept);
        }

        [HttpDelete("DeleteDept/{id}")]
        public IActionResult Delete(int id)
        {
            var dept = _deptRepo.DeleteDepartment(id);
            if (dept is not null)
            {
                _deptRepo.DeleteDepartment(id);
                return Ok(dept);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateDept")]
        public IActionResult Put([FromBody] Department updatedDept)
        {
            var existDept = _deptRepo.GetDeptByCode(updatedDept.DeptCode);
            if (existDept is not null)
            {
                _deptRepo.UpdateDepartment(updatedDept);
                return Accepted(updatedDept);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
