using FourPointImport.Data;
using Utilities;

namespace FourPointImport.Web.Functions
{
    public class MOB207
    {
        public SuspenseMaster susMst { get; set; }
        public MOB207(string SmAgnt, string SmCert, decimal PrCovC, string ExCd, SuspenseMaster susMstL)
        {
            DateTime SysDate = DateTime.Now;

            decimal SysDte = 0;
            SysDte = 10000.0001m * ((SysDate.Year * 10000) + (SysDate.Month * 100) + SysDate.Day);
            SysDate = new DateTime(1, 1, 1).AddDays(Convert.ToDouble(SysDte));
            DateTime NullDate = new DateTime(1, 1, 1);


            if (susMstL != null)
            {
                if (susMstL.SmDebt == PrCovC)
                {
                    susMstL.SmExcd = ExCd.StringSafe();
                    susMstL.SmExcP = (int)SysDte;
                    susMstL.SmDatU = DateTime.Now;
                    susMstL.SmUsrU = SmAgnt;
                }
            }
            susMst = susMstL;
        }
    }
}
