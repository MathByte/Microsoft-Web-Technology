using Microsoft.EntityFrameworkCore.Migrations;

namespace StockTransactionApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companys",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TickerSymbol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companys", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                columns: table => new
                {
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommissionFee = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.TransactionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionRecords",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SharePrice = table.Column<double>(type: "float", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionRecords", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_TransactionRecords_Companys_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companys",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionRecords_TransactionTypes_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionTypes",
                        principalColumn: "TransactionTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companys",
                columns: new[] { "CompanyId", "Address", "Name", "TickerSymbol" },
                values: new object[,]
                {
                    { 1, "Waterloo", "Google", "GOOG" },
                    { 2, "Kitchener", "Microsoft", "MSFT" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "TransactionTypeId", "CommissionFee", "Name" },
                values: new object[,]
                {
                    { 1, 5.9900000000000002, "Sell" },
                    { 2, 5.4000000000000004, "Buy" }
                });

            migrationBuilder.InsertData(
                table: "TransactionRecords",
                columns: new[] { "TransactionId", "CompanyId", "Quantity", "SharePrice", "TransactionTypeId" },
                values: new object[] { 1, 1, 100, 2701.7600000000002, 1 });

            migrationBuilder.InsertData(
                table: "TransactionRecords",
                columns: new[] { "TransactionId", "CompanyId", "Quantity", "SharePrice", "TransactionTypeId" },
                values: new object[] { 2, 2, 100, 123.45, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionRecords_CompanyId",
                table: "TransactionRecords",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionRecords_TransactionTypeId",
                table: "TransactionRecords",
                column: "TransactionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionRecords");

            migrationBuilder.DropTable(
                name: "Companys");

            migrationBuilder.DropTable(
                name: "TransactionTypes");
        }
    }
}
