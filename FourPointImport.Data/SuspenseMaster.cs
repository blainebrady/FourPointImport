using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPointImport.Data
{
    public class SuspenseMaster:IImport
    {
        public virtual int id { get; set; }
        public virtual bool Archive { get; set; }
        public virtual DateTimeOffset CreateOn { get; set; }
        public virtual DateTimeOffset LastUpdated { get; set; }
        public virtual string SmAgnt { get; set; }
        public virtual string SmRegn { get; set; }
        public virtual string SmTerr { get; set; }
        public virtual string SmBrch { get; set; }
        public virtual string SmOffc { get; set; }
        public virtual string SmCert { get; set; }
        public virtual string SmBen1 { get; set; }
        public virtual string SmBen2 { get; set; }
        public virtual DateTime SmEfft { get; set; }
        public virtual int SmDays { get; set; }
        public virtual DateTime SmFPay { get; set; }
        public virtual int SmTerm { get; set; }
        public virtual DateTime SmExpr { get; set; }
        public virtual int SmFreq { get; set; }
        public virtual int SmAmnt { get; set; }
        public virtual string SmBall { get; set; }
        public virtual decimal SmIntr { get; set; }
        public virtual int SmSchd { get; set; }
        public virtual decimal SmLAmt { get; set; }
        public virtual decimal SmDAmt { get; set; }
        public virtual string SmLChg { get; set; }
        public virtual string SmDChg { get; set; }
        public virtual int SmLBen { get; set; }
        public virtual string SmLend { get; set; }
        public virtual int SmDBen { get; set; }
        public virtual int SmForm { get; set; }
        public virtual string SmType { get; set; }
        public virtual string SmCalc { get; set; }
        public virtual DateTime SmFPrm { get; set; }
        public virtual DateTime SmEffL { get; set; }
        public virtual int SmTrmL { get; set; }
        public virtual DateTime SmExpL { get; set; }
        public virtual DateTime SmEffD { get; set; }
        public virtual int SmTrmD { get; set; }
        public virtual DateTime SmExpD { get; set; }
        public virtual DateTime SmEffP { get; set; }
        public virtual int SmTrmP { get; set; }
        public virtual DateTime SmExpP { get; set; }
        public virtual int SmIdn1 { get; set; }
        public virtual string SmMNam1 { get; set; }
        public virtual string SmLNam2 { get; set; }
        public virtual string SmLNam1 { get; set; }
        public virtual string SmFNam1 { get; set; }
        public virtual string SmSufx1 { get; set; }
        public virtual string SmAdd11 { get; set; }
        public virtual string SmAdd21 { get; set; }
        public virtual string SmCity1 { get; set; }
        public virtual string SmSte1 { get; set; }
        public virtual string SmZip1 { get; set; }
        public virtual decimal SmPhne1 { get; set; }
        public virtual DateTime SmDob1 { get; set; }
        public virtual string SmSex1 { get; set; }
        public virtual string SmHQ01A { get; set; }
        public virtual string SmHQ02A { get; set; }
        public virtual string SmHQ03A { get; set; }
        public virtual string SmHQ04A { get; set; }
        public virtual string SmHQ05A { get; set; }
        public virtual string SmHQ06A { get; set; }
        public virtual string SmHQ07A { get; set; }
        public virtual string SmHQ08A { get; set; }
        public virtual string SmHQ09A { get; set; }
        public virtual string SmHQ10A { get; set; }
        public virtual string SmHQ11A { get; set; }
        public virtual string SmHQ12A { get; set; }
        public virtual string SmHQ13A { get; set; }
        public virtual string SmHQ14A { get; set; }
        public virtual string SmHQ15A { get; set; }
        public virtual string SmHQ16A { get; set; }
        public virtual string SmHQ17A { get; set; }
        public virtual string SmHQ18A { get; set; }
        public virtual string SmHQ19A { get; set; }
        public virtual string SmHQ20A { get; set; }
        public virtual string SmSig1 { get; set; }
        public virtual int SmIdn2 { get; set; }
        public virtual string SmFNam2 { get; set; }
        public virtual string SmMNam2 { get; set; }
        public virtual string SmSufx2 { get; set; }
        public virtual string SmAdd12 { get; set; }
        public virtual string SmAdd22 { get; set; }
        public virtual string SmCity2 { get; set; }
        public virtual string SmSte2 { get; set; }
        public virtual string SmZip2 { get; set; }
        public virtual decimal SmPhne2 { get; set; }
        public virtual DateTime SmDob2 { get; set; }
        public virtual string SmSex2 { get; set; }
        public virtual string SmHQ01B { get; set; }
        public virtual string SmHQ02B { get; set; }
        public virtual string SmHQ03B { get; set; }
        public virtual string SmHQ04B { get; set; }
        public virtual string SmHQ05B { get; set; }
        public virtual string SmHQ06B { get; set; }
        public virtual string SmHQ07B { get; set; }
        public virtual string SmHQ08B { get; set; }
        public virtual string SmHQ09B { get; set; }
        public virtual string SmHQ10B { get; set; }
        public virtual string SmHQ11B { get; set; }
        public virtual string SmHQ12B { get; set; }
        public virtual string SmHQ13B { get; set; }
        public virtual string SmHQ14B { get; set; }
        public virtual string SmHQ15B { get; set; }
        public virtual string SmHQ16B { get; set; }
        public virtual string SmHQ17B { get; set; }
        public virtual string SmHQ18B { get; set; }
        public virtual string SmHQ19B { get; set; }
        public virtual string SmHQ20B { get; set; }
        public virtual string SmSig2 { get; set; }
        public virtual string SmExcd { get; set; }
        public virtual int SmExcP { get; set; }
        public virtual string SmUsrA { get; set; }
        public virtual DateTime SmDatU { get; set; }
        public virtual DateTime SmData { get; set; }
        public virtual string SmUsrU { get; set; }
        public virtual string SmFlag { get; set; }
        public virtual decimal SmCnl { get; set; }
        public virtual int SmCnlL { get; set; }
        public virtual int SmCnlD { get; set; }
        public virtual string SmSovS { get; set; }
        public virtual int SmSovD { get; set; }
        public virtual decimal SmPanI { get; set; }
        public virtual decimal SSmLine { get; set; }
        public virtual string SmDeal { get; set; }
        public virtual decimal SmLif { get; set; }
        public virtual decimal SmDis { get; set; }
        public virtual decimal SmDebt { get; set; }
        public virtual int SmFut1 { get; set; }
        public virtual int SmFut2 { get; set; }
        public virtual decimal SmLine { get; set; }
        public virtual string SmVIN { get; set; }
        public virtual int SmYear { get; set; }
        public virtual string SmMake { get; set; }
        public virtual string SmModel { get; set; }
        public virtual decimal SmFee { get; set; }
        public virtual decimal SmComR { get; set; }
        public virtual int SmGEfft { get; set; }
        public virtual int SmGExpr { get; set; }
        public virtual string SmGStat { get; set; }
        public virtual DateTime SmGDate { get; set; }
        public virtual decimal Smmntf { get; set; }
        public virtual string SmCert2 { get; set; }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<billingDetail>().Property(x => x.id);
            modelBuilder.Entity<billingDetail>().Property(x => x.Archive);
            modelBuilder.Entity<billingDetail>().Property(x => x.CreateOn);
            modelBuilder.Entity<billingDetail>().Property(x => x.LastUpdated);
        }
    }
}
