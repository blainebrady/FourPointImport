using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FourPointImport.Data
{
    [Table("BillingDetail", Schema = "dbo")]
    public class BillingDetail : Import
    {
        public string BdAgnt { get; set; }
        public string BdCert { get; set; }
        public int BdSEQ { get; set; }
        public decimal BdCovc  { get; set; }
        public DateTime BdFrom { get; set; }
        public DateTime BdDue { get; set; }
        public decimal BdBill { get; set; }
        public DateTime BdThru { get; set; }
        public DateTime BdPaid { get; set; }
        public  DateTime BdNext { get; set; }
        public decimal BdBAmt { get; set; }
        public decimal BdComm { get; set; }
        public decimal BdPAmt { get; set; }
        public decimal BdPCom { get; set; }
        public decimal BdMOB { get; set; }
        public decimal BdIntr { get; set; }
        public  decimal BdInt { get; set; }
        public decimal BdPrin { get; set; }
        public decimal BdSchd { get; set; }
        public string BdMsgC { get; set; }
        public string BdMsgCD { get; set; }
        public string BdCode { get; set; }
        public string BdDesc { get; set; }
        public DateTime BdData { get; set; }
        public string BdUsrA { get; set; }
        public DateTime BdDatU { get; set; }
        public string BdUsrU { get; set; }
        public DateTime BdDatC { get; set; }
        public string BdUsrC { get; set; }
        public decimal BdPanI { get { return BdInt + BdPrin; } }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillingDetail>().Property(x => x.id);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdAgnt).HasMaxLength(10);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdCert).HasMaxLength(20);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdSEQ).HasPrecision(9,0);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdCovc).HasPrecision(5,0);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdFrom);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdDue);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdBill);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdThru);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdPaid);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdNext);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdBAmt).HasPrecision(11,2);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdComm).HasPrecision(11, 2);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdPCom).HasPrecision(11, 2);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdPAmt).HasPrecision(11, 2);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdMOB).HasPrecision(11, 2);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdIntr).HasPrecision(7, 5);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdInt).HasPrecision(11, 2);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdPrin).HasPrecision(11,2);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdSchd).HasPrecision(11, 2);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdMsgC).HasMaxLength(2);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdMsgCD).HasMaxLength(25);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdCode).HasMaxLength(2);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdDesc).HasMaxLength(25);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdData);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdUsrA).HasMaxLength(10);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdDatU);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdUsrU).HasMaxLength(10);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdDatC);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdUsrC).HasMaxLength(10);
        }
    }
}
