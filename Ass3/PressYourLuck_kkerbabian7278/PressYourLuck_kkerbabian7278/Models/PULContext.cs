using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PressYourLuck.Models
{
    public class PULContext : DbContext
    {
        public PULContext(DbContextOptions options)
              : base(options)
        {
        }

        public DbSet<Audit> Audits { get; set; }
        public DbSet<AuditType> AuditTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //do nothing
            //create without data
        }
    }
}
