using BL.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Article = BL.Domain.Models.Article;

namespace BL.Data.Context
{
    public class BLContext : DbContext
    {
        public BLContext(DbContextOptions<BLContext> options)
            : base(options)
        { }


        public DbSet<BE> BEs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<BLs> BLs { get; set; }
        public DbSet<Vehicule> Vehicules { get; set; }

        public DbSet<Chauffeur> Chauffeurs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BE>().HasKey(sc => new { sc.BEId });
            modelBuilder.Entity<Client>().HasKey(sc => new { sc.ClientId });
            modelBuilder.Entity<BLs>().HasKey(sc => new { sc.BLId });
            modelBuilder.Entity<Article>().HasKey(sc => new { sc.ArticleId });
            modelBuilder.Entity<Vehicule>().HasKey(sc => new { sc.VehiculeId });
            modelBuilder.Entity<Chauffeur>().HasKey(sc => new { sc.ChauffeurId });







            modelBuilder.Entity<BE>()
               .HasOne(BE => BE.Client)
               .WithMany(Client => Client.BEs)
               .HasForeignKey("ClientId")
               .OnDelete(DeleteBehavior.Cascade);

          

           modelBuilder.Entity<Article>()
                .HasOne(Article => Article.BE)
                .WithMany(BE => BE.Articles)
                .HasForeignKey("BEId")
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<BE>()
             .HasOne<BLs>(s => s.Bl)
             .WithOne(ad => ad.BE)
             .HasForeignKey<BLs>(ad => ad.BLId);

          


        }




    }
}
