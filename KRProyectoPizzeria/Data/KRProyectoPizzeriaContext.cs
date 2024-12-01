using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KRProyectoPizzeria.Models;

    public class KRProyectoPizzeriaContext : DbContext
    {
        public KRProyectoPizzeriaContext (DbContextOptions<KRProyectoPizzeriaContext> options)
            : base(options)
        {
        }

        public DbSet<KRProyectoPizzeria.Models.KRPizzeria> KRPizzeria { get; set; } = default!;
    }
