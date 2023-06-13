using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    public class Import : IImport
    {
        public int id { get; set; }
        public bool Archive { get; set; }
        public DateTimeOffset CreateOn { get; set; }
        public DateTimeOffset LastUpdated { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Import>().Property(x => x.id);
            modelBuilder.Entity<Import>().Property(x => x.Archive);
            modelBuilder.Entity<Import>().Property(x => x.CreateOn);
            modelBuilder.Entity<Import>().Property(x => x.LastUpdated);
        }
    }
}
