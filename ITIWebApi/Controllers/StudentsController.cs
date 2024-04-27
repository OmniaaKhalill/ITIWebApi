﻿using ITIWebApi.DTO;
using ITIWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITIWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        ITIContext _db;
        public StudentsController(ITIContext db)
        {
            _db = db;

        }


        /// <summary>
        ///   get  all student  
        /// </summary>
        /// <param>  </param>
        /// <returns>  students data </returns>
        /// <remarks>
        /// request example: api/students
        /// </remarks>
        /// 
        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _db.Students.ToList();
            if (students == null)
            {
                return NotFound();
            }
            else
            { 
                List<StudentDTO> studentsDTO = new List<StudentDTO>();

                foreach (var std in students)
                {
                    StudentDTO stdDto = new StudentDTO()
                    {
                        Id = std.St_Id,
                        FullName = std.St_Fname!=null? std.St_Fname:"" + " " +  std.St_Lname ==null? "": std.St_Lname,
                        Address = std.St_Address != null?  std.St_Address:"no address",
                        DepartmentName = std.Dept !=null? std.Dept.Dept_Name:"no department",
                        SupervisorName = std.St_superNavigation == null ? "no  supervisor" :
                        std.St_superNavigation.St_Fname + " " + std.St_superNavigation.St_Lname

                    };
                    studentsDTO.Add(stdDto);
                }
                return Ok(studentsDTO);

            }


        }

        [HttpGet("byPage")]
        public IActionResult GetByPage([FromQuery] int pageNum , [FromQuery] int pageSize )
        {
            var students = _db.Students.ToList();
           

            if (students == null)
            {
                return NotFound();
            }

            else
            {
                int studentsCount = students.Count;
                var totalPages= (int)Math.Ceiling((double)studentsCount/pageSize);

                var studentsPerPage = students.Skip((pageNum-1)*pageSize).Take(pageSize);
                List<StudentDTO> studentsDTO = new List<StudentDTO>();

                foreach (var std in studentsPerPage)
                {
                    StudentDTO stdDto = new StudentDTO()
                    {
                        Id = std.St_Id,
                        FullName = std.St_Fname != null ? std.St_Fname : "" + " " + std.St_Lname == null ? "" : std.St_Lname,
                        Address = std.St_Address != null ? std.St_Address : "no address",
                        DepartmentName = std.Dept != null ? std.Dept.Dept_Name : "no department",
                        SupervisorName = std.St_superNavigation == null ? "no  supervisor" :
                        std.St_superNavigation.St_Fname + " " + std.St_superNavigation.St_Lname

                    };
                    studentsDTO.Add(stdDto);
                }
                return Ok(studentsDTO);

            }


        }




        /// <summary>
        ///   get student by id 
        /// </summary>
        /// <param name="id"> student id </param>
        /// <returns>  student data </returns>
        /// <remarks>
        /// request example: api/student/3
        /// </remarks>
        /// 
        [HttpGet("{id:int}")]
        [Produces("application/json")]
        public IActionResult GetById(int id)
        {
          
            var std = _db.Students.Find(id);
            if (std == null)
            {
                return NotFound();
            }
            else
            {
                StudentDTO stdDto = new StudentDTO()
                {
                    Id = std.St_Id,
                    FullName = std.St_Fname != null ? std.St_Fname : "" + " " + std.St_Lname == null ? "" : std.St_Lname,
                    Address = std.St_Address != null ? std.St_Address : "no address",
                    DepartmentName = std.Dept != null ? std.Dept.Dept_Name : "no department",
                    SupervisorName = std.St_superNavigation == null ? "no  supervisor" :
                       std.St_superNavigation.St_Fname + " " + std.St_superNavigation.St_Lname

                };

                return Ok(stdDto);
            }
        }

        // change route ==> "/api/crs/name"
      
        [HttpGet("{name:alpha}")]
        [Produces("application/json")]
        public IActionResult GetByName(string name)
        {
            var std = _db.Students.FirstOrDefault(s => s.St_Fname == name);
            if (std == null)
            {
                return NotFound();
            }
            else
            {
                StudentDTO stdDto = new StudentDTO()
                {
                    Id = std.St_Id,
                    FullName = std.St_Fname != null ? std.St_Fname : "" + " " + std.St_Lname == null ? "" : std.St_Lname,
                    Address = std.St_Address != null ? std.St_Address : "no address",
                    DepartmentName = std.Dept != null ? std.Dept.Dept_Name : "no department",
                    SupervisorName = std.St_superNavigation == null ? "no  supervisor" :
                       std.St_superNavigation.St_Fname + " " + std.St_superNavigation.St_Lname

                };

                return Ok(stdDto);
            }
        }




        [HttpPost]

        [Consumes("application/json")]
      
        public IActionResult AddStudent(Student std)
        {
            if (std == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

         

           // _db.Entry(std).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _db.Students.Add(std);

            _db.SaveChanges();
            return CreatedAtAction("GetById", new { id = std.St_Id }, std);

        }

        [HttpPut("{id:int}")]
        public IActionResult EditCourse(Student std, int id)
        {
            if (std == null)
            {
                return BadRequest();
            }
            if (std.St_Id != id)
            {
                return BadRequest();
            }

            _db.Entry(std).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //_db.Courses.Update(crs);
            _db.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public IActionResult DeleteStudent(int id)
        {
            var std = _db.Students.Find(id);

            if (std == null)
            {
                return NotFound();
            }

            _db.Entry(std).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
          
            _db.SaveChanges();

            var std1 = _db.Students.Find(id);

            if (std1 == null)
            {
                return Ok();
            }
            else return BadRequest();
           

        }

    }
}