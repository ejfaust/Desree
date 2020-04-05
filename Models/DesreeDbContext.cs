using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Desree.Models
{
    public class DesreeDbContext : DbContext
    {
        public DesreeDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ResumeDb;Integrated Security=True");
        }

        public DbSet<Resume> Resume { get; set; }
    }
}
