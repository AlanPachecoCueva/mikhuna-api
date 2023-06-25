using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace MikhunaAPI.Models
{
    public partial class MikhunaDB : DbContext
    {
        public MikhunaDB()
            : base("name=MikhunaDB")
        {
        }

        public DbSet<Calificacions> Calificacions { get; set; }
        public DbSet<Comentarios> Comentarios { get; set; }
        public DbSet<Favoritos> Favoritos { get; set; }
        public DbSet<Ingredientes> Ingredientes { get; set; }
        public DbSet<Pasos> Pasos { get; set; }
        public DbSet<Recetas> Recetas { get; set; }
        public DbSet<RecetasTerminadas> RecetasTerminadas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
