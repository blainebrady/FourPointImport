using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    [Table("PatronCustHist", Schema = "dbo")]
    public class PatronCustHist : Base
    {
        public virtual decimal ImIDN { get; set; }
        public virtual string ImLNam { get; set; }
        public virtual string ImFNam { get; set; }
        public virtual string ImMNam { get; set; }
        public virtual string ImSufx { get; set; }
        public virtual string ImAdd1 { get; set; }
        public virtual string ImAdd2 { get; set; }
        public virtual string ImCity { get; set; }
        public virtual string ImSte { get; set; }
        public virtual string ImZip { get; set; }
        public virtual decimal ImPhne { get; set; }
        public virtual DateTime ImDob { get; set; }
        public virtual string ImSex { get; set; }
        public virtual string ImStat { get; set; }
        public virtual string IMHQ01 { get; set; }
        public virtual string IMHQ02 { get; set; }
        public virtual string IMHQ03 { get; set; }
        public virtual string IMHQ04 { get; set; }
        public virtual string IMHQ05 { get; set; }
        public virtual string IMHQ06 { get; set; }
        public virtual string IMHQ07 { get; set; }
        public virtual string IMHQ08 { get; set; }
        public virtual string IMHQ09 { get; set; }
        public virtual string IMHQ10 { get; set; }
        public virtual string IMHQ11 { get; set; }
        public virtual string IMHQ12 { get; set; }
        public virtual string IMHQ13 { get; set; }
        public virtual string IMHQ14 { get; set; }
        public virtual string IMHQ15 { get; set; }
        public virtual string IMHQ16 { get; set; }
        public virtual string IMHQ17 { get; set; }
        public virtual string IMHQ18 { get; set; }
        public virtual string IMHQ19 { get; set; }
        public virtual string IMHQ20 { get; set; }
        public virtual string ImUsrA { get; set; }
        public virtual DateTime ImDatU { get; set; }
        public virtual string ImUsrU { get; set; }
        public virtual DateTime ImDatA { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatronCustHist>().Property(x => x.ImIDN);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.ImLNam).HasMaxLength(25);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.ImFNam).HasMaxLength(25);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.ImMNam).HasMaxLength(25);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.ImSufx).HasMaxLength(3);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.ImAdd1).HasMaxLength(25);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.ImAdd2).HasMaxLength(25);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.ImCity).HasMaxLength(25);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.ImSte).HasMaxLength(2);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.ImZip).HasMaxLength(10);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.ImPhne).HasPrecision(10, 0);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.ImDob);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.ImSex).HasMaxLength(1);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.IMHQ01).HasMaxLength(1);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.IMHQ02).HasMaxLength(1);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.IMHQ03).HasMaxLength(1);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.IMHQ04).HasMaxLength(1);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.IMHQ05).HasMaxLength(1);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.IMHQ06).HasMaxLength(1);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.IMHQ07).HasMaxLength(1);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.IMHQ08).HasMaxLength(1);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.IMHQ09).HasMaxLength(1);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.IMHQ10).HasMaxLength(1);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.IMHQ11).HasMaxLength(1);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.IMHQ12).HasMaxLength(1);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.IMHQ13).HasMaxLength(1);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.IMHQ14).HasMaxLength(1);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.IMHQ15).HasMaxLength(1);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.IMHQ16).HasMaxLength(1);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.IMHQ17).HasMaxLength(1);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.IMHQ18).HasMaxLength(1);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.IMHQ19).HasMaxLength(1);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.IMHQ20).HasMaxLength(1);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.ImUsrA).HasMaxLength(10);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.ImDatU);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.ImUsrU).HasMaxLength(10);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.ImDatA);
            modelBuilder.Entity<PatronCustHist>().Property(x => x.ImStat).HasMaxLength(1);
        }
        public static PatronCustHist ImportClass(PatronCustomer instMstp)
        {

            PatronCustHist x_INSHSTP = new PatronCustHist();
            PropertyInfo[] propInstMstp = instMstp.GetType().GetProperties();
            PropertyInfo[] propInstHstp = x_INSHSTP.GetType().GetProperties();

            //match the names of the objects
            foreach (var item in propInstMstp)
            {
                var prop = propInstHstp.FirstOrDefault(x => x.Name.ToUpper() == item.Name.ToUpper());
                if (prop != null && item.GetValue(instMstp) != null)
                {
                    // Get the value of the property in instMstp
                    object value = item.GetValue(instMstp);

                    // Set the value of the property in x_INSHSTP
                    prop.SetValue(x_INSHSTP, value);
                }
            }

            return x_INSHSTP;
        }
    }
}
