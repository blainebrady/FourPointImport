using FourPointImport.Data;
using FourPointImport.Web.Models ;
using System.Globalization;
using Utilities;
using FourPointImport.Services;
using System.Data;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace FourPointImport.Web.Functions
{
    public class MOB206
    {
        CoverageInsuranceMaster covInsMaster { get; set; }
        StoreDebtProtection storeDebtProtection { get; set; }
        SuspenseMaster suspenseMaster { get; set; }
        List<CoverageInsuranceMaster> covMaster { get; set; }
        private DateTime _SmEfftTest { get; set; }
        string ErrCode { get; set; }
        private decimal ErrorLimit { get; set; }
        string ExCd { get; set; }
        private AgentDetail agDetail { get; set; }
        private AgentMaster agMaster { get; set; }
        bool PostData { get; set; }
        private string SecondReq { get; set; }
        private int Severity { get; set; }
        private string SeverityDesc { get; set; }
        private string SeverityErr { get; set; }
        private StoreLifeCoverage storeLifeCoverage { get; set; }
        private StoreDisabilityCoverage storeDisabilityCoverage { get; set; }
        private int TestDays { get; set; }
        protected readonly CoverageMasterService cmService;
        protected readonly AgentDetailService adService;
        protected readonly AgentMasterService amService;
        protected readonly ConfirmationService confService;
        protected readonly CoverageInsuranceService coverageInsuranceService;
        protected readonly FormMasterService fmService;
        protected readonly RateMasterService rmService;
        protected readonly RateDetailService rdService;
        protected readonly LoanApplicationService lmService;
        protected readonly PatronCustomerService patCustService;
        DateTime WorkDate { get; set; }
        DateTime WorkDate2 { get; set; }
        
        public Key01 Key_1;
        public struct Key01
        {
            public string Agnt { get; set; }
            public string Cert { get; set; }
        }
        public Key03Ah Key_3Ah;
        public struct Key03Ah
        {
            public string PrAgnt { get; set; }
            public int SmDis { get; set; }
        }
               
        public Key03LF Key_3LF;
        public struct Key03LF
        {
            public string PrAgnt { get; set; }
            public int SmLif { get; set; }
        }
        public Key07 Key_7;
        public struct Key07
        {
            public string PrAgnt { get; set; }
            public int SmForm { get; set; }
        }
        public Key08 Key_8;
        public struct Key08
        {
            public string LfTble { get; set; }
        }
        public Key09 Key_9;
        public struct Key09
        {
            public string LfTble { get; set; }
            public string SmTrml { get; set; }
        }
        public Key09a Key_9a;
        public struct Key09a
        {
            public string LfTble { get; set; }
        }
        public Key10 Key_10;
        public struct Key10
        {
            public string AhTble { get; set; }
        }
        public Key11 Key_11;
        public struct Key11
        {
            public string AhTble { get; set; }
            public int SmTrmD { get; set; }
        }
        public Key11a Key_11a;
        public struct Key11a
        {
            public string AhTble { get; set; }
        }
        public MOB206(SuspenseMaster _suspenseMaster, CoverageMasterService _cmCervice, AgentMasterService _amService, CoverageInsuranceService _coverageInsuranceService,
            RateMasterService _rmService, RateDetailService _rdService, FormMasterService _fmService, AgentDetailService _adService, LoanApplicationService _lmService,
            PatronCustomerService _patCustService, ConfirmationService _confService)
        {
            suspenseMaster = _suspenseMaster;
            confService = _confService;
            coverageInsuranceService = _coverageInsuranceService;
            cmService = _cmCervice;
            adService = _adService;
            amService = _amService;
            fmService = _fmService;
            lmService = _lmService;
            patCustService = _patCustService;
            rmService = _rmService;
            rdService = _rdService;
            WorkDate = DateTime.Now;
            getCoverage();
        }
        private async void getCoverage()
        {
            covMaster = await cmService.ReadAllAsync();
            Key_1 = new Key01
            {
                Agnt = suspenseMaster.SmAgnt,
                Cert = suspenseMaster.SmCert
            };
        }
        public SuspenseMaster Process()
        {
            //if (suspenseMaster.SmCert.StringSafe().Length == 0)
            //{
            //    Key01 Setll     SusMstL3
            //    Key01         Reade SusMstL3
            //}                                                                 This finds the right record in SuspenseMaster 
            //else                                                              Seeing as we're doing this a record at a time, we'll drop it
            //{
            //    Key01b Setll SusMstL3

            //    Key01b Reade SusMstL3
            //}

            // IF RECORD WAS CANCELLED DON'T CHECK DATA                                                        

            if (suspenseMaster.SmCnl > 0 || suspenseMaster.SmCnlL > 0 || suspenseMaster.SmCnlD > 0)
            {
                PostData = true;
                UpdHist();
                ChgData(suspenseMaster.SmAgnt);
                Post_Data();
                return suspenseMaster;
            }

            SmEfftTest();
            //* Make Sure the Agent is Active and On File                    
            ErrCode = "";

            Severity = 0;

            SeverityDesc = "";

            SeverityErr = "";
            PostData = false;

            Agent_Master();
            if (ErrCode == "AGTMSTL1")
            {
                return suspenseMaster;
            }

            // Test for second insured and valid joint coverage selected                    
            Test2nd();
            // Make Sure the Dates are Valid                             
            Dates();
            if (Severity > ErrorLimit)
                return suspenseMaster;

            // Get the Underwriting Limits from the Agent Detail Files                      
            BuildAgentDetail();
            // Get the Rates for Life  coverage                              
            if (suspenseMaster.SmLif > 0)
            {
                LfRates();
            }
            // Get the Rates for Disability Coverage                   
            if (suspenseMaster.SmDis > 0) {

                AhRates();
            }
            //Get the Rates for Debt Protection Coverage                          
            if (suspenseMaster.SmDebt > 0)
            {
                DpRates();
            }
            // Test all the fields in the Suspense Master Record ....                              
            FieldTest();
            PostData = false;
            if (Severity <= ErrorLimit)
            {
                PostData = true;
                UpdHist();
                ChgData(suspenseMaster.SmAgnt);
                Post_Data();
            }
            //this was used to cycle to the next record - we do that in the controller now
            //NextRead();
            Confirm();
            if (suspenseMaster.SmCert == "")
            {
                //Key01         Reade SusMstL3
            }
            else
            {
                // Key01b Reade SusMstL3
            }

            EndPgm();
            return suspenseMaster;
        }
        private async void Agent_Master()
        {
            var agMasterList = await amService.ReadAllAsync();
            if (agMasterList != null && agMasterList.Count > 0)
            {
                agMaster = agMasterList.Find(x => x.AMEFFT <= _SmEfftTest && x.AMEXPR >= _SmEfftTest);
                if (agMaster != null)
                {
                    return;
                }
            }
            ErrCode = "AgentMaster";
        }
        private async void AhRates()
        {
            if(storeDisabilityCoverage == null)
            {
                storeDisabilityCoverage = new StoreDisabilityCoverage();
            }
            //----------------------------------------------------------------------*
            //Get Rate Amounts and Defintions                                   
            //----------------------------------------------------------------------*
            //Get the Rate Master file infirmation for "LIFE RATES"                                                 
            var RatMaster = await rmService.ReadAllAsync();
            var RatMstL1 = RatMaster.Find(x => x.RmEfft <= _SmEfftTest && x.RmExpr >= _SmEfftTest);
            if (RatMstL1 != null)
            {
                storeDisabilityCoverage.AhBase = RatMstL1.RmBase;
                storeDisabilityCoverage.AhDesc = RatMstL1.RmDesc;

            }
            // No Rate Master File Found of Not Active                                 
            else
            {
                ErrCode = "AH-RATMSTP";
                ErrMsg(ErrCode);
            }                                                                             
                                                                            
// Get the Rate Detail for "LIFE" Coverage
            var RateDetail = await rdService.ReadAllAsync();
            var RatDtlP   = RateDetail.Find(x=>x.RdEfft<= _SmEfftTest && x.RdExpr >= _SmEfftTest);
            if (RatDtlP != null)
            {
                storeDisabilityCoverage.AhBand = RatDtlP.RdBand;
                storeDisabilityCoverage.AhRate = RatDtlP.RdRate;
                storeDisabilityCoverage.AhPrct = RatDtlP.RdPrct;
                Key_11.AhTble = RatDtlP.RDTBLE;
                storeDisabilityCoverage.AhTble = RatDtlP.RDTBLE;
                return;
            }
            else
            {
                // If No record found for this Coverage / Term check Term = 0(Straight Percentage)  
                RatDtlP = RateDetail.Find(x => x.RDTBLE == Key_11a.AhTble);
                if (RatDtlP != null)
                {
                    if (_SmEfftTest >= RatDtlP.RdEfft && _SmEfftTest <= RatDtlP.RdExpr)
                    {
                        storeDisabilityCoverage.AhBand = RatDtlP.RdBand;
                        storeDisabilityCoverage.AhRate = RatDtlP.RdRate;
                        storeDisabilityCoverage.AhPrct = RatDtlP.RdPrct;
                    }

                    else
                    {
                        // No Rate Detail File Found of Not Active
                        ErrCode = "AH-RATDTLP";  
                        ErrMsg(ErrCode); 
                    }
                }
            }                
        }
        private async void BuildAgentDetail()
        {
            agDetail = new AgentDetail();
            // Get Agent Detail Lif(e Underwriting Limits                                                              
            if (suspenseMaster.SmLif > 0)
            {
                var AgtDtll1 = await adService.ReadAllAsync();
                var agDetailList = AgtDtll1.Where(x => x.ADAGNT == Key_3LF.PrAgnt);
                if (agDetailList == null)
                {
                    ErrCode = "AGTDTL - Lif";
                    ErrMsg(ErrCode);
                }
                else
                    foreach (var ag in agDetailList)
                    {
                        if (_SmEfftTest >= agDetail.AdEfft &&
                                  _SmEfftTest <= agDetail.AdExpr)
                        {
                            storeLifeCoverage = new StoreLifeCoverage();
                            storeLifeCoverage.LfTble = agDetail.AdTble;
                            storeLifeCoverage.LfType = agDetail.AdType;
                            storeLifeCoverage.LfMxBa = agDetail.AdMxBa;
                            storeLifeCoverage.LfMxBM = agDetail.AdMxBM;
                            storeLifeCoverage.LfMnAg = agDetail.AdMnAg;
                            storeLifeCoverage.LfMxAg = agDetail.AdMxAg;
                            storeLifeCoverage.LfMnA2 = agDetail.AdMnA2;
                            storeLifeCoverage.LfMxTr = agDetail.AdMxTr;

                            storeLifeCoverage.LfMxCT = agDetail.AdMxCT;
                            storeLifeCoverage.LfHqML = agDetail.AdHqML;
                            storeLifeCoverage.LfHlth = agDetail.AdHlth;
                            storeLifeCoverage.LfLaps = agDetail.AdLaps;
                            storeLifeCoverage.LfComm = agDetail.AdComm;
                            storeLifeCoverage.LfPRat = agDetail.AdPRat;
                            storeLifeCoverage.LfTolP = agDetail.AdTolP;
                            storeLifeCoverage.LfTolA = agDetail.AdTolA;
                            break;
                        }
                    }





                // Get Agent Detail Disability Underwriting Limits               
                if (suspenseMaster.SmDis > 0 && suspenseMaster.SmDis <= 999)
                {
                    foreach (var item in agDetailList)
                    {
                        if (_SmEfftTest >= item.AdEfft && _SmEfftTest <= item.AdExpr)
                        {
                            storeDisabilityCoverage = new StoreDisabilityCoverage();
                            storeDisabilityCoverage.AhType = item.AdType;
                            storeDisabilityCoverage.AhTble = item.AdTble;
                            storeDisabilityCoverage.AhMxBa = item.AdMxBa;
                            storeDisabilityCoverage.AhMxBM = item.AdMxBM;
                            storeDisabilityCoverage.AhMnAg = item.AdMnAg;
                            storeDisabilityCoverage.AhMxAg = item.AdMxAg;
                            storeDisabilityCoverage.AhMnA2 = item.AdMnA2;
                            storeDisabilityCoverage.AhMxTr = item.AdMxTr;
                            storeDisabilityCoverage.AhMxCT = item.AdMxCT;
                            storeDisabilityCoverage.AhHqML = item.AdHqML;
                            storeDisabilityCoverage.AhHlth = item.AdHlth;
                            storeDisabilityCoverage.AhLaps = item.AdLaps;
                            storeDisabilityCoverage.AhComm = item.AdComm;
                            storeDisabilityCoverage.AhPRat = item.AdPRat;
                            storeDisabilityCoverage.AhTolP = item.AdTolP;
                            storeDisabilityCoverage.AhTolA = item.AdTolA;
                            break;
                        }

                    }
                }

                //Get Agent Detail Debt Protection underwriting Limits                                                   
                if (suspenseMaster.SmDebt > 0)
                {
                    foreach (var item in agDetailList)
                    {
                        if (_SmEfftTest >= item.AdEfft && _SmEfftTest <= item.AdExpr)
                        {
                            storeDebtProtection = new StoreDebtProtection();
                            storeDebtProtection.DpType = item.AdType;
                            storeDebtProtection.DpTble = item.AdTble;
                            storeDebtProtection.DpMxBa = item.AdMxBa;
                            storeDebtProtection.DpMxBM = item.AdMxBM;
                            storeDebtProtection.DpMnAg = item.AdMnAg;
                            storeDebtProtection.DpMxAg = item.AdMxAg;
                            storeDebtProtection.DpMnA2 = item.AdMnA2;
                            storeDebtProtection.DpMxTr = item.AdMxTr;
                            storeDebtProtection.DpMxCT = item.AdMxCT;
                            storeDebtProtection.DpHqML = item.AdHqML;
                            storeDebtProtection.DpHlth = item.AdHlth;
                            storeDebtProtection.DpLaps = item.AdLaps;
                            storeDebtProtection.DpComm = item.AdComm;
                            storeDebtProtection.DpPRat = item.AdPRat;
                            storeDebtProtection.DpTolP = item.AdTolP;
                            storeDebtProtection.DpTolA = item.AdTolA;
                            break;
                        }
                        else
                        {
                            ErrCode = "AGTDTL-DP ";
                            ErrMsg(ErrCode);
                        }
                    }
                }
            } 
        }
        private async void ChgData(string SmAgnt)
        {
            if (Utils.ParseNumControlledReturn(suspenseMaster.SmAgnt) <= 90000 || Utils.ParseNumControlledReturn(suspenseMaster.SmAgnt) >= 99999)
            {
                List<CoverageInsuranceMaster> CovMstL1 = await cmService.ReadAllAsync();                                           //need to fill this
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
                            cmService.UpdateAsync(coverageInsuranceMaster.id, coverageInsuranceMaster);
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
        public async void DpRates()
        {
            // ---------------------------------------------------------------------- *     
            // -  Get Rate Amounts and Defintions                                   - *     
            // ---------------------------------------------------------------------- *     


            //  Get the Rate Master file infirmation for "Debt Protection"
            var RatMaster = await rmService.ReadAllAsync();
            var rmRes = RatMaster.Find(x => x.RmEfft <= _SmEfftTest && x.RmExpr >= _SmEfftTest);
            if (rmRes != null)
            {
                storeDisabilityCoverage.AhBase = rmRes.RmBase;
                storeDisabilityCoverage.AhDesc = rmRes.RmDesc;
            }
            else
            {
                // No Rate Master File Found or Not Active                                      

                ErrMsg("DP - RATMSTP");
            }
            //  Get the Rate Detail for "LIFE" Coverage                                     
            var RatDetail = await rdService.ReadAllAsync();
            var rdRes = RatDetail.Find(x => x.RdEfft <= _SmEfftTest && x.RdExpr >= _SmEfftTest);
            if (rdRes != null)
            {
                storeDisabilityCoverage.AhBand = rdRes.RdBand;
                storeDisabilityCoverage.AhRate = rdRes.RdRate;
                storeDisabilityCoverage.AhPrct = rdRes.RdPrct;
            }
            else
            {
                //  If No record found for this Coverage / Term check Term = 0 ( Straight Percentage )  
                rdRes = RatDetail.Find(x => x.RdEfft <= _SmEfftTest && x.RdExpr >= _SmEfftTest);
                if (rdRes != null)
                {
                    storeDisabilityCoverage.AhBand = rdRes.RdBand;
                    storeDisabilityCoverage.AhRate = rdRes.RdRate;
                    storeDisabilityCoverage.AhPrct = rdRes.RdPrct;
                }
                else
                { // No Rate Detail File Found or Not Active                                      
                    ErrMsg("DP - RATDTLP");
                }
            }
        }
        private void FieldTest()
        {
            //***** Field : Agent - Checked in Subroutine "$AGTMSTL1" **************************************           
            // ***** Field : Cert  - Checked in Subroutine "$LONMSTL1" **************************************            
            //  ***** Field : Region - Optional by Bank - No Edit Checking ***********************************            
            if (agMaster.AMRTRQ == "Y" || agMaster.AMRTRQ == "R")
            {
                if (suspenseMaster.SmRegn == "")
                {
                    ErrCode = "REGION";
                    ErrMsg(ErrCode);
                }
            }

            //***** Field : Territory - Optional by Bank - No Edit Checking ********************************   
            if (agMaster.AMRTRQ == "Y" || agMaster.AMRTRQ == "T")
            {
                if (suspenseMaster.SmTerr == "")
                {
                    ErrCode = "TERRITORY";
                    ErrMsg(ErrCode);

                }
            }
            // ***** Field : Branch - (AMBORQ) Branch / Officer Required ************************************
            if (agMaster.AmBoRq == "Y" || agMaster.AmBoRq == "B")
            {
                if (suspenseMaster.SmBrch == "")
                {
                    ErrCode = "BRANCH";
                    ErrMsg(ErrCode);
                }
            }

            //***** Field : Offcier - (AMBORQ) Branch / Officer Required ***********************************   

            if (agMaster.AmBoRq == "Y" || agMaster.AmBoRq == "O")
            {
                if (suspenseMaster.SmOffc == "")
                {
                    ErrCode = "OFFICER";
                    ErrMsg(ErrCode);
                }
            }

            //***** Field : Beneficiary # 1 - Not Currently Used !! ****************************************     

            //***** Field : Beneficiary # 2 - Not Currently Used !! ****************************************       

            //***** Field : First Payment Date - Test in the Subroutine "$DATES" ***************************    

            //***** Field : Effective Date - Test in the Subroutine "$DATES" *******************************   

            //***** Field : Loan Expiration Date - Tested in the Subroutine "$DATES" ***********************    
            //***** Field : Loan Term **********************************************************************    
            if (suspenseMaster.SmTerm == 0)
            {
                ErrCode = "LOANTERMMN";
                ErrMsg(ErrCode);
            }

            //***** Field : Loan Payment Frequency **- Payments Per Year -**********************************
            if (suspenseMaster.SmFreq == 1 ||
                 suspenseMaster.SmFreq == 2 ||
                       suspenseMaster.SmFreq == 4 ||
                     suspenseMaster.SmFreq == 6 ||
                        suspenseMaster.SmFreq == 12 ||
                       suspenseMaster.SmFreq == 24 ||
                        suspenseMaster.SmFreq == 26 ||
                       suspenseMaster.SmFreq == 52)
            { }
            else
            {
                ErrCode = "PAYMNTFREQ";
                ErrMsg(ErrCode);
            }

            //***** Field : Loan Amount ********************************************************************
            if (suspenseMaster.SmAmnt <= 0 && suspenseMaster.SmType != "OEDP")
            {
                ErrCode = "LOANAMTMN";
                ErrMsg(ErrCode);
            }

            //*****Field : Interest Rate ******************************************************************   
            if (suspenseMaster.SmIntr == 0)
            {
                if (suspenseMaster.SmCalc == "LM" ||
                             suspenseMaster.SmCalc == "DA" ||
                           suspenseMaster.SmCalc == "DP")
                { }
                else {
                    ErrCode = "INTRATE";
                    ErrMsg(ErrCode);
                }
            }

            //***** Field : Scheduled Payment **************************************************************
            if (suspenseMaster.SmSchd == 0)
            {
                if (suspenseMaster.SmType != "OEDP")
                     {
                    ErrCode = "SCHDPMT";
                    ErrMsg(ErrCode);
                }
            }
            //***** Field : Form Number ********************************************************************            
            //* -------------------------------------------------- *                                                   
            //* - Skip Per Karen Stockton 3/19/2003              - *                                                   
            //* -------------------------------------------------- *                                                   
            Form_Master();


            //* ****Field : Daily Life Rate * ***************************************************************

            //***** Field : Daily Disability Rate **********************************************************            

            // ***** Field : Estimated Annual Life Charge ***************************************************            
            //**********************************************************************************************            
            //** Steve Clark - 09/16/2004 - Condition the Life amount check with the A&H Only field from  **            
            //**                            the Agent Master File - If A&H Only is allowed then this check**            
            //**                            should be skipped becasue a $0 amount is allowed . . . . .    **            
            //**********************************************************************************************            
            if (suspenseMaster.SmLChg.StringSafe().Length <= 0)
                if (suspenseMaster.SmType == "CEMOB")
                    if (suspenseMaster.SmLif > 0)
                        if (agMaster.AmOnly == "N") {
                            ErrCode = "ANNUAL-LIF";
                            ErrMsg(ErrCode);
                        }


            if (agMaster.AmOnly == "Y")
            {
                ErrCode = "A&H ONLY  ";
                ErrMsg(ErrCode);

            }

            //***** Field : Intial Amount of Life Insurance ************************************************            
            if (suspenseMaster.SmLif > 0)
            {
                if (suspenseMaster.SmLBen <= 0)
                {
                    ErrCode = "LFAMNT=0";
                    ErrMsg(ErrCode);
                }
                if (suspenseMaster.SmLBen > suspenseMaster.SmAmnt)
                {
                    ErrCode = "LFAMNT";
                    ErrMsg(ErrCode);
                }
                if (suspenseMaster.SmLBen > agDetail.AdMxBa)
                {
                    ErrCode = "LFAMNT-MAX";
                    ErrMsg(ErrCode);
                }
            }
            //***** Field : Intial Amount of Disability Insurance ******************************************            
            if (suspenseMaster.SmDis > 0)
            {
                if (suspenseMaster.SmDBen <= 0)
                {
                    ErrCode = "AHAMNT=0";
                    ErrMsg(ErrCode);
                }
                if (suspenseMaster.SmDBen > suspenseMaster.SmSchd)
                {
                    ErrCode = "AHAMNT";
                    ErrMsg(ErrCode);
                }
                if (suspenseMaster.SmDBen > storeDisabilityCoverage.AhMxBa)
                {
                    storeDisabilityCoverage.AhExBa = (suspenseMaster.SmDBen * suspenseMaster.SmTrmD) - 1;

                    if (storeDisabilityCoverage.AhExBa > storeDisabilityCoverage.AhMxBa)
                    {
                        ErrCode = "AHAMNT-MAX";
                        ErrMsg(ErrCode);
                    }
                }
            }
            //***** Field : First Premium Due Date - Checked in Subroutine "$DATES" ************************            
            //***** Field : Term of Life Coverage **********************************************************            
            if (suspenseMaster.SmLif > 0)
            {
                if (suspenseMaster.SmTrmL <= 0)
                {
                    ErrCode = "LF-TERM-MN";
                    ErrMsg(ErrCode);
                }
                if (suspenseMaster.SmTrmL > storeLifeCoverage.LfMxCT)
                {
                    ErrCode = "LF-TERM-MX";
                    ErrMsg(ErrCode);
                }
            }
            //***** Field : Term of Disability Coverage ****************************************************            
            if (suspenseMaster.SmDis > 0)
            {
                if (suspenseMaster.SmTrmD <= 0)
                {
                    ErrCode = "AH-TERM-MN";
                    ErrMsg(ErrCode);
                }
                if (suspenseMaster.SmTrmD > storeDisabilityCoverage.AhMxCT)
                {
                    ErrCode = "AH-TERM-MX";
                    ErrMsg(ErrCode);
                }
            }
            // ***** Field : Term of Debt Protection Coverage ***********************************************            
            if (suspenseMaster.SmDebt > 0)
            {
                if (suspenseMaster.SmTrmP <= 0)
                {
                    ErrCode = "DP-TERM-MN";
                    ErrMsg(ErrCode);
                }
                if (suspenseMaster.SmTrmP > storeDebtProtection.DpMxCT)
                {
                    if (suspenseMaster.SmType == "CEDP")
                    {
                        ErrCode = "TRUNC-DP";
                        ErrMsg(ErrCode);
                    }
                }
            }
            //***** Field : Extra Days - Tested in the Subroutine "$DATES" *********************************            
            //***** Field : Life Coverage Code - Tested in Subroutine "$PRDCOVL1 & AGTDTLL1" ***************            
            //***** Field : Disability  Coverage Code - Tested in Subroutine "$PRDCOVL1 & AGTDTLL1" ********            
            //***** Field : First Insured ID - No Editing or Validation ************************************            
            //***** Field : First Insured Last Name ********************************************************            
            if (suspenseMaster.SmLNam1 == "" || suspenseMaster.SmLNam1A == "")
            {
                ErrCode = "1ST-LNAME";
                ErrMsg(ErrCode);
            }

            //***** Field : First Insured First Name *******************************************************            
            if (suspenseMaster.SmFNam1 == "" || suspenseMaster.SmFNam1A == "")
            {
                ErrCode = "1ST-FNAME";
                ErrMsg(ErrCode);

            }
            //***** Field : First Insured Middle Name - No editing or Validation ***************************            
            // ***** Field : First Insured Address Line 1 - No Editing or Validation ************************            
            //    ***** Field : First Insured Address Line 2 - No Editing or Validation ************************            
            //    ***** Field : First Insured City  - No editing or Validation *********************************            
            //    ***** Field : First Insured State - No editing or Validation *********************************            
            //    ***** Field : First Insured ZipCode - No editing or Validation *******************************            
            //  ***** Field : First Insured Phone   - No editing or Validation *******************************            
            //   ***** Field : First Insured Date of Birth - Checked and Edited in Subroutine "$DATES" ********            

            //***** Field : First Insured Gender  - No editing or Validation *******************************            
            if (suspenseMaster.SmSex1 != "M" &&
                 suspenseMaster.SmSex1 != "F" &&
                       suspenseMaster.SmSex1 != " ")
            {
                ErrCode = "1ST-GENDER";
                ErrMsg(ErrCode);
            }

            //***** Field : First Insured Health Question # 1 - Must be "Y" / "N" / " " ********************            
            if (suspenseMaster.SmHQ01A == "Y" ||
                      suspenseMaster.SmHQ01A == "N" ||
                       suspenseMaster.SmHQ01A == " ")
            { }
            else
            {
                ErrCode = "1ST-HQ#1";
                ErrMsg(ErrCode);
            }

            //***** Field : First Insured Health Question # 2 - Must be "Y" / "N" / " " ********************            
            if (suspenseMaster.SmHQ02A == "Y" ||
                     suspenseMaster.SmHQ02A == "N" ||
                     suspenseMaster.SmHQ02A == " ")
            { }
            else {
                ErrCode = "1ST-HQ#2";
                ErrMsg(ErrCode);
            }

            //***** Field : First Insured Health Question # 3 - Must be "Y" / "N" / " " ********************            
            if (suspenseMaster.SmHQ03A == "Y" ||
                      suspenseMaster.SmHQ03A == "N" ||
                     suspenseMaster.SmHQ03A == " ")
            { }
            else {
                ErrCode = "1ST-HQ#3";
                ErrMsg(ErrCode);
            }

            //***** Field : First Insured Health Question # 4 - Must be "Y" / "N" / " " ********************            
            if (suspenseMaster.SmHQ04A == "Y" ||
                       suspenseMaster.SmHQ04A == "N" ||
                       suspenseMaster.SmHQ04A == " ")
            { }
            else {
                ErrCode="1ST-HQ#4  ";
                ErrMsg(ErrCode);
            }

            // ***** Field : Second Insured Last Name *******************************************************            
            if (suspenseMaster.SmLNam2 == "" || suspenseMaster.SmLNam2A == "")
            {
                ErrCode = "2ND-LNAME";
                ErrMsg(ErrCode);
            }                                                                                                                                                                                  
//***** Field : Second Insured First Name ******************************************************            
            if(suspenseMaster.SmFNam2     == "" || suspenseMaster.SmFNam2A == ""   )
            {
                ErrCode =  "2ND-FNAME";
                ErrMsg(ErrCode);
            }

            //***** Field : smidn2 is not a duplicate of first *********************************************           

            if (suspenseMaster.SmIdn2 == suspenseMaster.SmIdn1 && suspenseMaster.SmIdn2 != 0)
            {
                ErrCode = "2ND-ID DUP";
                ErrMsg(ErrCode);
            }
            //***** Field : Second Insured Address Line 1 - No Editing or Validation ***********************            

            //***** Field : Second Insured Middle Name - No editing or Validation **************************           
            //***** Field : Second Insured Address Line 1 - No Editing or Validation ***********************           
            //***** Field : Second Insured Address Line 2 - No Editing or Validation ***********************            
            //***** Field : Second Insured City  - No editing or Validation ********************************            
            //     ***** Field : Second Insured State - No editing or Validation ********************************            
            //      ***** Field : Second Insured ZipCode - No editing or Validation ******************************            

            //    ***** Field : Second Insured Phone   - No editing or Validation ******************************            
            //      ***** Field : Second Insured Date of Birth - Checked and Edited in Subroutine "$DATES" *******            
            //***** Field : Second Insured Gender  - No editing or Validation ******************************            
            if (suspenseMaster.SmSex2 != "M" &&
                      suspenseMaster.SmSex2 != "F" &&
                      suspenseMaster.SmSex2 != " ") 
            {
                ErrCode = "2ND-GENDER";
                ErrMsg(ErrCode);
            }

            //***** Field : Second Insured Health Question # 1 - Must be "Y" / "N" / " " *******************            
            if (suspenseMaster.SmHQ01B != "Y" &&
                      suspenseMaster.SmHQ01B != "N" &&
                    suspenseMaster.SmHQ01B != " ")
            {
                ErrCode = "2ND-HQ#1";
                ErrMsg(ErrCode);
            }

            //***** Field : Second Insured Health Question # 2 - Must be "Y" / "N" / " " *******************            
            if (suspenseMaster.SmHQ02B != "Y" &&
                     suspenseMaster.SmHQ02B != "N" &&
                     suspenseMaster.SmHQ02B != " ")
            {
                ErrCode = "2ND-HQ#2";
                ErrMsg(ErrCode);
            }

            //***** Field : Second Insured Health Question # 3 - Must be "Y" / "N" / " " *******************            
            if (suspenseMaster.SmHQ03B != "Y" &&
                      suspenseMaster.SmHQ03B != "N" &&
                      suspenseMaster.SmHQ03B != " ")
            {
                ErrCode = "2ND-HQ#3";
                ErrMsg(ErrCode);
            }

            //***** Field : Second Insured Health Question # 4 - Must be "Y" / "N" / " " *******************            
            if (suspenseMaster.SmHQ04B != "Y" &&
                      suspenseMaster.SmHQ04B != "N" &&
                      suspenseMaster.SmHQ04B != " ")
            {
                ErrCode = "2ND-HQ#4";
                ErrMsg(ErrCode);
            }                                                                       
                                                                                                                                                                                
                          
        }
        private async void Form_Master()
        {
            var FrmMstl1 = await fmService.ReadAllAsync();
            if (FrmMstl1 != null)
            {
                var frmMast = FrmMstl1.Find(x => x.FmAGNT == Key_7.PrAgnt && x.FmForm == Key_7.SmForm);
                if (_SmEfftTest >= frmMast.FmEfft && _SmEfftTest <= frmMast.FmExpr)
                {
                    return;
                }
            }
        }
        private CoverageInsuranceMaster GapChg(string smAgnt, string smcert, CoverageInsuranceMaster cOVMSTR)
        {
            // If coverage changed call program that will determine the cancel date from the last billing 
            // and mark record as cancelled then process as it would normally...

            return new MOB216(smAgnt, smcert, cOVMSTR).covMSTR;
        }
        public void Confirm()
        {
            Confirmation error = new Confirmation();
            if (Severity < ErrorLimit)
            {
                error.CfAgnt = suspenseMaster.SmAgnt;
                error.CfCert = suspenseMaster.SmCert;
                error.CfFlag = "A";
                error.CfErr = "";
                error.CfProc = DateTime.Now;
                // ConFrmR.Write();                                                      get a way to store this
            }
            else
            {
                error.CfAgnt = suspenseMaster.SmAgnt;
                error.CfCert = suspenseMaster.SmCert;
                error.CfFlag = "R";
                error.CfErr = SeverityErr;
                error.CfProc = DateTime.Now;
                // ConFrmR.WriteLine();
            }

            if (ExCd == "")
            {
                ExCd = "NV";
            }
            confService.CreateAsync(error).Wait();
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
        private void Post_Data()
        {
            suspenseMaster = new MOB210(suspenseMaster).Process();
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

            if (storeDisabilityCoverage == null)
                storeDisabilityCoverage = new StoreDisabilityCoverage();
            // Get the Rate Master file information for "LIFE RATES"
            var ratMstL1 = RatMstL1.Find(x => x.RmTble == key10);
            if (ratMstL1 != null)
            {
                if (_SmEfftTest >= ratMstL1.RmEfft && _SmEfftTest <= ratMstL1.RmExpr)
                {
                    storeDisabilityCoverage.AhBase = ratMstL1.RmBase;
                    storeDisabilityCoverage.AhDesc = ratMstL1.RmDesc;
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
                    storeDisabilityCoverage.AhBand = RateDetailLife.RdBand;
                    storeDisabilityCoverage.AhRate = RateDetailLife.RdRate;
                    storeDisabilityCoverage.AhPrct = RateDetailLife.RdPrct;
                }
            }
            else// If No record found for this Coverage / Term check Term = 0 ( Straight Percentage )
            {
                RateDetailLife = RatDtl.Find(x => x.RDTBLE == key11a);
                if (RateDetailLife != null)
                {
                    if (_SmEfftTest >= RateDetailLife.RdEfft && _SmEfftTest <= RateDetailLife.RdExpr)
                    {
                        storeDisabilityCoverage.AhBand = RateDetailLife.RdBand;
                        storeDisabilityCoverage.AhRate = RateDetailLife.RdRate;
                        storeDisabilityCoverage.AhPrct = RateDetailLife.RdPrct;
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
            if(storeLifeCoverage == null)
            {
                storeLifeCoverage = new StoreLifeCoverage();
            }
            // Get the Rate Master file information for "LIFE RATES"
            List<RateMaster> ratMstL1 = new List<RateMaster>();
            var ratMstL = ratMstL1.Find(x => x.RmTble == Key_8.LfTble);

            if (ratMstL != null)
            {
                if (_SmEfftTest >= ratMstL.RmEfft && _SmEfftTest <= ratMstL.RmExpr)
                {
                    storeLifeCoverage.LfBase = ratMstL.RmBase;
                    storeLifeCoverage.LfDesc = ratMstL.RmDesc;
                }
            }

            // No Rate Master File Found of Not Active
            else
            {
                ErrMsg("LF-RateMaster");
            }

            // Get the Rate Detail for "LIFE" Coverage
            List<RateDetailLife> ratDtlP = new List<RateDetailLife>();
            var ratDtl = ratDtlP.Find(x => x.RDTBLE == Key_9.LfTble);

            if (ratDtl != null)
            {
                if (_SmEfftTest >= ratDtl.RdEfft && _SmEfftTest <= ratDtl.RdExpr)
                {
                    storeLifeCoverage.LfBand = ratDtl.RdBand;
                    storeLifeCoverage.LfRate = ratDtl.RdRate;
                    storeLifeCoverage.LfPrct = ratDtl.RdPrct;
                }
            }
            else             // If No record found for this Coverage / Term check Term = 0 ( Straight Percentage )
            {
                ratDtl = ratDtlP.Find(x => x.RDTBLE == Key_9a.LfTble);

                if (ratDtl != null)
                {
                    if (_SmEfftTest >= ratDtl.RdEfft && _SmEfftTest <= ratDtl.RdExpr)
                    {
                        storeLifeCoverage.LfBand = ratDtl.RdBand;
                        storeLifeCoverage.LfRate = ratDtl.RdRate;
                        storeLifeCoverage.LfPrct = ratDtl.RdPrct;
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
        private void Test2nd()
        {

        }
        private void UpdHist()
        {
            string pragnt = suspenseMaster.SmAgnt;
            decimal prdebt = suspenseMaster.SmDebt;

            if (suspenseMaster.SmDebt == 0)
            {
                var covItem = covMaster.Find(x => x.CmAgnt == Key_1.Agnt && x.CmAgnt == Key_1.Cert);
                new MOB208(pragnt, suspenseMaster.SmCert, suspenseMaster, covItem, lmService, patCustService);
            }
            else
            {
                new MOB208DCC(pragnt, suspenseMaster.SmCert, prdebt, suspenseMaster, covInsMaster);
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
