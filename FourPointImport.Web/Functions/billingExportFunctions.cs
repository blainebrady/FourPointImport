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
        private readonly billingDetailService _billingService;
        private readonly formMasterService _formMasterService;
        private readonly ProductCoverageService productCoverageService;
        public int GapCovC { get; set; }
        public billingExport inComing { get; set; }
        public SuspenseMaster suspenseMaster { get; set; }                                //this will be the outgoing class
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
        //suspenseMasterAccess tableAccess, PRDCOVPAccess prdcovpAccess, FrmMstPAccess frmMstLAccess, COVMSTRAccess covmstr,
        public billingExportFunctions([NotNull] billingDetailService billingService, billingExport _inComing, ProductCoverageService _productCoverageService)
        {
            _billingService = billingService;
            Key_2 = new Key02();
            Key_3 = new Key03();
            Key_4 = new Key04();
            Key_5 = new Key05();
            Key_6 = new Key06();
            Key_7 = new Key07();
            Key_8 = new Key08();

            //_tableAccess = tableAccess;
            productCoverageService = _productCoverageService;
            //_formMasterService = frmMstLAccess;
            //_covmstr = covmstr;
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

                    var frmMstL1 = await _formMasterService.ReadAsyncP(seAgent, seForm);

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
                    var keyCalc = _formMasterService.ReadAsyncF(inComing.SeCalc); // initialize a search key with the calculation method
                    if (keyCalc != null)
                    {
                        if (inComing.SeLend.StringSafe().Length > 0) // check if SeLend is not blank
                        {

                            var frmMstL2 = await _formMasterService.ReadAsyncL(Key_6.SeType, Key_6.SeLend); // initialize a search key with the type and lending type
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
                        var frmMstL3 = await _formMasterService.ReadAsyncL(inComing.SeType, inComing.SeCalc); // initialize a search key with the type and calculation method
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
        public void Update()
        {
            //Delete SusMstR2;              this is probably a replacement of the data
        }
    }
}
