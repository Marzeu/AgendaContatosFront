using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AgendaContatos.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AgendaContatos.Data
{
    public class PessoasContext : DbContext
    {
        public DbSet<Pessoa> Pessoa { get; set; } = default!;
        public DbSet<Contato> Contato { get; set; } = default!;

        public PessoasContext(DbContextOptions<PessoasContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()
                .HasMany(p => p.Contatos)
                .WithOne(c => c.Pessoa)
                .HasForeignKey(c => c.PessoaId)
                .HasPrincipalKey(p => p.Id);
        }
    }
}
