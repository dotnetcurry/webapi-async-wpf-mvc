using System.Collections.Generic;
using System.Net;
using System.Web.Http;

using APIService.Models;
using APIService.DataAccessRepository;
using System.Web.Http.Description;

namespace APIService.Controllers
{
    public class EmployeeInfoAPIController : ApiController
    {
        private IDataAccessRepository<EmployeeInfo, int> _repository;
        //Inject the DataAccessRepository using Construction Injection 
        public EmployeeInfoAPIController(IDataAccessRepository<EmployeeInfo, int> r)
        {
            _repository = r;
        }
        public IEnumerable<EmployeeInfo> Get()
        {
            return _repository.Get();
        }

        [ResponseType(typeof(EmployeeInfo))]
        public IHttpActionResult Get(int id)
        {
            return Ok (_repository.Get(id)); 
        }

        [ResponseType(typeof(EmployeeInfo))]
        public IHttpActionResult Post(EmployeeInfo emp)
        {
            _repository.Post(emp);
            return Ok(emp);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id ,EmployeeInfo emp)
        {
            _repository.Put(id,emp);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            _repository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
