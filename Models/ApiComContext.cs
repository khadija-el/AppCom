using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FistApi.Models.seed;
using ApiCom.Models;

namespace ApiCom.Models
{
    public partial class ApiComContext : DbContext
    {
    //     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     var coonectionString = "data source=DESKTOP-JS5KSFO\\COMMERCIAL;database=FirstApp;user id=sa; password=mo@Git#13";
    //     optionsBuilder.UseSqlServer(coonectionString);
    // }
        public ApiComContext()
        {
            // dotnet tool install -g dotnet-aspnet-codegenerator
            // dotnet tool update -g dotnet-aspnet-codegenerator
            // dotnet aspnet-codegenerator --project . controller -name HelloController -m Author -dc WebAPIDataContext
            // dotnet tool install --global dotnet-ef --version 3.0.0
            // scafolding to db
            // dotnet ef migrations add secondMG
            // dotnet ef database update
            // dotnet ef migrations remove
            // dotnet ef database update LastGoodMigration
            // dotnet ef migrations script
        }

        public ApiComContext(DbContextOptions<ApiComContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<LivraisonClient> LivraisonClients { get; set; }
        public virtual DbSet<DetailLivraisonClient> DetailLivraisonClients { get; set; }
        public virtual DbSet<ReglementClient> ReglementClients { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Nom);
                entity.Property(e => e.Prenom);
                entity.Property(e => e.Email);
                entity.Property(e => e.Username);
                entity.Property(e => e.Password);
                entity.Property(e => e.Adresse);
              
            });     

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasIndex(e => e.Raisonsociale).IsUnique();
                entity.HasIndex(e => e.code).IsUnique();
                entity.Property(e => e.Telephone);
                entity.Property(e => e.Email);
                entity.Property(e => e.Fax);
                entity.Property(e => e.Adresse);
              
            }); 

             modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasIndex(e => e.Reference).IsUnique();
                entity.Property(e => e.Designation);
                entity.Property(e => e.Couleur);
                entity.Property(e => e.Largeur);
                entity.Property(e => e.Longeur);
                entity.Property(e => e.stockFinal);
                entity.Property(e => e.stockInitial);
                entity.Property(e => e.stockInitial);
                entity.Property(e => e.QteVendue);
                entity.Property(e => e.QteAcheté);
                entity.Property(e => e.stockMinimal);
                entity.Property(e => e.PrixAchat_HT);
                entity.Property(e => e.PrixAchat_TTC);
                entity.Property(e => e.PrixVente_HT);
                entity.Property(e => e.PrixVente_TTC);
                entity.Property(e => e.Info);
                
              
            }); 

            modelBuilder.Entity<LivraisonClient>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasIndex(e => e.Numero).IsUnique();
                entity.Property(e => e.date).IsRequired();
                entity.Property(e => e.Info);
                entity.Property(e => e.MontantHT).IsRequired();
                entity.Property(e => e.MontantTTC).IsRequired();
                entity.Property(e => e.TVA).IsRequired();
                entity.Property(e => e.Escompte).IsRequired();
                entity.Property(e => e.IdClient).IsRequired();
                entity.Property(e => e.IdUser).IsRequired();
                // entity.HasOne(d => d.Organisme).WithMany(p => p.User).HasForeignKey(d => d.IdOrganisme);
                entity.HasOne(d => d.Client).WithMany(p => p.LivrasoinClients).HasForeignKey(d => d.IdClient);
                entity.HasOne(d => d.User).WithMany(p => p.LivrasoinClients).HasForeignKey(d => d.IdUser);
                // entity.HasMany(d => d.Syntheses).WithOne(p => p.User).HasForeignKey(d => d.IdUser).OnDelete(DeleteBehavior.NoAction);
            });

          modelBuilder.Entity<DetailLivraisonClient>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Numero).IsRequired();
                entity.Property(e => e.Designation).IsRequired();
                entity.Property(e => e.Quantite);
                entity.Property(e => e.Prix);
                entity.Property(e => e.MontantHT).IsRequired();
                entity.Property(e => e.MontantTTC).IsRequired();
                entity.Property(e => e.IdLivraisonClient).IsRequired();
                entity.Property(e => e.IdArticle).IsRequired();
                // entity.HasOne(d => d.Organisme).WithMany(p => p.User).HasForeignKey(d => d.IdOrganisme);
                entity.HasOne(d => d.LivraisonClient).WithMany(p => p.DetailLivrasoinClients).HasForeignKey(d => d.IdLivraisonClient);
                entity.HasOne(d => d.Article).WithMany(p => p.DetailLivraisonClients).HasForeignKey(d => d.IdArticle);
                // entity.HasMany(d => d.Syntheses).WithOne(p => p.User).HasForeignKey(d => d.IdUser).OnDelete(DeleteBehavior.NoAction);
            });

           modelBuilder.Entity<ReglementClient>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Montant).IsRequired();
                entity.Property(e => e.D_Creation);
                entity.Property(e => e.IdLivraisonClient);
                entity.HasOne(d => d.LivraisonClient).WithMany(p => p.ReglementClient).HasForeignKey(d => d.IdLivraisonClient);
                
              
            }); 
            OnModelCreatingPartial(modelBuilder);

            modelBuilder
                .Profils()
               
             ;

            // Database.ExecuteSqlRaw("update recommendations set etat = 'Réalisé', EtatAvancementChiffre = 100 where id % 3 = 0;");
            // Database.ExecuteSqlRaw("update recommendations set etat = 'En cours', EtatAvancementChiffre = 50 where id % 3 = 1;");
            // Database.ExecuteSqlRaw("update recommendations set etat = 'Non réalisé', EtatAvancementChiffre = 0 where id % 3 = 2;");

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
