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
           // modelBuilder.Entity<Article>()
           // .HasOne(Article => Article.BE)
           // .WithMany(BE => BE.Articles)
                // .HasForeignKey("EquipeFK")
           // .OnDelete(DeleteBehavior.Cascade);


         /*   modelBuilder.Entity<BE>()
    .HasMany(be => be.Articles)
    .WithOne(article => article.BE)
        .IsRequired()
        .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);*/



            modelBuilder.Entity<Article>()
                      .HasOne(e => e.BE)
                       .WithMany(c => c.Articles)
                       .HasForeignKey(c => c.Fk_BE);



           
        }




    }
}
