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
    public class BusinessDayService : IService<BusinessDayDto>
    {
        private readonly IRepository<BusinessDay> _repository;
        private readonly IMapper _mapper;
        public BusinessDayService(IRepository<BusinessDay> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<BusinessDayDto>> AddAsync(BusinessDayDto entity)
        {
            var c = await _repository.AddAsync(_mapper.Map<BusinessDay>(entity));
            return _mapper.Map<List<BusinessDayDto>>(c);
        }

        public async Task<List<BusinessDayDto>> DeleteAsync(int id)
        {
            
            return _mapper.Map<List<BusinessDayDto>>(await _repository.DeleteAsync(id));
        }

        public async Task<List<BusinessDayDto>> GetAllAsync()
        {
            return _mapper.Map<List<BusinessDayDto>>(await _repository.GetAllAsync());
        }

        public async Task<BusinessDayDto> GetByIdAsync(int id)
        {
            return _mapper.Map<BusinessDayDto>(await _repository.GetByIdAsync(id));
        }

        public async Task<List<BusinessDayDto>> UpdateAsync(BusinessDayDto entity)
        {
            var c = await _repository.UpdateAsync(_mapper.Map<BusinessDay>(entity));
            return _mapper.Map<List<BusinessDayDto>>(c);
        }

       
    }
}
