using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    [Table("QuestionAnswer", Schema = "dbo")]
    public class QuestionAnswer : Import
    {
        public string QaAgnt { get; set; }
        public string QaCert { get; set; }
        public decimal QaIDN { get; set; }
        public decimal QaSeq { get; set; }
        public string QaQstn { get; set; }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionAnswer>().Property(x => x.Archive);
            modelBuilder.Entity<QuestionAnswer>().Property(x => x.QaAgnt);
            modelBuilder.Entity<QuestionAnswer>().Property(x => x.QaCert);
            modelBuilder.Entity<QuestionAnswer>().Property(x => x.QaIDN);
            modelBuilder.Entity<QuestionAnswer>().Property(x => x.QaSeq);
            modelBuilder.Entity<QuestionAnswer>().Property(x => x.QaQstn);
        }
    }
}
