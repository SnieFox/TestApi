using GeneratorProject.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorProject.BLL.Interfaces
{
    public interface IGeneratorService
    {
        Task<(bool IsSuccess, string Message, IEnumerable<GeneratorResponse>? Entities)> GetAllAsync();
        Task<(bool IsSuccess, string Message, GeneratorResponse? Entity)> GetGeneratorByIdAsync(int id);
        Task<(bool IsSuccess, string Message)> AddGeneratorAsync(GeneratorRequest entity);
        Task<(bool IsSuccess, string Message)> UpdateGeneratorAsync(GeneratorRequest entity);
        Task<(bool IsSuccess, string Message)> DeleteGeneratorAsync(GeneratorRequest entity);
        Task<(bool IsSuccess, string Message)> DeleteGeneratorByIdAsync(int id);
    }
}
