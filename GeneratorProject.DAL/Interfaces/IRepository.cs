using GeneratorProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorProject.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<(bool IsSuccess, string Message, TEntity? Entity)> GetByIdAsync(int id);
        Task<(bool IsSuccess, string Message)> AddAsync(TEntity entity);
        Task<(bool IsSuccess, string Message)> UpdateAsync(TEntity entity);
        Task<(bool IsSuccess, string Message)> DeleteAsync(TEntity entity);
        Task<(bool IsSuccess, string Message)> DeleteByIdAsync(int id);
    }
}
