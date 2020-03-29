using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Desree.Models
{
    public class DesreeDbContext : DbContext
    {
        public DesreeDbContext(DbContextOptions<DesreeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Resume> Resume { get; set; }
    }
}
