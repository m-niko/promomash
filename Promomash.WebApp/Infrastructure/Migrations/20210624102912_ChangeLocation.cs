using Microsoft.EntityFrameworkCore.Migrations;

namespace Promomash.WebApp.Infrastructure.Migrations
{
    public partial class ChangeLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Province_Countries_CountryId",
                table: "Province");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Province",
                table: "Province");

            migrationBuilder.DropColumn(
                name: "Location_CountryId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Province",
                newName: "Provinces");

            migrationBuilder.RenameColumn(
                name: "Location_ProvinceId",
                table: "AspNetUsers",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Province_CountryId",
                table: "Provinces",
                newName: "IX_Provinces_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provinces",
                table: "Provinces",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LocationId",
                table: "AspNetUsers",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Provinces_LocationId",
                table: "AspNetUsers",
                column: "LocationId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Provinces_Countries_CountryId",
                table: "Provinces",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Provinces_LocationId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Provinces_Countries_CountryId",
                table: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LocationId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Provinces",
                table: "Provinces");

            migrationBuilder.RenameTable(
                name: "Provinces",
                newName: "Province");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "AspNetUsers",
                newName: "Location_ProvinceId");

            migrationBuilder.RenameIndex(
                name: "IX_Provinces_CountryId",
                table: "Province",
                newName: "IX_Province_CountryId");

            migrationBuilder.AddColumn<int>(
                name: "Location_CountryId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Province",
                table: "Province",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Province_Countries_CountryId",
                table: "Province",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
