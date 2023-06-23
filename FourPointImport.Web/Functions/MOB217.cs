using FourPointImport.Data;

namespace FourPointImport.Web.Functions
{
    public class MOB217
    {
        public CoverageInsuranceMaster covMSTR { get; set; }
        public MOB217(string agent, string cert, CoverageInsuranceMaster cOVMSTR)
        {
            decimal candat = 0;
            //Find the last bill date for agent and certifcate and use as the
            //cancellation date for the old coverage.
            if (cOVMSTR != null && cOVMSTR.CmCand == 0)
            {
                List<BillingDetail> bildtll = new List<BillingDetail>();

                // Set the KeyBil and read the record.  Guessing that it's CmBat
                decimal KeyBil = cOVMSTR.CmBAmt;
                var bildtll2 = bildtll.Find(x => x.BdBill == KeyBil);
                if (bildtll2 != null)
                {

                    candat = bildtll2.BdBill;

                }

                // If there is no billing found need to get rid of the record.
                if (candat != 0)
                {

                    // Cancel the old coverage.
                    cOVMSTR.CmCand = (int)candat;
                    string canrsn = "Coverage change";
                    cOVMSTR.CmCanr = canrsn.PadRight(10);
                    //covmstr.Update();
                }

            }
            covMSTR = cOVMSTR;
        }
    }
}
