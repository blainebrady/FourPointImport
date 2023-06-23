using FourPointImport.Data;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Globalization;
using Utilities;
using FourPointImport.Services;
using Microsoft.AspNetCore.Routing;
using System.Xml.Linq;

namespace FourPointImport.Web.Functions
{
    public class MOB206
    {
        SuspenseMaster suspenseMaster { get; set; }
        CoverageInsuranceMaster covMaster { get; set; }
        private DateTime _SmEfftTest { get; set; }
        string ErrCode { get; set; }
        private decimal ErrorLimit { get; set; }
        string ExCd { get; set; }
        private decimal LfBand;
        private decimal LfRate;
        private decimal LfPrct;
        private string LfDesc;
        private decimal LfBase;
        bool PostData { get; set; }
        private string SecondReq { get; set; }
        private int Severity { get; set; }
        private string SeverityErr { get; set; }
        private int TestDays { get; set; }
        protected readonly CoverageMasterService smService;
        DateTime WorkDate { get; set; }
        DateTime WorkDate2 { get; set; }
        public MOB206(SuspenseMaster _suspenseMaster, CoverageMasterService _smCervice, CoverageInsuranceMaster _covMaster)
        {
            suspenseMaster = _suspenseMaster;
            smService = _smCervice;
            covMaster = _covMaster;
            WorkDate = DateTime.Now;

            if (suspenseMaster.SmCnl > 0 || suspenseMaster.SmCnlL > 0 || suspenseMaster.SmCnlD > 0)
            {
                ExCd = suspenseMaster.SmExcd;
                PostData = true;
                UpdHist();
                ChgData(suspenseMaster.SmAgnt);
                suspenseMaster = new MOB210(suspenseMaster.SmAgnt, suspenseMaster.SmCert, suspenseMaster);

                Confirm();
                if (suspenseMaster.SmCert.StringSafe().Length == 0)
                {

                }
            }

        }
        private async void ChgData(string SmAgnt)
        {
            if (Utils.ParseNumControlledReturn(suspenseMaster.SmAgnt) <= 90000 || Utils.ParseNumControlledReturn(suspenseMaster.SmAgnt) >= 99999)
            {
                List<CoverageInsuranceMaster> CovMstL1 = await smService.ReadAllAsync();                                           //need to fill this
                var covMstL1 = CovMstL1.Find(x => x.CmAgnt == SmAgnt);
                if (covMstL1 != null)
                    foreach (var item in CovMstL1)
                    {
                        CoverageInsuranceMaster coverageInsuranceMaster = new CoverageInsuranceMaster();
                        if (suspenseMaster.SmDebt <= 50000 || suspenseMaster.SmDebt >= 50999)
                        {
                            coverageInsuranceMaster = CovChg(item.CmAgnt, item.CmCert, item);
                        }
                        else
                        {
                            coverageInsuranceMaster = GapChg(item.CmAgnt, item.CmCert, item);
                        }

                        if (item.CmCand != 0)
                        {
                            coverageInsuranceMaster = CovChg(item.CmAgnt, item.CmCert, item);
                        }
                        if(coverageInsuranceMaster.LastUpdated== DateTime.Today)
                        {
                            smService.UpdateAsync(coverageInsuranceMaster.id, coverageInsuranceMaster);
                        }
                    }

            }
        }
        private CoverageInsuranceMaster CovChg(string smAgnt, string smcert, CoverageInsuranceMaster cOVMSTR)
        {
            //If coverage changed call program that will determine the cancel
            //date from the last billing and mark record as cancelled then
            //process as it would normally...  

            return new MOB217(smAgnt, smcert, cOVMSTR).covMSTR;
        }
        private CoverageInsuranceMaster GapChg(string smAgnt, string smcert, CoverageInsuranceMaster cOVMSTR)
        {
            // If coverage changed call program that will determine the cancel date from the last billing 
            // and mark record as cancelled then process as it would normally...

            return new MOB216(smAgnt, smcert, cOVMSTR).covMSTR;
        }
        public void Confirm()
        {
            Error error = new Error();
            if (Severity < ErrorLimit)
            {
                error.CfAgnt = suspenseMaster.SmAgnt;
                error.CfCert = suspenseMaster.SmCert;
                error.CfFlag = "A";
                error.CfErr = "";
                error.CfProc = DateTime.Now.ToString("HHmmss");
                // ConFrmR.Write();                                                      get a way to store this
            }
            else
            {
                error.CfAgnt = suspenseMaster.SmAgnt;
                error.CfCert = suspenseMaster.SmCert;
                error.CfFlag = "R";
                error.CfErr = SeverityErr;
                error.CfProc = DateTime.Now.ToString("hh:mm:ss tt");
                // ConFrmR.WriteLine();
            }

            if (ExCd == "")
            {
                ExCd = "NV";
            }

            suspenseMaster = Mob207(suspenseMaster);
        }
        private void ErrMsg(string err)
        {
            

        }
        private double dateMult(DateTime SmEfft)
        {
            SmEfft = DateTime.ParseExact(SmEfft.ToString("00000000"), "yyyyMMdd", CultureInfo.InvariantCulture);
            double Mult = 10000.0001;
            return SmEfft.Ticks * Mult;
        }
        // Get the Agent Detail File with Underwriting Limits

        private SuspenseMaster Mob207(SuspenseMaster suspenseMaster)
        {

            decimal Mob207_Parm3 = suspenseMaster.SmDebt;
            string Mob207_Parm4 = ExCd;

            new MOB207(suspenseMaster.SmAgnt, suspenseMaster.SmCert, Mob207_Parm3, Mob207_Parm4, suspenseMaster);

            Mob207_Parm3 = 0;
            Mob207_Parm4 = "";
            return suspenseMaster;
        }

        public void Dates()
        {
            // Validate First Payment Date / First Premium DueDate
            if (!suspenseMaster.SmFPay.DateNotNull() && !suspenseMaster.SmFPrm.DateNotNull())
            {
                suspenseMaster.SmFPay = suspenseMaster.SmFPrm;
            }
            else if (!suspenseMaster.SmFPrm.DateNotNull() && !suspenseMaster.SmFPay.DateNotNull())
            {
                suspenseMaster.SmFPrm = suspenseMaster.SmFPay;
            }

            // Validate First Payment Date
            if (DateTime.TryParseExact(suspenseMaster.SmFPay.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                // Valid Date
                if (suspenseMaster.SmFPay <= DateTime.Now)
                {
                    // Did not miss 1st Premium billing
                    ErrMsg("SMFPAY2");
                    return;
                }
            }
            else
            {
                ErrMsg("SMFPAY");
                return;
            }

            // Validate First Insured Birthday
            if (!DateTime.TryParseExact(suspenseMaster.SmDob1.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                ErrMsg("SmDob1");
                return;
            }

            // Validate Second Insured's Birthday
            if (SecondReq == "Yes")
            {
                if (!DateTime.TryParseExact(suspenseMaster.SmDob2.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                {
                    ErrMsg("SMDob2");
                    return;
                }
            }

            // Calculate Life Coverage Effective Date
            if (suspenseMaster.SmLif > 0)
            {
                if (!suspenseMaster.SmEffL.DateNotNull())
                {
                    suspenseMaster.SmEffL = suspenseMaster.SmEfft;
                }

                if (DateTime.TryParseExact(suspenseMaster.SmEffL.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                {
                    // Valid date
                }
                else
                {
                    ErrMsg("SMEFFL");
                    return;
                }

                if (suspenseMaster.SmLif > 0)
                {
                    if (!suspenseMaster.SmExpL.DateNotNull())
                    {
                        if (!suspenseMaster.SmFPrm.DateNotNull() && suspenseMaster.SmTrmL > 0)
                        {
                            WorkDate = suspenseMaster.SmFPrm;
                            WorkDate = WorkDate.AddMonths(suspenseMaster.SmTrmL);
                            suspenseMaster.SmExpr = WorkDate;
                        }
                    }
                    else
                    {
                        suspenseMaster.SmExpr = suspenseMaster.SmExpL;
                    }
                    if (!suspenseMaster.SmExpL.DateNotNull())
                    {
                        ErrCode = "SMEXPL";
                        ErrMsg(ErrCode);
                    }
                }
                if (suspenseMaster.SmLif > 0)
                {
                    if (suspenseMaster.SmTrmL == 0 && !suspenseMaster.SmExpL.DateNotNull())
                    {
                        WorkDate = suspenseMaster.SmFPrm;
                        WorkDate2 = suspenseMaster.SmExpL;
                        WorkDate2 = WorkDate2.AddMonths(-suspenseMaster.SmTrmL);
                    }
                    if (suspenseMaster.SmTrmL <= 0)
                    {
                        suspenseMaster.SmTerm = suspenseMaster.SmTrmL;
                    }
                }
                if (suspenseMaster.SmDis > 0)
                {
                    if (!suspenseMaster.SmEffD.DateNotNull())
                    {
                        suspenseMaster.SmEffD = suspenseMaster.SmEfft;
                    }
                    if (!suspenseMaster.SmEffD.DateNotNull())
                    {
                        ErrCode = "SMEFFD";
                        ErrMsg(ErrCode);
                    }
                }
                if (suspenseMaster.SmDis > 0)
                {
                    if (!suspenseMaster.SmExpD.DateNotNull())
                    {
                        if (!suspenseMaster.SmFPrm.DateNotNull() && suspenseMaster.SmTrmD > 0)
                        {
                            WorkDate = suspenseMaster.SmFPrm;
                            WorkDate = WorkDate.AddMonths(suspenseMaster.SmTrmD);
                            suspenseMaster.SmExpD = WorkDate;
                        }
                    }
                    //else
                    //{
                    //    AhExpr = suspenseMaster.SmExpD;
                    //}
                    if (!suspenseMaster.SmExpD.DateNotNull())
                    {
                        ErrCode = "SMEXPD";
                        ErrMsg(ErrCode);
                    }
                }
                if (suspenseMaster.SmDis > 0)
                {
                    if (suspenseMaster.SmTrmD == 0 && !suspenseMaster.SmExpD.DateNotNull())
                    {
                        WorkDate = suspenseMaster.SmFPrm;
                        WorkDate2 = suspenseMaster.SmExpD;
                        WorkDate2 = WorkDate2.AddMonths(-suspenseMaster.SmTrmD);
                    }
                    if (suspenseMaster.SmTrmD <= 0)
                    {
                        suspenseMaster.SmTerm = suspenseMaster.SmTrmD;
                    }
                }
                if (suspenseMaster.SmDebt > 0)
                {
                    if (!suspenseMaster.SmEffP.DateNotNull())
                    {
                        suspenseMaster.SmEffP = suspenseMaster.SmEffP;
                        if (!suspenseMaster.SmEffP.DateNotNull())
                        {
                            ErrCode = "SMEFFP";
                            ErrMsg(ErrCode);
                        }
                    }
                    if (suspenseMaster.SmDebt > 0)
                    {
                        if (!suspenseMaster.SmExpP.DateNotNull())
                        {

                            if (!suspenseMaster.SmFPrm.DateNotNull() && suspenseMaster.SmTrmP > 0)
                            {
                                WorkDate = suspenseMaster.SmFPrm;
                                WorkDate = WorkDate.AddMonths(suspenseMaster.SmTrmP);
                                suspenseMaster.SmExpP = WorkDate;

                            }
                        }
                        else
                        {
                            DateTime DpExpr = suspenseMaster.SmExpP;
                        }
                    }
                }

            }

            // * ****Calculate Disability Term from Expiration Date *****************************************
            if (suspenseMaster.SmDebt > 0)
            {
                if (suspenseMaster.SmTrmP == 0 && !suspenseMaster.SmExpP.DateNotNull())
                {
                    WorkDate = suspenseMaster.SmFPrm;
                    WorkDate2 = suspenseMaster.SmExpP;
                    WorkDate2 = WorkDate.AddMonths(suspenseMaster.SmTrmP);
                }

                if (suspenseMaster.SmTrmP <= 0)
                {
                    suspenseMaster.SmTerm = suspenseMaster.SmTrmP;
                }
            }

            // ****Is the Loan Expiration Dates Correct ? **************************************************
            WorkDate = suspenseMaster.SmFPay;
            WorkDate = WorkDate.AddMonths(suspenseMaster.SmTerm);
            WorkDate = WorkDate.AddMonths(1);
            WorkDate2 = suspenseMaster.SmExpr;
            WorkDate = WorkDate2.AddDays(TestDays);
            if (TestDays > 1 || TestDays < -1)
            {
                ErrMsg("SMEXPR2");
            }

            // ****Is the Life or Disability Term Longer than the Loan Term ?******************************
            if (suspenseMaster.SmTrmL > suspenseMaster.SmTerm)
            {
                ErrMsg("SMTRML");
            }
            if (suspenseMaster.SmTrmD > (suspenseMaster.SmTerm + 1))
            {
                ErrMsg("SMTRMD");
            }


        }
        private void EndPgm() { }
        // Get the Underwriting Limits from the Agent Detail Files

        public RateMaster AhRates(List<RateMaster> RatMstL1, List<RateDetailLife> RatDtl)
        {
            string key10 = string.Empty;
            string key11 = string.Empty;
            string key11a = string.Empty;
            decimal AhBase;
            string AhDesc = "";
            decimal AhBand;
            decimal RdBand;
            decimal AhRate;
            decimal AhPrct;

            // Get the Rate Master file information for "LIFE RATES"
            var ratMstL1 = RatMstL1.Find(x => x.RmTble == key10);
            if (ratMstL1 != null)
            {
                if (_SmEfftTest >= ratMstL1.RmEfft && _SmEfftTest <= ratMstL1.RmExpr)
                {
                    AhBase = ratMstL1.RmBase;
                    AhDesc = ratMstL1.RmDesc;
                }
            }
            else         // No Rate Master File Found or Not Active
            {
                ErrCode = "AH-RateMaster";
                ErrMsg(ErrCode);
            }

            // Get the Rate Detail for "LIFE" Coverage
            var RateDetailLife = RatDtl.Find(x => x.RDTBLE == key11);
            if (RateDetailLife != null)
            {
                if (_SmEfftTest >= RateDetailLife.RdEfft && _SmEfftTest <= RateDetailLife.RdExpr)
                {
                    AhBand = RateDetailLife.RdBand;
                    AhRate = RateDetailLife.RdRate;
                    AhPrct = RateDetailLife.RdPrct;
                }
            }
            else// If No record found for this Coverage / Term check Term = 0 ( Straight Percentage )
            {
                RateDetailLife = RatDtl.Find(x => x.RDTBLE == key11a);
                if (RateDetailLife != null)
                {
                    if (_SmEfftTest >= RateDetailLife.RdEfft && _SmEfftTest <= RateDetailLife.RdExpr)
                    {
                        AhBand = RateDetailLife.RdBand;
                        AhRate = RateDetailLife.RdRate;
                        AhPrct = RateDetailLife.RdPrct;
                    }
                }
                else // No Rate Detail File Found or Not Active
                {
                    ErrCode = "AH-RateDetailLife";
                    ErrMsg(ErrCode);
                }
            }

            return ratMstL1;
        }

        private void LfRates()
        {

            // Get the Rate Master file information for "LIFE RATES"
            List<RateMaster> ratMstL1 = new List<RateMaster>();
            var ratMstL = ratMstL1.Find(x => x.RmDATA == key08);

            if (ratMstL != null)
            {
                if (_SmEfftTest >= ratMstL.RmEfft && _SmEfftTest <= ratMstL.RmExpr)
                {
                    LfBase = ratMstL.RmBase;
                    LfDesc = ratMstL.RmDesc;
                }
            }

            // No Rate Master File Found of Not Active
            else
            {
                ErrMsg("LF-RateMaster");
            }

            // Get the Rate Detail for "LIFE" Coverage
            List<RateDetailLife> ratDtlP = new List<RateDetailLife>();
            var ratDtl = ratDtlP.Find(x => x.RDDATA == key09);

            if (ratDtl != null)
            {
                if (_SmEfftTest >= ratDtl.RdEfft && _SmEfftTest <= ratDtl.RdExpr)
                {
                    LfBand = ratDtl.RdBand;
                    LfRate = ratDtl.RdRate;
                    LfPrct = ratDtl.RdPrct;
                }
            }
            else             // If No record found for this Coverage / Term check Term = 0 ( Straight Percentage )
            {
                ratDtl = ratDtlP.Find(x => x.RDDATA == key09A);

                if (ratDtl != null)
                {
                    if (_SmEfftTest >= ratDtl.RdEfft && _SmEfftTest <= ratDtl.RdExpr)
                    {
                        LfBand = ratDtl.RdBand;
                        LfRate = ratDtl.RdRate;
                        LfPrct = ratDtl.RdPrct;
                    }
                }
                else
                {
                    ErrMsg("LF-RATDTL2");
                }
            }
        }

        public void SmEfftTest()
        {
               //SMEFFTTEST" - this routine will use the Loan effective date as  - 
               //the default effective date then use the Benefit effective date if-
               //different from the Loan Effective Date - 
               //Reaplced the SmEfft Field with a field   
               //named SmEfftTest to do al the date routine test against the date -/
               //driven files..suspenseMaster.SmEfft = _SmEfftTest;
            int res = string.Compare(suspenseMaster.SmAgnt, "D99999");
            if (res > 0)
            {
                if (suspenseMaster.SmEffL > _SmEfftTest)
                {
                    suspenseMaster.SmEffL = _SmEfftTest;
                }

                if (suspenseMaster.SmEffD > _SmEfftTest)
                {
                    suspenseMaster.SmEffD = _SmEfftTest;
                }
            }
            if (res <= 0)
            {
                if (suspenseMaster.SmEffP > _SmEfftTest)
                    suspenseMaster.SmEffP = _SmEfftTest;
            }
        }

        private void UpdHist()
        {
            string pragnt = suspenseMaster.SmAgnt;
            decimal prdebt = suspenseMaster.SmDebt;

            if (suspenseMaster.SmDebt == 0)
            {
                new MOB208(pragnt, suspenseMaster.SmCert, suspenseMaster, covMaster);
            }
            else
            {
                new MOB208DCC(pragnt, suspenseMaster.SmCert, prdebt, suspenseMaster, covMaster);
            }
        }
        //BegSr
        private void Initialize(string Parm1, string Parm2, int Parm3)
        {
            //Z-Add 20 Parm3
            Parm3 += 20;

            //Move Entry parms to the Program Variables
            string PrAgnt = Parm1;
            suspenseMaster.SmCert = Parm2;
            int ErrorLimit = Parm3;

            //Eval PrintEor = '*No '
            string PrintEor = "*No ";

            //Get System Date From the Time Statement Then Convert it to CCYYMMDD
            DateTime SysDate = DateTime.Now;
            int SysDte = (int)(10000.0001 * SysDate.Ticks);
            int SystemDate = SysDte;
            DateTime NullDate = new DateTime(1, 1, 1);

            //Set up Headers and Footers for output lines
            string Title1 = @"@Title(1)";
            string Title2 = @"@Title(2)";
            string Title3 = @"@Title(3)";
            string Route1 = @"@Route(1)";


        }
    }
}
