using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskWebApi.Migrations
{
    /// <inheritdoc />
    public partial class finalDb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblOrderDetails_tblOrderMaster_OrderId",
                table: "tblOrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblOrderMaster",
                table: "tblOrderMaster");

            migrationBuilder.RenameTable(
                name: "tblOrderMaster",
                newName: "tblOrderMasters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblOrderMasters",
                table: "tblOrderMasters",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblOrderDetails_tblOrderMasters_OrderId",
                table: "tblOrderDetails",
                column: "OrderId",
                principalTable: "tblOrderMasters",
                principalColumn: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblOrderDetails_tblOrderMasters_OrderId",
                table: "tblOrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblOrderMasters",
                table: "tblOrderMasters");

            migrationBuilder.RenameTable(
                name: "tblOrderMasters",
                newName: "tblOrderMaster");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblOrderMaster",
                table: "tblOrderMaster",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblOrderDetails_tblOrderMaster_OrderId",
                table: "tblOrderDetails",
                column: "OrderId",
                principalTable: "tblOrderMaster",
                principalColumn: "OrderId");
        }
    }
}
