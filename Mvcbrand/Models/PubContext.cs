﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mvcbrand.Models;

public partial class PubContext : DbContext
{
    public PubContext()
    {
    }

    public PubContext(DbContextOptions<PubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beer> Beers { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BRAYAN\\SQLEXPRESS; Database=Pub; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beer>(entity =>
        {
            entity.ToTable("Beer");

            entity.Property(e => e.BeerId).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.BrandId).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Brand).WithMany(p => p.Beers)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK_Beer_Brand");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.ToTable("Brand");

            entity.Property(e => e.BrandId).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
