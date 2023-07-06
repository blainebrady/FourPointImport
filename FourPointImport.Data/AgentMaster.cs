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
    public class AgentMaster : Base
    {
        public virtual string AMHOLD { get; set; }
        public virtual string AMAGNT { get; set; }
        public virtual string AMCNTC { get; set; }
        public virtual string AMAGNY { get; set; }
        public virtual string AMADD1 { get; set; }
        public virtual string AMADD2 { get; set; }
        public virtual string AMCITY { get; set; }
        public virtual string AMSTE { get; set; }
        public virtual string AMZIP { get; set; }
        public virtual string AMRPST { get; set; }
        public virtual int AMPHNE { get; set; }
        public virtual int AMTXID { get; set; }
        public virtual int AMSSNO { get; set; }
        public virtual int AMREP { get; set; }
        public virtual string AMSTAT { get; set; }
        public virtual string AmOnly { get; set; }
        public virtual string AMRTRQ { get; set; }
        public virtual string AmBoRq { get; set; }
        public virtual string AMBILL { get; set; }
        public virtual string AMCLMD { get; set; }
        public virtual string AMMTHD { get; set; }
        public virtual string AMREIN { get; set; }
        public virtual DateTime AMEFFT { get; set; }
        public virtual DateTime AMEXPR { get; set; }
        public virtual DateTime AMDATA { get; set; }
        public virtual string AMUSRA { get; set; }
        public virtual DateTime AMDATU { get; set; }
        public virtual string AMUSRU { get; set; }
        public virtual DateTime AMDATC { get; set; }
        public virtual string AMUSRC { get; set; }
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
            modelBuilder.Entity<AgentMaster>().Property(x => x.AmOnly).HasMaxLength(1);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AMRTRQ).HasMaxLength(1);
            modelBuilder.Entity<AgentMaster>().Property(x => x.AmBoRq).HasMaxLength(1);
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
