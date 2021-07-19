using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Q_LESS_Transport.Migrations
{
    public partial class alter_Relationship_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardTypeDetails_Cards_CardId",
                table: "CardTypeDetails");

            migrationBuilder.DropIndex(
                name: "IX_CardTypeDetails_CardId",
                table: "CardTypeDetails");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "CardTypeDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "CardTypeDetailsId",
                table: "Cards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CardTypeDetailsId",
                table: "Cards",
                column: "CardTypeDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_CardTypeDetails_CardTypeDetailsId",
                table: "Cards",
                column: "CardTypeDetailsId",
                principalTable: "CardTypeDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_CardTypeDetails_CardTypeDetailsId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_CardTypeDetailsId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardTypeDetailsId",
                table: "Cards");

            migrationBuilder.AddColumn<Guid>(
                name: "CardId",
                table: "CardTypeDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CardTypeDetails_CardId",
                table: "CardTypeDetails",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardTypeDetails_Cards_CardId",
                table: "CardTypeDetails",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
