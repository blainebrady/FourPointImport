using FourPointImport.Data;

namespace FourPointImport.Web.Functions
{
    public class MOB208
    {
        public LoanApplicationMaster InsMstL1 { get; set; }
        public CoverageInsuranceMaster covMstr { get; set; }
        public MOB208(string pragnt, string prcert, SuspenseMaster susMst, CoverageInsuranceMaster CovMstr)
        {
            List<LoanApplicationMaster> lonMstL1 = new List<LoanApplicationMaster>();
            covMstr = CovMstr;


            if (lonMstL1 != null)
            {
                foreach (var item in lonMstL1)
                {
                    // Copy all Insured Master Records to History (DO NOT Delete Production records)
                    InsMstL1A();
                    InsMstL1B();

                    // Copy all Loan Master Records to History (Then Delete Production Records)
                    LoanApplicationHistory lonHstR = LoanApplicationHistory.ImportClass(item);
                    //lonHstR.Write();

                }

                CovMstL1();
            }
        }
        void InsMstL1A()
        {
            if (InsMstL1.LmIdn1 != 0)
            {
                List<PatronCustomer> InsMstL = new List<PatronCustomer>();
                var insMstL = InsMstL.Find(x => x.ImIDN == InsMstL1.LmIdn1);
                if (insMstL != null)
                {
                    PatronCustHist insHstR = PatronCustHist.ImportClass(insMstL);
                }
            }
        }

        void InsMstL1B()
        {
            if (InsMstL1.LmIdn2 != 0)
            {
                List<PatronCustomer> InsMstL = new List<PatronCustomer>();
                var insMstL = InsMstL.Find(x => x.ImIDN == InsMstL1.LmIdn1);
                if (insMstL != null)
                {
                    PatronCustHist insHstR = PatronCustHist.ImportClass(insMstL);
                    //insHstR.Write();

                }
            }
        }
        void CovMstL1()
        {
            if (covMstr != null)
            {
                // Write to history
                var covHstR = CoverageInsHist.ImportClass(covMstr);

            }
        }

    }
}
