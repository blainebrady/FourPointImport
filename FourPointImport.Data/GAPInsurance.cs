using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    public class GAPInsurance : Import
    {
        public string GmAgnt { get; set; }
        public string GmCert { get; set; }
        public string GmVIN { get; set; }
        public int GmYear { get; set; }
        public string GmMake { get; set; }
        public string GmModel { get; set; }
        public decimal GmFee { get; set; }
        public decimal GmComR { get; set; }
        public DateTime GmEfft { get; set; }
        public DateTime GmExpr { get; set; }
        public string GmStat { get; set; }
        public DateTime GmSDte { get; set; }
        public DateTime GmDatU { get; set; }
        public string GmUsrU { get; set; }
        public DateTime GmDatA { get; set; }
        public string GmUsrA { get; set; }
        public DateTime GmHstD { get; set; }
        public string GmHstU { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmAgnt).HasMaxLength(10);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmCert).HasMaxLength(20);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmVIN).HasMaxLength(40);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmYear);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmMake).HasMaxLength(40);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmModel).HasMaxLength(40);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmFee).HasPrecision(11, 2);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmComR).HasPrecision(7, 5);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmEfft);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmExpr);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmStat).HasMaxLength(10);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmSDte);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmDatU);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmUsrU).HasMaxLength(10);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmDatA);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmUsrA).HasMaxLength(10);
        }
    }
}
