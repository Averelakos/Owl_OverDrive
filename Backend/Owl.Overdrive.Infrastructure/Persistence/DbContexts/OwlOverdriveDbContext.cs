using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Infrastructure.Persistence.DbContexts
{
    public sealed partial class OwlOverdriveDbContext : DbContext
    {
        public OwlOverdriveDbContext(DbContextOptions<OwlOverdriveDbContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableSensitiveDataLogging();
            //.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
        }

    }
}
