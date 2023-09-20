using AutoMapper;
using Common.DTOs;
using Repositories.Entities;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PartialDeliveryToPackageService:IService<PartialDeliveryToPackageDto>
    {
        private readonly IRepository<PartialDeliveryToPackage> _repository;
        private readonly IMapper _mapper;
        public PartialDeliveryToPackageService(IRepository<PartialDeliveryToPackage> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<PartialDeliveryToPackageDto>> AddAsync(PartialDeliveryToPackageDto entity)
        {
            var c = await _repository.AddAsync(_mapper.Map<PartialDeliveryToPackage>(entity));
            return _mapper.Map<List<PartialDeliveryToPackageDto>>(c);
        }

        public async Task<List<PartialDeliveryToPackageDto>> DeleteAsync(int id)
        {

            return _mapper.Map<List<PartialDeliveryToPackageDto>>(await _repository.DeleteAsync(id));
        }

        public async Task<List<PartialDeliveryToPackageDto>> GetAllAsync()
        {
            return _mapper.Map<List<PartialDeliveryToPackageDto>>(await _repository.GetAllAsync());
        }

        public async Task<PartialDeliveryToPackageDto> GetByIdAsync(int id)
        {
            return _mapper.Map<PartialDeliveryToPackageDto>(await _repository.GetByIdAsync(id));
        }

        public async Task<List<PartialDeliveryToPackageDto>> UpdateAsync(PartialDeliveryToPackageDto entity)
        {
            var c = await _repository.UpdateAsync(_mapper.Map<PartialDeliveryToPackage>(entity));
            return _mapper.Map<List<PartialDeliveryToPackageDto>>(c);
        }
    }
}
