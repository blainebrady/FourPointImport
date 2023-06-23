using Utilities;
using FourPointImport.Data;

namespace FourPointImport.Web.Functions
{
    public class MOB208DCC
    {
        public CoverageInsuranceMaster CovMstl1 { get; set; }
        public PatronCustHist patronCustHist { get; set; }
        public List<PatronCustomer> patronCustomer { get; set; }
        public LoanApplicationHistory loanApplicationHistory { get; set; }
        public SuspenseMaster susMstL3 { get; set; }
        public List<LoanApplicationMaster> LonMst { get; set; }
        public LoanApplicationMaster lonMst { get; set; }
        public bool Duplicate { get; set; }
        public int Key04 { get; set; }

        private decimal Key03;
        public MOB208DCC(string pragnt, string prcert, decimal prdebt, SuspenseMaster susMstL, CoverageInsuranceMaster covMstL1)
        {
            susMstL3 = susMstL;
            CovMstl1 = covMstL1;
            Key03 = prdebt;
            //Only process Debt Protection Records
            if (susMstL3.SmDebt > 0)
            {
                //Is this a true duplicate record? or an add-on monthly benefit? (Check Package code level)
                Duplicate = false;
                CovMstL1();
                //If Duplicate then Replace the Loan Master Record
                if (Duplicate == true)
                {
                    LonMstL1();
                }
                //If Duplicate then Replace the Write the Primary Insured Name to history
                if (Duplicate == true)
                {
                    InsMstL1A();
                }
                //If Duplicate then Replace the Write the Secondary Insured Name to history
                if (Duplicate == true)
                {
                    InsMstL1B();
                }

            }
        }
        public void CovMstL1()
        {
            Duplicate = false;
            // Set lower limit for search
            Key04 = 0;
            bool isRead = true;
            while (isRead)
            {
                // Read next record in sequence
                CoverageInsHist covHstp = CoverageInsHist.ImportClass(CovMstl1);
                if (covHstp != null)
                {

                    // CovHstR.Write();
                    // CovMstR.Delete();
                }
            }
        }

        private void InsMstL1A()
        {
            if (lonMst.LmIdn1 != 0)
            {
                var keyData = patronCustomer.Find(x => x.ImIDN == Key03);
                if (keyData != null)
                {
                    var inHstP = PatronCustHist.ImportClass(keyData);
                }

                //write to data
            }
        }

        public void InsMstL1B()
        {
            if (lonMst.LmIdn2 != 0)
            {
                var inHstP = LoanApplicationHistory.ImportClass(lonMst);


                if (inHstP != null)
                {
                    //InsHstRec2.Write();
                }
            }
        }
        private void LonMstL1()
        {
            // Key01 Set Lower Limit
            var key01 = "VALUE"; // replace VALUE with actual value
            lonMst = LonMst.Find(x => x.LmCert == key01);

            if (lonMst != null)
            {

                // Write record to LonHstR file
                //LonHstR.Write();

            }
        }
    }
}
