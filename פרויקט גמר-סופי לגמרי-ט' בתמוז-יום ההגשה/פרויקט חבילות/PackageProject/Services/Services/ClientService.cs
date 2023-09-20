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
    public class ClientService:IService<ClientDto>
    {
        private readonly IRepository<Client> _repository;
        private readonly IMapper _mapper;
        public ClientService(IRepository<Client> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ClientDto>> AddAsync(ClientDto entity)
        {
            var c = await _repository.AddAsync(_mapper.Map<Client>(entity));
            return _mapper.Map<List<ClientDto>>(c);
        }

        public async Task<List<ClientDto>> DeleteAsync(int id)
        {
           
            return _mapper.Map<List<ClientDto>>(await _repository.DeleteAsync(id));
        }

        public async Task<List<Common.DTOs.ClientDto>> GetAllAsync()
        {
            return _mapper.Map<List<ClientDto>>(await _repository.GetAllAsync());
        }

        public async Task<ClientDto> GetByIdAsync(int id)
        {
            return _mapper.Map<ClientDto>(await _repository.GetByIdAsync(id));
        }

        public async Task<List<ClientDto>> UpdateAsync(ClientDto entity)
        {
            var c=await _repository.UpdateAsync(_mapper.Map<Client>(entity));
            return _mapper.Map<List<ClientDto>>(c);
        }
    }
}
