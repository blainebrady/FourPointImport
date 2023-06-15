using FourPointImport.Web.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.CodeAnalysis;
using FourPointImport.Services;
using FourPointImport.Data;
using Utilities;
using System.Text;

namespace FourPointImport.Web.Functions
{
    public class billingExportFunctions<TEntity>
        where TEntity : class
    {
        private readonly BillingDetailService billingService;
        private readonly FormMasterService formMasterService;
        private readonly CoverageMasterService coverageMasterService;
        private readonly ProductCoverageService productCoverageService;
        public int GapCovC { get; set; }
        public billingExport inComing { get; set; }
        public CoverageInsuranceMaster coverageMaster { get; set; }
        public SuspenseMaster suspenseMaster { get; set; }                                //this will be the outgoing class
        private string CertHold { get; set; }
        public Key02 Key_2;
        public struct Key02
        {
            public decimal Key02_Fld01;
            public string Key02_Fld02;
        }
        public Key03 Key_3;
        public struct Key03
        {
            public decimal Key03_Fld01;
            public string Key03_Fld02;
        }
        public Key04 Key_4;
        public struct Key04
        {
            public decimal Key04_Fld01;
            public string LType;
        }
        public struct Key04B
        {
            public decimal Key04_Fld01;
        }
        public Key05 Key_5;
        public struct Key05
        {
            public string SeAgnt;
            public int SeForm;
        }
        public Key06 Key_6;
        public struct Key06
        {
            public string SeAgnt;
            public string SeType;
            public int Key_Calc;
            public string SeLend;
        }
        public Key07 Key_7;
        public struct Key07
        {
            public string SeAgnt;
            public string SeType;
            public int Key_Calc;
        }
        public Key08 Key_8;
        public struct Key08
        {
            public string SeAgnt;
            public string SeCert;
        }
        public struct Key09
        {
            public string SeAgnt;
        }
        public struct Key10
        {
            public string SeAgnt;
            public string SeCert;
        }
        private readonly DateTime MinValue = Utils.ParseDateControlledReturn("01/01/1900");
        private readonly DateTime sysDate = DateTime.Now;
        private readonly string sysDte;
        private string WrkNameS { get; set; }

        //suspenseMasterAccess tableAccess, PRDCOVPAccess prdcovpAccess, FrmMstPAccess frmMstLAccess, COVMSTRAccess covmstr,
        public billingExportFunctions([NotNull] BillingDetailService _billingService, billingExport _inComing, CoverageMasterService _coverageService, FormMasterService _formMasterService,
            ProductCoverageService _productCoverageService)
        {
            billingService = _billingService;
            Key_2 = new Key02();
            Key_3 = new Key03();
            Key_4 = new Key04();
            Key_5 = new Key05();
            Key_6 = new Key06();
            Key_7 = new Key07();
            Key_8 = new Key08();

            //_tableAccess = tableAccess;
            productCoverageService = _productCoverageService;
            formMasterService = _formMasterService;
            coverageMasterService = _coverageService;
            //_buildAccess = buildAccess;
            inComing = _inComing;
            Initialize();
            sysDte = (sysDate.Year * 10000 + sysDate.Month * 100 + sysDate.Day).ToString();

            if (inComing.SeCert.StringSafe() != "")
            {

                // Correct Problem where SeFut1 and SeFut2 are blank
                if (inComing.SeFut1.StringSafe() == "")
                {
                    inComing.SeFut1 = 0;
                }
                if (inComing.SeFut2.StringSafe() == "")
                {
                    inComing.SeFut2 = 0;
                }
            }
        }
        public void Clear()
        {
            GapCovC = 0;

            if (inComing.SeEfft <= this.MinValue)
            {
                if (!inComing.SeEffL.DateNotNull())
                {
                    inComing.SeEfft = inComing.SeEffL;
                }
                else
                {
                    if (inComing.SeEffD.DateNotNull())
                    {
                        inComing.SeEfft = inComing.SeEffD;
                    }
                    else
                    {
                        if (inComing.SeEffP.DateNotNull())
                        {
                            inComing.SeEfft = inComing.SeEffP;
                        }
                    }
                }
            }
            if (inComing.SeLif >= 0)
            {
                if (inComing.SeEffL == DateTime.MinValue && inComing.SeEfft > DateTime.MinValue)
                {
                    inComing.SeEffL = inComing.SeEfft;
                }
                if (inComing.SeTrmL == 0 && inComing.SeTerm > 0)
                {
                    inComing.SeTrmL = inComing.SeTerm;
                }
                else
                {
                    if (inComing.SeType.StringSafe() == "OEMOB")
                    {
                        inComing.SeTrmL = 999;
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(inComing.SeDis))
            {
                if (inComing.SeEffD == DateTime.MinValue && inComing.SeEfft > DateTime.MinValue)
                {
                    inComing.SeEffD = inComing.SeEfft;
                }
                if (inComing.SeTrmD == 0 && inComing.SeTerm > 0)
                {
                    inComing.SeTrmD = inComing.SeTerm;
                }
                else
                {
                    if (inComing.SeType == "OEMOB ")
                    {
                        inComing.SeTrmD = 999;
                    }
                }
            }
            if (inComing.SeDebtCode.StringSafe().Trim().Length > 0)
            {
                if (inComing.SeEffP == DateTime.MinValue && inComing.SeEfft > DateTime.MinValue)
                {
                    inComing.SeEffP = inComing.SeEfft;
                }
                if (!inComing.SeExpP.DateNotNull() && inComing.SeExpr.DateNotNull())
                {
                    inComing.SeExpP = inComing.SeExpr;
                }
                if (inComing.SeTrmP == 0 && inComing.SeTerm > 0)
                {
                    inComing.SeTrmP = inComing.SeTerm;
                }

            }
        }
        public void Custom90338()
        {

            if (inComing.SeAgnt == "90038")
            {
                if (inComing.SeDis == "S14N")
                {
                    inComing.SeDis = "S14R ";
                }
                if (inComing.SeDis == "J14N")
                {
                    inComing.SeDis = "J14R ";
                }
            }

            if ((inComing.SeAgnt == "90092 ") || (inComing.SeAgnt == "90093 ") || (inComing.SeAgnt == "90094 "))
            {
                if (inComing.SeDis == "S0N")
                {
                    inComing.SeDis = "S0R ";
                }
            }


        }
        public async void DebtProt()
        {
            // When Sovereign came onboard we changed the way we send the DCC data for them
            // Mark Nelson started adding '0000000000' to all dat coming to IAC ( Even CEMOB )
            // This check will prevent false DCC Records from corrupting the system ...
            if (inComing.SeDebtCode == "000000000000000000000000000000" && inComing.SeEffp == 0)
            {
                inComing.SeDebt = 0;
            }

            if (inComing.SeDebt != 0)
            {
                inComing.LType = "";
                // Is this an Open or Closed Loan??
                if (inComing.SeType == "OEDP ")
                {
                    inComing.LType = "O-";
                }
                else
                {
                    inComing.LType = "C-";
                }
                inComing.LType += inComing.SeLend;

                suspenseMaster.SmDebt = 99000;
                if (GapCovC != 0)
                {
                    suspenseMaster.SmDebt = 0;
                }

                Key_4.Key04_Fld01 = inComing.SeDebt + inComing.SeFut1 + inComing.SeFut2;
                var PrdCovL2 = await productCoverageService.ReadAsyncD(Key_4.Key04_Fld01);
                foreach (var item in PrdCovL2)
                {
                    if (inComing.SeEffP <= item.PCEXPR.IntToDate())
                    {
                        suspenseMaster.SmDebt = item.PCCOVC;
                        inComing.SeCalc = item.PCCALC;
                        break;
                    }
                }
            }
        }
        public async void Disability()
        {
            if (!string.IsNullOrWhiteSpace(inComing.SeDis))
            {
                suspenseMaster.SmDis = 99999;

                if (inComing.SeDis == "S7R")
                {
                    inComing.SeDis = "S07R";
                }
                else if (inComing.SeDis == "J7R")
                {
                    inComing.SeDis = "J07R";
                }
                else if (inComing.SeDis == "S7N")
                {
                    inComing.SeDis = "S07N";
                }
                else if (inComing.SeDis == "J7N")
                {
                    inComing.SeDis = "J07N";
                }
                else if (inComing.SeDis == "S7E")
                {
                    inComing.SeDis = "S07E";
                }
                else if (inComing.SeDis == "J7E")
                {
                    inComing.SeDis = "J07E";
                }
                //might not need these two items

                Key_3.Key03_Fld01 = Utils.ParseNumControlledReturn(inComing.SeDis);
                Key_3.Key03_Fld02 = inComing.SeCalc;
                //read PrdCovl1
                productCoverage _prodCoverage = await productCoverageService.ReadAsyncP(Key_3.Key03_Fld01, Key_3.Key03_Fld02);
                if (inComing.SeEffD >= _prodCoverage.PCEFFT.IntToDate() && inComing.SeEffD <= _prodCoverage.PCEXPR.IntToDate())
                {
                    suspenseMaster.SmDis = _prodCoverage.PCCOVC;
                }

            }
        }
        public async void Form()
        {

            //key05 = seagnt, seform
            if (inComing.SeForm == 0)
            {
                if (string.IsNullOrWhiteSpace(inComing.SeType) && string.IsNullOrWhiteSpace(inComing.SeCalc))
                {
                    // need the values SeAgnt(string) and SeForm(int);

                    string seAgent = "";
                    int seForm = 0;

                    seAgent = Key_5.SeAgnt.StringSafe();
                    seForm = (int)Utils.ParseNumControlledReturn(Key_5.SeForm);

                    var frmMstL1 = await formMasterService.ReadAsyncP(seAgent, seForm);

                    if (frmMstL1 != null)
                    {
                        if (inComing.SeEfft >= frmMstL1.FmEfft && inComing.SeEfft < frmMstL1.FmExpr)
                        {
                            frmMstL1.FmCalc = inComing.SeCalc;
                        }
                    }

                }
            }
            // Key06      public string SeAgnt;
            //public string SeType;
            //public int Key_Calc;
            //public string SeLend;
            if (inComing.SeForm.StringSafe().Length == 0) // check if SeForm is blank
            {
                if (inComing.SeType.StringSafe().Length > 0 && inComing.SeCalc.StringSafe().Length > 0) // check if SeType and SeCalc are not blank
                {
                    var keyCalc = formMasterService.ReadAsyncF(inComing.SeCalc); // initialize a search key with the calculation method
                    if (keyCalc != null)
                    {
                        if (inComing.SeLend.StringSafe().Length > 0) // check if SeLend is not blank
                        {

                            var frmMstL2 = await formMasterService.ReadAsyncL(Key_6.SeType, Key_6.SeLend); // initialize a search key with the type and lending type
                            if (frmMstL2 != null) // search for the first record with the given type and lending type
                            {
                                if (inComing.SeEfft >= frmMstL2.FmEfft && inComing.SeEfft < frmMstL2.FmEfft)
                                {
                                    inComing.SeForm = frmMstL2.FmForm; // set SeForm to the form number
                                }

                            }
                        }
                    }
                    else // if SeForm is not blank
                    {
                        var frmMstL3 = await formMasterService.ReadAsyncL(inComing.SeType, inComing.SeCalc); // initialize a search key with the type and calculation method
                        if (frmMstL3 != null) // search for the first record with the given type and calculation method
                        {

                            if (inComing.SeEfft >= frmMstL3.FmEfft && inComing.SeEfft < frmMstL3.FmExpr)
                            {
                                inComing.SeForm = frmMstL3.FmForm; // set SeForm to the form number
                            }
                        }
                    }

                }
            }

            if (string.IsNullOrWhiteSpace(inComing.SeCalc))
            {
                int portion = (int)Utils.ParseNumControlledReturn(inComing.SeAgnt.Substring(1, inComing.SeAgnt.Length - 1));
                if (portion > 0 && portion <= 99999)
                {
                    inComing.SeCalc = "DP";
                }
            }
        }
        public void HomeSavings()
        {
            if (inComing.SeAgnt == "D10059    " || inComing.SeAgnt == "D10060    " || inComing.SeAgnt == "D10061    ")
            {
                if (inComing.SeDebtCode == "010000100000000000000000000000")
                {
                    inComing.SeDebtCode = "010000000001000000000000000000";
                }
                if (inComing.SeDebtCode == "030000300000000000000000000000")
                {
                    inComing.SeDebtCode = "030000000003000000000000000000";
                }
            }
        }
        private void Initialize()
        {
            Key_4 = new Key04();

            Key_5.SeAgnt = inComing.SeAgnt;
            Key_5.SeForm = inComing.SeForm;

            Key_6.SeAgnt = inComing.SeAgnt;
            Key_6.SeType = inComing.SeType.StringSafe();
            Key_6.Key_Calc = inComing.Key_Calc;
            Key_6.SeLend = inComing.SeLend;

            Key_7.SeAgnt = inComing.SeAgnt;
            Key_7.SeType = inComing.SeType.StringSafe();
            Key_7.Key_Calc = inComing.Key_Calc;

            Key08 key8 = new Key08();
            key8.SeAgnt = inComing.SeAgnt;
            key8.SeCert = inComing.SeCert;

            Key09 key9 = new Key09();
            key9.SeAgnt = inComing.SeAgnt;

            Key10 key10 = new Key10();
            key10.SeAgnt = inComing.SeAgnt;
            key10.SeCert = inComing.SeCert;

        }
        public async void Life()
        {

            if (inComing.SeLif != 0 && inComing.SeLif != 0)
            {
                suspenseMaster.SmLif = 99999;

                Key_2.Key02_Fld01 = inComing.SeLif;
                Key_2.Key02_Fld02 = inComing.SeCalc;

                int pcCovC = 0;
                var PrdCovL2 = await productCoverageService.ReadAsyncL(Key_2.Key02_Fld01, Key_2.Key02_Fld02);
                foreach (var record in PrdCovL2)
                {
                    if (record.PCCOVC != 0 && record.PCCOVC != 0 && inComing.SeEffL >= record.PCEFFT.IntToDate() && inComing.SeEffL <= record.PCEXPR.IntToDate())
                    {
                        pcCovC = (int)record.PCCOVC;
                        break;
                    }
                }
                if (pcCovC > 0) suspenseMaster.SmLif = pcCovC;
            }
        }

        public void ReadAOMOB()
        {
            GapCovC = 0;
            if (inComing.SeFut17 != 0)
            {
                GapCovC = inComing.SeFut17;
                inComing.SeFut17 = 0;
            }
        }
        public async void Write()
        {
            string TestPhone1 = "";
            if (inComing.SelNam1 == "HIBBARD" && inComing.SelNam1 == "DONNA")
            {
                // customer id 123456789 should not be used if there is coverage need to use that id
                // otherwise need to reset it
                if (inComing.SeIDN1 == 123456789 || inComing.SeIDN2 == 123456789)
                {
                    var item = await coverageMasterService.ReadAsync(123456789);//key08 is the original search value here
                    if (item != null)
                    {
                        item.CmIDN1 = inComing.SeIDN1;
                        item.CmIDN2 = inComing.SeIDN2;
                        Key_8.SeAgnt = item.CmAgnt;
                    }
                    else
                    {
                        // reset to zero here and an id# is created later in pgm mob210
                        inComing.SeIDN1 = 0;
                        if (suspenseMaster.SmLNam2.StringSafe().Length > 0)
                        {
                            inComing.SeIDN2 = 1;
                        }
                    }
                }
            }
            if (suspenseMaster == null)
                suspenseMaster = new SuspenseMaster();
            suspenseMaster.SmAgnt = inComing.SeAgnt;
            suspenseMaster.SmRegn = inComing.SeRegn;
            suspenseMaster.SmTerr = inComing.SeTerr;
            suspenseMaster.SmBrch = inComing.SeBrch;
            suspenseMaster.SmOffc = inComing.SeOffc;
            suspenseMaster.SmCert = inComing.SeCert;
            suspenseMaster.SmBen1 = inComing.SeBen1;
            suspenseMaster.SmBen2 = inComing.SeBen2;
            suspenseMaster.SmEfft = inComing.SeEfft;
            suspenseMaster.SmDays = inComing.SeDays;
            suspenseMaster.SmFPay = inComing.SeFPay;
            suspenseMaster.SmTerm = inComing.SeTerm;
            suspenseMaster.SmExpr = inComing.SeExpr;

            // Term length for Loan
            if (inComing.SeTerm == 0)
            {
                DateTime WorkDate1 = inComing.SeFpay;
                DateTime WorkDate2 = inComing.SeExpr;
                double Diff = WorkDate2.Subtract(WorkDate1).TotalDays / 30;
                inComing.SeTerm = (int)Diff;
                suspenseMaster.SmTerm = (int)Diff;
            }

            // Default the frequency to 12 is not supplied by Four Point
            if (inComing.SeFreq == 0)
            {
                inComing.SeFreq = 12;
            }

            suspenseMaster.SmFreq = inComing.SeFreq;
            suspenseMaster.SmAmnt = inComing.SeAmnt;
            suspenseMaster.SmBall = inComing.SeBall;
            suspenseMaster.SmIntr = inComing.SeIntr;
            suspenseMaster.SmSchd = inComing.SeSchd;
            suspenseMaster.SmLAmt = inComing.SeLAmt;
            suspenseMaster.SmDAmt = inComing.SeDAmt;
            suspenseMaster.SmLChg = inComing.SeLChg;
            suspenseMaster.SmDChg = inComing.SeDChg;

            // Default the Life Benefit
            if (inComing.SeLBen == 0)
            {
                inComing.SeLBen = inComing.SeAmnt;
            }

            suspenseMaster.SmLBen = inComing.SeLBen;
            // Default the Monthly Benefit
            if (inComing.SeDBen == 0)
            {
                inComing.SeSchd = inComing.SeDBen;
            }
            suspenseMaster.SmDBen = inComing.SeDBen;

            // Set values
            suspenseMaster.SmForm = inComing.SeForm;
            suspenseMaster.SmType = inComing.SeType;
            suspenseMaster.SmCalc = inComing.SeCalc;
            suspenseMaster.SmLend = inComing.SeLend;
            suspenseMaster.SmFPrm = inComing.SeFPrm;

            // Effective Date for Life Coverage
            if (!inComing.SeEffL.DateNotNull())
            {
                inComing.SeEffL = DateTime.MinValue;
            }
            suspenseMaster.SmEffL = inComing.SeEffL;

            // Term length for Life
            if (inComing.SeTrmL == 0 && inComing.SeLif == 0)
            {
                // If no Expiration Date then use Loan Term
                if (!inComing.SeExpL.DateNotNull() && inComing.SeTerm > 0)
                {
                    inComing.SeTrmL = inComing.SeTerm;
                }
                else
                {
                    DateTime workDate1 = Utils.ParseDateControlledReturn(inComing.SeFPrm);
                    DateTime workDate2 = Utils.ParseDateControlledReturn(inComing.SeExpL);
                    TimeSpan diff = workDate2.Subtract(workDate1);
                    inComing.SeTrmL = (int)diff.TotalDays / 30;
                }
            }
            suspenseMaster.SmTrmL = inComing.SeTrmL;

            // Expiration Date For Life
            if (inComing.SeExpL == Utils.ParseDateControlledReturn("01/01/01"))
            {
                inComing.SeExpL = DateTime.MinValue;
            }
            if (!inComing.SeExpL.DateNotNull() && inComing.SeLif != 0)
            {
                DateTime workDate1 = DateTime.ParseExact(suspenseMaster.SmFPrm.ToString(), "MMddyy", null);
                DateTime workDate2 = workDate1.AddMonths(Convert.ToInt32(suspenseMaster.SmTrmL));
                workDate2 = workDate2.AddMonths(-1);
                inComing.SeExpL = workDate2;
            }
            suspenseMaster.SmExpL = inComing.SeExpL;

            // Effective Date fir Disability Coverage
            if (inComing.SeEffD == Utils.ParseDateControlledReturn("01/01/01"))
            {
                inComing.SeEffD = DateTime.MinValue;
            }
            suspenseMaster.SmEffD = inComing.SeEffD;

            // Term length for Disability Coverage
            if (inComing.SeTrmD == 0 && !string.IsNullOrWhiteSpace(inComing.SeDis))
            {
                // If no Expiration Date then use Loan Term
                if (!inComing.SeExpD.DateNotNull() && inComing.SeTerm > 0)
                {
                    inComing.SeTrmD = inComing.SeTerm;
                }
                else
                {
                    DateTime workDate1 = inComing.SeFPrm;
                    DateTime workDate2 = inComing.SeExpD;
                    TimeSpan diff = workDate2.Subtract(workDate1);
                    inComing.SeTrmD = (int)diff.TotalDays / 30;
                }
            }
            suspenseMaster.SmTrmD = inComing.SeTrmD;

            // Expiration Date for Disability Coverage
            if (!inComing.SeExpD.DateNotNull())
            {
                inComing.SeExpD = DateTime.MinValue;
            }
            if (!inComing.SeExpD.DateNotNull() && !string.IsNullOrWhiteSpace(inComing.SeDis))
            {
                DateTime workDate1 = DateTime.ParseExact(suspenseMaster.SmFPrm.ToString(), "MMddyy", null);
                DateTime workDate2 = workDate1.AddMonths(Convert.ToInt32(suspenseMaster.SmTrmD));
                workDate2 = workDate2.AddMonths(-1);
                inComing.SeExpD = workDate2;
            }
            suspenseMaster.SmExpD = inComing.SeExpD;

            // If no Expiration Date then Assume Open Ended Insurance
            if (!inComing.SeExpP.DateNotNull())
            {
                inComing.SeExpP = DateTime.MaxValue;
            }
            if (!inComing.SeExpP.DateNotNull())
            {
                inComing.SeExpP = DateTime.MaxValue;
            }
            if (inComing.SeEffP == Utils.ParseDateControlledReturn("01/01/01"))
            {
                inComing.SeEffP = DateTime.MinValue;
            }
            suspenseMaster.SmEffP = inComing.SeEffP;
            if (inComing.SeTrmP == 0 && inComing.SeDebt == 0)
            {
                DateTime workDate1 = DateTime.Now;
                DateTime workDate2 = DateTime.Now;
                if (!inComing.SeExpP.DateNotNull() && !inComing.SeExpr.DateNotNull())
                {
                    inComing.SeExpP = inComing.SeExpr;
                }
                workDate2 = inComing.SeExpP;
                TimeSpan diff = workDate2.Subtract(workDate1);
                inComing.SeTrmP = diff.Days / 30;
            }
            suspenseMaster.SmTrmP = inComing.SeTrmP;
            if (inComing.SeExpP == Utils.ParseDateControlledReturn("01/01/01"))
            {
                inComing.SeExpP = DateTime.MinValue;
            }
            if (!inComing.SeExpP.DateNotNull() && inComing.SeDebt != 0)
            {
                DateTime workDate1 = DateTime.Now;
                DateTime workDate2 = DateTime.Now;
                workDate1 = suspenseMaster.SmFPrm;
                workDate2 = workDate1.AddMonths(suspenseMaster.SmTrmP).AddMonths(-1);
                workDate2 = workDate2.AddDays(-1);
                inComing.SeExpP = workDate2;
            }
            suspenseMaster.SmExpP = inComing.SeExpP;
            suspenseMaster.SmLif = inComing.SeLif;
            suspenseMaster.SmDis = Utils.ParseNumControlledReturn(inComing.SeDis);
            suspenseMaster.SmDebt = inComing.SeDebt;
            suspenseMaster.SmFut1 = 0;
            suspenseMaster.SmFut2 = 0;
            suspenseMaster.SmIdn1 = inComing.SeIdn1;
            string WrkName = suspenseMaster.SmLNam1.StringSafe().TrimEnd();
            if (WrkName != "" && WrkNameS == "")
            {
                suspenseMaster.SmLNam1 = WrkName;
            }
            suspenseMaster.SmFNam1 = inComing.SeFNam1;
            WrkName = suspenseMaster.SmFNam1.StringSafe().TrimEnd();
            if (WrkName != "" && WrkNameS == "")
            {
                suspenseMaster.SmFNam1 = WrkName;
            }
            suspenseMaster.SmMNam1 = inComing.SeMNam1;
            suspenseMaster.SmSufx1 = inComing.SeSufx1;
            suspenseMaster.SmAdd11 = inComing.SeAdd11;
            suspenseMaster.SmAdd21 = inComing.SeAdd21;
            suspenseMaster.SmCity1 = inComing.SeCity1;
            suspenseMaster.SmSte1 = inComing.SeSte1;
            suspenseMaster.SmZip1 = inComing.SeZip1;
            if (TestPhone1 == "")
            {
                inComing.SePhne1 = 0;
            }
            suspenseMaster.SmPhne1 = inComing.SePhne1;
            suspenseMaster.SmDob1 = inComing.SeDob1;
            suspenseMaster.SmSex1 = inComing.SeSex1;
            suspenseMaster.SmHQ01A = inComing.SeHQ01A;
            suspenseMaster.SmHQ02A = inComing.SeHQ02A;
            suspenseMaster.SmHQ03A = inComing.SeHQ03A;
            suspenseMaster.SmHQ04A = inComing.SeHQ04A;
            suspenseMaster.SmHQ05A = inComing.SeHQ05A;
            suspenseMaster.SmHQ06A = inComing.SeHQ06A;
            suspenseMaster.SmHQ07A = inComing.SeHQ07A;
            suspenseMaster.SmHQ08A = inComing.SeHQ08A;
            suspenseMaster.SmHQ09A = inComing.SeHQ09A;
            suspenseMaster.SmHQ10A = inComing.SeHQ10A;
            suspenseMaster.SmHQ11A = inComing.SeHQ11A;
            suspenseMaster.SmHQ12A = inComing.SeHQ12A;
            suspenseMaster.SmHQ13A = inComing.SeHQ13A;
            suspenseMaster.SmHQ14A = inComing.SeHQ14A;
            suspenseMaster.SmHQ15A = inComing.SeHQ15A;
            suspenseMaster.SmHQ16A = inComing.SeHQ16A;
            suspenseMaster.SmHQ17A = inComing.SeHQ17A;
            suspenseMaster.SmHQ18A = inComing.SeHQ18A;
            suspenseMaster.SmHQ19A = inComing.SeHQ19A;
            suspenseMaster.SmHQ20A = inComing.SeHQ20A;
            suspenseMaster.SmSig1 = inComing.SeSig1;
            suspenseMaster.SmIdn2 = inComing.SeIdn2;
            WrkName = suspenseMaster.SmLNam2.TrimEnd();
            if (WrkName != "" && WrkNameS == "")
            {
                suspenseMaster.SmLNam2 = WrkName.Trim();
            }

            suspenseMaster.SmFNam2 = inComing.SeFNam2;
            WrkName = suspenseMaster.SmFNam2;

            if (WrkName != "" && WrkNameS == "")
            {
                suspenseMaster.SmFNam2 = WrkName.Trim();
            }

            suspenseMaster.SmMNam2 = inComing.SeMNam2;
            suspenseMaster.SmSufx2 = inComing.SeSufx2;
            suspenseMaster.SmAdd12 = inComing.SeAdd12;
            suspenseMaster.SmAdd22 = inComing.SeAdd22;
            suspenseMaster.SmCity2 = inComing.SeCity2;
            suspenseMaster.SmSte2 = inComing.SeSte2;
            suspenseMaster.SmZip2 = inComing.SeZip2;

            if (TestPhone1 == "")
            {
                inComing.SePhne2 = 0;
            }

            suspenseMaster.SmPhne2 = inComing.SePhne2;
            suspenseMaster.SmDob2 = inComing.SeDob2;
            suspenseMaster.SmSex2 = inComing.SeSex2;
            suspenseMaster.SmHQ01B = inComing.SeHQ01B;
            suspenseMaster.SmHQ02B = inComing.SeHQ02B;
            suspenseMaster.SmHQ03B = inComing.SeHQ03B;
            suspenseMaster.SmHQ04B = inComing.SeHQ04B;
            suspenseMaster.SmHQ05B = inComing.SeHQ05B;
            suspenseMaster.SmHQ06B = inComing.SeHQ06B;
            suspenseMaster.SmHQ07B = inComing.SeHQ07B;
            suspenseMaster.SmHQ08B = inComing.SeHQ08B;
            suspenseMaster.SmHQ09B = inComing.SeHQ09B;
            suspenseMaster.SmHQ10B = inComing.SeHQ10B;
            suspenseMaster.SmHQ11B = inComing.SeHQ11B;
            suspenseMaster.SmHQ12B = inComing.SeHQ12B;
            suspenseMaster.SmHQ13B = inComing.SeHQ13B;
            suspenseMaster.SmHQ14B = inComing.SeHQ14B;
            suspenseMaster.SmHQ15B = inComing.SeHQ15B;
            suspenseMaster.SmHQ16B = inComing.SeHQ16B;
            suspenseMaster.SmHQ17B = inComing.SeHQ17B;
            suspenseMaster.SmHQ18B = inComing.SeHQ18B;
            suspenseMaster.SmHQ19B = inComing.SeHQ19B;
            suspenseMaster.SmHQ20B = inComing.SeHQ20B;
            suspenseMaster.SmSig2 = inComing.SeSig2;
            suspenseMaster.SmFlag = inComing.SeFlag;
            suspenseMaster.SmCnl = inComing.SeCnl;
            suspenseMaster.SmCnlL = inComing.SeCnlL;
            suspenseMaster.SmCnlD = inComing.SeCnlD;
            suspenseMaster.SmSovS = inComing.SeSovS;
            suspenseMaster.SmSovD = inComing.SeSovD;
            suspenseMaster.SmExcd = "";
            suspenseMaster.SmExcP = 0;
            suspenseMaster.SmData = DateTime.Now;              //might need to be a time value
            suspenseMaster.SmUsrA = inComing.UserId;
            suspenseMaster.SmDatU = new DateTime();
            suspenseMaster.SmUsrU = "";
            suspenseMaster.SmPanI = inComing.SePanI;               //SePanI is held in BdPanI
            suspenseMaster.SmLine = inComing.SeLine;
            suspenseMaster.SmDeal = inComing.SeDeal;
            suspenseMaster.SmVIN = "";
            suspenseMaster.SmYear = 0;
            suspenseMaster.SmMake = "";
            suspenseMaster.SmModel = "";
            suspenseMaster.SmFee = 0;
            suspenseMaster.SmComR = 0;
            suspenseMaster.SmGEfft = 0;
            suspenseMaster.SmGExpr = 0;
            suspenseMaster.SmGStat = "";
            suspenseMaster.SmGDate = DateTime.MinValue;
            suspenseMaster.Smmntf = inComing.SeMntf;
            CertHold = "";
            suspenseMaster.SmCert2 = inComing.SeCert2;

            //If this Policy Only contains AOMOB do not write a No coverage record for 
            // the Debt Can part of this certificate.
            if (suspenseMaster.SmLif == 0 && suspenseMaster.SmDis == 0 && suspenseMaster.SmDebt == 0 && GapCovC != 0)
            {
                return;
            }
            else
            {
                // * If 'Superceded' ****** need to revamp this.  Has just place holders now
                if (inComing.SeFlag == "U" && inComing.SeCert2 != inComing.SeCert && inComing.SeCert2 != "")
                {
                    suspenseMaster.SmCnlL = 0;
                    suspenseMaster.SmCnlD = 0;

                    //If "Billed"--Cancel.If Not--Let system delete this cert 110607 101000
                    var bildt = await billingService.ReadAsyncB(Key_8.SeAgnt);

                    if (bildt != null)
                    {
                        Key_8.SeCert = suspenseMaster.SmCert;
                        CertHold = inComing.SeCert2;
                        suspenseMaster.SmCert2 = "";
                    }
                }
            }
            // Write to SusMstR

            //SkipWrite:

            suspenseMaster.SmCnl = inComing.SeCnl;
            suspenseMaster.SmCnlL = inComing.SeCnlL;
            suspenseMaster.SmCnlD = inComing.SeCnlD;

            if (CertHold != "")
            {
                suspenseMaster.SmCert = CertHold;
                //write to SusMstR
            }

            //Reset for "GAP"                                                                              
            suspenseMaster.SmCert = inComing.SeCert;
            suspenseMaster.SmCert2 = inComing.SeCert2;
        }
        public async void WriteAOMOB()
        {
            if (GapCovC != 0)
            {
                suspenseMaster.SmVIN = inComing.SeVIN;         // GAP: Auto VIN Number
                suspenseMaster.SmYear = inComing.SeYear;       // GAP: Auto Year
                suspenseMaster.SmMake = inComing.SeMake;       // GAP: Auto Make
                suspenseMaster.SmModel = inComing.SeModel;     // GAP: AUTO Model
                suspenseMaster.SmFee = inComing.SeFee;         // GAP: Fee Amount
                suspenseMaster.SmComR = inComing.SeComR;       // GAP: Comm. Rate
                suspenseMaster.SmGEfft = inComing.SeGEfft;     // GAP: Effective Date
                suspenseMaster.SmGExpr = inComing.SeGExpr;     // GAP: Expiraiton Date
                suspenseMaster.SmGStat = inComing.SeGStat;     // GAP: Current Status
                suspenseMaster.SmGDate = inComing.SeGDate;     // GAP: Status Date
            }

            // Reset the Coverage Code for GAP Coverage
            suspenseMaster.SmDebt = 50000;           // Default GAP Code
            inComing.SeDebt = 0;
            inComing.SeFut1 = 0;
            inComing.SeFut2 = 0;
            inComing.SeFut17 = GapCovC;
            Key04 key = new Key04();
            key.Key04_Fld01 = inComing.SeDebt + inComing.SeFut1 + inComing.SeFut2;                         //not sure of the values here
            // Chain to PrdCovL2 file
            var record = await productCoverageService.ReadAsyncW(key.Key04_Fld01);
            if (record != null)
            {
                if (inComing.SeEffP <= record.PCEXPR.IntToDate())
                {
                    suspenseMaster.SmDebt = record.PCCOVC;
                    inComing.SeCalc = record.PCCALC;
                }
            }

            CertHold = "";
            suspenseMaster.SmCert2 = inComing.SeCert2;

            // If 'Superceded'
            if (inComing.SeFlag == "U" && inComing.SeCert2 != inComing.SeCert && inComing.SeCert2.Trim() != "")
            {
                suspenseMaster.SmCnlL = 0;
                suspenseMaster.SmCnlD = 0;

                // If "Billed"--Cancel. If Not--Let system delete this cert

                var _record = await billingService.ReadAsyncB(suspenseMaster.SmAgnt);
                if (_record != null)
                {
                    _record.BdBill = suspenseMaster.SmCnl;
                    CertHold = inComing.SeCert2;
                    suspenseMaster.SmCert2 = "";
                }
            }
        }
        public void Update()
        {
            //Delete SusMstR2;              this is probably a replacement of the data
        }
    }
}
