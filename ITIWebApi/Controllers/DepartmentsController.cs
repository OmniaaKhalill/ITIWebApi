using ITIWebApi.BLL.Interfaces;
using ITIWebApi.DTO;
using ITIWebApi.Models;
using ITIWebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ITIWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        public DepartmentsController(IUnitOfWork unit)
        {
            _unit = unit;

        }


        [HttpGet]
        [SwaggerOperation(summary: "get all department", description: "get all departments with student number")]
        [SwaggerResponse(200, description: "all department", typeof(List<DeptDTO>))]
        public IActionResult GetAll()
        {
            var departments = _unit.DepartmentRepo.GetAll();
            if (departments == null)
            {
                return NotFound();
            }
            else
            {
                List<DeptDTO> departmentsDTO = new List<DeptDTO>();
                foreach (var dept in departments)
                {
                    DeptDTO deptDto = new DeptDTO()
                    {
                        Dept_Id = dept.Dept_Id,
                        Dept_Name = dept.Dept_Name,
                        Dept_Desc = dept.Dept_Desc,
                        Dept_Location = dept.Dept_Location,
                        Dept_Manager = dept.Dept_ManagerNavigation == null ? "no manger found" : dept.Dept_ManagerNavigation.Ins_Name,
                        Manager_hiredate = dept.Manager_hiredate,
                        Students_Count = dept.Students.Count,

                    };

                    departmentsDTO.Add(deptDto);
                }



                return Ok(departmentsDTO);
            }

        }





        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var dept = _unit.DepartmentRepo.GetById(id);
            if (dept == null)
            {
                return NotFound();
            }
            else
            {
                DeptDTO deptDto = new DeptDTO()
                {
                    Dept_Id = dept.Dept_Id,
                    Dept_Name = dept.Dept_Name,
                    Dept_Desc = dept.Dept_Desc,
                    Dept_Location = dept.Dept_Location,
                    Dept_Manager = dept.Dept_ManagerNavigation == null ? "no manger found" : dept.Dept_ManagerNavigation.Ins_Name,
                    Manager_hiredate = dept.Manager_hiredate,
                    Students_Count = dept.Students.Count,

                };

                return Ok(deptDto);
            }


        }




        [HttpPost]
        [Consumes("application/json")]
        public IActionResult AddDepartment(Department dept)
        {
            if (dept == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _unit.DepartmentRepo.Add(dept);
            _unit.DepartmentRepo.Save();

            return CreatedAtAction("GetById", new { id = dept.Dept_Id }, dept);

        }



        [HttpDelete("{id:int}")]
        public IActionResult DeleteDepartment(int id)
        {
            var dept = _unit.DepartmentRepo.GetById(id);

            if (dept == null)
            {
                return NotFound();
            }

            _unit.DepartmentRepo.Delete(id);
            _unit.DepartmentRepo.Save();
            return RedirectToAction("Index");
        }

      

        [HttpGet("{name:alpha}")]

        public IActionResult GetByName(string name)
        {
            var dept = _unit.DepartmentRepo.GetByName(name);
            if (dept == null)
            {
                return NotFound();
            }
            return Ok(dept);
        }
    }

}
