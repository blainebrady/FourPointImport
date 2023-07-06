using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    [Table("FormMaster", Schema = "dbo")]
    public class FormMaster : Base
    {
        public virtual string FmAGNT { get; set; } // Agent ID Number
        public virtual int FmForm { get; set; } // Form Number
        public virtual string FmDesc { get; set; } // Form Description
        public virtual string FmType { get; set; } // Product Type
        public virtual string FmCalc { get; set; } // Calculation Method
        public virtual string FmLend { get; set; } // Lending Type
        public virtual DateTime FmEfft { get; set; } // Effective Date
        public virtual DateTime FmExpr { get; set; } // Expiration Date
        public virtual DateTime FmDATA { get; set; } // Date Record Added
        public virtual string FmUSRA { get; set; } // User Added Record
        public virtual DateTime FmDATU { get; set; } // Date Record Updated
        public virtual string FmUSRU { get; set; } // User Created Record
        public virtual DateTime FmDATC { get; set; } // Date Record Cancelled
        public virtual string FmUSRC { get; set; } // User Cancelled Record
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormMaster>().Property(x => x.FmAGNT).HasMaxLength(10);
            modelBuilder.Entity<FormMaster>().Property(x => x.FmForm).HasMaxLength(15);
            modelBuilder.Entity<FormMaster>().Property(x => x.FmDesc).HasMaxLength(25);
            modelBuilder.Entity<FormMaster>().Property(x => x.FmType).HasMaxLength(15);
            modelBuilder.Entity<FormMaster>().Property(x => x.FmCalc).HasMaxLength(2);
            modelBuilder.Entity<FormMaster>().Property(x => x.FmLend).HasMaxLength(15);
            modelBuilder.Entity<FormMaster>().Property(x => x.FmEfft);
            modelBuilder.Entity<FormMaster>().Property(x => x.FmExpr);
            modelBuilder.Entity<FormMaster>().Property(x => x.FmDATA);
            modelBuilder.Entity<FormMaster>().Property(x => x.FmUSRA).HasMaxLength(10);
            modelBuilder.Entity<FormMaster>().Property(x => x.FmDATU);
            modelBuilder.Entity<FormMaster>().Property(x => x.FmUSRU).HasMaxLength(10);
            modelBuilder.Entity<FormMaster>().Property(x => x.FmDATC);
            modelBuilder.Entity<FormMaster>().Property(x => x.FmUSRC).HasMaxLength(10);
        }
    }
}
