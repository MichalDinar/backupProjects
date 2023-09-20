using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PackageProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IService<Common.DTOs.ClientDto> _clientServices;
        public ClientController(IService<Common.DTOs.ClientDto> clientServices)
        {
            _clientServices = clientServices;
        }

        // GET: api/<BissnesDayController>
        [HttpGet]
        public Task<List<Common.DTOs.ClientDto>> Get()
        {
            return _clientServices.GetAllAsync();
        }

        // GET api/<BissnesDayController>/5
        [HttpGet("{id}")]
        public Task<Common.DTOs.ClientDto> Get(int id)
        {
            return _clientServices.GetByIdAsync(id);
        }

        // POST api/<BissnesDayController>
        [HttpPost]
        public Task<List<Common.DTOs.ClientDto>> Post([FromBody] Common.DTOs.ClientDto entity)
        {
            return _clientServices.AddAsync(entity);
        }

        // PUT api/<BissnesDayController>/5
        [HttpPut("{id}")]
        public Task<List<Common.DTOs.ClientDto>> Put(int id, [FromBody] Common.DTOs.ClientDto c)
        {
           return _clientServices.UpdateAsync(c);
        }

        // DELETE api/<BissnesDayController>/5
        [HttpDelete("{id}")]
        public Task<List<Common.DTOs.ClientDto>> Delete(int id)
        {
            return _clientServices.DeleteAsync(id);
            
        }
    }
}
