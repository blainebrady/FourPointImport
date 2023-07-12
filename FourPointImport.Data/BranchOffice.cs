using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace FourPointImport.Data
{
    [Table("BranchOffice", Schema = "dbo")]
    public class BranchOffice : Base
    {
        public virtual  string BmAgnt { get; set; }
        public virtual  string BmRegn { get; set; }
        public virtual  string BMRNam { get; set; }
        public virtual string BmTerr { get; set; }
        public virtual string BMTNam { get; set; }
        public virtual  string BmBrch { get; set; }
        public virtual string BMBNam { get; set; }
        public virtual string BmOffc { get; set; }
        public virtual string BMONam { get; set; }
        public virtual  DateTime BmDatA { get; set; }
        public virtual  DateTime BmDatU { get; set; }
        public virtual  DateTime BmDatC { get; set; }
        public virtual  string BmUsrA { get; set; }
        public virtual  string BmUsrU { get; set; }
        public virtual  string BmUsrC { get; set; }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmAgnt).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmBrch).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmRegn).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmTerr).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BMBNam).HasMaxLength(25).IsRequired(false);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BMTNam).HasMaxLength(25).IsRequired(false);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmOffc).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BMONam).HasMaxLength(25).IsRequired(false);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmDatA).IsRequired(false);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmDatU).IsRequired(false);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmDatC).IsRequired(false);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmUsrA).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmUsrU).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmUsrA).HasMaxLength(10).IsRequired(false);
        }
    }
}
