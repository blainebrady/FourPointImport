using FourPointImport.Data;
using FourPointImport.Services;

namespace FourPointImport.Web.Functions
{
    public class MOB208
    {
        public LoanApplicationMaster patronCustomer1 { get; set; }
        public readonly LoanApplicationService lmService;
        public readonly PatronCustomerService patCustService;
        public CoverageInsuranceMaster covMstr { get; set; }
       public List<LoanApplicationMaster> lonMstL1 { get; set; }
        public List<PatronCustomer> patronCustomer { get; set; }
        private PatronCustomer _paCustomer { get; set; }
        public MOB208(string pragnt, string prcert, SuspenseMaster susMst, CoverageInsuranceMaster CovMstr, LoanApplicationService _lmService,
            PatronCustomerService _patCustService )
        {
            covMstr = CovMstr;
            lmService = _lmService;
            patCustService = _patCustService;
            SetService();

            if (lonMstL1 != null)
            {
                foreach (var item in lonMstL1)
                {
                    // Copy all Insured Master Records to History (DO NOT Delete Production records)
                    var loanApp = lonMstL1.Where(x => x.LmAgnt == pragnt && x.LmCert == prcert);
                    foreach (var item2 in loanApp)
                    {
                        patronCustomer1A(item2);
                        patronCustomer1B(item2);
                    }
                    

                    // Copy all Loan Master Records to History (Then Delete Production Records)
                    LoanApplicationHistory lonHstR = LoanApplicationHistory.ImportClass(item);
                    //lonHstR.Write();

                }

                CovMstL1();
            }
        }
        private async void SetService()
        {
            lonMstL1 = await lmService.ReadAllAsync();
            patronCustomer = await patCustService.ReadAllAsync();
        }
        private void patronCustomer1A(LoanApplicationMaster laMaster)
        {
            if (laMaster.LmIdn1 != 0)
            {
                var paCustomer = patronCustomer.Find(x => x.ImIDN == patronCustomer1.LmIdn1);
                if (paCustomer != null)
                {
                    PatronCustHist insHstR = PatronCustHist.ImportClass(paCustomer);
                    _paCustomer = paCustomer;
                }
            }
        }

        void patronCustomer1B(LoanApplicationMaster laMaster)
        {
            if (laMaster.LmIdn2 != 0)
            { 
                if (patronCustomer != null)
                {
                    PatronCustHist insHstR = PatronCustHist.ImportClass(_paCustomer);
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
