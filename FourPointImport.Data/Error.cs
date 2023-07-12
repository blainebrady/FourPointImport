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
    public class Error : Base
    {
        public virtual string CfAgnt { get; set; }
        public virtual string CfCert { get; set; }
        public virtual string CfFlag { get; set; }
        public virtual string CfErr { get; set; }
        public virtual string CfProc { get; set; }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Error>().Property(x => x.CfAgnt).IsRequired(false);
            modelBuilder.Entity<Error>().Property(x => x.CfCert).IsRequired(false);
            modelBuilder.Entity<Error>().Property(x => x.CfFlag).IsRequired(false);
            modelBuilder.Entity<Error>().Property(x => x.CfErr).IsRequired(false);
            modelBuilder.Entity<Error>().Property(x => x.CfProc).IsRequired(false);
        }
    }
}
