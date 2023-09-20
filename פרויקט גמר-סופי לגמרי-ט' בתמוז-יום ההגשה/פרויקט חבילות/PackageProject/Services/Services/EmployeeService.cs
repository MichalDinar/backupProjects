using AutoMapper;
using Common.DTOs;
using Repositories.Entities;
using Repositories.Interface;
using Services.Algoritm;
using Services.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class EmployeeService:IService<EmployeeDto>
    {
        private readonly IRepository<Employee> _repository;
        private readonly IMapper _mapper;
        public EmployeeService(IRepository<Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDto>> AddAsync(EmployeeDto entity)
        {
            Tuple<double,double> res= MyGoogleMapsApi.GetLocation(entity.Address);
            entity.LocationX = (decimal?)res.Item1;
            entity.LocationY = (decimal?)res.Item2;
            var c = await _repository.AddAsync(_mapper.Map<Employee>(entity));
            return _mapper.Map<List<EmployeeDto>>(c);
        }

        public async Task<List<EmployeeDto>> DeleteAsync(int id)
        {
            
            return _mapper.Map<List<EmployeeDto>>(await _repository.DeleteAsync(id));
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            return _mapper.Map<List<EmployeeDto>>(await _repository.GetAllAsync());
        }

        public async Task<EmployeeDto> GetByIdAsync(int id)
        {
            return _mapper.Map<EmployeeDto>(await _repository.GetByIdAsync(id));
        }

        public async Task<List<EmployeeDto>> UpdateAsync(EmployeeDto entity)
        {
            Tuple<double, double> res =MyGoogleMapsApi.GetLocation(entity.Address);
            entity.LocationX = (decimal?)res.Item1;
            entity.LocationY = (decimal?)res.Item2;
            var c=await _repository.UpdateAsync(_mapper.Map<Employee>(entity));
            return _mapper.Map<List<EmployeeDto>>(c);
        }
    }
}
