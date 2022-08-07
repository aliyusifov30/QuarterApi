using Microsoft.EntityFrameworkCore.Migrations;

namespace QuarterApp.Data.Migrations
{
    public partial class PosterImageAddedToProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PosterImage",
                table: "Properties",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosterImage",
                table: "Properties");
        }
    }
}
