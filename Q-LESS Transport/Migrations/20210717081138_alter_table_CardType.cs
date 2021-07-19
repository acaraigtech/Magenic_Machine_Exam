using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Q_LESS_Transport.Migrations
{
    public partial class alter_table_CardType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardTypes_FareAmounts_FareAmountId",
                table: "CardTypes");

            migrationBuilder.DropTable(
                name: "FareAmounts");

            migrationBuilder.DropIndex(
                name: "IX_CardTypes_FareAmountId",
                table: "CardTypes");

            migrationBuilder.DropColumn(
                name: "FareAmountId",
                table: "CardTypes");

            migrationBuilder.RenameColumn(
                name: "Validity",
                table: "Cards",
                newName: "ValidityDate");

            migrationBuilder.AddColumn<double>(
                name: "FareAmount",
                table: "CardTypes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Validity",
                table: "CardTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FareAmount",
                table: "CardTypes");

            migrationBuilder.DropColumn(
                name: "Validity",
                table: "CardTypes");

            migrationBuilder.RenameColumn(
                name: "ValidityDate",
                table: "Cards",
                newName: "Validity");

            migrationBuilder.AddColumn<Guid>(
                name: "FareAmountId",
                table: "CardTypes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "FareAmounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FareAmounts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardTypes_FareAmountId",
                table: "CardTypes",
                column: "FareAmountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CardTypes_FareAmounts_FareAmountId",
                table: "CardTypes",
                column: "FareAmountId",
                principalTable: "FareAmounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
