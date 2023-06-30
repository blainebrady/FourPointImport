using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    [Table("SuspenseMaster", Schema ="dbo")]
    public class SuspenseMaster : Import
    {
        public string SmAgnt { get; set; }
        public string SmRegn { get; set; }
        public string SmTerr { get; set; }
        public string SmBrch { get; set; }
        public string SmOffc { get; set; }
        public string SmCert { get; set; }
        public string SmBen1 { get; set; }
        public string SmBen2 { get; set; }
        public DateTime SmEfft { get; set; }
        public int SmDays { get; set; }
        public DateTime SmFPay { get; set; }
        public int SmTerm { get; set; }
        public DateTime SmExpr { get; set; }
        public int SmFreq { get; set; }
        public int SmAmnt { get; set; }
        public string SmBall { get; set; }
        public decimal SmIntr { get; set; }
        public decimal SmSchd { get; set; }
        public decimal SmLAmt { get; set; }
        public decimal SmDAmt { get; set; }
        public string SmLChg { get; set; }
        public string SmDChg { get; set; }
        public int SmLBen { get; set; }
        public string SmLend { get; set; }
        public int SmDBen { get; set; }
        public int SmForm { get; set; }
        public string SmType { get; set; }
        public string SmCalc { get; set; }
        public DateTime SmFPrm { get; set; }
        public DateTime SmEffL { get; set; }
        public int SmTrmL { get; set; }
        public DateTime SmExpL { get; set; }
        public DateTime SmEffD { get; set; }
        public int SmTrmD { get; set; }
        public DateTime SmExpD { get; set; }
        public DateTime SmEffP { get; set; }
        public int SmTrmP { get; set; }
        public DateTime SmExpP { get; set; }
        public int SmIdn1 { get; set; }
        public string SmMNam1 { get; set; }
        public string SmLNam2 { get; set; }
        public string SmLNam1 { get; set; }
        public string SmFNam1 { get; set; }
        public string SmLNam1A { get; set; }
        public string SmFNam1A { get; set; }
        public string SmLNam2A { get; set; }
        public string SmFNam2A { get; set; }
        public string SmSufx1 { get; set; }
        public string SmAdd11 { get; set; }
        public string SmAdd21 { get; set; }
        public string SmCity1 { get; set; }
        public string SmSte1 { get; set; }
        public string SmZip1 { get; set; }
        public decimal SmPhne1 { get; set; }
        public DateTime SmDob1 { get; set; }
        public string SmSex1 { get; set; }
        public string SmHQ01A { get; set; }
        public string SmHQ02A { get; set; }
        public string SmHQ03A { get; set; }
        public string SmHQ04A { get; set; }
        public string SmHQ05A { get; set; }
        public string SmHQ06A { get; set; }
        public string SmHQ07A { get; set; }
        public string SmHQ08A { get; set; }
        public string SmHQ09A { get; set; }
        public string SmHQ10A { get; set; }
        public string SmHQ11A { get; set; }
        public string SmHQ12A { get; set; }
        public string SmHQ13A { get; set; }
        public string SmHQ14A { get; set; }
        public string SmHQ15A { get; set; }
        public string SmHQ16A { get; set; }
        public string SmHQ17A { get; set; }
        public string SmHQ18A { get; set; }
        public string SmHQ19A { get; set; }
        public string SmHQ20A { get; set; }
        public string SmSig1 { get; set; }
        public int SmIdn2 { get; set; }
        public string SmFNam2 { get; set; }
        public string SmMNam2 { get; set; }
        public string SmSufx2 { get; set; }
        public string SmAdd12 { get; set; }
        public string SmAdd22 { get; set; }
        public string SmCity2 { get; set; }
        public string SmSte2 { get; set; }
        public string SmZip2 { get; set; }
        public decimal SmPhne2 { get; set; }
        public DateTime SmDob2 { get; set; }
        public string SmSex2 { get; set; }
        public string SmHQ01B { get; set; }
        public string SmHQ02B { get; set; }
        public string SmHQ03B { get; set; }
        public string SmHQ04B { get; set; }
        public string SmHQ05B { get; set; }
        public string SmHQ06B { get; set; }
        public string SmHQ07B { get; set; }
        public string SmHQ08B { get; set; }
        public string SmHQ09B { get; set; }
        public string SmHQ10B { get; set; }
        public string SmHQ11B { get; set; }
        public string SmHQ12B { get; set; }
        public string SmHQ13B { get; set; }
        public string SmHQ14B { get; set; }
        public string SmHQ15B { get; set; }
        public string SmHQ16B { get; set; }
        public string SmHQ17B { get; set; }
        public string SmHQ18B { get; set; }
        public string SmHQ19B { get; set; }
        public string SmHQ20B { get; set; }
        public string SmSig2 { get; set; }
        public string SmExcd { get; set; }
        public int SmExcP { get; set; }
        public string SmUsrA { get; set; }
        public DateTime SmDatU { get; set; }
        public DateTime SmData { get; set; }
        public string SmUsrU { get; set; }
        public string SmFlag { get; set; }
        public int SmCnl { get; set; }
        public int SmCnlL { get; set; }
        public int SmCnlD { get; set; }
        public string SmSovS { get; set; }
        public int SmSovD { get; set; }
        public decimal SmPanI { get; set; }
        public string SmDeal { get; set; }
        public decimal SmLif { get; set; }
        public decimal SmDis { get; set; }
        public decimal SmDebt { get; set; }
        public int SmFut1 { get; set; }
        public int SmFut2 { get; set; }
        public decimal SmLine { get; set; }
        public string SmVIN { get; set; }
        public int SmYear { get; set; }
        public string SmMake { get; set; }
        public string SmModel { get; set; }
        public decimal SmFee { get; set; }
        public decimal SmComR { get; set; }
        public int SmGEfft { get; set; }
        public int SmGExpr { get; set; }
        public string SmGStat { get; set; }
        public DateTime SmGDate { get; set; }
        public decimal Smmntf { get; set; }
        public string SmCert2 { get; set; }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.Archive);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.CreateOn);
            modelBuilder.Entity<SuspenseMaster> ().Property(x => x.LastUpdated);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmAgnt).HasMaxLength(10);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmOffc).HasMaxLength(10);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmCert).HasMaxLength(20);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmDeal).HasMaxLength(10);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmBen1).HasMaxLength(10);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmBen2).HasMaxLength(25);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmEfft);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmDays).HasPrecision(3, 0);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmFPay);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmTerm).HasPrecision(3, 0);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmExpr);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmFreq).HasPrecision(3, 0);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmAmnt).HasPrecision(11, 2);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmBall).HasPrecision(11, 2);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmIntr).HasPrecision(7, 5);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmSchd).HasPrecision(11, 2);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmLAmt).HasPrecision(11, 7);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmDAmt).HasPrecision(11, 7);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmLChg).HasPrecision(11, 2);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmDChg).HasPrecision(11, 2);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmLBen).HasPrecision(11, 2);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmDBen).HasPrecision(11, 2);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmForm).HasMaxLength(15);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmType).HasMaxLength(15);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmCalc).HasMaxLength(15);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmLend).HasMaxLength(15);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmFPrm);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmEffL);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmTrmL).HasPrecision(3, 0);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmExpL);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmEffD);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmTrmD).HasPrecision(3, 0);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmExpD);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmEffP);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmTrmP).HasPrecision(3, 0);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmExpP);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmLif).HasPrecision(5, 0);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmDis).HasPrecision(5, 0);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmDebt).HasPrecision(5, 0);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmFut1).HasPrecision(5, 0);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmFut2).HasPrecision(5, 0);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmIdn1).HasPrecision(9, 0);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmLNam1).HasMaxLength(25);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmFNam1).HasMaxLength(25);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmMNam1).HasMaxLength(25);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmSufx1).HasMaxLength(3);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmAdd11).HasMaxLength(25);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmAdd21).HasMaxLength(25);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmCity1).HasMaxLength(25);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmSte1).HasMaxLength(2);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmZip1).HasMaxLength(10);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmPhne1).HasPrecision(10, 0);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmDob1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmSex1).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ01A).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ02A).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ03A).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ04A).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ05A).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ06A).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ07A).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ08A).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ09A).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ10A).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ11A).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ12A).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ13A).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ14A).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ15A).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ16A).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ17A).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ18A).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ19A).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ20A).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmSig1).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmIdn2).HasPrecision(9, 0);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmLNam2).HasMaxLength(25);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmFNam2).HasMaxLength(25);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmMNam2).HasMaxLength(25);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmSufx2).HasMaxLength(3);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmAdd12).HasMaxLength(25);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmAdd22).HasMaxLength(25);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmCity2).HasMaxLength(25);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmSte2).HasMaxLength(2);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmZip2).HasMaxLength(10);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmPhne2).HasPrecision(10, 0);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmDob2);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmSex2).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ01B).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ02B).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ03B).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ04B).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ05B).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ06B).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ07B).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ08B).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ09B).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ10B).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ11B).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ12B).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ13B).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ14B).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ15B).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ16B).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ17B).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ18B).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ19B).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmHQ20B).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmSig2).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmFlag).HasMaxLength(1);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmCnl);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmCnlL);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmCnlD);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmSovS).HasMaxLength(10);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmSovD);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmPanI).HasPrecision(11, 2);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmLine).HasPrecision(11, 2);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmCert2).HasMaxLength(20);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmVIN).HasMaxLength(40);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmYear); 
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmMake).HasMaxLength(40);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmModel).HasMaxLength(40);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmFee).HasPrecision(11,2);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmComR).HasPrecision(7,5);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmGEfft);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmGExpr);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmGStat).HasMaxLength(10);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmGDate);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmExcd).HasMaxLength(2);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmExcP);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmData);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmUsrA).HasMaxLength(10);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmDatU);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmUsrU).HasMaxLength(10);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.Smmntf).HasPrecision(11, 2);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmCert2).HasMaxLength(20);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmLNam2A).HasMaxLength(25);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmFNam2A).HasMaxLength(25);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmLNam1A).HasMaxLength(25);
            modelBuilder.Entity<SuspenseMaster>().Property(x => x.SmFNam1A).HasMaxLength(25);
        }
    }
}
