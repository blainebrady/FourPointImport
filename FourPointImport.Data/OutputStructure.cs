using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FourPointImport.Data
{
    [Table("OutputStructure", Schema = "dbo")]
    public class OutputStructure : Base
    {
        public virtual int BankNo { get; set; }
        public virtual int SSNo1 { get; set; }
        public virtual string Name1 { get; set; }
        public virtual string Eadr1 { get; set; }
        public virtual string Eadr2 { get; set; }
        public virtual string ECity { get; set; }
        public virtual string ESt { get; set; }
        public virtual string EZip { get; set; }
        public virtual int BrthYY { get; set; }
        public virtual int BrthMM { get; set; }
        public virtual int BrthDD { get; set; }
        public virtual int SSNo2 { get; set; }
        public virtual string Name2 { get; set; }
        public virtual string Eadr12 { get; set; }
        public virtual string Eadr22 { get; set; }
        public virtual string ECity2 { get; set; }
        public virtual string ESt2 { get; set; }
        public virtual string EZip2 { get; set; }
        public virtual int BrthY2 { get; set; }
        public virtual int BrthM2 { get; set; }
        public virtual int BrthD2 { get; set; }
        public virtual int LoanNo { get; set; }
        public virtual int LoanYY { get; set; }
        public virtual int LoanMM { get; set; }
        public virtual int LoanDD { get; set; }
        public virtual int MatrYY { get; set; }
        public virtual int MatrMM { get; set; }
        public virtual int MatrDD { get; set; }
        public virtual string LnType { get; set; }
        public virtual string CkActNo { get; set; }
        public virtual int SignYY { get; set; }
        public virtual int SignMM { get; set; }
        public virtual int SignDD { get; set; }
        public virtual string AHCov { get; set; }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OutputStructure>().Property(x => x.BankNo).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.SSNo1).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.Name1).HasMaxLength(25).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.Eadr1).HasMaxLength(25).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.Eadr2).HasMaxLength(25).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.ECity).HasMaxLength(25).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.ESt).HasMaxLength(2).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.EZip).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.BrthDD).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.BrthMM).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.BrthYY).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.SSNo2).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.Name2).HasMaxLength(25).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.Eadr12).HasMaxLength(25).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.Eadr22).HasMaxLength(25).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.ECity2).HasMaxLength(25).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.ESt2).HasMaxLength(2).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.EZip2).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.BrthD2).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.BrthM2).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.BrthY2).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.LoanNo).HasMaxLength(15).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.LoanDD).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.LoanMM).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.LoanYY).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.MatrDD).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.MatrMM).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.LnType).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.CkActNo).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.SignDD).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.SignMM).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.SignYY).IsRequired(false);
            modelBuilder.Entity<OutputStructure>().Property(x => x.MatrYY).IsRequired(false);
        }
    }
}
