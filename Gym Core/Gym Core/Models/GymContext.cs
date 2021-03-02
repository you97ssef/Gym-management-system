using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Gym_Core.Models
{
    public partial class GymContext : DbContext
    {
        public GymContext()
        {
        }

        public GymContext(DbContextOptions<GymContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Groupe> Groupes { get; set; }
        public virtual DbSet<Membre> Membres { get; set; }
        public virtual DbSet<Payement> Payements { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Groupe>(entity =>
            {
                entity.ToTable("groupes");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DescriptionGroupe)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("description_groupe");

                entity.Property(e => e.NomGroupe)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nom_groupe");
            });

            modelBuilder.Entity<Membre>(entity =>
            {
                entity.ToTable("membres");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ContactMembre)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("contact_membre");

                entity.Property(e => e.DatejointureMembre)
                    .HasColumnType("date")
                    .HasColumnName("datejointure_membre");

                entity.Property(e => e.DatenaissanceMembre)
                    .HasColumnType("date")
                    .HasColumnName("datenaissance_membre");

                entity.Property(e => e.Groupe).HasColumnName("groupe");

                entity.Property(e => e.NomMembre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nom_membre");

                entity.Property(e => e.PrenomMembre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("prenom_membre");

                entity.HasOne(d => d.GroupeNavigation)
                    .WithMany(p => p.Membres)
                    .HasForeignKey(d => d.Groupe)
                    .HasConstraintName("FK__membres__groupe__1273C1CD");
            });

            modelBuilder.Entity<Payement>(entity =>
            {
                entity.ToTable("payements");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DatePayement)
                    .HasColumnType("date")
                    .HasColumnName("date_payement");

                entity.Property(e => e.DescriptionPayement)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("description_payement");

                entity.Property(e => e.Membre).HasColumnName("membre");

                entity.Property(e => e.MontantPayement)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("montant_payement");

                entity.HasOne(d => d.MembreNavigation)
                    .WithMany(p => p.Payements)
                    .HasForeignKey(d => d.Membre)
                    .HasConstraintName("FK__payements__membr__164452B1");
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasKey(e => e.NomUtilisateur)
                    .HasName("PK__utilisat__8EE745751416DF0C");

                entity.ToTable("utilisateurs");

                entity.Property(e => e.NomUtilisateur)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nom_utilisateur");

                entity.Property(e => e.MotdepasseUtilisateur)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("motdepasse_utilisateur");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
