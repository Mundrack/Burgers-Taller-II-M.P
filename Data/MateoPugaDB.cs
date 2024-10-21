using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MateoPugaProyectoII.Models;

    public class MateoPugaDB : DbContext
    {
        public MateoPugaDB (DbContextOptions<MateoPugaDB> options)
            : base(options)
        {
        }

        public DbSet<MateoPugaProyectoII.Models.Burger> Burger { get; set; } = default!;
    }
