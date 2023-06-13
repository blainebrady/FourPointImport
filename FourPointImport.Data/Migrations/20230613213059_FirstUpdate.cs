using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FourPointImport.Data.Migrations
{
    public partial class FirstUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Import",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Archive = table.Column<bool>(type: "bit", nullable: false),
                    CreateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Import", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BillingDetail",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    BDSEQ = table.Column<int>(type: "int", nullable: false),
                    BXAGNT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BXBRCH = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BXCERT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BXNAME = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    BXCOVC = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BXEFFT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BXFROM = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BXTHRU = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BXEXPR = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BXPAID = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BXNEXT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BXNEG01 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    BXBAMT = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    BXNEG02 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    BXCOMM = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    BXNEG03 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    BXBGRS = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    BXNEG04 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    BXPAMT = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    BXNEG05 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    BXCOMP = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    BXNEG06 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    BXPGRS = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    BXNEG07 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    BXMOB = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    BXINTR = table.Column<decimal>(type: "decimal(7,5)", precision: 7, scale: 5, nullable: false),
                    BXINT = table.Column<decimal>(type: "decimal(7,5)", precision: 7, scale: 5, nullable: false),
                    BXPRIN = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    BXSCHD = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    BXMSGC = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    BXMSGD = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    BXCODE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    BXDESC = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    BXCAND = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_BillingDetail_Import_id",
                        column: x => x.id,
                        principalTable: "Import",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "SuspenseMaster",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    SmAgnt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SmRegn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmTerr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmBrch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmOffc = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SmCert = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SmBen1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SmBen2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    SmEfft = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmDays = table.Column<int>(type: "int", precision: 3, scale: 0, nullable: false),
                    SmFPay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmTerm = table.Column<int>(type: "int", precision: 3, scale: 0, nullable: false),
                    SmExpr = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmFreq = table.Column<int>(type: "int", precision: 3, scale: 0, nullable: false),
                    SmAmnt = table.Column<int>(type: "int", precision: 11, scale: 2, nullable: false),
                    SmBall = table.Column<string>(type: "nvarchar(max)", precision: 11, scale: 2, nullable: false),
                    SmIntr = table.Column<decimal>(type: "decimal(7,5)", precision: 7, scale: 5, nullable: false),
                    SmSchd = table.Column<int>(type: "int", precision: 11, scale: 2, nullable: false),
                    SmLAmt = table.Column<decimal>(type: "decimal(11,7)", precision: 11, scale: 7, nullable: false),
                    SmDAmt = table.Column<decimal>(type: "decimal(11,7)", precision: 11, scale: 7, nullable: false),
                    SmLChg = table.Column<string>(type: "nvarchar(max)", precision: 11, scale: 2, nullable: false),
                    SmDChg = table.Column<string>(type: "nvarchar(max)", precision: 11, scale: 2, nullable: false),
                    SmLBen = table.Column<int>(type: "int", precision: 11, scale: 2, nullable: false),
                    SmLend = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SmDBen = table.Column<int>(type: "int", precision: 11, scale: 2, nullable: false),
                    SmForm = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    SmType = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SmCalc = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SmFPrm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmEffL = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmTrmL = table.Column<int>(type: "int", precision: 3, scale: 0, nullable: false),
                    SmExpL = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmEffD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmTrmD = table.Column<int>(type: "int", precision: 3, scale: 0, nullable: false),
                    SmExpD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmEffP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmTrmP = table.Column<int>(type: "int", precision: 3, scale: 0, nullable: false),
                    SmExpP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmIdn1 = table.Column<int>(type: "int", precision: 9, scale: 0, nullable: false),
                    SmMNam1 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    SmLNam2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    SmLNam1 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    SmFNam1 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    SmSufx1 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    SmAdd11 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    SmAdd21 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    SmCity1 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    SmSte1 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    SmZip1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SmPhne1 = table.Column<decimal>(type: "decimal(10,0)", precision: 10, scale: 0, nullable: false),
                    SmDob1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmSex1 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ01A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ02A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ03A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ04A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ05A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ06A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ07A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ08A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ09A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ10A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ11A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ12A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ13A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ14A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ15A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ16A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ17A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ18A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ19A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ20A = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmSig1 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmIdn2 = table.Column<int>(type: "int", precision: 9, scale: 0, nullable: false),
                    SmFNam2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    SmMNam2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    SmSufx2 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    SmAdd12 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    SmAdd22 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    SmCity2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    SmSte2 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    SmZip2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SmPhne2 = table.Column<decimal>(type: "decimal(10,0)", precision: 10, scale: 0, nullable: false),
                    SmDob2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmSex2 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ01B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ02B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ03B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ04B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ05B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ06B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ07B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ08B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ09B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ10B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ11B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ12B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ13B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ14B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ15B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ16B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ17B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ18B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ19B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmHQ20B = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmSig2 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmExcd = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    SmExcP = table.Column<int>(type: "int", nullable: false),
                    SmUsrA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SmDatU = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmUsrU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SmFlag = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    SmCnl = table.Column<int>(type: "int", nullable: false),
                    SmCnlL = table.Column<int>(type: "int", nullable: false),
                    SmCnlD = table.Column<int>(type: "int", nullable: false),
                    SmSovS = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SmSovD = table.Column<int>(type: "int", nullable: false),
                    SmPanI = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    SmDeal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SmLif = table.Column<decimal>(type: "decimal(5,0)", precision: 5, scale: 0, nullable: false),
                    SmDis = table.Column<decimal>(type: "decimal(5,0)", precision: 5, scale: 0, nullable: false),
                    SmDebt = table.Column<decimal>(type: "decimal(5,0)", precision: 5, scale: 0, nullable: false),
                    SmFut1 = table.Column<int>(type: "int", precision: 5, scale: 0, nullable: false),
                    SmFut2 = table.Column<int>(type: "int", precision: 5, scale: 0, nullable: false),
                    SmLine = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    SmVIN = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    SmYear = table.Column<int>(type: "int", nullable: false),
                    SmMake = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    SmModel = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    SmFee = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    SmComR = table.Column<decimal>(type: "decimal(7,5)", precision: 7, scale: 5, nullable: false),
                    SmGEfft = table.Column<int>(type: "int", nullable: false),
                    SmGExpr = table.Column<int>(type: "int", nullable: false),
                    SmGStat = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SmGDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Smmntf = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    SmCert2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuspenseMaster", x => x.id);
                    table.ForeignKey(
                        name: "FK_SuspenseMaster_Import_id",
                        column: x => x.id,
                        principalTable: "Import",
                        principalColumn: "id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillingDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SuspenseMaster",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Import");
        }
    }
}
