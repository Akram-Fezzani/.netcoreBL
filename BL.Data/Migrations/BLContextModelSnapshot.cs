﻿// <auto-generated />
using System;
using BL.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BL.Data.Migrations
{
    [DbContext(typeof(BLContext))]
    partial class BLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BL.Domain.Models.Article", b =>
                {
                    b.Property<Guid>("ArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BEId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BeFK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CodeELV")
                        .HasColumnType("int");

                    b.Property<int>("CodeGb")
                        .HasColumnType("int");

                    b.Property<int>("HSC")
                        .HasColumnType("int");

                    b.Property<string>("LibArticle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArticleId");

                    b.HasIndex("BEId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("BL.Domain.Models.BE", b =>
                {
                    b.Property<Guid>("BEId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BlId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CenterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChauffeurId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateBe")
                        .HasColumnType("datetime2");

                    b.Property<string>("MatriculeVehicule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumBE")
                        .HasColumnType("int");

                    b.Property<int>("NumPlombage")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TypeBE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VehiculeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BEId");

                    b.HasIndex("ClientId");

                    b.ToTable("BEs");
                });

            modelBuilder.Entity("BL.Domain.Models.BLs", b =>
                {
                    b.Property<Guid>("BLsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BEId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CenterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Chauffeur")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateBE")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateLivraison")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumBE")
                        .HasColumnType("int");

                    b.Property<int>("NumBL")
                        .HasColumnType("int");

                    b.Property<string>("NumPlombage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TypeBL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BLsId");

                    b.ToTable("BLs");
                });

            modelBuilder.Entity("BL.Domain.Models.Chauffeur", b =>
                {
                    b.Property<Guid>("ChauffeurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BEId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SocieteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<int>("Telephone")
                        .HasColumnType("int");

                    b.HasKey("ChauffeurId");

                    b.ToTable("Chauffeurs");
                });

            modelBuilder.Entity("BL.Domain.Models.Client", b =>
                {
                    b.Property<Guid>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CommandNbr")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SocieteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Telephone")
                        .HasColumnType("int");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BL.Domain.Models.Vehicule", b =>
                {
                    b.Property<Guid>("VehiculeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BEId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Matricule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Proprietaire")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SocieteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<int>("capacite")
                        .HasColumnType("int");

                    b.HasKey("VehiculeId");

                    b.ToTable("Vehicules");
                });

            modelBuilder.Entity("BL.Domain.Models.Article", b =>
                {
                    b.HasOne("BL.Domain.Models.BE", "BE")
                        .WithMany("Articles")
                        .HasForeignKey("BEId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("BL.Domain.Models.BE", b =>
                {
                    b.HasOne("BL.Domain.Models.Client", null)
                        .WithMany("BEs")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
