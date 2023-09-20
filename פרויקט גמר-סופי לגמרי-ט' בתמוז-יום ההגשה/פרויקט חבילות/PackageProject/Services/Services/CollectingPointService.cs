using AutoMapper;
using Common.DTOs;
using Repositories.Entities;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.DTOs;
using System.Threading.Tasks;
using Services.Algoritm;

namespace Services.Services
{
    public class CollectingPointService:IService<CollectingPointDto>
    {
        private readonly IRepository<CollectingPoint> _repository;
        private readonly IMapper _mapper;
        public CollectingPointService(IRepository<CollectingPoint> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CollectingPointDto>> AddAsync(CollectingPointDto entity)
        {
            Tuple<double, double> res = MyGoogleMapsApi.GetLocation(entity.Address);
            entity.LocationX = (decimal?)res.Item1;
            entity.LocationY = (decimal?)res.Item2;
            var mapped = _mapper.Map<CollectingPoint>(entity);
            var c = await _repository.AddAsync(mapped);
            var lst = _mapper.Map<List<CollectingPointDto>>(c);
            return lst;
        }

        public async Task<List<CollectingPointDto>> DeleteAsync(int id)
        {

            return _mapper.Map<List<CollectingPointDto>>(await _repository.DeleteAsync(id));
        }

        public async Task<List<CollectingPointDto>> GetAllAsync()
        {
            return _mapper.Map<List<CollectingPointDto>>(await _repository.GetAllAsync());
        }

        public async Task<CollectingPointDto> GetByIdAsync(int id)
        {
            return _mapper.Map<CollectingPointDto>(await _repository.GetByIdAsync(id));
        }

        public async Task<List<CollectingPointDto>> UpdateAsync(CollectingPointDto entity)
        {
            //CollectingPointDto collectingPoint =await GetByIdAsync(entity.CollectingPointId);
            //collectingPoint.LocationX = entity.LocationX;
            //collectingPoint.LocationY=entity.LocationY;
            //collectingPoint.State= entity.State;
            //collectingPoint.Address=entity.Address;
            //collectingPoint.PackageId=entity.PackageId;
            //collectingPoint.CollectingPointName=entity.CollectingPointName;
            //collectingPoint.ColPointType=entity.ColPointType;
            Tuple<double, double> res = MyGoogleMapsApi.GetLocation(entity.Address);
            entity.LocationX = (decimal?)res.Item1;
            entity.LocationY = (decimal?)res.Item2;
            var c = await _repository.UpdateAsync(_mapper.Map<CollectingPoint>(entity));
            return  _mapper.Map<List<CollectingPointDto>>(c);
        }
    }
}
