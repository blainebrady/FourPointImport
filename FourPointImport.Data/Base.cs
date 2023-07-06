using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    public class Base : IBase
    {
        public virtual int id { get; set; }
        public virtual DateTimeOffset? Archive { get; set; }
        public virtual DateTimeOffset CreateOn { get; set; }
        public virtual DateTimeOffset? LastUpdated { get; set; }

        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Base>().HasKey(entity => entity.id);
            modelBuilder.Entity<Base>().HasKey(entity => entity.Archive);
            modelBuilder.Entity<Base>().HasKey(entity => entity.CreateOn);
            modelBuilder.Entity<Base>().HasKey(entity => entity.LastUpdated);
        }
    }
}
