using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    [Table("CoverageInsHist", Schema = "dbo")]
    public class CoverageInsHist : Base
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
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CmAgnt).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CmCert).HasMaxLength(20).IsRequired(false);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CmIDN1).HasPrecision(9, 0);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CmIDN2).HasPrecision(9, 0);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CmFPrm);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CmEfft);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CmExpr);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CmTerm).HasPrecision(3, 0);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CmDays).HasPrecision(3, 0);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CmAmnt).HasPrecision(11, 2);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CmBAmt).HasPrecision(11, 2);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CmStat).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CmCovc).HasPrecision(5, 0);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CmTble).HasMaxLength(7).IsRequired(false);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CmLapD);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CmLapR).HasMaxLength(25).IsRequired(false);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CmCand);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CmCanr).HasMaxLength(25).IsRequired(false);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CmPrev).HasMaxLength(20).IsRequired(false);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CmData);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CMUsrA).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CMDatU);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CMUsrU).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CMDatC);
            modelBuilder.Entity<CoverageInsHist>().Property(x => x.CMUsrC).HasMaxLength(10).IsRequired(false);
        }
        public static CoverageInsHist ImportClass(CoverageInsuranceMaster instMstp)
        {

            CoverageInsHist x_CovHist = new CoverageInsHist();
            PropertyInfo[] propInstMstp = instMstp.GetType().GetProperties();
            PropertyInfo[] propInstHstp = x_CovHist.GetType().GetProperties();

            //match the names of the objects
            foreach (var item in propInstMstp)
            {
                var prop = propInstHstp.FirstOrDefault(x => x.Name.ToUpper() == item.Name.ToUpper());
                if (prop != null && item.GetValue(instMstp) != null)
                {
                    // Get the value of the property in instMstp
                    object value = item.GetValue(instMstp);

                    // Set the value of the property in x_INSHSTP
                    prop.SetValue(x_CovHist, value);
                }
            }

            return x_CovHist;
        }
    }
}
