using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    [Table("Confirmation", Schema = "dbo")]
    public class Confirmation : Base
    {
        public virtual string CfAgnt { get; set; }
        public virtual string CfCert { get; set; }
        public virtual string CfFlag { get; set; }
        public virtual string CfErr { get; set; }
        public virtual DateTime CfProc { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Confirmation>().Property(x => x.CfAgnt).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<Confirmation>().Property(x => x.CfCert).HasMaxLength(20).IsRequired(false);
            modelBuilder.Entity<Confirmation>().Property(x => x.CfFlag).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<Confirmation>().Property(x => x.CfErr).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<Confirmation>().Property(x => x.CfProc);
        }
    }
}
