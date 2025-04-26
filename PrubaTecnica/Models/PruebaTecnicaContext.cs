using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PrubaTecnica.Models
{
    public partial class PruebaTecnicaContext : DbContext
    {
        public PruebaTecnicaContext()
        {
        }

        public PruebaTecnicaContext(DbContextOptions<PruebaTecnicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> PRODUCTO { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle("User Id=SYSTEM;Password=12345678;Data Source=localhost:1521/xe");
        }



    }
}