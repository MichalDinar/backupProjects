using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using PackageProject.CommonEzer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PackageProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        //כאן לשנות שיקבל את העזר ולא את הקמן
        private readonly IService<PackageDto> _packageServices;
        public PackageController(IService<Common.DTOs.PackageDto> packageServices)
        {
            _packageServices = packageServices;
        }

        // GET: api/<BissnesDayController>
        [HttpGet]
        public Task<List<Common.DTOs.PackageDto>> Get()
        {
            return _packageServices.GetAllAsync();
        }

        // GET api/<BissnesDayController>/5
        [HttpGet("{id}")]
        public Task<Common.DTOs.PackageDto> Get(int id)
        {
            return _packageServices.GetByIdAsync(id);
        }

        // POST api/<BissnesDayController>
        [HttpPost]
        public Task<List<Common.DTOs.PackageDto>> Post([FromBody]PackagePostModel p)
        {
            
            return _packageServices.AddAsync(new PackageDto
            {
                ClientId = p.ClientId,
                PackageId = p.PackageId,
                ///SourceLocationX = p.SourceLocationX,
                //SourceLocationY = p.SourceLocationY,
                //DestinationLocationX = p.DestinationLocationX,
                //DestinationLocationY = p.DestinationLocationY,
                State = 1,
                //CollectingPointId = p.CollectingPointId,
                AddressSource = p.AddressSource,
                AddressDestination = p.AddressDestination,
                date = DateTime.Today
            }) ; 
        }

        // PUT api/<BissnesDayController>/5
        [HttpPut("{id}")]
        public Task<List<Common.DTOs.PackageDto>> Put(int id, [FromBody] PackagePostModel p)
        {
           return _packageServices.UpdateAsync(new PackageDto 
           {
               ClientId=p.ClientId,
               PackageId=p.PackageId,
               //SourceLocationX=p.SourceLocationX,
               //SourceLocationY=p.SourceLocationY,
               //DestinationLocationX=p.DestinationLocationX,
               //DestinationLocationY=p.DestinationLocationY,
               //State=p.State,
              // CollectingPointId=p.CollectingPointId,
               AddressSource = p.AddressSource,
               AddressDestination=p.AddressDestination
           });
        }

        // DELETE api/<BissnesDayController>/5
        [HttpDelete("{id}")]
        public Task<List<Common.DTOs.PackageDto>> Delete(int id)
        {
            return _packageServices.DeleteAsync(id);
            
        }
    }
}
