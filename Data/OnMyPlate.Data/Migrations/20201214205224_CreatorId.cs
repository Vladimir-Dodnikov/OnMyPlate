using Microsoft.EntityFrameworkCore.Migrations;

namespace OnMyPlate.Data.Migrations
{
    public partial class CreatorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Places",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Places_CreatedByUserId",
                table: "Places",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_AspNetUsers_CreatedByUserId",
                table: "Places",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_AspNetUsers_CreatedByUserId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_CreatedByUserId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Places");
        }
    }
}
