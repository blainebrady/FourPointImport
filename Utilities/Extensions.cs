﻿using System.Data;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Utilities
{
    public static class Extensions
    {
        private static DateTime sqlDate { get { return Convert.ToDateTime("01/01/1900"); } }
        public static int Absolute(this int container)
        {
            if (container < 0)
            {
                container = container * -1;
            }
            return container;
        }
        public static DateTime CorrectTimeZone(this DateTime dt)
        {
            TimeZoneInfo local = TimeZoneInfo.Local;
            int adjust = 8;
            TimeSpan ts = local.GetUtcOffset(dt);

            // correct for current time zone
            if (local.IsDaylightSavingTime(dt))
                adjust = 7;
            return dt.AddHours(ts.Hours + adjust);
        }
        public static void CopyShallow(this Object dst, object src)
        {
            var srcT = src.GetType();
            var dstT = dst.GetType();
            foreach (var f in srcT.GetFields())
            {

                var dstF = dstT.GetField(f.Name);
                if (dstF == null)
                    continue;
                dstF.SetValue(dst, f.GetValue(src));
            }

            foreach (var f in srcT.GetProperties())
            {
                var typ = f.GetType();
                var dType = typ.GetProperty(f.Name);

                var dstF = dstT.GetProperty(f.Name);
                if (dstF == null)
                    continue;

                dstF.SetValue(dst, f.GetValue(src, null), null);
            }
        }
        public static bool DateNotNull(this DateTime dt)
        {
            if (dt == DateTime.Parse("1/1/0001 12:00:00 AM"))
                return false;
            try
            {
                return dt >= DateTime.MinValue;
            }
            catch { return false; }
        }
        public static DateTime IntToDate(this int d)
        {
            string s = d.StringSafe();
            DateTime dt = DateTime.MinValue;
            if (s.Length == 0)
            {
                try
                {
                    dt = DateTime.Parse(s.Substring(4, 2) + "/" + s.Substring(6, 2) + "/" + s.Substring(0, 4));
                }
                catch { }
            }
            return dt;
        }
        public static T DeepClone<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }
        public static decimal RoundOff(this decimal container, int limit)
        {
            return Math.Round(container, limit);
        }
        public static int ToInt(this object container)
        {
            int value = 0;
            try
            {
                value = container.ToInt();
            }
            catch { }
            return value;
        }
        public static string TrimThis(this string container, int maxLength)
        {
            string value = container;

            if (value.Length > maxLength)
                value = value.Substring(0, maxLength) + "...";
            return value;
        }
        public static object DateInsertForDatabase(this string container)
        {
            object obj = DBNull.Value;
            try
            {
                DateTime dDate = Utils.ParseDateControlledReturn(container);
                if (dDate > DateTime.MinValue && dDate != sqlDate)
                {
                    obj = string.Format("{0: MM/dd/yyyy}", dDate);
                }
            }
            catch { }           //we don't care if there's an error - just return nothing
            return obj;
        }
        public static string DateWithoutTime(this string container)
        {
            string sRet = "";
            try
            {
                DateTime dDate = Utils.ParseDateControlledReturn(container);
                if (dDate > DateTime.MinValue && dDate != sqlDate)
                {
                    sRet = string.Format("{0: MM/dd/yyyy}", dDate);
                }
            }
            catch { }           //we don't care if there's an error - just return nothing
            return sRet;
        }
        public static DateTime? DateScreen(this DateTime container)
        {
            try
            {
                DateTime dDate = Utils.ParseDateControlledReturn(container);
                if (dDate > DateTime.MinValue && dDate != sqlDate)
                {
                    return dDate;
                }
                else
                    return null;
            }
            catch { return null; }           //we don't care if there's an error - just return nothing

        }
        public static string DateWithTime(this DateTime container)
        {
            string sRet = "";
            try
            {
                DateTime dDate = Utils.ParseDateControlledReturn(container);
                if (dDate > DateTime.MinValue && dDate != sqlDate)
                {
                    sRet = string.Format("{0: MM/dd/yyyy hh:mm tt}", dDate);
                }
            }
            catch { }
            return sRet;
        }
        public static string RemoveMinDate(this DateTime container)
        {
            if (container == DateTime.MinValue || container == sqlDate)
                return "";
            else
                return string.Format("{0:MM/dd/yyyy}", container);
        }
        public static string RemoveSpaces(this string container)
        {
            string sRet = container.Replace(" ", "");

            return sRet;
        }
        public static string ShowDollarValue(this decimal container)
        {
            string sRet = string.Format("{0:C}", container);
            return sRet;
        }
        public static string Suffix(this string fileName)
        {
            string ret = "";

            if (fileName.IndexOf(".") > 0)
            {
                ret = fileName.Substring(fileName.IndexOf("."), (fileName.Length - fileName.IndexOf(".")));
            }
            ret = ret.Replace(".", "");
            return ret;
        }

        public static T? GetValue<T>(this DataRow row, string columnName) where T : struct
        {
            if (row.IsNull(columnName))
                return null;

            return row[columnName] as T?;
        }
        public static T? GetValue<T>(this DataRow row, int columnIndex) where T : struct
        {
            if (row[columnIndex] == null)
                return null;

            return row[columnIndex] as T?;
        }
        public static string GetText(this DataRow row, string columnName)
        {
            if (row.IsNull(columnName))
                return string.Empty;

            return row[columnName] as string ?? string.Empty;
        }
        public static bool isNumeric(this object value)
        {
            try
            {
                int i = (int)value;
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Returns a copy of the string enclosed in double-quotes and with escaped CRLF, back-slash
        /// and double-quote characters (as is expected by some commands of the IMAP protocol).
        /// </summary>
        /// <param name="value">Extends the System.String class</param>
        /// <returns>A copy of the string enclosed in double-quotes and properly escaped as is required
        /// by the IMAP protocol.</returns>
        public static string QuoteString(this string value)
        {
            return "\"" + value
                .Replace("\\", "\\\\")
                .Replace("\r", "\\r")
                .Replace("\n", "\\n")
                .Replace("\"", "\\\"") + "\"";
        }
        public static string StringLimit(this object value, int Limit)
        {
            string sRet = "";

            if (value != null)
                sRet = value.ToString();

            if (sRet.Length > Limit)
                sRet = sRet.Substring(0, Limit - 1);
            return sRet;
        }
        public static string StringSafe(this object value)
        {
            string sRet = "";

            if (value != null)
                sRet = value.ToString();

            return sRet;
        }
    }
}
