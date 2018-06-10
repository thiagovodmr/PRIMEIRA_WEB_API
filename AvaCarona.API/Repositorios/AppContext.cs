using AvaCarona.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AvaCarona.API.Repositorios
{
    public class AppContext : DbContext
    {
        public DbSet<Carona> Carona { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Avapool;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaronaColaborador>()
                .HasKey(s => new { s.ColaboradorId, s.CaronaId });

            modelBuilder.Entity<CaronaColaborador>()
                .HasOne(cc => cc.Carona)
                .WithMany(ca => ca.Passageiros)
                .HasForeignKey(cc => cc.CaronaId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

    }
}
