using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PackageProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessDayController : ControllerBase
    {
        private readonly IService<Common.DTOs.BusinessDayDto> _businessDayServices;
        public BusinessDayController(IService<Common.DTOs.BusinessDayDto> businessDayServices)
        {
            _businessDayServices = businessDayServices;
        }

        // GET: api/<BissnesDayController>
        [HttpGet]
        public Task<List<Common.DTOs.BusinessDayDto>> Get()
        {
            return _businessDayServices.GetAllAsync();
        }

        // GET api/<BissnesDayController>/5
        [HttpGet("{id}")]
        public Task<Common.DTOs.BusinessDayDto> Get(int id)
        {
            return _businessDayServices.GetByIdAsync(id);
        }

        // POST api/<BissnesDayController>
        [HttpPost]
        public Task<List<Common.DTOs.BusinessDayDto>> Post([FromBody] Common.DTOs.BusinessDayDto entity)
        {
            return _businessDayServices.AddAsync(entity);
        }

        // PUT api/<BissnesDayController>/5
        [HttpPut("{id}")]
        public Task<List<Common.DTOs.BusinessDayDto>> Put(int id, [FromBody] Common.DTOs.BusinessDayDto b)
        {
            return _businessDayServices.UpdateAsync(b);
        }

        // DELETE api/<BissnesDayController>/5
        [HttpDelete("{id}")]
        public Task<List<Common.DTOs.BusinessDayDto>> Delete(int id)
        {
            return _businessDayServices.DeleteAsync(id);
            
        }
    }
}
