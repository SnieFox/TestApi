using GeneratorProject.DAL.DatabaseContext;
using GeneratorProject.DAL.Entities;
using GeneratorProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorProject.DAL.Repository
{
    internal class GeneratorDetailRepository : IRepository<Generator>
    {
        private readonly GeneratorProjectContext _context;
        public GeneratorDetailRepository(GeneratorProjectContext context) => _context = context;

        public async Task<(bool IsSuccess, string Message)> AddAsync(Generator entity)
        {
            _context.Generators.Add(entity);
            var success = await _context.SaveChangesAsync();
            if(success == 0)
            {
                return (false, "Something went wrong when adding to db");
            }
            else
            {
                return (true, string.Empty);
            }
        }

        public async Task<(bool IsSuccess, string Message)> DeleteAsync(Generator entity)
        {
            var dbEntity = await _context.Generators.FindAsync(entity.Id);
            if (dbEntity == null)
                return (false, "No such record in db");

            _context.Generators.Remove(dbEntity);
            var success = await _context.SaveChangesAsync();

            if (success == 0)
            {
                return (false, "Something went wrong when deleting from db");
            }
            else
            {
                return (true, string.Empty);
            }
        }

        //hg
        public async Task<(bool IsSuccess, string Message)> DeleteByIdAsync(int id)
        {
            var dbEntity = await _context.Generators.FirstOrDefaultAsync(e => e.Id == id);
            if(dbEntity == null)
                return (false, "No such record in db");

            _context.Generators.Remove(dbEntity);
            var success = await _context.SaveChangesAsync();

            if (success == 0)
            {
                return (false, "Something went wrong when deleting from db");
            }
            else
            {
                return (true, string.Empty);
            }
        }

        public async Task<IEnumerable<Generator>> GetAllAsync()
        {
            var entities = await _context.Generators.ToListAsync();

            return entities;
        }

        public async Task<(bool IsSuccess, string Message, Generator? Entity)> GetByIdAsync(int id)
        {
            var entity = await _context.Generators.FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null)
                return (false, "No such record in db", null);

            return (true, string.Empty, entity);
        }

        public async Task<(bool IsSuccess, string Message)> UpdateAsync(Generator entity)
        {
            var dbEntity = await _context.Generators.FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (dbEntity == null)
                return (false, "No such record in db");

            dbEntity.Id = entity.Id;
            dbEntity.Name = entity.Name;
            dbEntity.Description = entity.Description;
            dbEntity.Location = entity.Location;

            var success = await _context.SaveChangesAsync();

            if (success == 0)
            {
                return (false, "Something went wrong when updating db");
            }
            else
            {
                return (true, string.Empty);
            }
        }
    }
}
