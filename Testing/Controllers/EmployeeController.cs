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
            using (EmployeeDBEntities ToData = new EmployeeDBEntities())
            {
                return ToData.Employees.ToList();
            }
        }
        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            using (EmployeeDBEntities ToData = new EmployeeDBEntities())
            {
                var entity = ToData.Employees.FirstOrDefault(e => e.ID == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee No found" + id.ToString());
                }
            };
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]Employee value)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    entities.Employees.Add(value);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, value);
                    message.Headers.Location = new Uri(Request.RequestUri + value.ID.ToString());
                    return message;

                };
            }
            catch (Exception exp)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, exp);
                throw;
            }
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
