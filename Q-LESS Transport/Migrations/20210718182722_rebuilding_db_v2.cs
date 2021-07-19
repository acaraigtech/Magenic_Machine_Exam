using Microsoft.EntityFrameworkCore.Migrations;

namespace Q_LESS_Transport.Migrations
{
    public partial class rebuilding_db_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_transactionTypes_TransactionCode",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transactionTypes",
                table: "transactionTypes");

            migrationBuilder.RenameTable(
                name: "transactionTypes",
                newName: "TransactionTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionTypes",
                table: "TransactionTypes",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionTypes_TransactionCode",
                table: "Transactions",
                column: "TransactionCode",
                principalTable: "TransactionTypes",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionTypes_TransactionCode",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionTypes",
                table: "TransactionTypes");

            migrationBuilder.RenameTable(
                name: "TransactionTypes",
                newName: "transactionTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transactionTypes",
                table: "transactionTypes",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_transactionTypes_TransactionCode",
                table: "Transactions",
                column: "TransactionCode",
                principalTable: "transactionTypes",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
