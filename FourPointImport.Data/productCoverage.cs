using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    [Table("ProductCoverage", Schema = "dbo")]
    public class productCoverage : Import
    {
        public decimal PCCOVC { get; set; }
        public string PCDESC { get; set; }
        public string PCLTYPE { get; set; }
        public string PCSHRT { get; set; }
        public string PCINS { get; set; }
        public string PCCALC { get; set; }
        public string PCSORJ { get; set; }
        public decimal PCCOMM { get; set; }
        public int PCEFFT { get; set; }
        public int PCEXPR { get; set; }
        public DateTime PCDATA { get; set; }
        public string PCUSRA { get; set; }
        public DateTime PCDATU { get; set; }
        public string PCUSRU { get; set; }
        public DateTime PCDATC { get; set; }
        public string PCUSRC { get; set; }
        public bool Archive { get; set; }
        public DateTimeOffset Created { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<productCoverage>().Property(x => x.Archive);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCCOVC).HasPrecision(5,0);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCDESC).HasMaxLength(40);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCLTYPE).HasMaxLength(10);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCSHRT).HasMaxLength(30);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCINS).HasMaxLength(1);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCCALC).HasMaxLength(2);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCSORJ).HasMaxLength(1);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCCOMM).HasPrecision(5,3);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCEFFT);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCEXPR);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCDATA);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCUSRA).HasMaxLength(10);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCDATU);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCUSRU).HasMaxLength(10);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCDATC);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCUSRC).HasMaxLength(10);
            modelBuilder.Entity<productCoverage>().Property(x => x.CreateOn);
            modelBuilder.Entity<productCoverage>().Property(x => x.LastUpdated);
        }
    }
}
