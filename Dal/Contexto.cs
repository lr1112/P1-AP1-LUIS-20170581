using Microsoft.EntityFrameworkCore;
using P1_AP1_LUIS_20170581.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_AP1_LUIS_20170581.Dal
{
    public class Contexto : DbContext
        
    {
        public DbSet<Aportes> Aportes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Data\registro.db");
        }

    }
}
