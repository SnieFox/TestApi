using GeneratorProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeneratorProject.DAL.DatabaseContext
{
    public class GeneratorProjectContext : DbContext
    {
        public GeneratorProjectContext(DbContextOptions<GeneratorProjectContext> options)
            : base(options) { }

        public virtual DbSet<Generator> Generators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Generator>(entity =>
            {
                entity.ToTable("Generators");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name);
                entity.Property(e => e.Description);
                entity.Property(e => e.Location);
            });
        }
    }
}
