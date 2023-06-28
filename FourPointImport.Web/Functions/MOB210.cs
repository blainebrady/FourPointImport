using FourPointImport.Data;
using Microsoft.AspNetCore.DataProtection;
using Utilities;

namespace FourPointImport.Web.Functions
{
    public class MOB210
    {
        public SuspenseMaster susMaster { get; set; }
        public CoverageInsuranceMaster cOVMSTR { get; set; }
        public LoanApplicationHistory lONMSTP { get; set; }
        public QuestionAnswer qstNsp { get; set; }
        public List<AgentDetail> aGTDTLL { get; set; }
        public List<PatronCustomer> Insmstl1 { get; set; }
        public List<RateMaster> ratMast { get; set; }
        public string Key02A { get; set; }
        public string Key02B { get; set; }
        public string UserId { get; set; }
        public string PgmNam { get; set; }
        public decimal Rate { get; set; }
        public string Key04 { get; set; }
        public string SmRtng1 { get; set; }
        public string SmRtng2 { get; set; }
        public string SmAcct1 { get; set; }
        public string SmAcct2 { get; set; }
        public string Key05 { get; set; }
        // Key to File : FrmMstL1 - Form Number and Type 
        public int Key06 { get; set; }
        public string Key07 { get; set; }
        public MOB210(SuspenseMaster _susMaster)
        {
            
            cOVMSTR = new CoverageInsuranceMaster();
            susMaster = _susMaster;
            Key02A = susMaster.SmAgnt;
            Key02B = susMaster.SmCert;
            UserId = susMaster.SmAgnt;
           
        }
        public SuspenseMaster Process()
        {
            if (susMaster != null)
            {
                CertChg();
                Upper();
                FrmMstL1();
                GetIDN();
                BrcMstL2();
                LonMst();
                InsMst_01();
                InsMst_02();
                GapMstL1();
                CovMst_Lif();
                CovMst_Dis();
                CovMst_DP();
                Delete_Sus();
            }
            return susMaster;
        }
        public void CertChg()
        {
            string CertHold = string.Empty; //assuming CertHold is a string variable
            if (susMaster.SmFlag == "U")
            {
                if (susMaster.SmCert2.Trim() != string.Empty)
                {
                    CertHold = susMaster.SmCert2.Trim();
                    susMaster.SmCert2 = susMaster.SmCert.Trim();
                    susMaster.SmCert = CertHold;
                }
            }
        }
        public void Upper()
        {
            susMaster.SmRegn = susMaster.SmRegn.ToUpper();
            susMaster.SmTerr = susMaster.SmTerr.ToUpper();
            susMaster.SmBrch = susMaster.SmBrch.ToUpper();
            susMaster.SmOffc = susMaster.SmOffc.ToUpper();
            susMaster.SmBen1 = susMaster.SmBen1.ToUpper();
            susMaster.SmBen2 = susMaster.SmBen2.ToUpper();
            susMaster.SmType = susMaster.SmType.ToUpper();
            susMaster.SmCalc = susMaster.SmCalc.ToUpper();
            susMaster.SmLend = susMaster.SmLend.ToUpper();
            susMaster.SmLNam1 = susMaster.SmLNam1.ToUpper();
            susMaster.SmFNam1 = susMaster.SmFNam1.ToUpper();
            susMaster.SmMNam1 = susMaster.SmMNam1.ToUpper();
            susMaster.SmSufx1 = susMaster.SmSufx1.ToUpper();
            susMaster.SmAdd11 = susMaster.SmAdd11.ToUpper();
            susMaster.SmAdd21 = susMaster.SmAdd21.ToUpper();
            susMaster.SmCity1 = susMaster.SmCity1.ToUpper();
            susMaster.SmSte1 = susMaster.SmSte1.ToUpper();
            susMaster.SmLNam2 = susMaster.SmLNam2.ToUpper();
            susMaster.SmFNam2 = susMaster.SmFNam2.ToUpper();
            susMaster.SmMNam2 = susMaster.SmMNam2.ToUpper();
            susMaster.SmSufx2 = susMaster.SmSufx2.ToUpper();
            susMaster.SmAdd12 = susMaster.SmAdd12.ToUpper();
            susMaster.SmAdd22 = susMaster.SmAdd22.ToUpper();
            susMaster.SmCity2 = susMaster.SmCity2.ToUpper();
            susMaster.SmSte2 = susMaster.SmSte2.ToUpper();
        }
        void FrmMstL1()
        {
            var recFound = new List<FormMaster>().Find(x => x.FmAGNT == Key06.StringSafe());

            if (recFound == null)
            {
                return;
            }

            if (lONMSTP.LmCalc == "" && recFound.FmCalc != "")
            {
                lONMSTP.LmCalc = recFound.FmCalc;
            }
        }

        private void GetIDN()
        {
            // Define Data Area for Manufactured Customer ID Number

            if (susMaster.SmIdn1 == 0)
            {
                if (susMaster.SmIdn1 < 2)
                {
                    susMaster.SmIdn1 = 1;
                }
            }

            if (!string.IsNullOrEmpty(susMaster.SmLNam2))
            {
                if (susMaster.SmIdn2 == 0)
                {
                    if (susMaster.SmIdn2 < 2)
                    {
                        susMaster.SmIdn2 = 1;
                    }
                }
            }
        }


        public void BrcMstL2()
        {
            if (susMaster.SmRegn.StringSafe().Length > 0 || susMaster.SmTerr.StringSafe().Length > 0 || susMaster.SmBrch.StringSafe().Length > 0 || susMaster.SmOffc.StringSafe().Length > 0)
            {
                List<BranchOffice> brcMstp = new List<BranchOffice>();
                var record = brcMstp.Find(x => x.BmAgnt == Key07);

                if (record == null)
                {
                    return;
                }

                susMaster.SmAgnt = record.BmAgnt;
                susMaster.SmRegn = record.BmRegn;
                susMaster.SmTerr = record.BmTerr;
                susMaster.SmBrch = record.BmBrch;
                susMaster.SmOffc = record.BmOffc;
                record.BmDatA = DateTime.Now;
                record.BmUsrA = PgmNam;
                //brcMstp.Write(record);
            }
        }

        void LonMst()
        {
            lONMSTP.LmAgnt = susMaster.SmAgnt;
            lONMSTP.LmRegn = susMaster.SmRegn;
            lONMSTP.LmTerr = susMaster.SmTerr;
            lONMSTP.LmBrch = susMaster.SmBrch;
            lONMSTP.LmOffc = susMaster.SmOffc;
            lONMSTP.LmCert = susMaster.SmCert;
            lONMSTP.LmIdn1 = susMaster.SmIdn1;
            lONMSTP.LmIdn2 = susMaster.SmIdn2;
            lONMSTP.LmBen1 = susMaster.SmBen1;
            lONMSTP.LmBen2 = susMaster.SmBen2;
            lONMSTP.LmFPay = susMaster.SmFPay;
            lONMSTP.LmEfft = susMaster.SmEfft;
            lONMSTP.LmExpr = susMaster.SmExpr;
            lONMSTP.LmTerm = susMaster.SmTerm;
            lONMSTP.LmFreq = susMaster.SmFreq;
            lONMSTP.LmAmnt = susMaster.SmAmnt;
            lONMSTP.LmSchd = susMaster.SmSchd;
            lONMSTP.LmIntr = susMaster.SmIntr;
            lONMSTP.LmForm = susMaster.SmForm;
            lONMSTP.LmStat = "";
            lONMSTP.LmSig1 = susMaster.SmSig1;
            lONMSTP.LmSig2 = susMaster.SmSig2;
            lONMSTP.LmCnlD = susMaster.SmCnlD;
            lONMSTP.LmDatA = DateTime.Now;
            lONMSTP.LmUsrA = UserId;
            lONMSTP.LmPani = susMaster.SmPanI;
            lONMSTP.LmLine = susMaster.SmLine;
            lONMSTP.LmPrev = susMaster.SmCert2;
            lONMSTP.LmMntf = susMaster.Smmntf;

            //LonMstR.Write();
        }
        void InsMst_01()
        {
            var recFound = Insmstl1.Find(x => x.ImStat == Key02A);

            recFound.ImIDN = susMaster.SmIdn1;
            recFound.ImLNam = susMaster.SmLNam1;
            recFound.ImFNam = susMaster.SmFNam1;
            recFound.ImMNam = susMaster.SmMNam1;
            recFound.ImSufx = susMaster.SmSufx1;
            recFound.ImAdd1 = susMaster.SmAdd11;
            recFound.ImAdd2 = susMaster.SmAdd21;
            recFound.ImCity = susMaster.SmCity1;
            recFound.ImSte = susMaster.SmSte1;
            recFound.ImZip = susMaster.SmZip1;
            recFound.ImPhne = susMaster.SmPhne1;
            recFound.ImDob = susMaster.SmDob1;
            recFound.ImSex = susMaster.SmSex1;
            recFound.ImUsrA = UserId;

            if (recFound != null)
            {
                recFound.ImDatU = DateTime.Now;
                recFound.ImUsrU = UserId;
                //Insmstl1.Update();
            }
            else
            {
                recFound.ImDatA = DateTime.Now;
                recFound.ImUsrA = UserId;
                //InsmstR.Write();
            }

            Health01();
        }
        void InsMst_02()
        {
            if (susMaster.SmIdn2 > 0)
            {
                var recFound = Insmstl1.Find(x => x.ImUsrA == Key02B);

                recFound.ImIDN = susMaster.SmIdn2;
                recFound.ImLNam = susMaster.SmLNam2;
                recFound.ImFNam = susMaster.SmFNam2;
                recFound.ImMNam = susMaster.SmMNam2;
                recFound.ImSufx = susMaster.SmSufx2;
                recFound.ImAdd1 = susMaster.SmAdd12;
                recFound.ImAdd2 = susMaster.SmAdd22;
                recFound.ImCity = susMaster.SmCity2;
                recFound.ImSte = susMaster.SmSte2;
                recFound.ImZip = susMaster.SmZip2;
                recFound.ImPhne = susMaster.SmPhne2;
                recFound.ImDob = susMaster.SmDob2;
                recFound.ImSex = susMaster.SmSex2;
                //        recFound.ImRtng = SmRtng2;
                //        recFound.ImAcct = SmAcct2;
                recFound.ImUsrA = UserId;

                if (recFound != null)
                {
                    recFound.ImDatU = DateTime.Now;
                    recFound.ImUsrU = UserId;
                    //Insmstl1.Update();
                }
                else
                {
                    recFound.ImDatA = DateTime.Now;
                    recFound.ImUsrA = UserId;
                    //InsmstR.Write();
                }
            }

            Health02();
        }
        public void GapMstL1()
        {
            if (susMaster.SmVIN.Trim() != "" || susMaster.SmMake.Trim() != "" || susMaster.SmModel.Trim() != "")
            {
                // Move a Copy of the current record to History File
                List<GAPInsurance> GapMstL1 = new List<GAPInsurance>();
                var record = GapMstL1.Find(x => x.GmVIN == susMaster.SmVIN);
                if (record != null)
                {
                    record.GmHstD = DateTime.Now;
                    record.GmHstU = UserId;
                    //GapHstR.Write();

                    // Update Existing Record with new information
                    record.GmAgnt = susMaster.SmAgnt;
                    record.GmCert = susMaster.SmCert;
                    record.GmVIN = susMaster.SmVIN;
                    record.GmYear = susMaster.SmYear;
                    record.GmMake = susMaster.SmMake;
                    record.GmModel = susMaster.SmModel;
                    record.GmFee = susMaster.SmFee;
                    record.GmComR = susMaster.SmComR;
                    record.GmEfft = Utils.DecimalToDate(susMaster.SmGEfft);
                    record.GmExpr = Utils.DecimalToDate(susMaster.SmGExpr);
                    record.GmStat = susMaster.SmGStat;
                    record.GmSDte = susMaster.SmGDate;
                    record.GmDatU = DateTime.Now;
                    record.GmUsrU = UserId;
                    record.GmHstU = "";
                    //GapMstR.Update();
                }
                else
                {
                    // Create new Record
                    record.GmAgnt = susMaster.SmAgnt;
                    record.GmCert = susMaster.SmCert;
                    record.GmVIN = susMaster.SmVIN;
                    record.GmYear = susMaster.SmYear;
                    record.GmMake = susMaster.SmMake;
                    record.GmModel = susMaster.SmModel;
                    record.GmFee = susMaster.SmFee;
                    record.GmComR = susMaster.SmComR;
                    record.GmEfft = Utils.DecimalToDate(susMaster.SmGEfft);
                    record.GmExpr = Utils.DecimalToDate(susMaster.SmGExpr);
                    record.GmStat = susMaster.SmGStat;
                    record.GmSDte = susMaster.SmGDate;
                    record.GmDatA = DateTime.Now;
                    record.GmUsrA = UserId;
                    record.GmHstU = "";
                    //GapMstR.Write();
                }
            }
        }

        public void CovMst_Amnt()
        {
            Key04 = ""; /* initialize value */
            bool In04 = false;

            var ChainResult = ratMast.Find(x => x.RmTble == Key04);

            if (ChainResult != null)
            {
                Key05 = ""; /* initialize value */;
                bool In05 = false;

                ChainResult = ratMast.Find(x => x.RmTble == Key05);
                //To Calculate: First Calculate the Daily Premium Rate                                        
                //Principle Amount Divide by 1000 to get per Thousand Basis                             
                // Multiple by daily Rate to get daily premium                                           
                // Multiple by 30 days per month to get Monthly Premium Rate
                if (ChainResult != null)
                {
                    decimal RdRate = Rate;
                    decimal BaseDiff = 0;
                    decimal RmBase = BaseDiff / 1000;
                    Rate = Rate / BaseDiff;

                    decimal DayRate = 0;
                    decimal WrkAmnt = 0;
                    decimal CmAmnt = 0;
                    DayRate = ((Rate * 12) / 365);
                    WrkAmnt = ((lONMSTP.LmAmnt / 1000) * DayRate);
                    CmAmnt = ((lONMSTP.LmAmnt / 1000) * Rate);
                }
            }
        }

        void CovMst_Lif()
        {
            if (susMaster.SmLif > 0)
            {
                cOVMSTR.CmAgnt = susMaster.SmAgnt;
                cOVMSTR.CmCert = susMaster.SmCert;
                cOVMSTR.CmIDN1 = susMaster.SmIdn1;
                cOVMSTR.CmIDN2 = susMaster.SmIdn2;
                cOVMSTR.CmFPrm = susMaster.SmFPrm;
                cOVMSTR.CmTerm = susMaster.SmTrmL;
                cOVMSTR.CmDays = susMaster.SmDays;
                cOVMSTR.CmStat = string.Empty;
                cOVMSTR.CmCovc = susMaster.SmLif;
                cOVMSTR.CmTble = string.Empty;
                cOVMSTR.CmLapD = 0;
                cOVMSTR.CmLapR = string.Empty;
                cOVMSTR.CmCand = 0;
                cOVMSTR.CmCanr = string.Empty;
                cOVMSTR.CmEfft = susMaster.SmEfft;

                // Life Benefit Amount from 4Point - Added per Diana Santellan (March 6th 2008)
                cOVMSTR.CmBAmt = susMaster.SmLBen;

                // Life Cancellation Date
                if (susMaster.SmCnl > 0 && susMaster.SmCnlL == 0)
                {
                    susMaster.SmCnlL = (int)susMaster.SmCnl;
                }

                if (susMaster.SmCnlL > 0)
                {
                    cOVMSTR.CmCand = susMaster.SmCnlL;
                    if (cOVMSTR.CmCanr != string.Empty)
                    {
                        cOVMSTR.CmCanr = "CANCELLED PER 4POINT";
                    }
                }

                cOVMSTR.CmData = DateTime.Now;
                cOVMSTR.CMUsrA = UserId;

                // Life Effective Date / Term and Expiration Date
                cOVMSTR.CmEfft = !susMaster.SmEffL.DateNotNull() ? susMaster.SmEfft : cOVMSTR.CmEfft;
                cOVMSTR.CmTerm = susMaster.SmTrmL == 0 ? susMaster.SmTerm : cOVMSTR.CmTerm;

                if (!susMaster.SmExpL.DateNotNull())
                {
                    DateTime LmFPayDate = lONMSTP.LmFPay.AddMonths(cOVMSTR.CmTerm);
                    cOVMSTR.CmExpr = LmFPayDate;
                }
                else
                {
                    cOVMSTR.CmExpr = susMaster.SmExpL;
                }

                RateTable();

                if (lONMSTP.LmCalc == "DA")
                {
                    CovMst_Amnt();
                }
                else
                {
                    cOVMSTR.CmAmnt = susMaster.SmLAmt;
                }

                //CovMstR.Insert();
            }
        }
        private void CovMst_Dis()
        {
            if (susMaster.SmDis > 0)
            {
                cOVMSTR.CmAgnt = susMaster.SmAgnt;
                cOVMSTR.CmCert = susMaster.SmCert;
                cOVMSTR.CmIDN1 = susMaster.SmIdn1;
                cOVMSTR.CmIDN2 = susMaster.SmIdn2;
                cOVMSTR.CmFPrm = susMaster.SmFPrm;
                cOVMSTR.CmTerm = susMaster.SmTrmD;
                cOVMSTR.CmDays = susMaster.SmDays;
                cOVMSTR.CmStat = string.Empty;
                cOVMSTR.CmCovc = susMaster.SmDis;
                cOVMSTR.CmTble = string.Empty;
                cOVMSTR.CmLapD = 0;
                cOVMSTR.CmLapR = string.Empty;
                cOVMSTR.CmCand = 0;
                cOVMSTR.CmCanr = string.Empty;
                cOVMSTR.CmEfft = susMaster.SmEfft;

                // Disability Benefit Amount from 4Point
                susMaster.SmDBen = (int)cOVMSTR.CmBAmt;

                // A&H Cancellation Date
                if (susMaster.SmCnl > 0 && susMaster.SmCnlD == 0)
                {
                    susMaster.SmCnlD = (int)susMaster.SmCnl;
                }
                if (susMaster.SmCnlD > 0)
                {
                    cOVMSTR.CmCand = susMaster.SmCnlD;
                    if (string.IsNullOrWhiteSpace(cOVMSTR.CmCanr))
                    {
                        cOVMSTR.CmCanr = "CANCELLED PER 4POINT";
                    }
                }

                cOVMSTR.CmData = DateTime.Now;
                cOVMSTR.CMUsrA = UserId;

                // Disability Effective Date / Term and Expiration Date
                cOVMSTR.CmEfft = !susMaster.SmEffD.DateNotNull() ? susMaster.SmEfft : cOVMSTR.CmEfft;
                cOVMSTR.CmTerm = susMaster.SmTrmD == 0 ? susMaster.SmTerm : cOVMSTR.CmTerm;
                if (!susMaster.SmExpD.DateNotNull())
                {
                    DateTime LmFPayDate = lONMSTP.LmFPay;
                    LmFPayDate = LmFPayDate.AddMonths(cOVMSTR.CmTerm);
                    cOVMSTR.CmExpr = LmFPayDate;
                }
                else
                {
                    cOVMSTR.CmExpr = susMaster.SmExpD;
                }

                RateTable();
                if (lONMSTP.LmCalc == "DA")
                {
                    CovMst_Amnt();
                }
                else
                {
                    cOVMSTR.CmAmnt = susMaster.SmDAmt;
                }

                //CovMstR.Write();
            }
        }

        void CovMst_DP()
        {
            if (susMaster.SmDebt > 0)
            {
                cOVMSTR.CmAgnt = susMaster.SmAgnt;
                cOVMSTR.CmCert = susMaster.SmCert;
                cOVMSTR.CmIDN1 = susMaster.SmIdn1;
                cOVMSTR.CmIDN2 = susMaster.SmIdn2;
                cOVMSTR.CmFPrm = susMaster.SmFPrm;
                cOVMSTR.CmTerm = susMaster.SmTrmP;
                cOVMSTR.CmDays = susMaster.SmDays;
                cOVMSTR.CmStat = "";
                cOVMSTR.CmCovc = susMaster.SmDebt;
                cOVMSTR.CmTble = "";
                cOVMSTR.CmLapD = 0;
                cOVMSTR.CmLapR = "";
                cOVMSTR.CmCand = 0;
                cOVMSTR.CmCanr = "";
                cOVMSTR.CmEfft = susMaster.SmEfft;
                cOVMSTR.CmBAmt = 0;

                if (susMaster.SmCnl > 0)
                {
                    cOVMSTR.CmCand = (int)susMaster.SmCnl;
                    if (cOVMSTR.CmCanr == "")
                    {
                        cOVMSTR.CmCanr = "Cancelled Per 4 Point";
                    }
                }

                DateTime now = DateTime.Now;
                cOVMSTR.CmData = now;
                cOVMSTR.CMUsrA = UserId;

                // Disability Effective Date / Term and Expiration Date
                cOVMSTR.CmEfft = susMaster.SmEffP;

                if (!susMaster.SmEffP.DateNotNull())
                {
                    cOVMSTR.CmEfft = susMaster.SmEfft;
                }

                if (susMaster.SmTrmP == 0)
                {
                    cOVMSTR.CmTerm = susMaster.SmTerm;
                }

                if (!susMaster.SmExpP.DateNotNull())
                {
                    DateTime LmFPayDate = lONMSTP.LmFPay;
                    DateTime CmExprDate = LmFPayDate.AddMonths(cOVMSTR.CmTerm);
                    cOVMSTR.CmExpr = CmExprDate;

                }
                else
                {
                    cOVMSTR.CmExpr = susMaster.SmExpP;
                }

                RateTable();
                if (lONMSTP.LmCalc == "DA")
                {
                    CovMst_Amnt();
                }
                else
                {
                    cOVMSTR.CmAmnt = susMaster.SmDAmt;
                }

                //ExprDate();
                // CovMstR.Write();
            }

            // Break / 5
            // Break /= 5;
        }

        public void Delete_Sus()
        {
            //SusMstR                                                                      
        }
        public void RateTable()
        {
            var key03 = "key03"; // initialize key03

            // set the file pointer to the first record with a matching key
            var agtDtll1 = aGTDTLL.FindAll(x => x.ADAGNT == key03);

            if (agtDtll1.Count > 0)
            {
                foreach (var item in agtDtll1)

                    if (susMaster.SmEfft >= item.AdEfft && susMaster.SmEfft <= item.AdExpr)
                    {
                        cOVMSTR.CmTble = item.AdTble;
                        break;
                    }
            }
        }
        void Health01()
        {
            qstNsp.QaAgnt = susMaster.SmAgnt;
            qstNsp.QaCert = susMaster.SmCert;
            qstNsp.QaIDN = susMaster.SmIdn1;

            if (susMaster.SmHQ01A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMaster.SmHQ01A;
                qstNsp.QaSeq = 1;
            }

            if (susMaster.SmHQ02A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMaster.SmHQ02A;
                qstNsp.QaSeq = 2;
            }

            if (susMaster.SmHQ03A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMaster.SmHQ03A;
                qstNsp.QaSeq = 3;
            }

            if (susMaster.SmHQ04A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMaster.SmHQ04A;
                qstNsp.QaSeq = 4;
            }

            if (susMaster.SmHQ05A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMaster.SmHQ05A;
                qstNsp.QaSeq = 5;
            }

            if (susMaster.SmHQ06A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMaster.SmHQ06A;
                qstNsp.QaSeq = 6;
            }

            if (susMaster.SmHQ07A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMaster.SmHQ07A;
                qstNsp.QaSeq = 7;
            }

            if (susMaster.SmHQ08A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMaster.SmHQ08A;
                qstNsp.QaSeq = 8;
            }

            if (susMaster.SmHQ09A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMaster.SmHQ09A;
                qstNsp.QaSeq = 9;
            }

            if (susMaster.SmHQ10A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMaster.SmHQ10A;
                qstNsp.QaSeq = 10;
            }

            if (susMaster.SmHQ11A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMaster.SmHQ11A;
                qstNsp.QaSeq = 11;
            }

            if (susMaster.SmHQ12A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMaster.SmHQ12A;
                qstNsp.QaSeq = 12;
            }

            if (susMaster.SmHQ13A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMaster.SmHQ13A;
                qstNsp.QaSeq = 13;
            }

            if (susMaster.SmHQ14A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMaster.SmHQ14A;
                qstNsp.QaSeq = 14;
            }

            if (susMaster.SmHQ15A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMaster.SmHQ15A;
                qstNsp.QaSeq = 15;
            }

            if (susMaster.SmHQ16A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMaster.SmHQ16A;
                qstNsp.QaSeq = 16;
            }

            if (susMaster.SmHQ17A != " ")
            {
                qstNsp.QaQstn = susMaster.SmHQ17A;
                qstNsp.QaSeq = 17;
            }


            if (susMaster.SmHQ18A != " ")
            {
                qstNsp.QaQstn = susMaster.SmHQ18A;
                qstNsp.QaSeq = 18;
            }

            if (susMaster.SmHQ19A != " ")
            {
                qstNsp.QaQstn = susMaster.SmHQ19A;
                qstNsp.QaSeq = 19;
            }


            if (susMaster.SmHQ20A != " ")
            {
                qstNsp.QaQstn = susMaster.SmHQ20A;
                qstNsp.QaSeq = 20;
            }
        }
        void Health02()
        {
            qstNsp.QaAgnt = susMaster.SmAgnt;
            qstNsp.QaCert = susMaster.SmCert;
            qstNsp.QaIDN = susMaster.SmIdn2;

            if (susMaster.SmHQ01B.Trim() != "")
            {
                qstNsp.QaQstn = susMaster.SmHQ01B;
                qstNsp.QaSeq = 1;
            }

            if (susMaster.SmHQ02B.Trim() != "")
            {
                qstNsp.QaQstn = susMaster.SmHQ02B;
                qstNsp.QaSeq = 2;
            }

            if (susMaster.SmHQ03B.Trim() != "")
            {
                qstNsp.QaQstn = susMaster.SmHQ03B;
                qstNsp.QaSeq = 3;
            }

            if (susMaster.SmHQ04B.Trim() != "")
            {
                qstNsp.QaQstn = susMaster.SmHQ04B;
                qstNsp.QaSeq = 4;
            }

            if (susMaster.SmHQ05B.Trim() != "")
            {
                qstNsp.QaQstn = susMaster.SmHQ05B;
                qstNsp.QaSeq = 5;
            }

            if (susMaster.SmHQ06B.Trim() != "")
            {
                qstNsp.QaQstn = susMaster.SmHQ06B;
                qstNsp.QaSeq = 6;
            }

            if (susMaster.SmHQ07B.Trim() != "")
            {
                qstNsp.QaQstn = susMaster.SmHQ07B;
                qstNsp.QaSeq = 7;
            }

            if (susMaster.SmHQ08B.Trim() != "")
            {
                qstNsp.QaQstn = susMaster.SmHQ08B;
                qstNsp.QaSeq = 8;
            }

            if (susMaster.SmHQ09B.Trim() != "")
            {
                qstNsp.QaQstn = susMaster.SmHQ09B;
                qstNsp.QaSeq = 9;
            }

            if (susMaster.SmHQ10B.Trim() != "")
            {
                qstNsp.QaQstn = susMaster.SmHQ10B;
                qstNsp.QaSeq = 10;
            }

            if (susMaster.SmHQ11B.Trim() != "")
            {
                qstNsp.QaQstn = susMaster.SmHQ11B;
                qstNsp.QaSeq = 11;
            }

            if (susMaster.SmHQ12B.Trim() != "")
            {
                qstNsp.QaQstn = susMaster.SmHQ12B;
                qstNsp.QaSeq = 12;
            }

            if (susMaster.SmHQ13B.Trim() != "")
            {
                qstNsp.QaQstn = susMaster.SmHQ13B;
                qstNsp.QaSeq = 13;
            }

            if (susMaster.SmHQ14B.Trim() != "")
            {
                qstNsp.QaQstn = susMaster.SmHQ14B;
                qstNsp.QaSeq = 14;
            }

            if (susMaster.SmHQ15B.Trim() != "")
            {
                qstNsp.QaQstn = susMaster.SmHQ15B;
                qstNsp.QaSeq = 15;
            }

            if (susMaster.SmHQ16B.Trim() != "")
            {
                qstNsp.QaQstn = susMaster.SmHQ16B;
                qstNsp.QaSeq = 16;
            }

            if (susMaster.SmHQ17B.Trim() != "")
            {
                qstNsp.QaQstn = susMaster.SmHQ17B;
                qstNsp.QaSeq = 17;
            }

            if (susMaster.SmHQ18B.Trim() != "")
            {
                qstNsp.QaQstn = susMaster.SmHQ18B;
                qstNsp.QaSeq = 18;
            }

            if (susMaster.SmHQ19B.Trim() != "")
            {
                qstNsp.QaQstn = susMaster.SmHQ19B;
                qstNsp.QaSeq = 19;
            }

            if (susMaster.SmHQ20B.Trim() != "")
            {
                qstNsp.QaQstn = susMaster.SmHQ20B;
                qstNsp.QaSeq = 20;
            }
        }

    }
}

