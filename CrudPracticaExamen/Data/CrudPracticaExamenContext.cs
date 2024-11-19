using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CapaENT;

namespace CrudPracticaExamen.Data
{
    public class CrudPracticaExamenContext : DbContext
    {
        public CrudPracticaExamenContext (DbContextOptions<CrudPracticaExamenContext> options)
            : base(options)
        {
        }

        public DbSet<CapaENT.ClsPersona> ClsPersona { get; set; } = default!;
    }
}
