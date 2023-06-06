using FourPointImport.Web.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.CodeAnalysis;
using FourPointImport.Services;
using FourPointImport.Data;

namespace FourPointImport.Web.Functions
{
    public class billingExportFunctions<TEntity>
        where TEntity : class
    {
        public Key02 Key_2;
        public struct Key02
        {
            public decimal Key02_Fld01;
            public string Key02_Fld02;
        }
        public Key03 Key_3;
        public struct Key03
        {
            public decimal Key03_Fld01;
            public string Key03_Fld02;
        }
        public Key04 Key_4;
        public struct Key04
        {
            public decimal Key04_Fld01;
            public string LType;
        }
        public struct Key04B
        {
            public decimal Key04_Fld01;
        }
        public Key05 Key_5;
        public struct Key05
        {
            public string SeAgnt;
            public int SeForm;
        }
        public Key06 Key_6;
        public struct Key06
        {
            public string SeAgnt;
            public string SeType;
            public int Key_Calc;
            public string SeLend;
        }
        public Key07 Key_7;
        public struct Key07
        {
            public string SeAgnt;
            public string SeType;
            public int Key_Calc;
        }
        public Key08 Key_8;
        public struct Key08
        {
            public string SeAgnt;
            public string SeCert;
        }
        public struct Key09
        {
            public string SeAgnt;
        }
        public struct Key10
        {
            public string SeAgnt;
            public string SeCert;
        }
        //SUSMSTPAccess tableAccess, PRDCOVPAccess prdcovpAccess, FrmMstPAccess frmMstLAccess, COVMSTRAccess covmstr,
        public billingExportFunctions([NotNull] billingExport _inComing, billingDetailService buildAccess)
        {
            Key_2 = new Key02();
            Key_3 = new Key03();
            Key_4 = new Key04();
            Key_5 = new Key05();
            Key_6 = new Key06();
            Key_7 = new Key07();
            Key_8 = new Key08();
        }
    }
}
