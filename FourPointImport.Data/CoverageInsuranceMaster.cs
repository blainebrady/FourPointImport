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
    public class CoverageInsuranceMaster : Import
    {
        public string CmAgnt { get; set; }
        public string CmCert { get; set; }
        public int CmIDN1 { get; set; }
        public decimal CmIDN2 { get; set; }
        public DateTime CmFPrm { get; set; }
        public DateTime CmEfft { get; set; }
        public DateTime CmExpr { get; set; }
        public int CmTerm { get; set; }
        public decimal CmDays { get; set; }
        public decimal CmAmnt { get; set; }
        public decimal CmBAmt { get; set; }
        public string CmStat { get; set; }
        public decimal CmCovc { get; set; }
        public string CmTble { get; set; }
        public int CmLapD { get; set; }
        public string CmLapR { get; set; }
        public int CmCand { get; set; }
        public string CmCanr { get; set; }
        public string CmPrev { get; set; }
        public DateTime CmData { get; set; }
        public string CMUsrA { get; set; }
        public DateTime CMDatU { get; set; }
        public string CMUsrU { get; set; }
        public DateTime CMDatC { get; set; }
        public string CMUsrC { get; set; }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoverageInsuranceMaster>().Property(x => x.Archive);
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
