using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    [Table("ProductCoverage", Schema = "dbo")]
    public class productCoverage : Base
    {
        public virtual decimal PCCOVC { get; set; }
        public virtual string PCDESC { get; set; }
        public virtual string PCLTYPE { get; set; }
        public virtual string PCSHRT { get; set; }
        public virtual string PCINS { get; set; }
        public virtual string PCCALC { get; set; }
        public virtual string PCSORJ { get; set; }
        public virtual decimal PCCOMM { get; set; }
        public virtual int PCEFFT { get; set; }
        public virtual int PCEXPR { get; set; }
        public virtual DateTime PCDATA { get; set; }
        public virtual string PCUSRA { get; set; }
        public virtual DateTime PCDATU { get; set; }
        public virtual string PCUSRU { get; set; }
        public virtual DateTime PCDATC { get; set; }
        public virtual string PCUSRC { get; set; }
        public virtual bool Archive { get; set; }
        public virtual DateTimeOffset Created { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<productCoverage>().Property(x => x.PCCOVC).HasPrecision(5,0);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCDESC).HasMaxLength(40).IsRequired(false);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCLTYPE).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCSHRT).HasMaxLength(30).IsRequired(false);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCINS).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCCALC).HasMaxLength(2).IsRequired(false);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCSORJ).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCCOMM).HasPrecision(5, 3);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCEFFT).IsRequired(false);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCEXPR).IsRequired(false);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCDATA).IsRequired(false);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCUSRA).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCDATU).IsRequired(false);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCUSRU).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCDATC).IsRequired(false);
            modelBuilder.Entity<productCoverage>().Property(x => x.PCUSRC).HasMaxLength(10).IsRequired(false);
        }
    }
}
