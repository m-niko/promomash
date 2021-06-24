using Microsoft.EntityFrameworkCore.Migrations;

namespace Promomash.WebApp.Infrastructure.Migrations
{
    public partial class RenameLocationToProvince : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Provinces_LocationId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "AspNetUsers",
                newName: "ProvinceId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_LocationId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Provinces_ProvinceId",
                table: "AspNetUsers",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Provinces_ProvinceId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ProvinceId",
                table: "AspNetUsers",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_ProvinceId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Provinces_LocationId",
                table: "AspNetUsers",
                column: "LocationId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
