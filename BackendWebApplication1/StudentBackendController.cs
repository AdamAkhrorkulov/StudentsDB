using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentBackendApplicationData;

namespace BackendWebApplication1
{
    [ApiController]
    [Route("[controller]")]
    public class StudentBackendController : ControllerBase
    {

        private readonly ILogger<StudentBackendController> _logger;

        public StudentBackendController(ILogger<StudentBackendController> logger)
        {
            _logger = logger;
        }

        //write a new get method that will get data from db
        [HttpGet(Name = "GetStudentsData")]
        public IEnumerable<Student> GetData()
        {
            var ds = new StudentDataService();
            var res = ds.GetData();
            return res;

        }
        
    }
}
