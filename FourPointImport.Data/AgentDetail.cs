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
    public class AgentDetail : Base
    {
        public virtual string ADAGNT { get; set; }
        public virtual decimal ADCOVC { get; set; }
        public virtual string AdTble { get; set; }
        public virtual string AdType { get; set; }
        public virtual string ADCCF { get; set; }
        public virtual decimal ADGLCO { get; set; }
        public virtual decimal ADGL { get; set; }
        public virtual string ADCLM { get; set; }
        public virtual string ADCLMP { get; set; }
        public virtual string ADCLMT { get; set; }
        public virtual DateTime AdEfft { get; set; }
        public virtual DateTime AdExpr { get; set; }
        public virtual decimal AdMxBa { get; set; }
        public virtual decimal AdMxBM { get; set; }
        public virtual decimal AdMnAg { get; set; }
        public virtual decimal AdMxAg { get; set; }
        public virtual decimal AdMnA2 { get; set; }
        public virtual decimal ADMXA2 { get; set; }
        public virtual decimal AdMxTr { get; set; }
        public virtual decimal AdMxCT { get; set; }
        public virtual decimal AdHqML { get; set; }
        public virtual string AdHlth { get; set; }
        public virtual decimal AdLaps { get; set; }
        public virtual decimal ADDINY { get; set; }
        public virtual decimal AdComm { get; set; }
        public virtual decimal AdPRat { get; set; }
        public virtual decimal AdTolP { get; set; }
        public virtual decimal AdTolA { get; set; }
        public virtual decimal ADDATA { get; set; }
        public virtual string ADUSRA { get; set; }
        public virtual decimal ADDATU { get; set; }
        public virtual string ADUSRU { get; set; }
        public virtual decimal ADDATC { get; set; }
        public virtual string ADUSRC { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADAGNT).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADCOVC).HasPrecision(5, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdTble).HasMaxLength(7).IsRequired(false);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdType).HasMaxLength(2).IsRequired(false);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADCCF).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADGLCO).HasPrecision(3, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADGL).HasPrecision(7, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADCLM).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADCLMP).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADCLMT).HasMaxLength(10).IsRequired(false);
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
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdHlth).HasMaxLength(1).IsRequired(false);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdLaps).HasPrecision(3, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADDINY).HasPrecision(3, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdComm).HasPrecision(5, 3);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdPRat).HasPrecision(3, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdTolP).HasPrecision(5, 3);
            modelBuilder.Entity<AgentDetail>().Property(x => x.AdTolA).HasPrecision(11, 2);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADDATA).HasPrecision(14, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADUSRA).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADDATU).HasPrecision(14, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADUSRU).HasMaxLength(10).IsRequired(false);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADDATC).HasPrecision(14, 0);
            modelBuilder.Entity<AgentDetail>().Property(x => x.ADUSRC).HasMaxLength(10).IsRequired(false);
        }

    }
}
