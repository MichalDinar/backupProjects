using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PackageProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartialDeliveryToPackageController : ControllerBase
    {
        private readonly IService<Common.DTOs.PartialDeliveryToPackageDto> _PartialDeliveryToPackageServices;
        public PartialDeliveryToPackageController(IService<Common.DTOs.PartialDeliveryToPackageDto> PartialDeliveryToPackageServices)
        {
            _PartialDeliveryToPackageServices = PartialDeliveryToPackageServices;
        }

        // GET: api/<PartialDeliveryToPackageController>
        [HttpGet]
        public Task<List<Common.DTOs.PartialDeliveryToPackageDto>> Get()
        {
            return _PartialDeliveryToPackageServices.GetAllAsync();
        }

        // GET api/<PartialDeliveryToPackageController>/5
        [HttpGet("{id}")]
        public Task<Common.DTOs.PartialDeliveryToPackageDto> Get(int id)
        {
            return _PartialDeliveryToPackageServices.GetByIdAsync(id);
        }

        // POST api/<PartialDeliveryToPackageController>
        [HttpPost]
        public Task<List<Common.DTOs.PartialDeliveryToPackageDto>> Post([FromBody] Common.DTOs.PartialDeliveryToPackageDto entity)
        {
            return _PartialDeliveryToPackageServices.AddAsync(entity);
        }

        // PUT api/<PartialDeliveryToPackageController>/5
        [HttpPut("{id}")]
        public Task<List<Common.DTOs.PartialDeliveryToPackageDto>> Put(int id, [FromBody] Common.DTOs.PartialDeliveryToPackageDto b)
        {
            return _PartialDeliveryToPackageServices.UpdateAsync(b);
        }

        // DELETE api/<PartialDeliveryToPackageController>/5
        [HttpDelete("{id}")]
        public Task<List<Common.DTOs.PartialDeliveryToPackageDto>> Delete(int id)
        {
            return _PartialDeliveryToPackageServices.DeleteAsync(id);

        }
    }
}
