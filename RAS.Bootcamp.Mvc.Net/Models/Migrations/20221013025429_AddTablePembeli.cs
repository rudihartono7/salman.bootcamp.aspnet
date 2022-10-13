using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RAS.Bootcamp.Mvc.Net.Models.Migrations
{
    public partial class AddTablePembeli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Barang_Penjuals_IdPenjual",
                table: "Barang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Barang",
                table: "Barang");

            migrationBuilder.RenameTable(
                name: "Barang",
                newName: "Barangs");

            migrationBuilder.RenameIndex(
                name: "IX_Barang_IdPenjual",
                table: "Barangs",
                newName: "IX_Barangs_IdPenjual");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Barangs",
                table: "Barangs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Pembelies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUser = table.Column<int>(type: "integer", nullable: false),
                    Alamat = table.Column<string>(type: "text", nullable: false),
                    NoHp = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pembelies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pembelies_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pembelies_IdUser",
                table: "Pembelies",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Barangs_Penjuals_IdPenjual",
                table: "Barangs",
                column: "IdPenjual",
                principalTable: "Penjuals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Barangs_Penjuals_IdPenjual",
                table: "Barangs");

            migrationBuilder.DropTable(
                name: "Pembelies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Barangs",
                table: "Barangs");

            migrationBuilder.RenameTable(
                name: "Barangs",
                newName: "Barang");

            migrationBuilder.RenameIndex(
                name: "IX_Barangs_IdPenjual",
                table: "Barang",
                newName: "IX_Barang_IdPenjual");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Barang",
                table: "Barang",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Barang_Penjuals_IdPenjual",
                table: "Barang",
                column: "IdPenjual",
                principalTable: "Penjuals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
