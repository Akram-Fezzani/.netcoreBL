using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Data.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chauffeurs",
                columns: table => new
                {
                    ChauffeurId = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    Telephone = table.Column<int>(nullable: false),
                    State = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chauffeurs", x => x.ChauffeurId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicules",
                columns: table => new
                {
                    VehiculeId = table.Column<Guid>(nullable: false),
                    Matricule = table.Column<string>(nullable: true),
                    Proprietaire = table.Column<Guid>(nullable: false),
                    capacite = table.Column<int>(nullable: false),
                    State = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicules", x => x.VehiculeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chauffeurs");

            migrationBuilder.DropTable(
                name: "Vehicules");
        }
    }
}
