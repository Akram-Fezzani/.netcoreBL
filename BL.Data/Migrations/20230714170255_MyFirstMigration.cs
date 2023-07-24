using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Data.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    Telephone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "BEs",
                columns: table => new
                {
                    BEId = table.Column<Guid>(nullable: false),
                    NumBE = table.Column<int>(nullable: false),
                    DateBe = table.Column<DateTime>(nullable: false),
                    Chauffeur = table.Column<string>(nullable: true),
                    MatriculeVehicule = table.Column<string>(nullable: true),
                    TypeBE = table.Column<string>(nullable: true),
                    NumPlombage = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BEs", x => x.BEId);
                    table.ForeignKey(
                        name: "FK_BEs_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(nullable: false),
                    HSC = table.Column<int>(nullable: false),
                    CodeGb = table.Column<int>(nullable: false),
                    CodeELV = table.Column<int>(nullable: false),
                    LibArticle = table.Column<string>(nullable: true),
                    BEId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleId);
                    table.ForeignKey(
                        name: "FK_Articles_BEs_BEId",
                        column: x => x.BEId,
                        principalTable: "BEs",
                        principalColumn: "BEId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BLs",
                columns: table => new
                {
                    BLId = table.Column<Guid>(nullable: false),
                    NumBL = table.Column<int>(nullable: false),
                    NumBE = table.Column<int>(nullable: false),
                    DateBE = table.Column<DateTime>(nullable: false),
                    Chauffeur = table.Column<string>(nullable: true),
                    NumPlombage = table.Column<string>(nullable: true),
                    TypeBL = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    DateLivraison = table.Column<DateTime>(nullable: false),
                    BEId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BLs", x => x.BLId);
                    table.ForeignKey(
                        name: "FK_BLs_BEs_BLId",
                        column: x => x.BLId,
                        principalTable: "BEs",
                        principalColumn: "BEId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_BEId",
                table: "Articles",
                column: "BEId");

            migrationBuilder.CreateIndex(
                name: "IX_BEs_ClientId",
                table: "BEs",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "BLs");

            migrationBuilder.DropTable(
                name: "BEs");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
