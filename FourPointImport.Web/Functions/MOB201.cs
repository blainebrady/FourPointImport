using FourPointImport.Data;
using FourPointImport.Services;
using Microsoft.AspNetCore.DataProtection;
using Utilities;

namespace FourPointImport.Web.Functions
{
    public class MOB201
    {
        //Called Program "MOB206" Parameter
        protected readonly SuspenseMasterService _smService;
        protected readonly CoverageMasterService _cmService;
        protected readonly ConfirmationService _confService;
        protected readonly AgentMasterService _amService;
        protected readonly CoverageInsuranceService _coverageInsuranceService;
        protected readonly RateMasterService _rmService;
        protected readonly RateDetailService _rdService;
        protected readonly FormMasterService _fmService;
        protected readonly AgentDetailService _adService;
        protected readonly LoanApplicationService _lmService;
        protected readonly PatronCustomerService _patCustService;
        protected readonly Confirmation _conf;
        public string Param1
        {
            get; set;
        }
        public string Param2
        {
            get; set;
        }
        public int Param3
        {
            get; set;
        }
        public string LastAgent { get; set; }
                                                       
        public MOB201(List<SuspenseMaster> suspenseMaster, SuspenseMasterService service, CoverageMasterService cmService, AgentMasterService amService,
            CoverageInsuranceService coverageInsuranceService, RateMasterService rmService, RateDetailService rdService, Confirmation conf, 
            FormMasterService fmService, AgentDetailService adService, LoanApplicationService lmService, PatronCustomerService patCustService, ConfirmationService confService)
        {
            _smService = service;
            _cmService = cmService;
            _confService = confService;
            _rmService = rmService;
            _rdService = rdService;
            _amService = amService;
            _patCustService = patCustService;
            _fmService = fmService;
            _adService = adService;
            _lmService = lmService;
            _coverageInsuranceService = coverageInsuranceService;
            _conf = conf;
            
            foreach (var item in suspenseMaster)
            {
                var suspenseMasterRes = item;
                Param1 = item.SmAgnt;
                Param2 = item.SmCert;
                Param3 = 0;
                LastAgent = item.SmAgnt;

                //Process the Debt Cancellation New Business Records from the Suspense File              
                if (!CompareAgentNumbers(item.SmAgnt, "D00000") && CompareAgentNumbers(item.SmAgnt, "D99999"))
                {
                    suspenseMasterRes.SmCert = "";
                    suspenseMasterRes.SmDebt = 20;
                    suspenseMasterRes = new MOB206(suspenseMasterRes, _cmService, _amService, _coverageInsuranceService,_rmService, _rdService,
                        _fmService, _adService, _lmService, _patCustService, _confService).Process();
                }
                if (!CompareAgentNumbers(item.SmAgnt, "DH00000") && CompareAgentNumbers(item.SmAgnt, "DH99999"))
                {
                    suspenseMasterRes = new MOB206(item, _cmService, _amService, _coverageInsuranceService,_rmService, _rdService,
                        _fmService, _adService, _lmService, _patCustService, _confService).Process();
                }
                //Process the CEMOB New Business Records from the Suspense File    
                if (item.SmAgnt.ToInt() >= 90000 && item.SmAgnt.ToInt() <= 99999)
                {
                    suspenseMasterRes = new MOB206(item, _cmService, _amService, _coverageInsuranceService, _rmService, _rdService,
                         _fmService, _adService, _lmService, _patCustService, _confService).Process();
                }
                // Process the OEMOB New Business Records from the Suspense File       
                if (item.SmAgnt.ToInt() >= 20000 && item.SmAgnt.ToInt() <= 29999)
                {
                    new MOB206OB(item, _conf);
                }
            }
        }
        public bool CompareAgentNumbers(string agentNumber1, string agentNumber2)               //true if agent 1< agent 2
        {
            if (agentNumber1.Length < 1 || agentNumber2.Length < 1)
            {
                // Agent numbers should be at least 1 character long (1 or 2 letter prefix)
                throw new ArgumentException("Invalid agent number format");
            }

            string prefix1 = agentNumber1.Substring(0, Math.Min(agentNumber1.Length, 2));
            string prefix2 = agentNumber2.Substring(0, Math.Min(agentNumber2.Length, 2));
            int number1, number2;

            if (!int.TryParse(agentNumber1.Substring(prefix1.Length), out number1) ||
                !int.TryParse(agentNumber2.Substring(prefix2.Length), out number2))
            {
                // Invalid agent number format (non-numeric part)
                throw new ArgumentException("Invalid agent number format");
            }

            // Compare prefixes
            if (prefix1 != prefix2)
            {
                return string.Compare(prefix1, prefix2, StringComparison.OrdinalIgnoreCase) < 0;
            }

            // Compare numbers
            return number1 < number2;
        }

    }
}
