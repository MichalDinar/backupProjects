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
    public class PackageService:IService<PackageDto>
    {
        private readonly IRepository<Package> _repository;
        private readonly IMapper _mapper;
        public PackageService(IRepository<Package> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<PackageDto>> AddAsync(PackageDto entity)
        {
            Tuple<double, double> res1 = MyGoogleMapsApi.GetLocation(entity.AddressSource);
            Tuple<double, double> res2 = MyGoogleMapsApi.GetLocation(entity.AddressDestination);
            entity.SourceLocationX = (decimal?)res1.Item1;
            entity.SourceLocationY = (decimal?)res1.Item2;
            entity.DestinationLocationX = (decimal?)res2.Item1;
            entity.DestinationLocationY = (decimal?)res2.Item2;
            var c = await _repository.AddAsync(_mapper.Map<Package>(entity));
            return _mapper.Map<List<PackageDto>>(c);
        }

        public async Task<List<PackageDto>> DeleteAsync(int id)
        {
            
            return _mapper.Map<List<PackageDto>>(await _repository.DeleteAsync(id));
        }

        public async Task<List<PackageDto>> GetAllAsync()
        {
            return _mapper.Map<List<PackageDto>>(await _repository.GetAllAsync());
        }

        public async Task<PackageDto> GetByIdAsync(int id)
        {
            return _mapper.Map<PackageDto>(await _repository.GetByIdAsync(id));
        }

        public async Task<List<PackageDto>> UpdateAsync(PackageDto entity)
        {
            Tuple<double, double> res1 = MyGoogleMapsApi.GetLocation(entity.AddressSource);
            Tuple<double, double> res2 = MyGoogleMapsApi.GetLocation(entity.AddressDestination);
            entity.SourceLocationX = (decimal?)res1.Item1;
            entity.SourceLocationY = (decimal?)res1.Item2;
            entity.DestinationLocationX = (decimal?)res2.Item1;
            entity.DestinationLocationY = (decimal?)res2.Item2;
            var c=await _repository.UpdateAsync(_mapper.Map<Package>(entity));
            return _mapper.Map<List<PackageDto>>(c);
        }
    }
}
