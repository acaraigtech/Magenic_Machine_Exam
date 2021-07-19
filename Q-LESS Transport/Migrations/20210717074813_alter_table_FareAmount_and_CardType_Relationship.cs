using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Q_LESS_Transport.Migrations
{
    public partial class alter_table_FareAmount_and_CardType_Relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_FareAmounts_FareAmountId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_FareAmountId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "FareAmountId",
                table: "Cards");

            migrationBuilder.AddColumn<Guid>(
                name: "FareAmountId",
                table: "CardTypes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardTypes_FareAmounts_FareAmountId",
                table: "CardTypes");

            migrationBuilder.DropIndex(
                name: "IX_CardTypes_FareAmountId",
                table: "CardTypes");

            migrationBuilder.DropColumn(
                name: "FareAmountId",
                table: "CardTypes");

            migrationBuilder.AddColumn<Guid>(
                name: "FareAmountId",
                table: "Cards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Cards_FareAmountId",
                table: "Cards",
                column: "FareAmountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_FareAmounts_FareAmountId",
                table: "Cards",
                column: "FareAmountId",
                principalTable: "FareAmounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
