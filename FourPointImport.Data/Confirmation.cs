using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    public class Confirmation : Import
    {
        public string CfAgnt { get; set; }
        public string CfCert { get; set; }
        public string CfFlag { get; set; }
        public string CfErr { get; set; }
        public DateTime CfProc { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Confirmation>().Property(x => x.Archive);
            modelBuilder.Entity<Confirmation>().Property(x => x.CfAgnt).HasMaxLength(10);
            modelBuilder.Entity<Confirmation>().Property(x => x.CfCert).HasMaxLength(20);
            modelBuilder.Entity<Confirmation>().Property(x => x.CfFlag).HasMaxLength(1);
            modelBuilder.Entity<Confirmation>().Property(x => x.CfErr).HasMaxLength(10);
            modelBuilder.Entity<Confirmation>().Property(x => x.CfProc);
        }
    }
}
