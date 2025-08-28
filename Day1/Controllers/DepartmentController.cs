using Day1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ITIContext context;
        public DepartmentController(ITIContext _context) 
        {
            context = _context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Department>DEptList = context.Department.ToList();
            Console.WriteLine(DEptList);
            return Ok(DEptList);
        }
        //[HttpGet]
        //[Route("{id:int}")]
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            Department dept= context.Department.FirstOrDefault(d=> d.Id == id);
            return Ok(dept);
        }
        [HttpGet]
        [Route("{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            Department dept = context.Department.FirstOrDefault(d=> d.Name.Contains(name));
            return Ok(dept);
        }
        [HttpPost]
        public IActionResult AddDept(Department newDept)
        {
            if (ModelState.IsValid)
            {
                context.Add(newDept);
                context.SaveChanges();
                //return CreatedAtAction("GetAll",newDept);
                return CreatedAtAction("GetById", new {id=newDept.Id},newDept);

            }
            return BadRequest(ModelState);
        }


        [HttpPut("{id:int}")]
        //[HttpPatch]
        public IActionResult Edit(int id,Department updatedDept)
        {

            Department deptFromDB = context.Department.FirstOrDefault(d => d.Id == id);
            if (deptFromDB == null)
            {
                return BadRequest("Invalid ID");

            }

            else if (deptFromDB.Id != updatedDept.Id)
            {
                return BadRequest("ID Must not be changed ");

            }
            deptFromDB.Name = updatedDept.Name;
            deptFromDB.ManagerName = updatedDept.ManagerName;
             context.SaveChanges();
            return NoContent();

        }
        [HttpDelete("{id:int}")]
        public IActionResult Remove(int id)
        {
            try
            {
                Department dept=context.Department.FirstOrDefault(d=>d.Id==id);
                context.Department.Remove(dept);
                context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
