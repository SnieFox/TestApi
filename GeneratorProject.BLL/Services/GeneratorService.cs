using AutoMapper;
using GeneratorProject.BLL.DTO;
using GeneratorProject.BLL.Interfaces;
using GeneratorProject.DAL.Entities;
using GeneratorProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorProject.BLL.Services
{
    internal class GeneratorService : IGeneratorService
    {
        private readonly IRepository<Generator> _generatorRepository;
        private readonly IMapper _mapper;
        public GeneratorService(IRepository<Generator> repository, IMapper mapper) 
        { 
            _generatorRepository = repository;
            _mapper = mapper;
        }

        public async Task<(bool IsSuccess, string Message)> AddGeneratorAsync(GeneratorRequest entity)
        {
            var generatorMap = _mapper.Map<Generator>(entity);
            if (generatorMap == null)
                return (false, "Mapping failed, object was null");

            var addGenerator = await _generatorRepository.AddAsync(generatorMap);
            if(!addGenerator.IsSuccess)
                return (false, addGenerator.Message);

            return (true, string.Empty);
        }

        public async Task<(bool IsSuccess, string Message)> DeleteGeneratorAsync(GeneratorRequest entity)
        {
            var generatorMap = _mapper.Map<Generator>(entity);
            if (generatorMap == null)
                return (false, "Mapping failed, object was null");

            var deleteGenerator = await _generatorRepository.DeleteAsync(generatorMap);
            if (!deleteGenerator.IsSuccess)
                return (false, deleteGenerator.Message);

            return (true, string.Empty);
        }

        public async Task<(bool IsSuccess, string Message)> DeleteGeneratorByIdAsync(int id)
        {
            var deleteGenerator = await _generatorRepository.DeleteByIdAsync(id);
            if (!deleteGenerator.IsSuccess)
                return (false, deleteGenerator.Message);

            return (true, string.Empty);
        }

        public async Task<(bool IsSuccess, string Message, IEnumerable<GeneratorResponse>? Entities)> GetAllAsync()
        {
            var generators = await _generatorRepository.GetAllAsync();
            if(generators == null)
                return(false, "No generators available", null);

            var generatorsMap = _mapper.Map<IEnumerable<GeneratorResponse>>(generators);
            if(generatorsMap == null)
                return (false, "Mapping failed, object was null", null);

            return (true, string.Empty, generatorsMap);
        }

        public async Task<(bool IsSuccess, string Message, GeneratorResponse? Entity)> GetGeneratorByIdAsync(int id)
        {
            var generator = await _generatorRepository.GetByIdAsync(id);
            if(!generator.IsSuccess)
                return(false, generator.Message, null);

            var generatorMap = _mapper.Map<GeneratorResponse>(generator.Entity);
            if(generatorMap == null)
                return (false, "Mapping failed, object was null", null);

            return(true, string.Empty, generatorMap);

        }

        public async Task<(bool IsSuccess, string Message)> UpdateGeneratorAsync(GeneratorRequest entity)
        {
            var generatorMap = _mapper.Map<Generator>(entity);
            if( generatorMap == null)
                return (false, "Mapping failed, object was null");

            var generatorUpdate = await _generatorRepository.UpdateAsync(generatorMap);
            if (!generatorUpdate.IsSuccess)
                return (false, generatorUpdate.Message);

            return (true, string.Empty);
        }
    }
}
