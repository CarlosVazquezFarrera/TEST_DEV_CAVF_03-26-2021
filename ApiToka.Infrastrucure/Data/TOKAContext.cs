using ApiToka.Core.Entites;
using ApiToka.Infrastrucure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiToka.Infrastrucure.Data
{
    public partial class TOKAContext : DbContext
    {
        public TOKAContext()
        {
        }

        public TOKAContext(DbContextOptions<TOKAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbPersonasFisicas> TbPersonasFisicas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TbPersonaFisicaConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
