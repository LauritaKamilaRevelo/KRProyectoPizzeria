using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KRProyectoPizzeria.Models;

    public class KRPizzeriaAPIContext : DbContext
    {
        public KRPizzeriaAPIContext (DbContextOptions<KRPizzeriaAPIContext> options)
            : base(options)
        {
        }

        public DbSet<KRProyectoPizzeria.Models.KRPizzeria> KRPizzeria { get; set; } = default!;
    }
