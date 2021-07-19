using Microsoft.EntityFrameworkCore.Migrations;

namespace Q_LESS_Transport.Migrations
{
    public partial class alter_DiscountCard_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "DiscountCards");

            migrationBuilder.AddColumn<bool>(
                name: "IsSenior",
                table: "DiscountCards",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSenior",
                table: "DiscountCards");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DiscountCards",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
