using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    [Table("GAPInsurance", Schema = "dbo")]
    public class GAPInsurance : Base
    {
        public virtual string GmAgnt { get; set; }
        public virtual string GmCert { get; set; }
        public virtual string GmVIN { get; set; }
        public virtual int GmYear { get; set; }
        public virtual string GmMake { get; set; }
        public virtual string GmModel { get; set; }
        public virtual decimal GmFee { get; set; }
        public virtual decimal GmComR { get; set; }
        public virtual DateTime GmEfft { get; set; }
        public virtual DateTime GmExpr { get; set; }
        public virtual string GmStat { get; set; }
        public virtual DateTime GmSDte { get; set; }
        public virtual DateTime GmDatU { get; set; }
        public virtual string GmUsrU { get; set; }
        public virtual DateTime GmDatA { get; set; }
        public virtual string GmUsrA { get; set; }
        public virtual DateTime GmHstD { get; set; }
        public virtual string GmHstU { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmAgnt).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmCert).HasMaxLength(20).IsRequired(false);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmVIN).HasMaxLength(40).IsRequired(false);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmYear).IsRequired(false);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmMake).HasMaxLength(40).IsRequired(false);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmModel).HasMaxLength(40).IsRequired(false);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmFee).HasPrecision(11, 2);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmComR).HasPrecision(7, 5);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmEfft).IsRequired(false);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmExpr).IsRequired(false);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmStat).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmSDte).IsRequired(false);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmDatU).IsRequired(false);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmUsrU).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmDatA).IsRequired(false);
            modelBuilder.Entity<GAPInsurance>().Property(x => x.GmUsrA).HasMaxLength(10).IsRequired(false);
        }
    }
}
