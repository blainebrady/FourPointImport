using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    [Table("AgentMaster", Schema = "dbo")]
    public class AgentMaster : Import
    {
        public string AMHOLD { get; set; }
        public string AMAGNT { get; set; }
        public string AMCNTC { get; set; }
        public string AMAGNY { get; set; }
        public string AMADD1 { get; set; }
        public string AMADD2 { get; set; }
        public string AMCITY { get; set; }
        public string AMSTE { get; set; }
        public string AMZIP { get; set; }
        public string AMRPST { get; set; }
        public int AMPHNE { get; set; }
        public int AMTXID { get; set; }
        public int AMSSNO { get; set; }
        public int AMREP { get; set; }
        public string AMSTAT { get; set; }
        public string AMONLY { get; set; }
        public string AMRTRQ { get; set; }
        public string AMBORQ { get; set; }
        public string AMBILL { get; set; }
        public string AMCLMD { get; set; }
        public string AMMTHD { get; set; }
        public string AMREIN { get; set; }
        public DateTime AMEFFT { get; set; }
        public DateTime AMEXPR { get; set; }
        public DateTime AMDATA { get; set; }
        public string AMUSRA { get; set; }
        public DateTime AMDATU { get; set; }
        public string AMUSRU { get; set; }
        public DateTime AMDATC { get; set; }
        public string AMUSRC { get; set; }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMHOLD).HasMaxLength(10);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMAGNT).HasMaxLength(10);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMCNTC).HasMaxLength(25);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMAGNY).HasMaxLength(25);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMADD1).HasMaxLength(25);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMADD2).HasMaxLength(25);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMCITY).HasMaxLength(25);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMSTE).HasMaxLength(2);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMZIP).HasMaxLength(10);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMRPST).HasMaxLength(2);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMPHNE);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMTXID);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMSSNO);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMREP);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMSTAT).HasMaxLength(1);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMONLY).HasMaxLength(1);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMRTRQ).HasMaxLength(1);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMBORQ).HasMaxLength(1);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMBILL).HasMaxLength(1);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMCLMD).HasMaxLength(1);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMMTHD).HasMaxLength(2);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMREIN).HasMaxLength(7);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMEFFT);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMEXPR);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMDATA);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMUSRA).HasMaxLength(10);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMDATU);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMUSRU).HasMaxLength(10);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMDATC);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMUSRC).HasMaxLength(10);

        }
    }
}
