using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ControleFinancas.API.Damain.Models;
using ControleFinancas.API.Data.Mappings;

namespace ControleFinancas.API.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Usuario> Usuario {get;set;}
        public DbSet<Lancamento> Lancamento {get;set;}
        public DbSet<Apagar> Apagar {get;set;} 
        public DbSet<Areceber> Areceber {get;set;}
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new LancamentoMap());
            modelBuilder.ApplyConfiguration(new ApagarMap());
            modelBuilder.ApplyConfiguration(new AreceberMap());
        }
    }
}