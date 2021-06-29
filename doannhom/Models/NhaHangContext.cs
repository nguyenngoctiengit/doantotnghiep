using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace doannhom.Models
{
    public partial class NhaHangContext : DbContext
    {
        public NhaHangContext()
        {
        }

        public NhaHangContext(DbContextOptions<NhaHangContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ban> Ban { get; set; }
        public virtual DbSet<Ca> Ca { get; set; }
        public virtual DbSet<Cthd> Cthd { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<LoaiMonAn> LoaiMonAn { get; set; }
        public virtual DbSet<MonAn> MonAn { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<PhanCong> PhanCong { get; set; }
        public virtual DbSet<PhanHoi> PhanHoi { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-GJ6UCAT;Database=NhaHang;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ban>(entity =>
            {
                entity.HasKey(e => e.MaBan)
                    .HasName("PK__Ban__3520ED6C4E1C0824");

                entity.Property(e => e.MaBan).HasMaxLength(10);

                entity.Property(e => e.TinhTrang)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Ca>(entity =>
            {
                entity.HasKey(e => e.MaCa)
                    .HasName("PK__Ca__27258E7B60410FBD");

                entity.Property(e => e.MaCa).HasMaxLength(10);

                entity.Property(e => e.LuuY).HasMaxLength(200);

                entity.Property(e => e.NgayBd)
                    .HasColumnName("NgayBD")
                    .HasColumnType("datetime");

                entity.Property(e => e.NgayKt)
                    .HasColumnName("NgayKT")
                    .HasColumnType("datetime");

                entity.Property(e => e.TenCa).HasMaxLength(100);
            });

            modelBuilder.Entity<Cthd>(entity =>
            {
                entity.HasKey(e => new { e.MaHd, e.MaMonAn })
                    .HasName("PK__CTHD__6C34D782C4A28199");

                entity.ToTable("CTHD");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.MaMonAn).HasMaxLength(10);

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany(p => p.Cthd)
                    .HasForeignKey(d => d.MaHd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cthd_mahd");

                entity.HasOne(d => d.MaMonAnNavigation)
                    .WithMany(p => p.Cthd)
                    .HasForeignKey(d => d.MaMonAn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CTHD__MaMonAn__30F848ED");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHd)
                    .HasName("PK__HoaDon__2725A6E083A769B9");

                entity.Property(e => e.MaHd)
                    .HasColumnName("MaHD")
                    .ValueGeneratedNever();

                entity.Property(e => e.MaBan)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.MaKh)
                    .IsRequired()
                    .HasColumnName("MaKH")
                    .HasMaxLength(10);

                entity.Property(e => e.MaNv)
                    .IsRequired()
                    .HasColumnName("MaNV")
                    .HasMaxLength(10);

                entity.Property(e => e.NgayLap).HasColumnType("datetime");

                entity.HasOne(d => d.MaBanNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.MaBan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_HoaDon_maban");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HoaDon__MaNV__33D4B598");
            });

            modelBuilder.Entity<LoaiMonAn>(entity =>
            {
                entity.HasKey(e => e.MaLoai)
                    .HasName("PK__LoaiMonA__730A57596926E798");

                entity.Property(e => e.MaLoai).HasMaxLength(10);

                entity.Property(e => e.TenLoai)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<MonAn>(entity =>
            {
                entity.HasKey(e => e.MaMonAn)
                    .HasName("PK__MonAn__B11716450478D0BB");

                entity.Property(e => e.MaMonAn)
                    .HasColumnName("MaMonAN")
                    .HasMaxLength(10);

                entity.Property(e => e.Dvt)
                    .IsRequired()
                    .HasColumnName("DVT")
                    .HasMaxLength(50);

                entity.Property(e => e.MaLoai)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TenMon)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.MonAn)
                    .HasForeignKey(d => d.MaLoai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MonAn__MaLoai__267ABA7A");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("PK__NhanVien__2725D70A3B1E0310");

                entity.Property(e => e.MaNv)
                    .HasColumnName("MaNV")
                    .HasMaxLength(10);

                entity.Property(e => e.ChucVu).HasMaxLength(100);

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.GioiTinh).HasMaxLength(10);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.NgayVaoLam).HasColumnType("datetime");

                entity.Property(e => e.PhuCap).HasColumnName("phuCap");

                entity.Property(e => e.Sdt).HasColumnName("SDT");

                entity.Property(e => e.TenNv)
                    .HasColumnName("TenNV")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<PhanCong>(entity =>
            {
                entity.HasKey(e => e.MaPC);

                entity.Property(e => e.MaPC).HasColumnName("MaPC");

                entity.Property(e => e.MaCa).HasMaxLength(10);

                entity.Property(e => e.MaNv)
                    .HasColumnName("MaNV")
                    .HasMaxLength(10);

                entity.Property(e => e.MaBan).HasMaxLength(10);

                entity.Property(e => e.NgayBatDau).HasColumnType("datetime");

                entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");

                entity.HasOne(d => d.MaBanNavigation)
                    .WithMany(p => p.PhanCong)
                    .HasForeignKey(d => d.MaBan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_phancong_maban");

                entity.HasOne(d => d.MaCaNavigation)
                    .WithMany(p => p.PhanCong)
                    .HasForeignKey(d => d.MaCa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_phancong_maca");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.PhanCong)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PhanCong__MaNV__3C69FB99");
            });

            modelBuilder.Entity<PhanHoi>(entity =>
            {
                entity.HasKey(e => e.Stt)
                    .HasName("PK__PhanHoi__CA1EB6900D2F578D");

                entity.Property(e => e.Stt).HasColumnName("STT");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Hinhthuc)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.HoTenKh)
                    .IsRequired()
                    .HasColumnName("HoTenKH")
                    .HasMaxLength(100);

                entity.Property(e => e.MaNv)
                    .HasColumnName("MaNV")
                    .HasMaxLength(10);

                entity.Property(e => e.NgayLap).HasColumnType("datetime");

                entity.Property(e => e.NoiDung)
                    .IsRequired()
                    .HasMaxLength(700);

                entity.Property(e => e.Sdt).HasColumnName("SDT");

                entity.Property(e => e.TinhTrang).HasMaxLength(100);

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.PhanHoi)
                    .HasForeignKey(d => d.MaNv)
                    .HasConstraintName("FK__PhanHoi__MaNV__2E1BDC42");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.TenTk)
                    .HasName("PK__TaiKhoan__4CF9E77608A0B78B");

                entity.Property(e => e.TenTk)
                    .HasColumnName("TenTK")
                    .HasMaxLength(100);

                entity.Property(e => e.ChucVu)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MaNv)
                    .IsRequired()
                    .HasColumnName("MaNV")
                    .HasMaxLength(10);

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NgayDk)
                    .HasColumnName("NgayDK")
                    .HasColumnType("date");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.TaiKhoan)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TaiKhoan__NgayDK__2B3F6F97");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
