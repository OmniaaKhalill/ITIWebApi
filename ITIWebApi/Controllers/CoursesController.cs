using ITIWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITIWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        ITIContext _db;
        public CoursesController(ITIContext db)
        {
            _db = db;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var coureses = _db.Courses.ToList();
            if (coureses == null)
            {
                return NotFound();
            }
            return Ok(coureses);

        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var crs = _db.Courses.Find(id);
            if (crs == null)
            {
                return NotFound();
            }
            return Ok(crs);
        }

        // change route ==> "/api/crs/name"
        [HttpGet("{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            var crs = _db.Courses.FirstOrDefault(c=>c.Crs_Name==name);
            if (crs == null)
            {
                return NotFound();
            }
            return Ok(crs);
        }


        [HttpPost]

        public IActionResult AddCourse(Course crs) 
        {
            if (crs == null )
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _db.Entry(crs).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            //_db.Courses.Add(crs);
            _db.SaveChanges();
            return CreatedAtAction("GetById", new {id =crs.Crs_Id},crs);

        }

        [HttpPut("{id:int}")]
        public IActionResult EditCourse(Course crs,int id )
        {
            if (crs == null)
            {
                return BadRequest();
            }
            if (crs.Crs_Id!=id)
            {
                return BadRequest();
            }

            _db.Entry(crs).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //_db.Courses.Update(crs);
            _db.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public IActionResult DeleteCourse(int id)
        {
            var crs = _db.Courses.Find(id);

            if (crs == null)
            {
                return NotFound();
            }
            
            _db.Entry(crs).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _db.SaveChanges();
            return Ok(_db.Courses.ToList());

        }


    }
}
