using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Algoritm;
using Services.Interface;
using Services.Services;
using System.Drawing;
using System.Runtime.InteropServices;

namespace PackageProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlgorithmController : ControllerBase
    {
        private readonly IAlgorithm _algorithm;
        public AlgorithmController(IAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }


        // POST: api/<AlgorithmController>
        [HttpPost("Algorithm")]
        public Task<int> Post([FromBody] MyDay myDay )
        {
            //Algorithm a = new Algorithm();// (clientService, collectingPointService, employeeService, packageService, partialDeliveryService, partialDeliveryToPackageService, open, close);
            return _algorithm.RunningTheAlgorithm(myDay.Open,myDay.Close);
        }
    }
    
}
