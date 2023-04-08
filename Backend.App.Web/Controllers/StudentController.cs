using System.Collections.Generic;
using Backend.App.Data.Sevices;
using Backend.App.Models.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.App.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {

        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
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
