using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FourPointImport.Data
{
    [Table("BillingDetail", Schema = "dbo")]
    public class BillingDetail : Base
    {
        public virtual string BdAgnt { get; set; }
        public virtual string BdCert { get; set; }
        public virtual int BdSEQ { get; set; }
        public virtual decimal BdCovc  { get; set; }
        public virtual DateTime BdFrom { get; set; }
        public virtual DateTime BdDue { get; set; }
        public virtual decimal BdBill { get; set; }
        public virtual DateTime BdThru { get; set; }
        public virtual DateTime BdPaid { get; set; }
        public virtual  DateTime BdNext { get; set; }
        public virtual decimal BdBAmt { get; set; }
        public virtual decimal BdComm { get; set; }
        public virtual decimal BdPAmt { get; set; }
        public virtual decimal BdPCom { get; set; }
        public virtual decimal BdMOB { get; set; }
        public virtual decimal BdIntr { get; set; }
        public virtual  decimal BdInt { get; set; }
        public virtual decimal BdPrin { get; set; }
        public virtual decimal BdSchd { get; set; }
        public virtual string BdMsgC { get; set; }
        public virtual string BdMsgCD { get; set; }
        public virtual string BdCode { get; set; }
        public virtual string BdDesc { get; set; }
        public virtual DateTime BdData { get; set; }
        public virtual string BdUsrA { get; set; }
        public virtual DateTime BdDatU { get; set; }
        public virtual string BdUsrU { get; set; }
        public virtual DateTime BdDatC { get; set; }
        public virtual string BdUsrC { get; set; }
        public virtual decimal BdPanI { get { return BdInt + BdPrin; } }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdAgnt).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdCert).HasMaxLength(20).IsRequired(false);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdSEQ).HasPrecision(9,0);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdCovc).HasPrecision(5, 0);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdFrom).IsRequired(false);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdDue).IsRequired(false);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdBill).IsRequired(false);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdThru).IsRequired(false);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdPaid).IsRequired(false);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdNext).IsRequired(false);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdBAmt).HasPrecision(11, 2);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdComm).HasPrecision(11, 2);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdPCom).HasPrecision(11, 2);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdPAmt).HasPrecision(11, 2);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdMOB).HasPrecision(11, 2);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdIntr).HasPrecision(7, 5);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdInt).HasPrecision(11, 2);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdPrin).HasPrecision(11, 2);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdSchd).HasPrecision(11, 2);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdMsgC).HasMaxLength(2).IsRequired(false);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdMsgCD).HasMaxLength(25).IsRequired(false);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdCode).HasMaxLength(2).IsRequired(false);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdDesc).HasMaxLength(25).IsRequired(false);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdData).IsRequired(false);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdUsrA).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdDatU).IsRequired(false);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdUsrU).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdDatC).IsRequired(false);
            modelBuilder.Entity<BillingDetail>().Property(x => x.BdUsrC).HasMaxLength(10).IsRequired(false);
        }
    }
}
