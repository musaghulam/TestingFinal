using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDB;
 

namespace Testing.Controllers
{
    public class EmployeeController : ApiController
    {
       
        // GET api/values
        public IEnumerable<Employee> Get()
        {
            using(EmployeeDBEntities ToData = new EmployeeDBEntities())
            {
                return ToData.Employees.ToList();
            }           
        }

        
        // GET api/values/5
        public Employee Get(int id)
        {
           using(EmployeeDBEntities ToData = new EmployeeDBEntities())
            {
                return ToData.Employees.FirstOrDefault(e => e.ID == id);
            };
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            using (EmployeeDBEntities ToData = new EmployeeDBEntities())
            {
                 
            };
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            using (EmployeeDBEntities ToData = new EmployeeDBEntities())
            {
                
            };
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            using (EmployeeDBEntities ToData = new EmployeeDBEntities())
            {
                 
            };
        }
    }
}
