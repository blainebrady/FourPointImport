using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace FourPointImport.Data
{
    [Table("BranchOffice", Schema = "dbo")]
    public class BranchOffice : Import
    {
        public  string BmAgnt { get; set; }
        public  string BmRegn { get; set; }
        public  string BMRNam { get; set; }
        public string BmTerr { get; set; }
        public string BMTNam { get; set; }
        public  string BmBrch { get; set; }
        public string BMBNam { get; set; }
        public string BmOffc { get; set; }
        public string BMONam { get; set; }
        public  DateTime BmDatA { get; set; }
        public  DateTime BmDatU { get; set; }
        public  DateTime BmDatC { get; set; }
        public  string BmUsrA { get; set; }
        public  string BmUsrU { get; set; }
        public  string BmUsrC { get; set; }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BranchOffice>().Property(x => x.Archive);
            modelBuilder.Entity<BranchOffice>().Property(x => x.CreateOn);
            modelBuilder.Entity<BranchOffice>().Property(x => x.LastUpdated);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmAgnt).HasMaxLength(10);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmBrch).HasMaxLength(10);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmRegn).HasMaxLength(10);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmTerr).HasMaxLength(10);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BMBNam).HasMaxLength(25);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BMTNam).HasMaxLength(25);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmOffc).HasMaxLength(10);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BMONam).HasMaxLength(25);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmDatA);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmDatU);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmDatC);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmUsrA).HasMaxLength(10);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmUsrU).HasMaxLength(10);
            modelBuilder.Entity<BranchOffice>().Property(x => x.BmUsrA).HasMaxLength(10);
        }
    }
}
