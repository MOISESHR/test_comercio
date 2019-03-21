using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WBE_NetCore.Models;

namespace WApp_NetCore_v2.Data
{
    public class ComercioDbContext : DbContext
    {
        public ComercioDbContext(DbContextOptions<ComercioDbContext> options): base(options)
        {
        }

        public DbSet<Banco> Banco { get; set; }
        public DbSet<Sucursales> Sucursales { get; set; }
        public DbSet<OrdenPago> OrdenPago { get; set; }

    }
}
