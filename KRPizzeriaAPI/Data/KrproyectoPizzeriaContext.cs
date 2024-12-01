﻿using System;
using System.Collections.Generic;
using KRPizzeriaAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KRPizzeriaAPI.Data;

public partial class KrproyectoPizzeriaContext : DbContext
{
    public KrproyectoPizzeriaContext()
    {
    }

    public KrproyectoPizzeriaContext(DbContextOptions<KrproyectoPizzeriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Krpizzerium> Krpizzeria { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KRProyectoPizzeria");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Krpizzerium>(entity =>
        {
            entity.HasKey(e => e.IdKrpizzeria);

            entity.ToTable("KRPizzeria");

            entity.Property(e => e.IdKrpizzeria).HasColumnName("idKRPizzeria");
            entity.Property(e => e.KrName).HasColumnName("KR_Name");
            entity.Property(e => e.KrPrecio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("KR_Precio");
            entity.Property(e => e.KrWithCocaCola).HasColumnName("KR_WithCocaCola");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}