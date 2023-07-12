using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    [Table("RateDetailLife", Schema = "dbo")]
    public class RateDetailLife : Base
    {
        public virtual string RDTBLE { get; set; }
        public virtual decimal RdBand { get; set; }
        public virtual decimal RdRate { get; set; }
        public virtual decimal RdPrct { get; set; }
        public virtual DateTime RdEfft { get; set; }
        public virtual DateTime RdExpr { get; set; }
        public virtual DateTime RDDATA { get; set; }
        public virtual string RDUSRA { get; set; }
        public virtual DateTime RDDATU { get; set; }
        public virtual string RDUSRU { get; set; }
        public virtual DateTime RDDATC { get; set; }
        public virtual string RDUSRC { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RDTBLE).HasMaxLength(7).IsRequired(false);
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RdBand).HasPrecision(3, 0);
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RdRate).HasPrecision(7, 5);
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RdPrct).HasPrecision(7, 5);
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RdEfft).IsRequired(false);
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RdExpr).IsRequired(false);
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RDDATA).IsRequired(false);
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RDUSRA).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RDDATU).IsRequired(false);
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RDUSRU).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RDDATC).IsRequired(false);
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RDUSRC).HasMaxLength(10).IsRequired(false);
        }
    }
}
