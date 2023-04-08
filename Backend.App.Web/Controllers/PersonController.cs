using System.Collections.Generic;
using Backend.App.Data.Sevices;
using Backend.App.Models.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Backend.App.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        //write a new get method that will get data from db
        [HttpGet(Name = "GetDbData")]
        public IEnumerable<Person> GetData()
        {
            var config = new ConfigurationBuilder();
            var ds = new PersonDataService();
            var res = ds.GetData();
            return res;

        }
        //create new studentController
        //GetStudentData, will get data from db. 
        //create StudentDataService = 
        //create Student class in models project
    }
}