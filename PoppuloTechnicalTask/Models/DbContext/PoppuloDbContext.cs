using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoppuloTechnicalTask.Models.InventoryCategory;

namespace PoppuloTechnicalTask.Models.DbContext
{
    public class PoppuloDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public PoppuloDbContext(DbContextOptions<PoppuloDbContext> options):base(options)
        {
                
        }

        public DbSet<InventoryCategory.InventoryItem> InventoryItems { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}
