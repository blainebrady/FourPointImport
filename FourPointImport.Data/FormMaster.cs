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
    public class FormMaster : Import
    {
        public string FmAGNT { get; set; } // Agent ID Number
        public int FmForm { get; set; } // Form Number
        public string FmDesc { get; set; } // Form Description
        public string FmType { get; set; } // Product Type
        public string FmCalc { get; set; } // Calculation Method
        public string FmLend { get; set; } // Lending Type
        public DateTime FmEfft { get; set; } // Effective Date
        public DateTime FmExpr { get; set; } // Expiration Date
        public DateTime FmDATA { get; set; } // Date Record Added
        public string FmUSRA { get; set; } // User Added Record
        public DateTime FmDATU { get; set; } // Date Record Updated
        public string FmUSRU { get; set; } // User Created Record
        public DateTime FmDATC { get; set; } // Date Record Cancelled
        public string FmUSRC { get; set; } // User Cancelled Record
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
