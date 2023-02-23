using Microsoft.EntityFrameworkCore;
using WebAPI.Controllers.Models;

namespace BackOffice.Models
{
    public class BackOfficeContext : DbContext
    {
        public BackOfficeContext(DbContextOptions<BackOfficeContext> options)
            : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Qualificacao> Qualificacoes { get; set; }
        public DbSet<QualificacaoPessoa> QualificacoesPessoa { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()
                .HasIndex(p => p.Documento)
                .IsUnique();

            modelBuilder.Entity<Departamento>()
                .HasOne(d => d.Responsavel)
                .WithMany()
                .HasForeignKey(d => d.ResponsavelId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
