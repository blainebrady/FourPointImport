using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FourPointImport.Data.Migrations
{
    public partial class NoNulls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AgentDetail",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADAGNT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ADCOVC = table.Column<decimal>(type: "decimal(5,0)", precision: 5, scale: 0, nullable: false),
                    AdTble = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    AdType = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    ADCCF = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ADGLCO = table.Column<decimal>(type: "decimal(3,0)", precision: 3, scale: 0, nullable: false),
                    ADGL = table.Column<decimal>(type: "decimal(7,0)", precision: 7, scale: 0, nullable: false),
                    ADCLM = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ADCLMP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ADCLMT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AdEfft = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdExpr = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdMxBa = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    AdMxBM = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    AdMnAg = table.Column<decimal>(type: "decimal(3,0)", precision: 3, scale: 0, nullable: false),
                    AdMxAg = table.Column<decimal>(type: "decimal(3,0)", precision: 3, scale: 0, nullable: false),
                    AdMnA2 = table.Column<decimal>(type: "decimal(3,0)", precision: 3, scale: 0, nullable: false),
                    ADMXA2 = table.Column<decimal>(type: "decimal(3,0)", precision: 3, scale: 0, nullable: false),
                    AdMxTr = table.Column<decimal>(type: "decimal(3,0)", precision: 3, scale: 0, nullable: false),
                    AdMxCT = table.Column<decimal>(type: "decimal(3,0)", precision: 3, scale: 0, nullable: false),
                    AdHqML = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    AdHlth = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    AdLaps = table.Column<decimal>(type: "decimal(3,0)", precision: 3, scale: 0, nullable: false),
                    ADDINY = table.Column<decimal>(type: "decimal(3,0)", precision: 3, scale: 0, nullable: false),
                    AdComm = table.Column<decimal>(type: "decimal(5,3)", precision: 5, scale: 3, nullable: false),
                    AdPRat = table.Column<decimal>(type: "decimal(3,0)", precision: 3, scale: 0, nullable: false),
                    AdTolP = table.Column<decimal>(type: "decimal(5,3)", precision: 5, scale: 3, nullable: false),
                    AdTolA = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    ADDATA = table.Column<decimal>(type: "decimal(14,0)", precision: 14, scale: 0, nullable: false),
                    ADUSRA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ADDATU = table.Column<decimal>(type: "decimal(14,0)", precision: 14, scale: 0, nullable: false),
                    ADUSRU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ADDATC = table.Column<decimal>(type: "decimal(14,0)", precision: 14, scale: 0, nullable: false),
                    ADUSRC = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Archive = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentDetail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AgentMaster",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AMHOLD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AMAGNT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AMCNTC = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    AMAGNY = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    AMADD1 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    AMADD2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    AMCITY = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    AMSTE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    AMZIP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AMRPST = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    AMPHNE = table.Column<int>(type: "int", nullable: false),
                    AMTXID = table.Column<int>(type: "int", nullable: false),
                    AMSSNO = table.Column<int>(type: "int", nullable: false),
                    AMREP = table.Column<int>(type: "int", nullable: false),
                    AMSTAT = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    AmOnly = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    AMRTRQ = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    AmBoRq = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    AMBILL = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    AMCLMD = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    AMMTHD = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    AMREIN = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    AMEFFT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AMEXPR = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AMDATA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AMUSRA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AMDATU = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AMUSRU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AMDATC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AMUSRC = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Archive = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentMaster", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BillingDetail",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BdAgnt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BdCert = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BdSEQ = table.Column<int>(type: "int", precision: 9, scale: 0, nullable: false),
                    BdCovc = table.Column<decimal>(type: "decimal(5,0)", precision: 5, scale: 0, nullable: false),
                    BdFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BdDue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BdBill = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BdThru = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BdPaid = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BdNext = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BdBAmt = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    BdComm = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    BdPAmt = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    BdPCom = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    BdMOB = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    BdIntr = table.Column<decimal>(type: "decimal(7,5)", precision: 7, scale: 5, nullable: false),
                    BdInt = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    BdPrin = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    BdSchd = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    BdMsgC = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    BdMsgCD = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    BdCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    BdDesc = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    BdData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BdUsrA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BdDatU = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BdUsrU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BdDatC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BdUsrC = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Archive = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingDetail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BranchOffice",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BmAgnt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BmRegn = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BMRNam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BmTerr = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BMTNam = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    BmBrch = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BMBNam = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    BmOffc = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BMONam = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    BmDatA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BmDatU = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BmDatC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BmUsrA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BmUsrU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BmUsrC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Archive = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchOffice", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Confirmation",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CfAgnt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CfCert = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CfFlag = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    CfErr = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CfProc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Archive = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confirmation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CoverageInsHist",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CmAgnt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CmCert = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CmIDN1 = table.Column<int>(type: "int", precision: 9, scale: 0, nullable: false),
                    CmIDN2 = table.Column<decimal>(type: "decimal(9,0)", precision: 9, scale: 0, nullable: false),
                    CmFPrm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CmEfft = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CmExpr = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CmTerm = table.Column<int>(type: "int", precision: 3, scale: 0, nullable: false),
                    CmDays = table.Column<decimal>(type: "decimal(3,0)", precision: 3, scale: 0, nullable: false),
                    CmAmnt = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    CmBAmt = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    CmStat = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    CmCovc = table.Column<decimal>(type: "decimal(5,0)", precision: 5, scale: 0, nullable: false),
                    CmTble = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    CmLapD = table.Column<int>(type: "int", nullable: false),
                    CmLapR = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    CmCand = table.Column<int>(type: "int", nullable: false),
                    CmCanr = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    CmPrev = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CmData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CMUsrA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CMDatU = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CMUsrU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CMDatC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CMUsrC = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Archive = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverageInsHist", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CoverageInsuranceMaster",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CmAgnt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CmCert = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CmIDN1 = table.Column<int>(type: "int", precision: 9, scale: 0, nullable: false),
                    CmIDN2 = table.Column<decimal>(type: "decimal(9,0)", precision: 9, scale: 0, nullable: false),
                    CmFPrm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CmEfft = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CmExpr = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CmTerm = table.Column<int>(type: "int", precision: 3, scale: 0, nullable: false),
                    CmDays = table.Column<decimal>(type: "decimal(3,0)", precision: 3, scale: 0, nullable: false),
                    CmAmnt = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    CmBAmt = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    CmStat = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    CmCovc = table.Column<decimal>(type: "decimal(5,0)", precision: 5, scale: 0, nullable: false),
                    CmTble = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    CmLapD = table.Column<int>(type: "int", nullable: false),
                    CmLapR = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    CmCand = table.Column<int>(type: "int", nullable: false),
                    CmCanr = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    CmPrev = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CmData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CMUsrA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CMDatU = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CMUsrU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CMDatC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CMUsrC = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Archive = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverageInsuranceMaster", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Error",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CfAgnt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CfCert = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CfFlag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CfErr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CfProc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archive = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Error", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FormMaster",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FmAGNT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FmForm = table.Column<int>(type: "int", nullable: false),
                    FmDesc = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    FmType = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    FmCalc = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    FmLend = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    FmEfft = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FmExpr = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FmDATA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FmUSRA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FmDATU = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FmUSRU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FmDATC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FmUSRC = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Archive = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormMaster", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GAPInsurance",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GmAgnt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    GmCert = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    GmVIN = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    GmYear = table.Column<int>(type: "int", nullable: false),
                    GmMake = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    GmModel = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    GmFee = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    GmComR = table.Column<decimal>(type: "decimal(7,5)", precision: 7, scale: 5, nullable: false),
                    GmEfft = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GmExpr = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GmStat = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    GmSDte = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GmDatU = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GmUsrU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    GmDatA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GmUsrA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    GmHstD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GmHstU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Archive = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GAPInsurance", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ImportFile",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BXAGNT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BXBRCH = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BXCERT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BXNAME = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    BXCOVC = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BXEFFT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BXFROM = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BXTHRU = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BXEXPR = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BXPAID = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BXNEXT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BXNEG01 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    BXBAMT = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    BXNEG02 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    BXCOMM = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    BXNEG03 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    BXBGRS = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    BXNEG04 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    BXPAMT = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    BXNEG05 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    BXCOMP = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    BXNEG06 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    BXPGRS = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    BXNEG07 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    BXMOB = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    BXINTR = table.Column<decimal>(type: "decimal(7,5)", precision: 7, scale: 5, nullable: false),
                    BXINT = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    BXPRIN = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    BXSCHD = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    BXMSGC = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    BXMSGD = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    BXCODE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    BXDESC = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    BXCAND = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Archive = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportFile", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationHistory",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LmAgnt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LmCert = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LmIdn1 = table.Column<int>(type: "int", nullable: false),
                    LmIdn2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LmCalc = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    LmRegn = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LmTerr = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LmBrch = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LmOffc = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LmDeal = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LmBen1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LmBen2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    LmFPay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LmEfft = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LmExpr = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LmCnlD = table.Column<int>(type: "int", nullable: false),
                    LmForm = table.Column<int>(type: "int", nullable: false),
                    LmTerm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LmFreq = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LmAmnt = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    LmBall = table.Column<int>(type: "int", nullable: false),
                    LmSchd = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    LmIntr = table.Column<decimal>(type: "decimal(7,5)", precision: 7, scale: 5, nullable: false),
                    LmPani = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    LmLine = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    LmStat = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    LmSig1 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    LmSig2 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    LmGuid = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    LmSts1 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    LmSts2 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    LmSts3 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    LmPrev = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LmDatA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LmUsrA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LmDatU = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LmUsrU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LmDatc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LmUsrc = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LmMntf = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    Archive = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplicationHistory", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationMaster",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LmAgnt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LmCert = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LmIdn1 = table.Column<int>(type: "int", nullable: false),
                    LmIdn2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LmCalc = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    LmRegn = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LmTerr = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LmBrch = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LmOffc = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LmDeal = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LmBen1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LmBen2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    LmFPay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LmEfft = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LmExpr = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LmCnlD = table.Column<int>(type: "int", nullable: false),
                    LmForm = table.Column<int>(type: "int", nullable: false),
                    LmTerm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LmFreq = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LmAmnt = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    LmBall = table.Column<int>(type: "int", nullable: false),
                    LmSchd = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    LmIntr = table.Column<decimal>(type: "decimal(7,5)", precision: 7, scale: 5, nullable: false),
                    LmPani = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    LmLine = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    LmStat = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    LmSig1 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    LmSig2 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    LmGuid = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    LmSts1 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    LmSts2 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    LmSts3 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    LmPrev = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LmDatA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LmUsrA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LmDatU = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LmUsrU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LmDatc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LmUsrc = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LmMntf = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    Archive = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplicationMaster", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OutputStructure",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankNo = table.Column<int>(type: "int", nullable: false),
                    SSNo1 = table.Column<int>(type: "int", nullable: false),
                    Name1 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Eadr1 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Eadr2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ECity = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ESt = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    EZip = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BrthYY = table.Column<int>(type: "int", nullable: false),
                    BrthMM = table.Column<int>(type: "int", nullable: false),
                    BrthDD = table.Column<int>(type: "int", nullable: false),
                    SSNo2 = table.Column<int>(type: "int", nullable: false),
                    Name2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Eadr12 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Eadr22 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ECity2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ESt2 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    EZip2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BrthY2 = table.Column<int>(type: "int", nullable: false),
                    BrthM2 = table.Column<int>(type: "int", nullable: false),
                    BrthD2 = table.Column<int>(type: "int", nullable: false),
                    LoanNo = table.Column<int>(type: "int", nullable: false),
                    LoanYY = table.Column<int>(type: "int", nullable: false),
                    LoanMM = table.Column<int>(type: "int", nullable: false),
                    LoanDD = table.Column<int>(type: "int", nullable: false),
                    MatrYY = table.Column<int>(type: "int", nullable: false),
                    MatrMM = table.Column<int>(type: "int", nullable: false),
                    MatrDD = table.Column<int>(type: "int", nullable: false),
                    LnType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CkActNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignYY = table.Column<int>(type: "int", nullable: false),
                    SignMM = table.Column<int>(type: "int", nullable: false),
                    SignDD = table.Column<int>(type: "int", nullable: false),
                    AHCov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Archive = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputStructure", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PatronCustHist",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImIDN = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImLNam = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ImFNam = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ImMNam = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ImSufx = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    ImAdd1 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ImAdd2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ImCity = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ImSte = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    ImZip = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ImPhne = table.Column<decimal>(type: "decimal(10,0)", precision: 10, scale: 0, nullable: false),
                    ImDob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImSex = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    ImStat = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ01 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ02 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ03 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ04 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ05 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ06 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ07 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ08 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ09 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ10 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ11 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ12 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ13 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ14 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ15 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ16 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ17 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ18 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ19 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ20 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    ImUsrA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ImDatU = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImUsrU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ImDatA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Archive = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatronCustHist", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PatronCustomer",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImIDN = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImLNam = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ImFNam = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ImMNam = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ImSufx = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    ImAdd1 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ImAdd2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ImCity = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ImSte = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    ImZip = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ImPhne = table.Column<decimal>(type: "decimal(10,0)", precision: 10, scale: 0, nullable: false),
                    ImDob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImSex = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    ImStat = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ01 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ02 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ03 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ04 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ05 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ06 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ07 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ08 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ09 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ10 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ11 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ12 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ13 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ14 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ15 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ16 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ17 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ18 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ19 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IMHQ20 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    ImUsrA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ImDatU = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImUsrU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ImDatA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Archive = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatronCustomer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCoverage",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PCCOVC = table.Column<decimal>(type: "decimal(5,0)", precision: 5, scale: 0, nullable: false),
                    PCDESC = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    PCLTYPE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PCSHRT = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PCINS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    PCCALC = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    PCSORJ = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    PCCOMM = table.Column<decimal>(type: "decimal(5,3)", precision: 5, scale: 3, nullable: false),
                    PCEFFT = table.Column<int>(type: "int", nullable: false),
                    PCEXPR = table.Column<int>(type: "int", nullable: false),
                    PCDATA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PCUSRA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PCDATU = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PCUSRU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PCDATC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PCUSRC = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Archive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCoverage", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswer",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QaAgnt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QaCert = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QaIDN = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QaSeq = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QaQstn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archive = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RateDetailLife",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RDTBLE = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    RdBand = table.Column<decimal>(type: "decimal(3,0)", precision: 3, scale: 0, nullable: false),
                    RdRate = table.Column<decimal>(type: "decimal(7,5)", precision: 7, scale: 5, nullable: false),
                    RdPrct = table.Column<decimal>(type: "decimal(7,5)", precision: 7, scale: 5, nullable: false),
                    RdEfft = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RdExpr = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RDDATA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RDUSRA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RDDATU = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RDUSRU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RDDATC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RDUSRC = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Archive = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateDetailLife", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RateMaster",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RmTble = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    RmDesc = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    RmShrt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RmBase = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    RmEfft = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RmExpr = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RmDATA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RmUSRA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RmDATU = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RmUSRU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RmDATC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RmUSRC = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Archive = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateMaster", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SuspenseMaster",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmAgnt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SmRegn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmTerr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmBrch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmOffc = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SmCert = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SmBen1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SmBen2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SmEfft = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmDays = table.Column<int>(type: "int", precision: 3, scale: 0, nullable: false),
                    SmFPay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmTerm = table.Column<int>(type: "int", precision: 3, scale: 0, nullable: false),
                    SmExpr = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmFreq = table.Column<int>(type: "int", precision: 3, scale: 0, nullable: false),
                    SmAmnt = table.Column<int>(type: "int", precision: 11, scale: 2, nullable: false),
                    SmBall = table.Column<string>(type: "nvarchar(max)", precision: 11, scale: 2, nullable: false),
                    SmIntr = table.Column<decimal>(type: "decimal(7,5)", precision: 7, scale: 5, nullable: false),
                    SmSchd = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    SmLAmt = table.Column<decimal>(type: "decimal(11,7)", precision: 11, scale: 7, nullable: false),
                    SmDAmt = table.Column<decimal>(type: "decimal(11,7)", precision: 11, scale: 7, nullable: false),
                    SmLChg = table.Column<string>(type: "nvarchar(max)", precision: 11, scale: 2, nullable: false),
                    SmDChg = table.Column<string>(type: "nvarchar(max)", precision: 11, scale: 2, nullable: false),
                    SmLBen = table.Column<int>(type: "int", precision: 11, scale: 2, nullable: false),
                    SmLend = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SmDBen = table.Column<int>(type: "int", precision: 11, scale: 2, nullable: false),
                    SmForm = table.Column<int>(type: "int", nullable: false),
                    SmType = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SmCalc = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SmFPrm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmEffL = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmTrmL = table.Column<int>(type: "int", precision: 3, scale: 0, nullable: false),
                    SmExpL = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmEffD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmTrmD = table.Column<int>(type: "int", nullable: false),
                    SmExpD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmEffP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmTrmP = table.Column<int>(type: "int", precision: 3, scale: 0, nullable: false),
                    SmExpP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmIdn1 = table.Column<int>(type: "int", precision: 9, scale: 0, nullable: false),
                    SmMNam1 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SmLNam2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SmLNam1 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SmFNam1 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SmLNam1A = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SmFNam1A = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SmLNam2A = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SmFNam2A = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SmSufx1 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    SmAdd11 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SmAdd21 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SmCity1 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SmSte1 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    SmZip1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SmPhne1 = table.Column<decimal>(type: "decimal(10,0)", precision: 10, scale: 0, nullable: false),
                    SmDob1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmSex1 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ01A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ02A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ03A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ04A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ05A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ06A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ07A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ08A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ09A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ10A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ11A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ12A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ13A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ14A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ15A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ16A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ17A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ18A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ19A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ20A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmSig1 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmIdn2 = table.Column<int>(type: "int", precision: 9, scale: 0, nullable: false),
                    SmFNam2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SmMNam2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SmSufx2 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    SmAdd12 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SmAdd22 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SmCity2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SmSte2 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    SmZip2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SmPhne2 = table.Column<decimal>(type: "decimal(10,0)", precision: 10, scale: 0, nullable: false),
                    SmDob2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmSex2 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ01B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ02B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ03B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ04B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ05B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ06B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ07B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ08B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ09B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ10B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ11B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ12B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ13B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ14B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ15B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ16B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ17B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ18B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ19B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmHQ20B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmSig2 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmExcd = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    SmExcP = table.Column<int>(type: "int", nullable: false),
                    SmUsrA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SmDatU = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmUsrU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SmFlag = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SmCnl = table.Column<int>(type: "int", nullable: false),
                    SmCnlL = table.Column<int>(type: "int", nullable: false),
                    SmCnlD = table.Column<int>(type: "int", nullable: false),
                    SmSovS = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SmSovD = table.Column<int>(type: "int", nullable: false),
                    SmPanI = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    SmDeal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SmLif = table.Column<decimal>(type: "decimal(5,0)", precision: 5, scale: 0, nullable: false),
                    SmDis = table.Column<decimal>(type: "decimal(5,0)", precision: 5, scale: 0, nullable: false),
                    SmDebt = table.Column<decimal>(type: "decimal(5,0)", precision: 5, scale: 0, nullable: false),
                    SmFut1 = table.Column<int>(type: "int", precision: 5, scale: 0, nullable: false),
                    SmFut2 = table.Column<int>(type: "int", precision: 5, scale: 0, nullable: false),
                    SmLine = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    SmVIN = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    SmYear = table.Column<int>(type: "int", nullable: false),
                    SmMake = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    SmModel = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    SmFee = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    SmComR = table.Column<decimal>(type: "decimal(7,5)", precision: 7, scale: 5, nullable: false),
                    SmGEfft = table.Column<int>(type: "int", nullable: false),
                    SmGExpr = table.Column<int>(type: "int", nullable: false),
                    SmGStat = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SmGDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Smmntf = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    SmCert2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Archive = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuspenseMaster", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AgentMaster",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BillingDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BranchOffice",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Confirmation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CoverageInsHist",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CoverageInsuranceMaster",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Error",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FormMaster",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GAPInsurance",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ImportFile",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LoanApplicationHistory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LoanApplicationMaster",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OutputStructure",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PatronCustHist",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PatronCustomer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductCoverage",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "QuestionAnswer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RateDetailLife",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RateMaster",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SuspenseMaster",
                schema: "dbo");
        }
    }
}
