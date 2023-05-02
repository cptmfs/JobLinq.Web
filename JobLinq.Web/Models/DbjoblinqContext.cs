using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JobLinq.Web.Models
{
    public partial class DBJoblinqContext : DbContext
    {
        public DBJoblinqContext()
        {
        }

        public DBJoblinqContext(DbContextOptions<DBJoblinqContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Advert> Adverts { get; set; } = null!;
        public virtual DbSet<Candidate> Candidates { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<JobApp> JobApps { get; set; } = null!;
        public virtual DbSet<Sector> Sectors { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DBJoblinq;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advert>(entity =>
            {
                entity.ToTable("Advert");

                entity.Property(e => e.AdvertId).HasColumnName("AdvertID");

                entity.Property(e => e.AdvertTitle).HasMaxLength(50);

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.JobType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.ToTable("Candidate");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.Fname)
                    .HasMaxLength(20)
                    .HasColumnName("FName");

                entity.Property(e => e.Gsmno)
                    .HasMaxLength(10)
                    .HasColumnName("GSMNo")
                    .IsFixedLength();

                entity.Property(e => e.Lname)
                    .HasMaxLength(20)
                    .HasColumnName("LName");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CityID");

                entity.Property(e => e.CityName).HasMaxLength(50);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.Cadress)
                    .HasMaxLength(50)
                    .HasColumnName("CAdress");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.Cname)
                    .HasMaxLength(50)
                    .HasColumnName("CName");

                entity.Property(e => e.SectorId).HasColumnName("SectorID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<JobApp>(entity =>
            {
                entity.ToTable("JobApp");

                entity.Property(e => e.JobAppId).HasColumnName("JobAppID");

                entity.Property(e => e.AdvertId).HasColumnName("AdvertID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.ToTable("Sector");

                entity.Property(e => e.SectorId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SectorID");

                entity.Property(e => e.SectorName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(50)
                    .HasColumnName("UserEMail");

                entity.Property(e => e.UserPassword).HasMaxLength(10);

                entity.Property(e => e.UserType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
