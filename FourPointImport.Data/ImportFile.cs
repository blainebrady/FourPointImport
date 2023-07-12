using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    [Table("ImportFile", Schema = "dbo")]
    public class ImportFile : Base
    {
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
        public virtual decimal BXPAMT { get; set; }
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
            modelBuilder.Entity<ImportFile>().Property(x => x.BXAGNT).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXBRCH).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXCERT).HasMaxLength(20).IsRequired(false);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXNAME).HasMaxLength(25).IsRequired(false);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXCOVC).HasMaxLength(30).IsRequired(false);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXEFFT).IsRequired(false);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXFROM).IsRequired(false);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXTHRU).IsRequired(false);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXEXPR).IsRequired(false);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXPAID).IsRequired(false);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXNEXT).IsRequired(false);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXNEG01).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXBAMT).HasPrecision(10, 2);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXNEG02).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXCOMM).HasPrecision(10, 2);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXNEG03).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXBGRS).HasPrecision(10, 2);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXNEG04).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXPAMT).HasPrecision(10, 2);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXNEG05).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXCOMP).HasPrecision(10, 2);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXNEG06).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXPGRS).HasPrecision(10, 2);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXNEG07).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXMOB).HasPrecision(10, 2);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXINTR).HasPrecision(7, 5);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXINT).HasPrecision(11, 2);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXPRIN).HasPrecision(11, 2);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXSCHD).HasPrecision(11, 2);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXMSGC).HasMaxLength(2).IsRequired(false);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXMSGD).HasMaxLength(25).IsRequired(false);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXCODE).HasMaxLength(2).IsRequired(false);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXDESC).HasMaxLength(25).IsRequired(false);
            modelBuilder.Entity<ImportFile>().Property(x => x.BXCAND).IsRequired(false);
        }
    }
}
