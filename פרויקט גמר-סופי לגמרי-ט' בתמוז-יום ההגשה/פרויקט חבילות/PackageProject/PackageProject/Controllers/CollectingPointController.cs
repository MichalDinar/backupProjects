using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using PackageProject.CommonEzer;
using Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PackageProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectingPointController : ControllerBase
    {
        private readonly IService<Common.DTOs.CollectingPointDto> _CollectingPointServices;
        public CollectingPointController(IService<Common.DTOs.CollectingPointDto> CollectingPointServices)
        {
            _CollectingPointServices = CollectingPointServices;
        }

        // GET: api/<CollectingPointController>
        [HttpGet]
        public Task<List<Common.DTOs.CollectingPointDto>> Get()
        {
            return _CollectingPointServices.GetAllAsync();
        }

        // GET api/<CollectingPointController>/5
        [HttpGet("{id}")]
        public Task<Common.DTOs.CollectingPointDto> Get(int id)
        {
            return _CollectingPointServices.GetByIdAsync(id);
        }

        // POST api/<CollectingPointController>
        [HttpPost]
        public Task<List<Common.DTOs.CollectingPointDto>> Post([FromBody] CollectingPointPostModel entity)
        {
            return _CollectingPointServices.AddAsync(new CollectingPointDto() 
            { 
                Address= entity.Address,
                CollectingPointId= entity.CollectingPointId,
                CollectingPointName= entity.CollectingPointName,
                ColPointType= (CollctingPointType)entity.ColPointType,
                LocationX=entity.LocationX,
                LocationY=entity.LocationY,
                PackageId=entity.PackageId,
                State=1
            });
        }

        // PUT api/<CollectingPointController>/5
        [HttpPut("{id}")]
        public Task<List<Common.DTOs.CollectingPointDto>> Put(int id, [FromBody] CollectingPointPostModel entity)
        {
            return _CollectingPointServices.UpdateAsync(new CollectingPointDto()
            {
                Address = entity.Address,
                CollectingPointId = entity.CollectingPointId,
                CollectingPointName = entity.CollectingPointName,
                ColPointType = CollctingPointType.collectingPoint,
                LocationX = entity.LocationX,
                LocationY = entity.LocationY,
                PackageId=entity.PackageId,
                State = 1

            });
        }

        // DELETE api/<CollectingPointController>/5
        [HttpDelete("{id}")]
        public Task<List<Common.DTOs.CollectingPointDto>> Delete(int id)
        {
            return _CollectingPointServices.DeleteAsync(id);

        }
    }
}
