using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ControleFinancas.API.Damain.Models;

namespace ControleFinancas.API.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Usuario> Usuario {get;set;}
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}
    }
}