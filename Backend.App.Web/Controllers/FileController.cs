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
    public class FileController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;

        public FileController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

       

        [HttpGet(Name = "GetData")]
        public string GetData()
        {
            _logger.LogInformation("Started");

            return System.IO.File.ReadAllText(@"C:\Users\Adam\Desktop\Homework.txt");
        }
     
    }
}