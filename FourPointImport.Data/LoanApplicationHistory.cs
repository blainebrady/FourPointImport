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
    [Table("LoanApplicationHistory", Schema = "dbo")]
    public class LoanApplicationHistory : Base
    {
        public virtual string LmAgnt { get; set; }
        public virtual string LmCert { get; set; }
        public virtual int LmIdn1 { get; set; }
        public virtual decimal LmIdn2 { get; set; }
        public virtual string LmCalc { get; set; }
        public virtual string LmRegn { get; set; }
        public virtual string LmTerr { get; set; }
        public virtual string LmBrch { get; set; }
        public virtual string LmOffc { get; set; }
        public virtual string LmDeal { get; set; }
        public virtual string LmBen1 { get; set; }
        public virtual string LmBen2 { get; set; }
        public virtual DateTime LmFPay { get; set; }
        public virtual DateTime LmEfft { get; set; }
        public virtual DateTime LmExpr { get; set; }
        public virtual int LmCnlD { get; set; }
        public virtual int LmForm { get; set; }
        public virtual decimal LmTerm { get; set; }
        public virtual decimal LmFreq { get; set; }
        public virtual decimal LmAmnt { get; set; }
        public virtual int LmBall { get; set; }
        public virtual decimal LmSchd { get; set; }
        public virtual decimal LmIntr { get; set; }
        public virtual decimal LmPani { get; set; }
        public virtual decimal LmLine { get; set; }
        public virtual string LmStat { get; set; }
        public virtual string LmSig1 { get; set; }
        public virtual string LmSig2 { get; set; }
        public virtual string LmGuid { get; set; }
        public virtual string LmSts1 { get; set; }
        public virtual string LmSts2 { get; set; }
        public virtual string LmSts3 { get; set; }
        public virtual string LmPrev { get; set; }
        public virtual DateTime LmDatA { get; set; }
        public virtual string LmUsrA { get; set; }
        public virtual decimal LmDatU { get; set; }
        public virtual string LmUsrU { get; set; }
        public virtual decimal LmDatc { get; set; }
        public virtual string LmUsrc { get; set; }
        public virtual decimal LmMntf { get; set; }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmAgnt).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmCert).HasMaxLength(20).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmIdn1).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmIdn2).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmCalc).HasMaxLength(2).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmRegn).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmTerr).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmBrch).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmOffc).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmDeal).HasMaxLength(20).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmBen1).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmBen2).HasMaxLength(25).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmFPay).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmEfft).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmExpr).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmCnlD).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmForm).HasMaxLength(15).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmTerm).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmFreq).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmAmnt).HasPrecision(11, 2);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmBall).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmSchd).HasPrecision(11, 2);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmIntr).HasPrecision(7, 5);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmPani).HasPrecision(11, 2);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmLine).HasPrecision(11, 2);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmStat).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmSig1).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmSig2).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmGuid).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmSts1).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmSts2).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmSts3).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmPrev).HasMaxLength(20).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmDatA).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmUsrA).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmDatU).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmUsrU).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmDatc).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmUsrc).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmMntf).HasPrecision(11, 2);
        }
        public static LoanApplicationHistory ImportClass(LoanApplicationMaster instMstp)
        {

            LoanApplicationHistory x_PatHist = new LoanApplicationHistory();
            PropertyInfo[] propInstMstp = instMstp.GetType().GetProperties();
            PropertyInfo[] propInstHstp = x_PatHist.GetType().GetProperties();

            //match the names of the objects
            foreach (var item in propInstMstp)
            {
                var prop = propInstHstp.FirstOrDefault(x => x.Name.ToUpper() == item.Name.ToUpper());
                if (prop != null && item.GetValue(instMstp) != null)
                {
                    // Get the value of the property in instMstp
                    object value = item.GetValue(instMstp);

                    // Set the value of the property in x_INSHSTP
                    prop.SetValue(x_PatHist, value);
                }
            }

            return x_PatHist;
        }
    }
}
