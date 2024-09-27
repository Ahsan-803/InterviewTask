using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addtableandsetrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblOrderMaster",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    OrderedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderedAmount = table.Column<float>(type: "real", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditBy = table.Column<int>(type: "int", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrderMaster", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "tblOrderDetails",
                columns: table => new
                {
                    OrderedDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<float>(type: "real", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditBy = table.Column<int>(type: "int", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrderDetails", x => x.OrderedDetailsId);
                    table.ForeignKey(
                        name: "FK_tblOrderDetails_tblItems_ItemId",
                        column: x => x.ItemId,
                        principalTable: "tblItems",
                        principalColumn: "ItemId");
                    table.ForeignKey(
                        name: "FK_tblOrderDetails_tblOrderMaster_OrderId",
                        column: x => x.OrderId,
                        principalTable: "tblOrderMaster",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderDetails_ItemId",
                table: "tblOrderDetails",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderDetails_OrderId",
                table: "tblOrderDetails",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblOrderDetails");

            migrationBuilder.DropTable(
                name: "tblOrderMaster");
        }
    }
}
