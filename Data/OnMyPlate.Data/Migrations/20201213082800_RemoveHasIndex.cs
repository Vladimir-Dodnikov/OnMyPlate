using Microsoft.EntityFrameworkCore.Migrations;

namespace OnMyPlate.Data.Migrations
{
    public partial class RemoveHasIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTime_Places_PlaceId",
                table: "WorkTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkTime",
                table: "WorkTime");

            migrationBuilder.RenameTable(
                name: "WorkTime",
                newName: "WorkTimes");

            migrationBuilder.RenameIndex(
                name: "IX_WorkTime_PlaceId",
                table: "WorkTimes",
                newName: "IX_WorkTimes_PlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkTime_IsDeleted",
                table: "WorkTimes",
                newName: "IX_WorkTimes_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkTimes",
                table: "WorkTimes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTimes_Places_PlaceId",
                table: "WorkTimes",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTimes_Places_PlaceId",
                table: "WorkTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkTimes",
                table: "WorkTimes");

            migrationBuilder.RenameTable(
                name: "WorkTimes",
                newName: "WorkTime");

            migrationBuilder.RenameIndex(
                name: "IX_WorkTimes_PlaceId",
                table: "WorkTime",
                newName: "IX_WorkTime_PlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkTimes_IsDeleted",
                table: "WorkTime",
                newName: "IX_WorkTime_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkTime",
                table: "WorkTime",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTime_Places_PlaceId",
                table: "WorkTime",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
