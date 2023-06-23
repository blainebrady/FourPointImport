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
    public class RateDetailLife : Import
    {
        public string RDTBLE { get; set; }
        public decimal RdBand { get; set; }
        public decimal RdRate { get; set; }
        public decimal RdPrct { get; set; }
        public DateTime RdEfft { get; set; }
        public DateTime RdExpr { get; set; }
        public DateTime RDDATA { get; set; }
        public string RDUSRA { get; set; }
        public DateTime RDDATU { get; set; }
        public string RDUSRU { get; set; }
        public DateTime RDDATC { get; set; }
        public string RDUSRC { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RateDetailLife>().Property(x => x.Archive);
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RDTBLE).HasMaxLength(7);
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RdBand).HasPrecision(3,0);
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RdRate).HasPrecision(7,5);
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RdPrct).HasPrecision(7,5);
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RdEfft);
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RdExpr);
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RDDATA);
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RDUSRA).HasMaxLength(10);
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RDDATU);
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RDUSRU).HasMaxLength(10);
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RDDATC);
            modelBuilder.Entity<RateDetailLife>().Property(x => x.RDUSRC).HasMaxLength(10);
        }
    }
}
