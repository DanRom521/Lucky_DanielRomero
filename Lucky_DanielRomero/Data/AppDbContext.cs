using Lucky_DanielRomero.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lucky_DanielRomero.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Luck> Lucky { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
