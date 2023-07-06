using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    [Table("RateMaster", Schema = "dbo")]
    public class RateMaster : Base
    {
        public virtual string RmTble { get; set; }
        public virtual string RmDesc { get; set; }
        public virtual string RmShrt { get; set; }
        public virtual decimal RmBase { get; set; }
        public virtual DateTime RmEfft { get; set; }
        public virtual DateTime RmExpr { get; set; }
        public virtual DateTime RmDATA { get; set; }
        public virtual string RmUSRA { get; set; }
        public virtual DateTime RmDATU { get; set; }
        public virtual string RmUSRU { get; set; }
        public virtual DateTime RmDATC { get; set; }
        public virtual string RmUSRC { get; set; }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RateMaster>().Property(x => x.RmTble).HasMaxLength(7);
            modelBuilder.Entity<RateMaster>().Property(x => x.RmDesc).HasMaxLength(40);
            modelBuilder.Entity<RateMaster>().Property(x => x.RmShrt).HasMaxLength(10);
            modelBuilder.Entity<RateMaster>().Property(x => x.RmBase).HasPrecision(7, 2);
            modelBuilder.Entity<RateMaster>().Property(x => x.RmEfft);
            modelBuilder.Entity<RateMaster>().Property(x => x.RmExpr);
            modelBuilder.Entity<RateMaster>().Property(x => x.RmDATA);
            modelBuilder.Entity<RateMaster>().Property(x => x.RmUSRA).HasMaxLength(10);
            modelBuilder.Entity<RateMaster>().Property(x => x.RmDATU);
            modelBuilder.Entity<RateMaster>().Property(x => x.RmUSRU).HasMaxLength(10);
            modelBuilder.Entity<RateMaster>().Property(x => x.RmDATC);
            modelBuilder.Entity<RateMaster>().Property(x => x.RmUSRC).HasMaxLength(10);
        }
    }
}
