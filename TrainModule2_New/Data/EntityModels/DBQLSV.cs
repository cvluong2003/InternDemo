using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data.EntityModels;

public partial class DBQLSV : DbContext
{
    public DBQLSV()
    {
    }

    public DBQLSV(DbContextOptions<DBQLSV> options)
        : base(options)
    {
    }

    public virtual DbSet<Giaovien> Giaoviens { get; set; }

    public virtual DbSet<Ketqua> Ketquas { get; set; }

    public virtual DbSet<Lop> Lops { get; set; }

    public virtual DbSet<Monhoc> Monhocs { get; set; }

    public virtual DbSet<Sinhvien> Sinhviens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 
        => optionsBuilder.UseSqlServer("Data Source=HCM2-000027;Initial Catalog=QLSV;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Giaovien>(entity =>
        {
            entity.HasKey(e => e.Magv).HasName("PK__GIAOVIEN__603F38B1CCFD9769");

            entity.ToTable("GIAOVIEN");

            entity.Property(e => e.Magv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MAGV");
            entity.Property(e => e.Malop)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MALOP");
            entity.Property(e => e.Pass)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PASS");
            entity.Property(e => e.Tengv)
                .HasMaxLength(40)
                .HasColumnName("TENGV");

            entity.HasOne(d => d.MalopNavigation).WithMany(p => p.Giaoviens)
                .HasForeignKey(d => d.Malop)
                .HasConstraintName("FK_GIAOVIEN_LOP");
        });

        modelBuilder.Entity<Ketqua>(entity =>
        {
            entity.HasKey(e => new { e.Masv, e.Mamh }).HasName("PK__KETQUA__C6217CB6B0F1A6F8");

            entity.ToTable("KETQUA");

            entity.Property(e => e.Masv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MASV");
            entity.Property(e => e.Mamh)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MAMH");
            entity.Property(e => e.Diemso).HasColumnName("DIEMSO");
            entity.Property(e => e.Xeploai)
                .HasMaxLength(20)
                .HasColumnName("XEPLOAI");

            entity.HasOne(d => d.MamhNavigation).WithMany(p => p.Ketquas)
                .HasForeignKey(d => d.Mamh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KETQUA_MONHOC");

            entity.HasOne(d => d.MasvNavigation).WithMany(p => p.Ketquas)
                .HasForeignKey(d => d.Masv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KETQUA_SINHVIEN");
        });

        modelBuilder.Entity<Lop>(entity =>
        {
            entity.HasKey(e => e.Malop).HasName("PK__LOP__7A3DE21178A238A0");

            entity.ToTable("LOP");

            entity.Property(e => e.Malop)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MALOP");
            entity.Property(e => e.Siso).HasColumnName("SISO");
            entity.Property(e => e.Tenlop)
                .HasMaxLength(30)
                .HasColumnName("TENLOP");
        });

        modelBuilder.Entity<Monhoc>(entity =>
        {
            entity.HasKey(e => e.Mamh).HasName("PK__MONHOC__603F69EB0C5EB903");

            entity.ToTable("MONHOC");

            entity.Property(e => e.Mamh)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MAMH");
            entity.Property(e => e.Sotc).HasColumnName("SOTC");
            entity.Property(e => e.Tenmh)
                .HasMaxLength(40)
                .HasColumnName("TENMH");
        });

        modelBuilder.Entity<Sinhvien>(entity =>
        {
            entity.HasKey(e => e.Masv).HasName("PK__SINHVIEN__60228A281CF9D71C");

            entity.ToTable("SINHVIEN");

            entity.Property(e => e.Masv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MASV");
            entity.Property(e => e.Diachi)
                .HasMaxLength(25)
                .HasColumnName("DIACHI");
            entity.Property(e => e.Malop)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MALOP");
            entity.Property(e => e.Namsinh).HasColumnName("NAMSINH");
            entity.Property(e => e.Tensv)
                .HasMaxLength(25)
                .HasColumnName("TENSV");

            entity.HasOne(d => d.MalopNavigation).WithMany(p => p.Sinhviens)
                .HasForeignKey(d => d.Malop)
                .HasConstraintName("FK_SINHVIEN_LOP");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
