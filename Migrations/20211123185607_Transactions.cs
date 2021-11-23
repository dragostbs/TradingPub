using Microsoft.EntityFrameworkCore.Migrations;

namespace TradingPub.Migrations
{
    public partial class Transactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Traders",
                columns: table => new
                {
                    TraderID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traders", x => x.TraderID);
                });

            migrationBuilder.CreateTable(
                name: "Cryptos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TraderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cryptos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cryptos_Traders_TraderID",
                        column: x => x.TraderID,
                        principalTable: "Traders",
                        principalColumn: "TraderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StocksTransactions",
                columns: table => new
                {
                    StocksTransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraderID = table.Column<int>(type: "int", nullable: false),
                    StocksID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StocksTransactions", x => x.StocksTransactionID);
                    table.ForeignKey(
                        name: "FK_StocksTransactions_Stocks_StocksID",
                        column: x => x.StocksID,
                        principalTable: "Stocks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StocksTransactions_Traders_TraderID",
                        column: x => x.TraderID,
                        principalTable: "Traders",
                        principalColumn: "TraderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraderID = table.Column<int>(type: "int", nullable: false),
                    QuotationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transactions_Quotations_QuotationID",
                        column: x => x.QuotationID,
                        principalTable: "Quotations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Traders_TraderID",
                        column: x => x.TraderID,
                        principalTable: "Traders",
                        principalColumn: "TraderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CryptoTransactions",
                columns: table => new
                {
                    CryptoTransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraderID = table.Column<int>(type: "int", nullable: false),
                    CryptoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoTransactions", x => x.CryptoTransactionID);
                    table.ForeignKey(
                        name: "FK_CryptoTransactions_Cryptos_CryptoID",
                        column: x => x.CryptoID,
                        principalTable: "Cryptos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CryptoTransactions_Traders_TraderID",
                        column: x => x.TraderID,
                        principalTable: "Traders",
                        principalColumn: "TraderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cryptos_TraderID",
                table: "Cryptos",
                column: "TraderID");

            migrationBuilder.CreateIndex(
                name: "IX_CryptoTransactions_CryptoID",
                table: "CryptoTransactions",
                column: "CryptoID");

            migrationBuilder.CreateIndex(
                name: "IX_CryptoTransactions_TraderID",
                table: "CryptoTransactions",
                column: "TraderID");

            migrationBuilder.CreateIndex(
                name: "IX_StocksTransactions_StocksID",
                table: "StocksTransactions",
                column: "StocksID");

            migrationBuilder.CreateIndex(
                name: "IX_StocksTransactions_TraderID",
                table: "StocksTransactions",
                column: "TraderID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_QuotationID",
                table: "Transactions",
                column: "QuotationID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TraderID",
                table: "Transactions",
                column: "TraderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CryptoTransactions");

            migrationBuilder.DropTable(
                name: "StocksTransactions");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Cryptos");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Quotations");

            migrationBuilder.DropTable(
                name: "Traders");
        }
    }
}
