using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JobLinq.Web.Models;

public partial class DbjoblinqContext : DbContext
{
    public DbjoblinqContext()
    {
    }

    public DbjoblinqContext(DbContextOptions<DbjoblinqContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DatIlan> DatIlans { get; set; }

    public virtual DbSet<DatOzluk> DatOzluks { get; set; }

    public virtual DbSet<DatSirket> DatSirkets { get; set; }

    public virtual DbSet<DatUser> DatUsers { get; set; }

    public virtual DbSet<JnkBasvuru> JnkBasvurus { get; set; }

    public virtual DbSet<Junction> Junctions { get; set; }

    public virtual DbSet<PrmHesapTipi> PrmHesapTipis { get; set; }

    public virtual DbSet<PrmSehir> PrmSehirs { get; set; }

    public virtual DbSet<PrmSektorBilgisi> PrmSektorBilgisis { get; set; }

    public virtual DbSet<TblDatUser> TblDatUsers { get; set; }

    public virtual DbSet<TblOzlukBilgisi> TblOzlukBilgisis { get; set; }

    public virtual DbSet<TblSirketBilgisi> TblSirketBilgisis { get; set; }

    public virtual DbSet<Tblilan> Tblilans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DBJoblinq;Trusted_Connection=True;");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DatIlan>(entity =>
        {
            entity.HasKey(e => e.IlanId);

            entity.ToTable("datIlan");

            entity.Property(e => e.IlanId).HasColumnName("IlanID");
            entity.Property(e => e.IlanBaslik).HasMaxLength(50);
            entity.Property(e => e.IsTip)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SehirId).HasColumnName("SehirID");
            entity.Property(e => e.SirketId).HasColumnName("SirketID");

            entity.HasOne(d => d.Sehir).WithMany(p => p.DatIlans)
                .HasForeignKey(d => d.SehirId)
                .HasConstraintName("FK_datIlan_prmSehir");

            entity.HasOne(d => d.Sirket).WithMany(p => p.DatIlans)
                .HasForeignKey(d => d.SirketId)
                .HasConstraintName("FK_datIlan_datSirket");
        });

        modelBuilder.Entity<DatOzluk>(entity =>
        {
            entity.HasKey(e => e.OzlukId);

            entity.ToTable("datOzluk");

            entity.Property(e => e.OzlukId).HasColumnName("OzlukID");
            entity.Property(e => e.DoğumTarihi)
                .HasMaxLength(8)
                .IsFixedLength();
            entity.Property(e => e.Gsmno)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("GSMNo");
            entity.Property(e => e.SehirId).HasColumnName("SehirID");
            entity.Property(e => e.UserAd).HasMaxLength(20);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserSoyad).HasMaxLength(20);

            entity.HasOne(d => d.User).WithMany(p => p.DatOzluks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_datOzluk_datUser");
        });

        modelBuilder.Entity<DatSirket>(entity =>
        {
            entity.HasKey(e => e.SirketId);

            entity.ToTable("datSirket");

            entity.Property(e => e.SirketId).HasColumnName("SirketID");
            entity.Property(e => e.SehirId).HasColumnName("SehirID");
            entity.Property(e => e.SektorId).HasColumnName("SektorID");
            entity.Property(e => e.SirketAdi).HasMaxLength(50);
            entity.Property(e => e.SirketAdres).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Sehir).WithMany(p => p.DatSirkets)
                .HasForeignKey(d => d.SehirId)
                .HasConstraintName("FK_datSirket_prmSehir");

            entity.HasOne(d => d.Sektor).WithMany(p => p.DatSirkets)
                .HasForeignKey(d => d.SektorId)
                .HasConstraintName("FK_datSirket_prmSektorBilgisi");

            entity.HasOne(d => d.User).WithMany(p => p.DatSirkets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_datSirket_datUser");
        });

        modelBuilder.Entity<DatUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("datUser");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserAccountType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UserEmail).HasMaxLength(50);
            entity.Property(e => e.UserPassword).HasMaxLength(10);
        });

        modelBuilder.Entity<JnkBasvuru>(entity =>
        {
            entity.HasKey(e => e.BasvuruId);

            entity.ToTable("jnkBasvuru");

            entity.Property(e => e.BasvuruId).HasColumnName("BasvuruID");
            entity.Property(e => e.IlanId).HasColumnName("IlanID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Ilan).WithMany(p => p.JnkBasvurus)
                .HasForeignKey(d => d.IlanId)
                .HasConstraintName("FK_jnkBasvuru_datIlan");

            entity.HasOne(d => d.User).WithMany(p => p.JnkBasvurus)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_jnkBasvuru_datUser");
        });

        modelBuilder.Entity<Junction>(entity =>
        {
            entity.ToTable("Junction");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IlanId).HasColumnName("IlanID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Ilan).WithMany(p => p.Junctions)
                .HasForeignKey(d => d.IlanId)
                .HasConstraintName("FK_Junction_tblilan");

            entity.HasOne(d => d.User).WithMany(p => p.Junctions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Junction_tblOzlukBilgisi");
        });

        modelBuilder.Entity<PrmHesapTipi>(entity =>
        {
            entity.ToTable("prmHesapTipi");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.HesapTipi).HasMaxLength(10);
        });

        modelBuilder.Entity<PrmSehir>(entity =>
        {
            entity.HasKey(e => e.SehirId);

            entity.ToTable("prmSehir");

            entity.Property(e => e.SehirId).HasColumnName("SehirID");
            entity.Property(e => e.SehirAdi).HasMaxLength(10);
        });

        modelBuilder.Entity<PrmSektorBilgisi>(entity =>
        {
            entity.HasKey(e => e.SektorId);

            entity.ToTable("prmSektorBilgisi");

            entity.Property(e => e.SektorId).HasColumnName("SektorID");
            entity.Property(e => e.SektorName).HasMaxLength(20);
        });

        modelBuilder.Entity<TblDatUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("tblDatUser");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Parola).HasMaxLength(10);

            entity.HasOne(d => d.HesapTipiNavigation).WithMany(p => p.TblDatUsers)
                .HasForeignKey(d => d.HesapTipi)
                .HasConstraintName("FK_tblDatUser_prmHesapTipi");
        });

        modelBuilder.Entity<TblOzlukBilgisi>(entity =>
        {
            entity.ToTable("tblOzlukBilgisi");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Ad).HasMaxLength(10);
            entity.Property(e => e.Bolum).HasMaxLength(50);
            entity.Property(e => e.CepNo).HasMaxLength(15);
            entity.Property(e => e.DogumTarihi).HasColumnType("date");
            entity.Property(e => e.EgitimSeviyesi).HasMaxLength(50);
            entity.Property(e => e.Okul).HasMaxLength(50);
            entity.Property(e => e.Pozisyon).HasMaxLength(50);
            entity.Property(e => e.SirketAdi).HasMaxLength(20);
            entity.Property(e => e.Soyad).HasMaxLength(10);
            entity.Property(e => e.Tecrube).HasMaxLength(10);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.SehirNavigation).WithMany(p => p.TblOzlukBilgisis)
                .HasForeignKey(d => d.Sehir)
                .HasConstraintName("FK_tblOzlukBilgisi_prmSehir");

            entity.HasOne(d => d.User).WithMany(p => p.TblOzlukBilgisis)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_tblOzlukBilgisi_tblDatUser");
        });

        modelBuilder.Entity<TblSirketBilgisi>(entity =>
        {
            entity.HasKey(e => e.SirketId);

            entity.ToTable("tblSirketBilgisi");

            entity.Property(e => e.SirketId).HasColumnName("SirketID");
            entity.Property(e => e.Ad)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Adres).HasMaxLength(100);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.SehirNavigation).WithMany(p => p.TblSirketBilgisis)
                .HasForeignKey(d => d.Sehir)
                .HasConstraintName("FK_tblSirketBilgisi_prmSehir");

            entity.HasOne(d => d.SektorNavigation).WithMany(p => p.TblSirketBilgisis)
                .HasForeignKey(d => d.Sektor)
                .HasConstraintName("FK_tblSirketBilgisi_prmSektorBilgisi");

            entity.HasOne(d => d.User).WithMany(p => p.TblSirketBilgisis)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_tblSirketBilgisi_tblDatUser");
        });

        modelBuilder.Entity<Tblilan>(entity =>
        {
            entity.ToTable("tblilan");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CalismaSekli).HasMaxLength(50);
            entity.Property(e => e.Departman).HasMaxLength(20);
            entity.Property(e => e.EgitimSeviyesi).HasMaxLength(50);
            entity.Property(e => e.Pozisyon).HasMaxLength(20);
            entity.Property(e => e.Tecrube).HasMaxLength(50);
            entity.Property(e => e.YabancilDil).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
