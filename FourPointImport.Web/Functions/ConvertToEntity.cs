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
        public billingExport PairFiles(BranchOffice _billingDetail)
        {
            _billingExport = new billingExport();
            _billingExport.SeAgnt = _billingDetail.BXAGNT;
            _billingExport.SeBrch = _billingDetail.BXBRCH;
            _billingExport.SeCert =_billingDetail.BXCERT;
            _billingExport.PgmNam = _billingDetail.BXNAME;
            _billingExport.SeDebtCode = _billingDetail.BXCOVC;
            _billingExport.SeEfft = _billingDetail.BXEFFT;
            _billingExport.SeFPrm = _billingDetail.BXFROM;
            _billingExport.BFTHRU = _billingDetail.BXTHRU;
            _billingExport.SeExpr = _billingDetail.BXEXPR;
            _billingExport.SeFPay = _billingDetail.BXPAID;
         //   _billingExport.BfNext = _billingDetail.BXNEXT;
            _billingExport.SeLAmt = _billingDetail.BXBAMT;
            _billingExport.SeComR = _billingDetail.BXCOMM;
            _billingExport.BFBGRS = _billingDetail.BXBGRS;
            _billingExport.SeDAmt = _billingDetail.BXPAMT;
            _billingExport.SeComR = _billingDetail.BXCOMP;
          //  _billingExport.BFGRS = _billingDetail.BXBGRS;
          //  _billingExport.BdPAmt = _billingDetail.BXMOB;
            _billingExport.SeIntr = _billingDetail.BXINTR;
         //   _billingExport.BdInt = _billingDetail.BXINT;
          //  _billingExport.BFPRIN = _billingDetail.BXPRIN;
            _billingExport.SeSchd = _billingDetail.BXSCHD;
            _billingExport.BFMSGC = _billingDetail.BXMSGC;
            _billingExport.BFMSGD = _billingDetail.BXMSGD;
            return _billingExport;
        }
    }
}
