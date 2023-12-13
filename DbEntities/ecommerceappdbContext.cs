using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EcommerceTickets.DbEntities
{
    public partial class ecommerceappdbContext : DbContext
    {
        public ecommerceappdbContext()
        {
        }

        public ecommerceappdbContext(DbContextOptions<ecommerceappdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; } = null!;
        public virtual DbSet<ActorMovie> ActorMovies { get; set; } = null!;
        public virtual DbSet<Cinema> Cinemas { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<Producer> Producers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=[your machine name];Database=[your database name];Trusted_Connection=True; User Id=[your User Id]; password=[your passwors]; Integrated security=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("Actor");

                entity.Property(e => e.ActorBio).HasMaxLength(50);

                entity.Property(e => e.ActorFullName).HasMaxLength(50);

                entity.Property(e => e.ProfilePictureUrl)
                    .HasMaxLength(50)
                    .HasColumnName("ProfilePictureURL");
            });

            modelBuilder.Entity<ActorMovie>(entity =>
            {
                entity.ToTable("Actor_Movie");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.ActorMovies)
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("FK_Actor_Movie_Actor");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.ActorMovies)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_Actor_Movie_Movie");
            });

            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.ToTable("Cinema");

                entity.Property(e => e.CinemaName).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Logo).HasMaxLength(50);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(50)
                    .HasColumnName("ImageURL");

                entity.Property(e => e.MovieName).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Cinema)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.CinemaId)
                    .HasConstraintName("FK_Movie_Cinema");

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.ProducerId)
                    .HasConstraintName("FK_Movie_Producer");
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.ToTable("Producer");

                entity.Property(e => e.ProducerBio).HasMaxLength(50);

                entity.Property(e => e.ProducerFullName).HasMaxLength(50);

                entity.Property(e => e.ProfilePictureUrl)
                    .HasMaxLength(50)
                    .HasColumnName("ProfilePictureURL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
