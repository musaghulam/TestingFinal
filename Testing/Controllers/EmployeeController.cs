using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDB;
using System.Web.Http.Cors;

namespace Testing.Controllers
{
    [EnableCorsAttribute("http://localhost:34335", "*","*")]
    public class EmployeeController : ApiController
    {
        // GET api/values
        [HttpGet]
        public HttpResponseMessage Get(string Gender = "all")
        {
            using (EmployeeDBEntities ToData = new EmployeeDBEntities())
            {
                switch (Gender)
                {
                    case "all":
                        return Request.CreateResponse(HttpStatusCode.OK, ToData.Employees.ToList());
                    case "male":
                        return Request.CreateResponse(HttpStatusCode.OK, ToData.Employees.Where(e => e.Gender.ToLower() == "male").ToList());
                    case "female":
                        return Request.CreateResponse(HttpStatusCode.OK, ToData.Employees.Where(e => e.Gender.ToLower() == "female").ToList());
                    default:
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "The Provided Value is not correct" + Gender + "is not correct");
                }
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
        //public void Put(int id, [FromBody]string value)
        //{
        //    using (EmployeeDBEntities ToData = new EmployeeDBEntities())
        //    {

        //    };
        //}

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (EmployeeDBEntities ToData = new EmployeeDBEntities())
                {
                    var result = ToData.Employees.FirstOrDefault(e => e.ID == id);
                    if (result == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with the " + id + "Not Found");
                    }
                    else
                    {
                        ToData.Employees.Remove(result);
                        ToData.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "Employee Deleted");
                    }

                };
            }
            catch (Exception exp)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, exp);
                throw;
            }

        }

        public HttpResponseMessage Put([FromBody]int id, [FromUri]Employee employee)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    var Entity = entities.Employees.FirstOrDefault(e => e.ID == id);

                    if (Entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with ID Not Found" + id.ToString());
                    }
                    else
                    {
                        Entity.FirstName = employee.FirstName;
                        Entity.LastName = employee.LastName;
                        Entity.Gender = employee.Gender;
                        Entity.Salary = employee.Salary;
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, Entity);
                    }
                }

            }
            catch (Exception exp)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, exp);
            }
        }
    }


}
