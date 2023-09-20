using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using PackageProject.Models;
using Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PackageProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IService<Common.DTOs.EmployeeDto> _employeeServices;
        public EmployeeController(IService<Common.DTOs.EmployeeDto> employeeServices)
        {
            _employeeServices = employeeServices;
        }

        // GET: api/<BissnesDayController>
        [HttpGet]
        public Task<List<Common.DTOs.EmployeeDto>> Get()
        {
            return _employeeServices.GetAllAsync();
        }

        // GET api/<BissnesDayController>/5
        [HttpGet("{id}")]
        public Task<Common.DTOs.EmployeeDto> Get(int id)
        {
            return _employeeServices.GetByIdAsync(id);
        }

        // POST api/<BissnesDayController>
        [HttpPost]
        public Task<List<Common.DTOs.EmployeeDto>> Post([FromBody] EmployeePostModel entity)
        {
           return _employeeServices.AddAsync(
               new EmployeeDto()
               {
                   EmployeeId=entity.EmployeeId,
                   LocationX=entity.LocationX,
                   LocationY=entity.LocationY,
                   Address= entity.Address,
                   CompanyEntryDate = DateTime.Today,
                   FirstName= entity.FirstName,
                   LastName = entity.LastName,
                   Mail=entity.Mail,
                   Password=entity.Password,
                   Phone=entity.Phone,
                   UserLevel= 1
               });
        }

        // PUT api/<BissnesDayController>/5
        [HttpPut("{id}")]
        public Task<List<Common.DTOs.EmployeeDto>> Put(int id, [FromBody] EmployeePostModel entity)
        {
            _employeeServices.UpdateAsync(new EmployeeDto()
            {
                EmployeeId = entity.EmployeeId,
                LocationX = entity.LocationX,
                LocationY = entity.LocationY,
                Address = entity.Address,
                CompanyEntryDate = entity.CompanyEntryDate,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Mail = entity.Mail,
                Password = entity.Password,
                Phone = entity.Phone,
                UserLevel = (int)entity.UserLevel
            });
            return _employeeServices.GetAllAsync();
        }

        // DELETE api/<BissnesDayController>/5
        [HttpDelete("{id}")]
        public Task<List<Common.DTOs.EmployeeDto>> Delete(int id)
        {
            return _employeeServices.DeleteAsync(id);
         
        }
    }
}
