using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    [Table("LoanApplicationMaster", Schema = "dbo")]
    public class LoanApplicationMaster : Base
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
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmAgnt).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmCert).HasMaxLength(20).IsRequired(false);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmIdn1);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmIdn2);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmCalc).HasMaxLength(2).IsRequired(false);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmRegn).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmTerr).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmBrch).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmOffc).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmDeal).HasMaxLength(20).IsRequired(false);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmBen1).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmBen2).HasMaxLength(25).IsRequired(false);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmFPay);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmEfft);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmExpr);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmCnlD);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmForm);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmTerm);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmFreq);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmAmnt).HasPrecision(11, 2);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmBall);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmSchd).HasPrecision(11, 2);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmIntr).HasPrecision(7, 5);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmPani).HasPrecision(11, 2);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmLine).HasPrecision(11, 2);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmStat).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmSig1).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmSig2).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmGuid).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmSts1).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmSts2).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmSts3).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmPrev).HasMaxLength(20).IsRequired(false);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmDatA);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmUsrA).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmDatU);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmUsrU).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmDatc);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmUsrc).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<LoanApplicationMaster>().Property(x => x.LmMntf).HasPrecision(11, 2);
        }
    }
}
