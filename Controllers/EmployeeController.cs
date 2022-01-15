using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebApi2.Models;
using WebApi2.DAL.Interfaces;
using WebApi2.DAL.Repositories;
using System.Web.Http.Description;

namespace WebApi2.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        private IGenericRepository<Employee> _db;

        public EmployeeController()
        {
            this._db = new GenericRepository<Employee>(new ApplicationDbContext());
        }
        [HttpGet]
        [Route("GetEmployees")]
        public IEnumerable<Employee> Get()
        {
            return _db.GetAll();
        }

        [ResponseType(typeof(Employee))]
        public IHttpActionResult Post(Employee employee)
        {
            _db.Insert(employee);
            return Ok(employee);
        }

    }
}
