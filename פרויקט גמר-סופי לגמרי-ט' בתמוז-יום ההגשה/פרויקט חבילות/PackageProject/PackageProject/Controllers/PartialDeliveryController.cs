using Common.DTOs;
using Microsoft.AspNetCore.Mvc;

using Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PackageProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartialDeliveryController : ControllerBase
    {
        private readonly IService<Common.DTOs.PartialDeliveryDto> _partialDeliveryServices;
        public PartialDeliveryController(IService<Common.DTOs.PartialDeliveryDto> partialDeliveryServices)
        {
            
            _partialDeliveryServices = partialDeliveryServices;
        }

        // GET: api/<BissnesDayController>
        [HttpGet]
        public Task<List<Common.DTOs.PartialDeliveryDto>> Get()
        {

            return _partialDeliveryServices.GetAllAsync();
        }

        // GET api/<BissnesDayController>/5
        [HttpGet("{id}")]
        public Task<Common.DTOs.PartialDeliveryDto> Get(int id)
        {
            return _partialDeliveryServices.GetByIdAsync(id);
        }

        // POST api/<BissnesDayController>
        [HttpPost]
        public Task<List<Common.DTOs.PartialDeliveryDto>> Post([FromBody] Common.DTOs.PartialDeliveryDto entity)
        {
            return _partialDeliveryServices.AddAsync(entity);
        }

        // PUT api/<BissnesDayController>/5
        [HttpPut("{id}")]
        public Task<List<Common.DTOs.PartialDeliveryDto>> Put(int id, [FromBody] Common.DTOs.PartialDeliveryDto c)
        {
            return _partialDeliveryServices.UpdateAsync(c);
        }

        // DELETE api/<BissnesDayController>/5
        [HttpDelete("{id}")]
        public Task<List<Common.DTOs.PartialDeliveryDto>> Delete(int id)
        {
             return _partialDeliveryServices.DeleteAsync(id);
            
        }
    }
}
