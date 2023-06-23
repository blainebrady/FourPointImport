using FourPointImport.Data;
using Utilities;

namespace FourPointImport.Web.Functions
{
    public class MOB210
    {
        public SuspenseMaster susMstl { get; set; }
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
        public MOB210(string SmAgnt, string SmCert, SuspenseMaster SusMstl3)
        {
            Key02A = SmAgnt;
            Key02B = SmCert;
            UserId = SmAgnt;
            cOVMSTR = new CoverageInsuranceMaster();
            susMstl = SusMstl3;//.Chain("01", "03/09/04");
            if (susMstl != null)
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
        }
        public void CertChg()
        {
            string CertHold = string.Empty; //assuming CertHold is a string variable
            if (susMstl.SmFlag == "U")
            {
                if (susMstl.SmCert2.Trim() != string.Empty)
                {
                    CertHold = susMstl.SmCert2.Trim();
                    susMstl.SmCert2 = susMstl.SmCert.Trim();
                    susMstl.SmCert = CertHold;
                }
            }
        }
        public void Upper()
        {
            susMstl.SmRegn = susMstl.SmRegn.ToUpper();
            susMstl.SmTerr = susMstl.SmTerr.ToUpper();
            susMstl.SmBrch = susMstl.SmBrch.ToUpper();
            susMstl.SmOffc = susMstl.SmOffc.ToUpper();
            susMstl.SmBen1 = susMstl.SmBen1.ToUpper();
            susMstl.SmBen2 = susMstl.SmBen2.ToUpper();
            susMstl.SmType = susMstl.SmType.ToUpper();
            susMstl.SmCalc = susMstl.SmCalc.ToUpper();
            susMstl.SmLend = susMstl.SmLend.ToUpper();
            susMstl.SmLNam1 = susMstl.SmLNam1.ToUpper();
            susMstl.SmFNam1 = susMstl.SmFNam1.ToUpper();
            susMstl.SmMNam1 = susMstl.SmMNam1.ToUpper();
            susMstl.SmSufx1 = susMstl.SmSufx1.ToUpper();
            susMstl.SmAdd11 = susMstl.SmAdd11.ToUpper();
            susMstl.SmAdd21 = susMstl.SmAdd21.ToUpper();
            susMstl.SmCity1 = susMstl.SmCity1.ToUpper();
            susMstl.SmSte1 = susMstl.SmSte1.ToUpper();
            susMstl.SmLNam2 = susMstl.SmLNam2.ToUpper();
            susMstl.SmFNam2 = susMstl.SmFNam2.ToUpper();
            susMstl.SmMNam2 = susMstl.SmMNam2.ToUpper();
            susMstl.SmSufx2 = susMstl.SmSufx2.ToUpper();
            susMstl.SmAdd12 = susMstl.SmAdd12.ToUpper();
            susMstl.SmAdd22 = susMstl.SmAdd22.ToUpper();
            susMstl.SmCity2 = susMstl.SmCity2.ToUpper();
            susMstl.SmSte2 = susMstl.SmSte2.ToUpper();
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

            if (susMstl.SmIdn1 == 0)
            {
                if (susMstl.SmIdn1 < 2)
                {
                    susMstl.SmIdn1 = 1;
                }
            }

            if (!string.IsNullOrEmpty(susMstl.SmLNam2))
            {
                if (susMstl.SmIdn2 == 0)
                {
                    if (susMstl.SmIdn2 < 2)
                    {
                        susMstl.SmIdn2 = 1;
                    }
                }
            }
        }


        public void BrcMstL2()
        {
            if (susMstl.SmRegn.StringSafe().Length > 0 || susMstl.SmTerr.StringSafe().Length > 0 || susMstl.SmBrch.StringSafe().Length > 0 || susMstl.SmOffc.StringSafe().Length > 0)
            {
                List<BranchOffice> brcMstp = new List<BranchOffice>();
                var record = brcMstp.Find(x => x.BmAgnt == Key07);

                if (record == null)
                {
                    return;
                }

                susMstl.SmAgnt = record.BmAgnt;
                susMstl.SmRegn = record.BmRegn;
                susMstl.SmTerr = record.BmTerr;
                susMstl.SmBrch = record.BmBrch;
                susMstl.SmOffc = record.BmOffc;
                record.BmDatA = DateTime.Now;
                record.BmUsrA = PgmNam;
                //brcMstp.Write(record);
            }
        }

        void LonMst()
        {
            lONMSTP.LmAgnt = susMstl.SmAgnt;
            lONMSTP.LmRegn = susMstl.SmRegn;
            lONMSTP.LmTerr = susMstl.SmTerr;
            lONMSTP.LmBrch = susMstl.SmBrch;
            lONMSTP.LmOffc = susMstl.SmOffc;
            lONMSTP.LmCert = susMstl.SmCert;
            lONMSTP.LmIdn1 = susMstl.SmIdn1;
            lONMSTP.LmIdn2 = susMstl.SmIdn2;
            lONMSTP.LmBen1 = susMstl.SmBen1;
            lONMSTP.LmBen2 = susMstl.SmBen2;
            lONMSTP.LmFPay = susMstl.SmFPay;
            lONMSTP.LmEfft = susMstl.SmEfft;
            lONMSTP.LmExpr = susMstl.SmExpr;
            lONMSTP.LmTerm = susMstl.SmTerm;
            lONMSTP.LmFreq = susMstl.SmFreq;
            lONMSTP.LmAmnt = susMstl.SmAmnt;
            lONMSTP.LmSchd = susMstl.SmSchd;
            lONMSTP.LmIntr = susMstl.SmIntr;
            lONMSTP.LmForm = susMstl.SmForm;
            lONMSTP.LmStat = "";
            lONMSTP.LmSig1 = susMstl.SmSig1;
            lONMSTP.LmSig2 = susMstl.SmSig2;
            lONMSTP.LmCnlD = susMstl.SmCnlD;
            lONMSTP.LmDatA = DateTime.Now;
            lONMSTP.LmUsrA = UserId;
            lONMSTP.LmPani = susMstl.SmPanI;
            lONMSTP.LmLine = susMstl.SmLine;
            lONMSTP.LmPrev = susMstl.SmCert2;
            lONMSTP.LmMntf = susMstl.Smmntf;

            //LonMstR.Write();
        }
        void InsMst_01()
        {
            var recFound = Insmstl1.Find(x => x.ImStat == Key02A);

            recFound.ImIDN = susMstl.SmIdn1;
            recFound.ImLNam = susMstl.SmLNam1;
            recFound.ImFNam = susMstl.SmFNam1;
            recFound.ImMNam = susMstl.SmMNam1;
            recFound.ImSufx = susMstl.SmSufx1;
            recFound.ImAdd1 = susMstl.SmAdd11;
            recFound.ImAdd2 = susMstl.SmAdd21;
            recFound.ImCity = susMstl.SmCity1;
            recFound.ImSte = susMstl.SmSte1;
            recFound.ImZip = susMstl.SmZip1;
            recFound.ImPhne = susMstl.SmPhne1;
            recFound.ImDob = susMstl.SmDob1;
            recFound.ImSex = susMstl.SmSex1;
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
            if (susMstl.SmIdn2 > 0)
            {
                var recFound = Insmstl1.Find(x => x.ImUsrA == Key02B);

                recFound.ImIDN = susMstl.SmIdn2;
                recFound.ImLNam = susMstl.SmLNam2;
                recFound.ImFNam = susMstl.SmFNam2;
                recFound.ImMNam = susMstl.SmMNam2;
                recFound.ImSufx = susMstl.SmSufx2;
                recFound.ImAdd1 = susMstl.SmAdd12;
                recFound.ImAdd2 = susMstl.SmAdd22;
                recFound.ImCity = susMstl.SmCity2;
                recFound.ImSte = susMstl.SmSte2;
                recFound.ImZip = susMstl.SmZip2;
                recFound.ImPhne = susMstl.SmPhne2;
                recFound.ImDob = susMstl.SmDob2;
                recFound.ImSex = susMstl.SmSex2;
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
            if (susMstl.SmVIN.Trim() != "" || susMstl.SmMake.Trim() != "" || susMstl.SmModel.Trim() != "")
            {
                // Move a Copy of the current record to History File
                List<GAPInsurance> GapMstL1 = new List<GAPInsurance>();
                var record = GapMstL1.Find(x => x.GmVIN == susMstl.SmVIN);
                if (record != null)
                {
                    record.GmHstD = DateTime.Now;
                    record.GmHstU = UserId;
                    //GapHstR.Write();

                    // Update Existing Record with new information
                    record.GmAgnt = susMstl.SmAgnt;
                    record.GmCert = susMstl.SmCert;
                    record.GmVIN = susMstl.SmVIN;
                    record.GmYear = susMstl.SmYear;
                    record.GmMake = susMstl.SmMake;
                    record.GmModel = susMstl.SmModel;
                    record.GmFee = susMstl.SmFee;
                    record.GmComR = susMstl.SmComR;
                    record.GmEfft = Utils.DecimalToDate(susMstl.SmGEfft);
                    record.GmExpr = Utils.DecimalToDate(susMstl.SmGExpr);
                    record.GmStat = susMstl.SmGStat;
                    record.GmSDte = susMstl.SmGDate;
                    record.GmDatU = DateTime.Now;
                    record.GmUsrU = UserId;
                    record.GmHstU = "";
                    //GapMstR.Update();
                }
                else
                {
                    // Create new Record
                    record.GmAgnt = susMstl.SmAgnt;
                    record.GmCert = susMstl.SmCert;
                    record.GmVIN = susMstl.SmVIN;
                    record.GmYear = susMstl.SmYear;
                    record.GmMake = susMstl.SmMake;
                    record.GmModel = susMstl.SmModel;
                    record.GmFee = susMstl.SmFee;
                    record.GmComR = susMstl.SmComR;
                    record.GmEfft = Utils.DecimalToDate(susMstl.SmGEfft);
                    record.GmExpr = Utils.DecimalToDate(susMstl.SmGExpr);
                    record.GmStat = susMstl.SmGStat;
                    record.GmSDte = susMstl.SmGDate;
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
            if (susMstl.SmLif > 0)
            {
                cOVMSTR.CmAgnt = susMstl.SmAgnt;
                cOVMSTR.CmCert = susMstl.SmCert;
                cOVMSTR.CmIDN1 = susMstl.SmIdn1;
                cOVMSTR.CmIDN2 = susMstl.SmIdn2;
                cOVMSTR.CmFPrm = susMstl.SmFPrm;
                cOVMSTR.CmTerm = susMstl.SmTrmL;
                cOVMSTR.CmDays = susMstl.SmDays;
                cOVMSTR.CmStat = string.Empty;
                cOVMSTR.CmCovc = susMstl.SmLif;
                cOVMSTR.CmTble = string.Empty;
                cOVMSTR.CmLapD = 0;
                cOVMSTR.CmLapR = string.Empty;
                cOVMSTR.CmCand = 0;
                cOVMSTR.CmCanr = string.Empty;
                cOVMSTR.CmEfft = susMstl.SmEfft;

                // Life Benefit Amount from 4Point - Added per Diana Santellan (March 6th 2008)
                cOVMSTR.CmBAmt = susMstl.SmLBen;

                // Life Cancellation Date
                if (susMstl.SmCnl > 0 && susMstl.SmCnlL == 0)
                {
                    susMstl.SmCnlL = (int)susMstl.SmCnl;
                }

                if (susMstl.SmCnlL > 0)
                {
                    cOVMSTR.CmCand = susMstl.SmCnlL;
                    if (cOVMSTR.CmCanr != string.Empty)
                    {
                        cOVMSTR.CmCanr = "CANCELLED PER 4POINT";
                    }
                }

                cOVMSTR.CmData = DateTime.Now;
                cOVMSTR.CMUsrA = UserId;

                // Life Effective Date / Term and Expiration Date
                cOVMSTR.CmEfft = !susMstl.SmEffL.DateNotNull() ? susMstl.SmEfft : cOVMSTR.CmEfft;
                cOVMSTR.CmTerm = susMstl.SmTrmL == 0 ? susMstl.SmTerm : cOVMSTR.CmTerm;

                if (!susMstl.SmExpL.DateNotNull())
                {
                    DateTime LmFPayDate = lONMSTP.LmFPay.AddMonths(cOVMSTR.CmTerm);
                    cOVMSTR.CmExpr = LmFPayDate;
                }
                else
                {
                    cOVMSTR.CmExpr = susMstl.SmExpL;
                }

                RateTable();

                if (lONMSTP.LmCalc == "DA")
                {
                    CovMst_Amnt();
                }
                else
                {
                    cOVMSTR.CmAmnt = susMstl.SmLAmt;
                }

                //CovMstR.Insert();
            }
        }
        private void CovMst_Dis()
        {
            if (susMstl.SmDis > 0)
            {
                cOVMSTR.CmAgnt = susMstl.SmAgnt;
                cOVMSTR.CmCert = susMstl.SmCert;
                cOVMSTR.CmIDN1 = susMstl.SmIdn1;
                cOVMSTR.CmIDN2 = susMstl.SmIdn2;
                cOVMSTR.CmFPrm = susMstl.SmFPrm;
                cOVMSTR.CmTerm = susMstl.SmTrmD;
                cOVMSTR.CmDays = susMstl.SmDays;
                cOVMSTR.CmStat = string.Empty;
                cOVMSTR.CmCovc = susMstl.SmDis;
                cOVMSTR.CmTble = string.Empty;
                cOVMSTR.CmLapD = 0;
                cOVMSTR.CmLapR = string.Empty;
                cOVMSTR.CmCand = 0;
                cOVMSTR.CmCanr = string.Empty;
                cOVMSTR.CmEfft = susMstl.SmEfft;

                // Disability Benefit Amount from 4Point
                susMstl.SmDBen = (int)cOVMSTR.CmBAmt;

                // A&H Cancellation Date
                if (susMstl.SmCnl > 0 && susMstl.SmCnlD == 0)
                {
                    susMstl.SmCnlD = (int)susMstl.SmCnl;
                }
                if (susMstl.SmCnlD > 0)
                {
                    cOVMSTR.CmCand = susMstl.SmCnlD;
                    if (string.IsNullOrWhiteSpace(cOVMSTR.CmCanr))
                    {
                        cOVMSTR.CmCanr = "CANCELLED PER 4POINT";
                    }
                }

                cOVMSTR.CmData = DateTime.Now;
                cOVMSTR.CMUsrA = UserId;

                // Disability Effective Date / Term and Expiration Date
                cOVMSTR.CmEfft = !susMstl.SmEffD.DateNotNull() ? susMstl.SmEfft : cOVMSTR.CmEfft;
                cOVMSTR.CmTerm = susMstl.SmTrmD == 0 ? susMstl.SmTerm : cOVMSTR.CmTerm;
                if (!susMstl.SmExpD.DateNotNull())
                {
                    DateTime LmFPayDate = lONMSTP.LmFPay;
                    LmFPayDate = LmFPayDate.AddMonths(cOVMSTR.CmTerm);
                    cOVMSTR.CmExpr = LmFPayDate;
                }
                else
                {
                    cOVMSTR.CmExpr = susMstl.SmExpD;
                }

                RateTable();
                if (lONMSTP.LmCalc == "DA")
                {
                    CovMst_Amnt();
                }
                else
                {
                    cOVMSTR.CmAmnt = susMstl.SmDAmt;
                }

                //CovMstR.Write();
            }
        }

        void CovMst_DP()
        {
            if (susMstl.SmDebt > 0)
            {
                cOVMSTR.CmAgnt = susMstl.SmAgnt;
                cOVMSTR.CmCert = susMstl.SmCert;
                cOVMSTR.CmIDN1 = susMstl.SmIdn1;
                cOVMSTR.CmIDN2 = susMstl.SmIdn2;
                cOVMSTR.CmFPrm = susMstl.SmFPrm;
                cOVMSTR.CmTerm = susMstl.SmTrmP;
                cOVMSTR.CmDays = susMstl.SmDays;
                cOVMSTR.CmStat = "";
                cOVMSTR.CmCovc = susMstl.SmDebt;
                cOVMSTR.CmTble = "";
                cOVMSTR.CmLapD = 0;
                cOVMSTR.CmLapR = "";
                cOVMSTR.CmCand = 0;
                cOVMSTR.CmCanr = "";
                cOVMSTR.CmEfft = susMstl.SmEfft;
                cOVMSTR.CmBAmt = 0;

                if (susMstl.SmCnl > 0)
                {
                    cOVMSTR.CmCand = (int)susMstl.SmCnl;
                    if (cOVMSTR.CmCanr == "")
                    {
                        cOVMSTR.CmCanr = "Cancelled Per 4 Point";
                    }
                }

                DateTime now = DateTime.Now;
                cOVMSTR.CmData = now;
                cOVMSTR.CMUsrA = UserId;

                // Disability Effective Date / Term and Expiration Date
                cOVMSTR.CmEfft = susMstl.SmEffP;

                if (!susMstl.SmEffP.DateNotNull())
                {
                    cOVMSTR.CmEfft = susMstl.SmEfft;
                }

                if (susMstl.SmTrmP == 0)
                {
                    cOVMSTR.CmTerm = susMstl.SmTerm;
                }

                if (!susMstl.SmExpP.DateNotNull())
                {
                    DateTime LmFPayDate = lONMSTP.LmFPay;
                    DateTime CmExprDate = LmFPayDate.AddMonths(cOVMSTR.CmTerm);
                    cOVMSTR.CmExpr = CmExprDate;

                }
                else
                {
                    cOVMSTR.CmExpr = susMstl.SmExpP;
                }

                RateTable();
                if (lONMSTP.LmCalc == "DA")
                {
                    CovMst_Amnt();
                }
                else
                {
                    cOVMSTR.CmAmnt = susMstl.SmDAmt;
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

                    if (susMstl.SmEfft >= item.AdEfft && susMstl.SmEfft <= item.AdExpr)
                    {
                        cOVMSTR.CmTble = item.AdTble;
                        break;
                    }
            }
        }
        void Health01()
        {
            qstNsp.QaAgnt = susMstl.SmAgnt;
            qstNsp.QaCert = susMstl.SmCert;
            qstNsp.QaIDN = susMstl.SmIdn1;

            if (susMstl.SmHQ01A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMstl.SmHQ01A;
                qstNsp.QaSeq = 1;
            }

            if (susMstl.SmHQ02A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMstl.SmHQ02A;
                qstNsp.QaSeq = 2;
            }

            if (susMstl.SmHQ03A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMstl.SmHQ03A;
                qstNsp.QaSeq = 3;
            }

            if (susMstl.SmHQ04A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMstl.SmHQ04A;
                qstNsp.QaSeq = 4;
            }

            if (susMstl.SmHQ05A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMstl.SmHQ05A;
                qstNsp.QaSeq = 5;
            }

            if (susMstl.SmHQ06A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMstl.SmHQ06A;
                qstNsp.QaSeq = 6;
            }

            if (susMstl.SmHQ07A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMstl.SmHQ07A;
                qstNsp.QaSeq = 7;
            }

            if (susMstl.SmHQ08A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMstl.SmHQ08A;
                qstNsp.QaSeq = 8;
            }

            if (susMstl.SmHQ09A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMstl.SmHQ09A;
                qstNsp.QaSeq = 9;
            }

            if (susMstl.SmHQ10A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMstl.SmHQ10A;
                qstNsp.QaSeq = 10;
            }

            if (susMstl.SmHQ11A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMstl.SmHQ11A;
                qstNsp.QaSeq = 11;
            }

            if (susMstl.SmHQ12A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMstl.SmHQ12A;
                qstNsp.QaSeq = 12;
            }

            if (susMstl.SmHQ13A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMstl.SmHQ13A;
                qstNsp.QaSeq = 13;
            }

            if (susMstl.SmHQ14A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMstl.SmHQ14A;
                qstNsp.QaSeq = 14;
            }

            if (susMstl.SmHQ15A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMstl.SmHQ15A;
                qstNsp.QaSeq = 15;
            }

            if (susMstl.SmHQ16A.Trim() != string.Empty)
            {
                qstNsp.QaQstn = susMstl.SmHQ16A;
                qstNsp.QaSeq = 16;
            }

            if (susMstl.SmHQ17A != " ")
            {
                qstNsp.QaQstn = susMstl.SmHQ17A;
                qstNsp.QaSeq = 17;
            }


            if (susMstl.SmHQ18A != " ")
            {
                qstNsp.QaQstn = susMstl.SmHQ18A;
                qstNsp.QaSeq = 18;
            }

            if (susMstl.SmHQ19A != " ")
            {
                qstNsp.QaQstn = susMstl.SmHQ19A;
                qstNsp.QaSeq = 19;
            }


            if (susMstl.SmHQ20A != " ")
            {
                qstNsp.QaQstn = susMstl.SmHQ20A;
                qstNsp.QaSeq = 20;
            }
        }
        void Health02()
        {
            qstNsp.QaAgnt = susMstl.SmAgnt;
            qstNsp.QaCert = susMstl.SmCert;
            qstNsp.QaIDN = susMstl.SmIdn2;

            if (susMstl.SmHQ01B.Trim() != "")
            {
                qstNsp.QaQstn = susMstl.SmHQ01B;
                qstNsp.QaSeq = 1;
            }

            if (susMstl.SmHQ02B.Trim() != "")
            {
                qstNsp.QaQstn = susMstl.SmHQ02B;
                qstNsp.QaSeq = 2;
            }

            if (susMstl.SmHQ03B.Trim() != "")
            {
                qstNsp.QaQstn = susMstl.SmHQ03B;
                qstNsp.QaSeq = 3;
            }

            if (susMstl.SmHQ04B.Trim() != "")
            {
                qstNsp.QaQstn = susMstl.SmHQ04B;
                qstNsp.QaSeq = 4;
            }

            if (susMstl.SmHQ05B.Trim() != "")
            {
                qstNsp.QaQstn = susMstl.SmHQ05B;
                qstNsp.QaSeq = 5;
            }

            if (susMstl.SmHQ06B.Trim() != "")
            {
                qstNsp.QaQstn = susMstl.SmHQ06B;
                qstNsp.QaSeq = 6;
            }

            if (susMstl.SmHQ07B.Trim() != "")
            {
                qstNsp.QaQstn = susMstl.SmHQ07B;
                qstNsp.QaSeq = 7;
            }

            if (susMstl.SmHQ08B.Trim() != "")
            {
                qstNsp.QaQstn = susMstl.SmHQ08B;
                qstNsp.QaSeq = 8;
            }

            if (susMstl.SmHQ09B.Trim() != "")
            {
                qstNsp.QaQstn = susMstl.SmHQ09B;
                qstNsp.QaSeq = 9;
            }

            if (susMstl.SmHQ10B.Trim() != "")
            {
                qstNsp.QaQstn = susMstl.SmHQ10B;
                qstNsp.QaSeq = 10;
            }

            if (susMstl.SmHQ11B.Trim() != "")
            {
                qstNsp.QaQstn = susMstl.SmHQ11B;
                qstNsp.QaSeq = 11;
            }

            if (susMstl.SmHQ12B.Trim() != "")
            {
                qstNsp.QaQstn = susMstl.SmHQ12B;
                qstNsp.QaSeq = 12;
            }

            if (susMstl.SmHQ13B.Trim() != "")
            {
                qstNsp.QaQstn = susMstl.SmHQ13B;
                qstNsp.QaSeq = 13;
            }

            if (susMstl.SmHQ14B.Trim() != "")
            {
                qstNsp.QaQstn = susMstl.SmHQ14B;
                qstNsp.QaSeq = 14;
            }

            if (susMstl.SmHQ15B.Trim() != "")
            {
                qstNsp.QaQstn = susMstl.SmHQ15B;
                qstNsp.QaSeq = 15;
            }

            if (susMstl.SmHQ16B.Trim() != "")
            {
                qstNsp.QaQstn = susMstl.SmHQ16B;
                qstNsp.QaSeq = 16;
            }

            if (susMstl.SmHQ17B.Trim() != "")
            {
                qstNsp.QaQstn = susMstl.SmHQ17B;
                qstNsp.QaSeq = 17;
            }

            if (susMstl.SmHQ18B.Trim() != "")
            {
                qstNsp.QaQstn = susMstl.SmHQ18B;
                qstNsp.QaSeq = 18;
            }

            if (susMstl.SmHQ19B.Trim() != "")
            {
                qstNsp.QaQstn = susMstl.SmHQ19B;
                qstNsp.QaSeq = 19;
            }

            if (susMstl.SmHQ20B.Trim() != "")
            {
                qstNsp.QaQstn = susMstl.SmHQ20B;
                qstNsp.QaSeq = 20;
            }
        }

    }
}

