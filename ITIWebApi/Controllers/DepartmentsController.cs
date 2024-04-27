using ITIWebApi.DTO;
using ITIWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ITIWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        ITIContext _db;
        public DepartmentsController(ITIContext db)
        {
            _db = db;

        }


        [HttpGet]
        [SwaggerOperation(summary:"get all department" ,description: "get all departments with student number")]
        [SwaggerResponse(200,description:"all department", typeof(List<DeptDTO>))]
        public IActionResult GetAll()
        {
            var departments = _db.Departments.ToList();
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
            var dept = _db.Departments.Find(id);
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
                    Dept_Manager = dept.Dept_ManagerNavigation==null? "no manger found":  dept.Dept_ManagerNavigation.Ins_Name,
                    Manager_hiredate = dept.Manager_hiredate,
                    Students_Count = dept.Students.Count,

                };

                return Ok(deptDto);
            }

            // change route ==> "/api/crs/name"
            /*
            [HttpGet("{name:alpha}")]

            public IActionResult GetByName(string name)
            {
                var dept = _db.Departments.FirstOrDefault(d => d.Dept_Name == name);
                if (dept == null)
                {
                    return NotFound();
                }
                return Ok(dept);
            }


            [HttpPost]

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
                _db.Entry(dept).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                //_db.Courses.Add(crs);
                _db.SaveChanges();
                return CreatedAtAction("GetById", new { id = dept.Dept_Id }, dept);

            }

            [HttpPut("{id:int}")]
            public IActionResult EditCourse(Department dept, int id)
            {
                if (dept == null)
                {
                    return BadRequest();
                }
                if (dept.Dept_Id != id)
                {
                    return BadRequest();
                }

                _db.Entry(dept).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();
                return NoContent();
            }


            [HttpDelete("{id:int}")]
            public IActionResult DeleteDepartment(int id)
            {
                var dept = _db.Departments.Find(id);

                if (dept == null)
                {
                    return NotFound();
                }

                _db.Entry(dept).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _db.SaveChanges();
                return Ok(_db.Departments.ToList());

            }
            */

        }
}   }
