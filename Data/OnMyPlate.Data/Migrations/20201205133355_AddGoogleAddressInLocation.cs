using Microsoft.EntityFrameworkCore.Migrations;

namespace OnMyPlate.Data.Migrations
{
    public partial class AddGoogleAddressInLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Places_PlaceId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Street_StreetId",
                table: "Address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Street",
                table: "Street");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Street",
                newName: "Streets");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_Street_IsDeleted",
                table: "Streets",
                newName: "IX_Streets_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Address_StreetId",
                table: "Addresses",
                newName: "IX_Addresses_StreetId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_PlaceId",
                table: "Addresses",
                newName: "IX_Addresses_PlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_IsDeleted",
                table: "Addresses",
                newName: "IX_Addresses_IsDeleted");

            migrationBuilder.AddColumn<string>(
                name: "GoogleAddress",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Streets",
                table: "Streets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Places_PlaceId",
                table: "Addresses",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Streets_StreetId",
                table: "Addresses",
                column: "StreetId",
                principalTable: "Streets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Places_PlaceId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Streets_StreetId",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Streets",
                table: "Streets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "GoogleAddress",
                table: "Locations");

            migrationBuilder.RenameTable(
                name: "Streets",
                newName: "Street");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Streets_IsDeleted",
                table: "Street",
                newName: "IX_Street_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_StreetId",
                table: "Address",
                newName: "IX_Address_StreetId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_PlaceId",
                table: "Address",
                newName: "IX_Address_PlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_IsDeleted",
                table: "Address",
                newName: "IX_Address_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Street",
                table: "Street",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Places_PlaceId",
                table: "Address",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Street_StreetId",
                table: "Address",
                column: "StreetId",
                principalTable: "Street",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
