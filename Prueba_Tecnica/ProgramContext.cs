using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica.Models;

namespace Prueba_Tecnica
{
    public class ProgramContext: DbContext
    {
        public DbSet<Tecnico> Tecnico { get; set; }
        public DbSet<Sucursal> Sucursal { get; set; }
        public DbSet<Elemento> Elemento { get; set; }
        public DbSet<ElementosPorTecnico> ElementosPorTecnico { get; set; }

        public ProgramContext(DbContextOptions<ProgramContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tecnico>(tecnico =>
            {
                tecnico.ToTable("Tecnico");
                tecnico.HasKey(p => p.Codigo);
                tecnico.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
                tecnico.Property(p => p.SueldoBase).IsRequired();

            });

            modelBuilder.Entity<Sucursal>(sucursal =>
            {
                sucursal.ToTable("Sucursal");
                sucursal.HasKey(p => p.Codigo);
                sucursal.Property(p => p.Nombre).IsRequired().HasMaxLength(150);

            });

            modelBuilder.Entity<Elemento>(elemento =>
            {
                elemento.ToTable("Elemento");
                elemento.HasKey(p => p.Codigo);
                elemento.Property(p => p.Nombre).IsRequired().HasMaxLength(150);

            });

            modelBuilder.Entity<ElementosPorTecnico>(ext =>
            {
                ext.ToTable("ElementoPorTecnico");
                ext.HasKey(p => p.Id);
                ext.Property(p => p.CodigoTecnico).IsRequired();
                ext.Property(p => p.CodigoElemento).IsRequired();

            });

        }
    }
}
