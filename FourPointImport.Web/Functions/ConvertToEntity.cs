using System.Reflection;
using Utilities;
using FourPointImport.Web.Models;

namespace FourPointImport.Web.Functions
{
    public class ConvertToEntity<TEntity>
     where TEntity : class, new()
    {
        private string textString;
        private List<Diagram> pattern;
        private TEntity result;

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
    }
}
