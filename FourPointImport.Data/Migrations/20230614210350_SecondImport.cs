using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FourPointImport.Data.Migrations
{
    public partial class SecondImport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormMaster",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    FmAGNT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FmForm = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    FmDesc = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    FmType = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FmCalc = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    FmLend = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FmEfft = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FmExpr = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FmDATA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FmUSRA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FmDATU = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FmUSRU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FmDATC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FmUSRC = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormMaster", x => x.id);

                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormMaster",
                schema: "dbo");
        }
    }
}
