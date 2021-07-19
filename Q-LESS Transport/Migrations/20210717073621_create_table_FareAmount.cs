using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Q_LESS_Transport.Migrations
{
    public partial class create_table_FareAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FareAmountId",
                table: "Cards",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_FareAmounts_FareAmountId",
                table: "Cards");

            migrationBuilder.DropTable(
                name: "FareAmounts");

            migrationBuilder.DropIndex(
                name: "IX_Cards_FareAmountId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "FareAmountId",
                table: "Cards");
        }
    }
}
