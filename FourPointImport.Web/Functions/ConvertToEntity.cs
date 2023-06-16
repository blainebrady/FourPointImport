using System.Reflection;
using Utilities;
using FourPointImport.Web.Models;
using FourPointImport.Data;

namespace FourPointImport.Web.Functions
{
    public class ConvertToEntity<TEntity>
     where TEntity : class, new()
    {
        private string textString;
        private List<Diagram> pattern;
        private TEntity result;
        private billingExport _billingExport;
        public ConvertToEntity(string textString, List<Diagram> pattern)
        {
            this.textString = textString;
            this.pattern = pattern;
            result = new TEntity();
        }

        public TEntity Convert()
        {
            PropertyInfo[] patternProperties = typeof(TEntity).GetProperties();

            foreach (var item in patternProperties)
            {
                try
                {
                    Diagram d = pattern.Find(p => p.fieldName.ToLower() == item.Name.ToLower());
                    if (d != null)
                    {
                        if (textString.Length > d.start + d.length)
                        {
                            string res = textString.Substring(d.start, d.length);
                            try
                            {
                                switch (item.PropertyType.Name)
                                {
                                    case "DateTime":
                                        int iRes = (int)Utils.ParseNumControlledReturn(res);
                                        item.SetValue(result, Utils.DecimalToDate(iRes));
                                        break;
                                    case "Boolean":
                                        item.SetValue(result, Utils.ParseBoolSafe(res));
                                        break;
                                    case "Int":
                                        item.SetValue(result, (int)Utils.ParseNumControlledReturn(res));
                                        break;
                                    case "Int32":
                                        item.SetValue(result, (int)Utils.ParseNumControlledReturn(res));
                                        break;
                                    case "Decimal":
                                        item.SetValue(result, Utils.ParseNumControlledReturn(res));
                                        break;
                                    default:
                                        item.SetValue(result, res.StringSafe());
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return result;
        }
        public billingExport PairFiles(ImportFile _importFile)
        {
            _billingExport = new billingExport();
            _billingExport.SeAgnt = _importFile.BXAGNT;
            _billingExport.SeBrch = _importFile.BXBRCH;
            _billingExport.SeCert = _importFile.BXCERT;
            _billingExport.PgmNam = _importFile.BXNAME;
            _billingExport.SeDebtCode = _importFile.BXCOVC;
            _billingExport.SeEfft = _importFile.BXEFFT;
            _billingExport.SeFPrm = _importFile.BXFROM;
            _billingExport.BFTHRU = _importFile.BXTHRU;
            _billingExport.SeExpr = _importFile.BXEXPR;
            _billingExport.SeFPay = _importFile.BXPAID;
            _billingExport.BfNext = _importFile.BXNEXT;
            _billingExport.SeLAmt = _importFile.BXBAMT;
            _billingExport.SeComR = _importFile.BXCOMM;
            _billingExport.BFBGRS = _importFile.BXBGRS;
            _billingExport.SeDAmt = _importFile.BXPAMT;
            _billingExport.SeComR = _importFile.BXCOMP;
            _billingExport.BFGRS = _importFile.BXBGRS;
            _billingExport.BdPAmt = _importFile.BXMOB;
            _billingExport.SeIntr = _importFile.BXINTR;
            _billingExport.BdInt = _importFile.BXINT;
            _billingExport.BFPRIN = _importFile.BXPRIN;
            _billingExport.SeSchd = _importFile.BXSCHD;
            _billingExport.BFMSGC = _importFile.BXMSGC;
            _billingExport.BFMSGD = _importFile.BXMSGD;
            return _billingExport;
        }
    }
}
