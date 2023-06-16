using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace FourPointImport.Data
{
    [Table("BranchOffice", Schema = "dbo")]
    public class BranchOffice : Import
    {
        public  string BMAGNT { get; set; }
        public  string BMRegn { get; set; }
        public  string BMRNam { get; set; }
        public string BMTerr { get; set; }
        public string BMTNam { get; set; }
        public  string BMBrch { get; set; }
        public string BMBNam { get; set; }
        public string BMOffc { get; set; }
        public string BMONam { get; set; }
        public  DateTime BMDatA { get; set; }
        public  DateTime BMDatU { get; set; }
        public  DateTime BMDatC { get; set; }
        public  string BmUsrA { get; set; }
        public  string BmUsrU { get; set; }
        public  string BmUsrC { get; set; }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BranchOffice>().Property(x => x.Archive);
            modelBuilder.Entity<BranchOffice>().Property(x => x.CreateOn);
            modelBuilder.Entity<BranchOffice>().Property(x => x.LastUpdated);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BMAGNT).HasMaxLength(10);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BMBrch).HasMaxLength(10);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BMRegn).HasMaxLength(10);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BMBNam).HasMaxLength(25);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BMTNam).HasMaxLength(25);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BMOffc).HasMaxLength(10);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BMONam).HasMaxLength(25);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BMDatA);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BMDatU);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BMDatC);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmUsrA).HasMaxLength(10);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmUsrU).HasMaxLength(10);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmUsrA).HasMaxLength(10);
        }
    }
}
