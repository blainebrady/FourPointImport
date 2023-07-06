using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FourPointImport.Data
{

    [Table("CoverageInsuranceMaster", Schema = "dbo")]
    public class CoverageInsuranceMaster : Base
    {
        public virtual string CmAgnt { get; set; }
        public virtual string CmCert { get; set; }
        public virtual int CmIDN1 { get; set; }
        public virtual decimal CmIDN2 { get; set; }
        public virtual DateTime CmFPrm { get; set; }
        public virtual DateTime CmEfft { get; set; }
        public virtual DateTime CmExpr { get; set; }
        public virtual int CmTerm { get; set; }
        public virtual decimal CmDays { get; set; }
        public virtual decimal CmAmnt { get; set; }
        public virtual decimal CmBAmt { get; set; }
        public virtual string CmStat { get; set; }
        public virtual decimal CmCovc { get; set; }
        public virtual string CmTble { get; set; }
        public virtual int CmLapD { get; set; }
        public virtual string CmLapR { get; set; }
        public virtual int CmCand { get; set; }
        public virtual string CmCanr { get; set; }
        public virtual string CmPrev { get; set; }
        public virtual DateTime CmData { get; set; }
        public virtual string CMUsrA { get; set; }
        public virtual DateTime CMDatU { get; set; }
        public virtual string CMUsrU { get; set; }
        public virtual DateTime CMDatC { get; set; }
        public virtual string CMUsrC { get; set; }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CmAgnt).HasMaxLength(10);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CmCert).HasMaxLength(20);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CmIDN1).HasPrecision(9,0);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CmIDN2).HasPrecision(9, 0);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CmFPrm);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CmEfft);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CmExpr);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CmTerm).HasPrecision(3, 0);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CmDays).HasPrecision(3, 0);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CmAmnt).HasPrecision(11, 2);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CmBAmt).HasPrecision(11, 2);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CmStat).HasMaxLength(1);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CmCovc).HasPrecision(5, 0);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CmTble).HasMaxLength(7);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CmLapD);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CmLapR).HasMaxLength(25);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CmCand);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CmCanr).HasMaxLength(25);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CmPrev).HasMaxLength(20);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CmData);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CMUsrA).HasMaxLength(10);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CMDatU);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CMUsrU).HasMaxLength(10);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CMDatC);
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.CMUsrC).HasMaxLength(10);
        }
    }
}
