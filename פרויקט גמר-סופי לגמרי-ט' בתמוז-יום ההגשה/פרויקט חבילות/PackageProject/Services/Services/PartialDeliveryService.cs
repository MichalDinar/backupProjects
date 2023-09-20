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
    public class PartialDeliveryService:IService<PartialDeliveryDto>
    {
        private readonly IRepository<PartialDelivery> _repository;
        private readonly IMapper _mapper;
        public PartialDeliveryService(IRepository<PartialDelivery> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<PartialDeliveryDto>> AddAsync(PartialDeliveryDto entity)
        {
            var c = await _repository.AddAsync(_mapper.Map<PartialDelivery>(entity));
            return _mapper.Map<List<PartialDeliveryDto>>(c);
        }

        public async Task<List<PartialDeliveryDto>> DeleteAsync(int id)
        {
            
            return _mapper.Map<List<PartialDeliveryDto>>(await _repository.DeleteAsync(id));
        }

        public async Task<List<PartialDeliveryDto>> GetAllAsync()
        {
            return _mapper.Map<List<PartialDeliveryDto>>(await _repository.GetAllAsync());
        }

        public async Task<PartialDeliveryDto> GetByIdAsync(int id)
        {
            return _mapper.Map<PartialDeliveryDto>(await _repository.GetByIdAsync(id));
        }

        public async Task<List<PartialDeliveryDto>> UpdateAsync(PartialDeliveryDto entity)
        {
            var c=await _repository.UpdateAsync(_mapper.Map<PartialDelivery>(entity));
            return _mapper.Map<List<PartialDeliveryDto>>(c);
        }
    }
}
