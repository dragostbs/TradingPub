using Microsoft.EntityFrameworkCore.Migrations;

namespace TradingPub.Migrations
{
    public partial class NewData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ForexAmount",
                table: "Transactions",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "ForexResult",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "StockAmount",
                table: "StocksTransactions",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "StockResult",
                table: "StocksTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "CryptoAmount",
                table: "CryptoTransactions",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "CryptoResult",
                table: "CryptoTransactions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForexAmount",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ForexResult",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "StockAmount",
                table: "StocksTransactions");

            migrationBuilder.DropColumn(
                name: "StockResult",
                table: "StocksTransactions");

            migrationBuilder.DropColumn(
                name: "CryptoAmount",
                table: "CryptoTransactions");

            migrationBuilder.DropColumn(
                name: "CryptoResult",
                table: "CryptoTransactions");
        }
    }
}
