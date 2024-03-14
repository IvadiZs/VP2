using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Ivadi_Zs_Beckend_ES.Models;

public partial class EuroskillsContext : DbContext
{
    public EuroskillsContext()
    {
    }

    public EuroskillsContext(DbContextOptions<EuroskillsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Orszag> Orszags { get; set; }

    public virtual DbSet<Szakma> Szakmas { get; set; }

    public virtual DbSet<Versenyzo> Versenyzos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=euroskills;user=root;ssl mode=none", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Orszag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orszag");

            entity.Property(e => e.Id)
                .HasMaxLength(2)
                .HasColumnName("id");
            entity.Property(e => e.OrszagNev)
                .HasMaxLength(31)
                .HasColumnName("orszagNev");
        });

        modelBuilder.Entity<Szakma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("szakma");

            entity.Property(e => e.Id)
                .HasMaxLength(2)
                .HasColumnName("id");
            entity.Property(e => e.SzakmaNev)
                .HasMaxLength(31)
                .HasColumnName("szakmaNev");
        });

        modelBuilder.Entity<Versenyzo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("versenyzo");

            entity.HasIndex(e => e.OrszagId, "orszagId");

            entity.HasIndex(e => e.SzakmaId, "szakmaId");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nev)
                .HasMaxLength(31)
                .HasColumnName("nev");
            entity.Property(e => e.OrszagId)
                .HasMaxLength(2)
                .HasColumnName("orszagId");
            entity.Property(e => e.Pont)
                .HasColumnType("int(11)")
                .HasColumnName("pont");
            entity.Property(e => e.SzakmaId)
                .HasMaxLength(2)
                .HasColumnName("szakmaId");

            entity.HasOne(d => d.Orszag).WithMany(p => p.Versenyzos)
                .HasForeignKey(d => d.OrszagId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("versenyzo_ibfk_2");

            entity.HasOne(d => d.Szakma).WithMany(p => p.Versenyzos)
                .HasForeignKey(d => d.SzakmaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("versenyzo_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
