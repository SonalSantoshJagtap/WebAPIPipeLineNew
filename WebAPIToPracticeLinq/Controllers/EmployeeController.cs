using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIToPracticeLinq.Models;

namespace WebAPIToPracticeLinq.Controllers
{
    
   // [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        LinqPracticeContext db;
        public EmployeeController(LinqPracticeContext _db)
        {
            db = _db;
        }
        [Route("api/GetAllEmployees")]
        [HttpGet]
        public List<Employee> GetAllEmployees()
        {
            List<Employee> emp = db.Employees.ToList();
            return emp;
        }

        [Route("api/GetEmployeeById/{id}")]
        [HttpGet]
        public Employee GetEmployeeById(int id)
        {
           var emp = db.Employees.Find(id);
            return emp;
        }

        [Route("api/Employee/GetEmpWithHighestSal")]
        [HttpGet]
        public List<Employee> GetEmpWithHighestSal()
        {
            List<Employee> lst= db.Employees.Where(e=> e.Salary== null || e.Salary > 80000).ToList();
            return lst;
        }

        [Route("api/Employee/AlphaBeticalNames")]
        [HttpGet]
        public List<Employee> AlphaBeticalNames()
        {
            // List<Employee> lst = db.Employees.OrderBy(e => e.Empname).ToList();

           // Find all employees whose phone numbers are invalid(less than 10 digits long). Hint: Look at Ajay's phone number.Phase 2: Selection & Aggregation
            List<Employee> lst = db.Employees.Where(e => e.MobileNumber == null ||e.MobileNumber.Length !=10).ToList();

            return lst;
        }

        [Route("api/Employee/FindByEmail")]
        [HttpGet]
        public Employee FindByEmail()
        {
            var employee = db.Employees.FirstOrDefault(e => e.EmailAddress== "sham@gamil.com" || e.EmailAddress == null);
            //var employee = db.Employees.First(e => e.EmailAddress == "sham@gamil.com");// Will retrive first matching record if no exists then thow error
            //var employee = db.Employees.SingleOrDefault(e => e.EmailAddress == "sham@gamil.com");// will throw error because it contains more than one matching record
            //var employee = db.Employees.Single(e => e.EmailAddress == "ram@gamil.com"); //Exactly one record must exist if not matched the will throw error.
            return employee;
        }

        [Route("api/CalculateTotalSal")]
        [HttpGet]
        public decimal CalculateTotalSal()
        {
            var e = db.Employees.Sum(e => (decimal ?)e.Salary)??0;
            return e;
        }


    }
}
