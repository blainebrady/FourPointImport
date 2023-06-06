using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FourPointImport.Data
{
    public class billingDetail : IImport
    {
        public virtual int id { get; set; }
        public virtual bool Archive { get; set; }
        public virtual DateTimeOffset CreateOn { get; set; }
        public virtual DateTimeOffset LastUpdated { get; set; }
        public virtual decimal BDSEQ { get; set; }
        public virtual string BXAGNT { get; set; }
        public virtual string BXBRCH { get; set; }
        public virtual string BXCERT { get; set; }
        public virtual string BXNAME { get; set; }
        public virtual string BXCOVC { get; set; }
        public virtual DateTime BXEFFT { get; set; }
        public virtual DateTime BXFROM { get; set; }
        public virtual DateTime BXTHRU { get; set; }
        public virtual DateTime BXEXPR { get; set; }
        public virtual DateTime BXPAID { get; set; }
        public virtual DateTime BXNEXT { get; set; }
        public virtual string BXNEG01 { get; set; }
        public virtual decimal BXBAMT { get; set; }
        public virtual string BXNEG02 { get; set; }
        public virtual decimal BXCOMM { get; set; }
        public virtual string BXNEG03 { get; set; }
        public virtual decimal BXBGRS { get; set; }
        public virtual string BXNEG04 { get; set; }
        public virtual decimal BXPAMT { get; set; }            //BFAMT
        public virtual string BXNEG05 { get; set; }
        public virtual decimal BXCOMP { get; set; }
        public virtual string BXNEG06 { get; set; }
        public virtual decimal BXPGRS { get; set; }
        public virtual string BXNEG07 { get; set; }
        public virtual decimal BXMOB { get; set; }
        public virtual decimal BXINTR { get; set; }
        public virtual decimal BXINT { get; set; }
        public virtual decimal BXPRIN { get; set; }
        public virtual decimal BXSCHD { get; set; }
        public virtual string BXMSGC { get; set; }
        public virtual string BXMSGD { get; set; }
        public virtual string BXCODE { get; set; }
        public virtual string BXDESC { get; set; }
        public virtual DateTime BXCAND { get; set; }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<billingDetail>().Property(x => x.id);
            modelBuilder.Entity<billingDetail>().Property(x => x.Archive);
            modelBuilder.Entity<billingDetail>().Property(x => x.CreateOn);
            modelBuilder.Entity<billingDetail>().Property(x => x.LastUpdated);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXAGNT).HasMaxLength(10);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXBRCH).HasMaxLength(10);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXCERT).HasMaxLength(20);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXNAME).HasMaxLength(25);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXCOVC).HasMaxLength(30);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXEFFT);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXFROM);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXTHRU);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXEXPR);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXPAID);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXNEXT);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXNEG01).HasMaxLength(1);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXBAMT).HasPrecision(10, 2);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXNEG02).HasMaxLength(1);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXCOMM).HasPrecision(10, 2);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXNEG03).HasMaxLength(1);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXBGRS).HasPrecision(10, 2);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXNEG04).HasMaxLength(1);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXPAMT).HasPrecision(10, 2);           //BFAMT
            modelBuilder.Entity<billingDetail>().Property(x => x.BXNEG05).HasMaxLength(1);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXCOMP).HasPrecision(10, 2);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXNEG06).HasMaxLength(1);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXPGRS).HasPrecision(10, 2);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXNEG07).HasMaxLength(1);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXMOB).HasPrecision(10, 2);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXINTR).HasPrecision(7, 5);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXINT).HasPrecision(7, 5);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXPRIN).HasPrecision(11, 2);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXSCHD).HasPrecision(11, 2);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXMSGC).HasMaxLength(2);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXMSGD).HasMaxLength(25);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXCODE).HasMaxLength(2);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXDESC).HasMaxLength(25);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXCAND);
        }
    }
}
