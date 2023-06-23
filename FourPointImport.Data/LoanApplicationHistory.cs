using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    public class LoanApplicationHistory : Import
    {
        public string LmAgnt { get; set; }
        public string LmCert { get; set; }
        public int LmIdn1 { get; set; }
        public decimal LmIdn2 { get; set; }
        public string LmCalc { get; set; }
        public string LmRegn { get; set; }
        public string LmTerr { get; set; }
        public string LmBrch { get; set; }
        public string LmOffc { get; set; }
        public string LmDeal { get; set; }
        public string LmBen1 { get; set; }
        public string LmBen2 { get; set; }
        public DateTime LmFPay { get; set; }
        public DateTime LmEfft { get; set; }
        public DateTime LmExpr { get; set; }
        public int LmCnlD { get; set; }
        public int LmForm { get; set; }
        public decimal LmTerm { get; set; }
        public decimal LmFreq { get; set; }
        public decimal LmAmnt { get; set; }
        public int LmBall { get; set; }
        public decimal LmSchd { get; set; }
        public decimal LmIntr { get; set; }
        public decimal LmPani { get; set; }
        public decimal LmLine { get; set; }
        public string LmStat { get; set; }
        public string LmSig1 { get; set; }
        public string LmSig2 { get; set; }
        public string LmGuid { get; set; }
        public string LmSts1 { get; set; }
        public string LmSts2 { get; set; }
        public string LmSts3 { get; set; }
        public string LmPrev { get; set; }
        public DateTime LmDatA { get; set; }
        public string LmUsrA { get; set; }
        public decimal LmDatU { get; set; }
        public string LmUsrU { get; set; }
        public decimal LmDatc { get; set; }
        public string LmUsrc { get; set; }
        public decimal LmMntf { get; set; }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.Archive);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmAgnt).HasMaxLength(10);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmCert).HasMaxLength(20);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmIdn1);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmIdn2);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmCalc).HasMaxLength(2);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmRegn).HasMaxLength(10);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmTerr).HasMaxLength(10);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmBrch).HasMaxLength(10);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmOffc).HasMaxLength(10);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmDeal).HasMaxLength(20);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmBen1).HasMaxLength(10);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmBen2).HasMaxLength(25);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmFPay);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmEfft);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmExpr);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmCnlD);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmForm).HasMaxLength(15);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmTerm);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmFreq);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmAmnt).HasPrecision(11, 2);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmBall);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmSchd).HasPrecision(11, 2);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmIntr).HasPrecision(7, 5);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmPani).HasPrecision(11, 2);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmLine).HasPrecision(11, 2);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmStat).HasMaxLength(1);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmSig1).HasMaxLength(1);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmSig2).HasMaxLength(1);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmGuid).HasMaxLength(1);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmSts1).HasMaxLength(1);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmSts2).HasMaxLength(1);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmSts3).HasMaxLength(1);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmPrev).HasMaxLength(20);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmDatA);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmUsrA).HasMaxLength(10);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmDatU);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmUsrU).HasMaxLength(10);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmDatc);
            modelBuilder.Entity<LoanApplicationHistory>().Property(x => x.LmUsrc).HasMaxLength(10);
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
