using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorProject.DAL.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        protected BaseEntity(int id) { Id = id; }
        protected BaseEntity() { }
    }
}
