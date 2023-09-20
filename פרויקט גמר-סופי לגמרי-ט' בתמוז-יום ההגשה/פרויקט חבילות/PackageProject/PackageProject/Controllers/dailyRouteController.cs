using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using Repositories.Entities;
using Services.Interface;

namespace PackageProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class dailyRouteController : ControllerBase
    {
        private readonly IService<Common.DTOs.PartialDeliveryDto> _partialDeliveryDto;
        private readonly IService<Common.DTOs.PartialDeliveryToPackageDto> _partialDeliveryToPackageDto;
        private readonly IService<Common.DTOs.BusinessDayDto> _businessDay;

        public dailyRouteController(IService<PartialDeliveryDto> partialDeliveryDto, IService<PartialDeliveryToPackageDto> partialDeliveryToPackageDto, IService<BusinessDayDto> businessDay)
        {
            _partialDeliveryDto = partialDeliveryDto;
            _partialDeliveryToPackageDto = partialDeliveryToPackageDto;
            _businessDay = businessDay;
        }


        // GET: api/<BissnesDayController>
        [HttpGet]
        public async Task<Tuple< List<PartialDeliveryDto>, List<PartialDeliveryToPackageDto>>> Get(int employeeId)
        {
            List<PartialDeliveryDto> partialDeliveries =await _partialDeliveryDto.GetAllAsync();
            List<PartialDeliveryToPackageDto> partialDeliveryToPackages = await _partialDeliveryToPackageDto.GetAllAsync();
            List<BusinessDayDto> businessDayDtos= await _businessDay.GetAllAsync();
            int businessDayId = businessDayDtos.Max(b => b.BusinessDayId);
            var filteredPartialDeliveries = partialDeliveries.Where(p => p.EmployeeId == employeeId && p.BusinessDayId==businessDayId).ToList();
            var filteredPartialDeliveryToPackages = partialDeliveryToPackages.Where(p => filteredPartialDeliveries.Select(fd => fd.PartialDeliveryId).Contains(p.PartialDeliveryId)).ToList();

            return new Tuple<List<PartialDeliveryDto>, List<PartialDeliveryToPackageDto>>(filteredPartialDeliveries, filteredPartialDeliveryToPackages);

        }

        
    }
    
}
