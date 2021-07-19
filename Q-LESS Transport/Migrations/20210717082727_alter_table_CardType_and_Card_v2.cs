using Microsoft.EntityFrameworkCore.Migrations;

namespace Q_LESS_Transport.Migrations
{
    public partial class alter_table_CardType_and_Card_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_CardTypes_CardTypeId",
                table: "Cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardTypes",
                table: "CardTypes");

            migrationBuilder.RenameTable(
                name: "CardTypes",
                newName: "CardTypeDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardTypeDetails",
                table: "CardTypeDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_CardTypeDetails_CardTypeId",
                table: "Cards",
                column: "CardTypeId",
                principalTable: "CardTypeDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_CardTypeDetails_CardTypeId",
                table: "Cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardTypeDetails",
                table: "CardTypeDetails");

            migrationBuilder.RenameTable(
                name: "CardTypeDetails",
                newName: "CardTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardTypes",
                table: "CardTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_CardTypes_CardTypeId",
                table: "Cards",
                column: "CardTypeId",
                principalTable: "CardTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
