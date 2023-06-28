using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    [Table("AgentDetail", Schema = "dbo")]
    public class AgentDetail : Import
    {
        public string ADAGNT { get; set; }
        public decimal ADCOVC { get; set; }
        public string AdTble { get; set; }
        public string AdType { get; set; }
        public string ADCCF { get; set; }
        public decimal ADGLCO { get; set; }
        public decimal ADGL { get; set; }
        public string ADCLM { get; set; }
        public string ADCLMP { get; set; }
        public string ADCLMT { get; set; }
        public DateTime AdEfft { get; set; }
        public DateTime AdExpr { get; set; }
        public decimal AdMxBa { get; set; }
        public decimal AdMxBM { get; set; }
        public decimal AdMnAg { get; set; }
        public decimal AdMxAg { get; set; }
        public decimal AdMnA2 { get; set; }
        public decimal ADMXA2 { get; set; }
        public decimal AdMxTr { get; set; }
        public decimal AdMxCT { get; set; }
        public decimal AdHqML { get; set; }
        public string AdHlth { get; set; }
        public decimal AdLaps { get; set; }
        public decimal ADDINY { get; set; }
        public decimal AdComm { get; set; }
        public decimal AdPRat { get; set; }
        public decimal AdTolP { get; set; }
        public decimal AdTolA { get; set; }
        public decimal ADDATA { get; set; }
        public string ADUSRA { get; set; }
        public decimal ADDATU { get; set; }
        public string ADUSRU { get; set; }
        public decimal ADDATC { get; set; }
        public string ADUSRC { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADAGNT).HasMaxLength(10);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADCOVC).HasPrecision(5, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdTble).HasMaxLength(7);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdType).HasMaxLength(2);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADCCF).HasMaxLength(10);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADGLCO).HasPrecision(3, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADGL).HasPrecision(7, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADCLM).HasMaxLength(10);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADCLMP).HasMaxLength(10);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADCLMT).HasMaxLength(10);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdEfft);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdExpr);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdMxBa).HasPrecision(11, 2);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdMxBM).HasPrecision(11, 2);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdMnAg).HasPrecision(3, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdMxAg).HasPrecision(3, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdMnA2).HasPrecision(3, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADMXA2).HasPrecision(3, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdMxTr).HasPrecision(3, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdMxCT).HasPrecision(3, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdHqML).HasPrecision(11, 2);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdHlth).HasMaxLength(1);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdLaps).HasPrecision(3, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADDINY).HasPrecision(3, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdComm).HasPrecision(5, 3);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdPRat).HasPrecision(3, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdTolP).HasPrecision(5, 3);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdTolA).HasPrecision(11, 2);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADDATA).HasPrecision(14, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADUSRA).HasMaxLength(10);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADDATU).HasPrecision(14, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADUSRU).HasMaxLength(10);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADDATC).HasPrecision(14, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADUSRC).HasMaxLength(10);
        }

    }
}
