using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrincaBackEnd.Models.Entities;

namespace TrincaBackEnd.Repositories
{
    public class ChurrasDbContext : DbContext
    {
        public DbSet<Churras> Churras { get; set; }
        public DbSet<Participante> Participantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-VLIPT72;Initial Catalog=TRINCA_Churras;Integrated Security=True");
        }
    }
}
