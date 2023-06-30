using FourPointImport.Data;
using Microsoft.AspNetCore.DataProtection;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using Utilities;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace FourPointImport.Web.Functions
{
    public class MOB206OB
    {
        public SuspenseMaster susMaster { get; set; }
        public OutputStructure outputStructure { get; set; }
        public Confirmation conf { get; set; }
        //we're changing this to just take one SuspenseMaster at a time.
        public MOB206OB(SuspenseMaster _susMaster, Confirmation _conf)
        {
            susMaster = _susMaster;
            conf = _conf;
            outputStructure = new OutputStructure();
        }
        public void Process()
        { 
            ConvertToUpper();

            // Bank Number Conversion from Alpha to Numeric
            outputStructure.BankNo = ConvertAlphaToNumeric(susMaster.SmAgnt);

            // First Insured Social Security number Conversion from Alpha to Numeric
            outputStructure.SSNo1 = susMaster.SmIdn1;

                // First Insured Name Construction
                outputStructure.Name1 = $"{susMaster.SmLNam1.Trim()}, {susMaster.SmFNam1.Trim()}";

                // First Insured Address Information
                outputStructure.Eadr1 = susMaster.SmAdd11;
            outputStructure.Eadr2 = susMaster.SmAdd21;
                outputStructure.ECity = susMaster.SmCity1;
            outputStructure.ESt = susMaster.SmSte1;
                outputStructure.EZip = susMaster.SmZip1;
            
                // Explode First Insured Date of Birth
                
            outputStructure.BrthYY = susMaster.SmDob1.Year;
            outputStructure.BrthMM = susMaster.SmDob1.Month;
            outputStructure.BrthDD = susMaster.SmDob1.Day;
                // Second Insured Social Security number Conversion from Alpha to Numeric
                outputStructure.SSNo2 = susMaster.SmIdn2;

                // Second Insured Name Construction
                if (susMaster.SmLNam2 != string.Empty)
                outputStructure.Name2 = $"{susMaster.SmLNam2.Trim()}, {susMaster.SmFNam2.Trim()}";

                // Second Insured Address Information
                outputStructure.Eadr12 = susMaster.SmAdd12;
            outputStructure.Eadr22 = susMaster.SmAdd22;
                outputStructure.ECity2 = susMaster.SmCity2;
            outputStructure.ESt2 = susMaster.SmSte2;
                outputStructure.EZip2 = susMaster.SmZip2;

                // Explode Second Insured Date of Birth
            outputStructure.BrthY2 = susMaster.SmDob2.Year;
            outputStructure.BrthM2 = susMaster.SmDob2.Month;
            outputStructure.BrthD2 = susMaster.SmDob2.Day;
            // Loan Number
            outputStructure.LoanNo = (int)Utils.ParseNumControlledReturn(susMaster.SmCert);

            // Explode Loan Effective Date
            outputStructure.LoanYY = susMaster.SmEfft.Year;
            outputStructure.LoanMM = susMaster.SmEfft.Month;
                outputStructure.LoanDD = susMaster.SmEfft.Day;
            
            // Maturity Date
            outputStructure.MatrYY = 0;
            outputStructure.MatrMM = 0;
                outputStructure.MatrDD = 0;

            // Line Type
            outputStructure.LnType = "O";

            // Checking Account Number
            outputStructure.CkActNo = string.Empty;

            // Explode the Protection Effective Date (As Signed Date)

            outputStructure.SignYY = susMaster.SmEffP.Year;
            outputStructure.SignMM = susMaster.SmEffP.Month;
                outputStructure.SignDD = susMaster.SmEffP.Day;
                // A&H Coverage ?
                outputStructure.AHCov = string.Empty;

                // Write Record to File
                WriteRIOEDIB();
            
            ConFirm();
            Mob207();
            //this appears to just be a write statement

                //if (susMaster.SmCert == string.Empty)
                //    Key01ReadeSusMstL3();
                //else
                //    Key01bReadeSusMstL3();
            
        
        
        }

        private int ConvertAlphaToNumeric(string alphaValue)
        {
            // Conversion logic from Alpha to Numeric
            return int.Parse(alphaValue);
        }

        private void ExplodeDate(string date, out int year, out int month, out int day)
        {
            // Date explosion logic for general date fields
            DateTime dt = Utils.DecimalToDate((int)Utils.ParseNumControlledReturn(date));
            year = dt.Year;
            month = dt.Month;
            day = dt.Day;
        }

        private void WriteRIOEDIB()
        {
            // Write record to RIOEDIB file
        }

        private void ConvertToUpper()
        {
            Type type = susMaster.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(string))
                {
                    string value = (string)property.GetValue(this);
                    if (!string.IsNullOrEmpty(value))
                    {
                        string upperValue = value.ToUpper();
                        property.SetValue(this, upperValue);
                    }
                }
            }
        }

        private void ConFirm()
        {
            // Build $Confirmation file
            conf.CfAgnt = susMaster.SmAgnt;
            conf.CfCert = susMaster.SmCert;
            conf.CfFlag = "A";
            conf.CfErr = "";
            conf.CfProc = DateTime.Now;
  //Write     ConFrmR
        }

        private void Mob207()
        {
            // Call MOB207 program for duplicate record processing
            new MOB207(susMaster.SmAgnt, susMaster.SmCert,0, "OB", susMaster);

        }

        private void EndPgm()
        {
            // End of program subroutine
        }

    }

}
