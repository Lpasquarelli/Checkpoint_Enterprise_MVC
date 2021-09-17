using CheckpointDigital.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckpointDigital.Database
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options) : base(options) { }


        public DbSet<Usuario> Usuario { get; set; }
    }
}
