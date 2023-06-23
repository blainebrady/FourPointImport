using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    [Table("Error", Schema = "dbo")]
    public class Error : Import
    {
        public string CfAgnt { get; set; }
        public string CfCert { get; set; }
        public string CfFlag { get; set; }
        public string CfErr { get; set; }
        public string CfProc { get; set; }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Error>().Property(x => x.Archive);
            modelBuilder.Entity<Error>().Property(x => x.CfAgnt);
            modelBuilder.Entity<Error>().Property(x => x.CfCert);
            modelBuilder.Entity<Error>().Property(x => x.CfFlag);
            modelBuilder.Entity<Error>().Property(x => x.CfErr);
            modelBuilder.Entity<Error>().Property(x => x.CfProc);
        }
    }
}
