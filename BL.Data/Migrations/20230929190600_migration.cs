using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Data.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BLs",
                columns: table => new
                {
                    BLsId = table.Column<Guid>(nullable: false),
                    NumBL = table.Column<int>(nullable: false),
                    NumBE = table.Column<int>(nullable: false),
                    DateBE = table.Column<DateTime>(nullable: false),
                    Chauffeur = table.Column<string>(nullable: true),
                    NumPlombage = table.Column<string>(nullable: true),
                    TypeBL = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    DateLivraison = table.Column<DateTime>(nullable: false),
                    BEId = table.Column<Guid>(nullable: false),
                    CenterId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BLs", x => x.BLsId);
                });

            migrationBuilder.CreateTable(
                name: "Chauffeurs",
                columns: table => new
                {
                    ChauffeurId = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    Telephone = table.Column<int>(nullable: false),
                    State = table.Column<bool>(nullable: false),
                    BEId = table.Column<Guid>(nullable: false),
                    SocieteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chauffeurs", x => x.ChauffeurId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    Telephone = table.Column<int>(nullable: false),
                    CommandNbr = table.Column<int>(nullable: false),
                    SocieteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicules",
                columns: table => new
                {
                    VehiculeId = table.Column<Guid>(nullable: false),
                    Matricule = table.Column<string>(nullable: true),
                    Proprietaire = table.Column<Guid>(nullable: false),
                    capacite = table.Column<int>(nullable: false),
                    State = table.Column<bool>(nullable: false),
                    SocieteId = table.Column<Guid>(nullable: false),
                    BEId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicules", x => x.VehiculeId);
                });

            migrationBuilder.CreateTable(
                name: "BEs",
                columns: table => new
                {
                    BEId = table.Column<Guid>(nullable: false),
                    NumBE = table.Column<int>(nullable: false),
                    DateBe = table.Column<DateTime>(nullable: false),
                    MatriculeVehicule = table.Column<string>(nullable: true),
                    TypeBE = table.Column<string>(nullable: true),
                    NumPlombage = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    BlId = table.Column<Guid>(nullable: false),
                    VehiculeId = table.Column<Guid>(nullable: false),
                    ChauffeurId = table.Column<Guid>(nullable: false),
                    CenterId = table.Column<Guid>(nullable: false)
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
                    Fk_BE = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleId);
                    table.ForeignKey(
                        name: "FK_Articles_BEs_Fk_BE",
                        column: x => x.Fk_BE,
                        principalTable: "BEs",
                        principalColumn: "BEId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Fk_BE",
                table: "Articles",
                column: "Fk_BE");

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
                name: "Chauffeurs");

            migrationBuilder.DropTable(
                name: "Vehicules");

            migrationBuilder.DropTable(
                name: "BEs");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
