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
        public virtual string EMPGM { get; set; }
        public virtual string EMERR { get; set; }
        public virtual string EMDESC { get; set; }
        public virtual decimal EMSEVR { get; set; }
        public virtual string EMDATA{ get; set; }
        public virtual string EMUSRA { get; set; }
        public virtual string EMTYPE { get; set; }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Error>().Property(x => x.EMPGM).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<Error>().Property(x => x.EMERR).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<Error>().Property(x => x.EMDESC).HasMaxLength(100).IsRequired(false);
            modelBuilder.Entity<Error>().Property(x => x.EMSEVR).HasPrecision(3,0);
            modelBuilder.Entity<Error>().Property(x => x.EMDATA).HasPrecision(14,0);
            modelBuilder.Entity<Error>().Property(x => x.EMUSRA).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<Error>().Property(x => x.EMTYPE).HasMaxLength(10).IsRequired(false);
        }
    }
}
