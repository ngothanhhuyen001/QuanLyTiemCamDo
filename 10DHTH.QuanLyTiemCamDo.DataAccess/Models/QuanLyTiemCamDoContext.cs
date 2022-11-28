using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.Models
{
    public partial class QuanLyTiemCamDoContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public QuanLyTiemCamDoContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public QuanLyTiemCamDoContext(DbContextOptions<QuanLyTiemCamDoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cthd> Cthds { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<HinhThucDongLai> HinhThucDongLais { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HopDong> HopDongs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LichSuDongLai> LichSuDongLais { get; set; }
        public virtual DbSet<LoaiTaiSan> LoaiTaiSans { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<TaiSan> TaiSans { get; set; }
        public virtual DbSet<TrangThai> TrangThais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("ServerConnectionString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Cthd>(entity =>
            {
                entity.HasKey(e => new { e.MaHoaDon, e.MaTaiSan });

                entity.ToTable("CTHD");

                entity.HasOne(d => d.MaHoaDonNavigation)
                    .WithMany(p => p.Cthds)
                    .HasForeignKey(d => d.MaHoaDon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTHD_HoaDon");

                entity.HasOne(d => d.MaTaiSanNavigation)
                    .WithMany(p => p.Cthds)
                    .HasForeignKey(d => d.MaTaiSan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTHD_TaiSan");
            });

            modelBuilder.Entity<DichVu>(entity =>
            {
                entity.HasKey(e => e.MaPhiDv);

                entity.ToTable("DichVu");

                entity.Property(e => e.MaPhiDv).HasColumnName("MaPhiDV");

                entity.Property(e => e.PhiDv).HasColumnName("PhiDV");

                entity.Property(e => e.TenDv)
                    .HasMaxLength(50)
                    .HasColumnName("TenDV");
            });

            modelBuilder.Entity<HinhThucDongLai>(entity =>
            {
                entity.HasKey(e => e.MaHtl);

                entity.ToTable("HinhThucDongLai");

                entity.Property(e => e.MaHtl).HasColumnName("MaHTL");

                entity.Property(e => e.TenHinhThuc).HasMaxLength(20);
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHoaDon);

                entity.ToTable("HoaDon");

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.NgayBan).HasColumnType("datetime");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaKh)
                    .HasConstraintName("FK_HoaDon_KhachHang");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaNv)
                    .HasConstraintName("FK_HoaDon_NhanVien");
            });

            modelBuilder.Entity<HopDong>(entity =>
            {
                entity.HasKey(e => e.MaHopDong);

                entity.ToTable("HopDong");

                entity.Property(e => e.MaHtl).HasColumnName("MaHTL");

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.NgayKt)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayKT");

                entity.Property(e => e.NgayLap).HasColumnType("datetime");

                entity.HasOne(d => d.MaHtlNavigation)
                    .WithMany(p => p.HopDongs)
                    .HasForeignKey(d => d.MaHtl)
                    .HasConstraintName("FK_HopDong_HTL");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.HopDongs)
                    .HasForeignKey(d => d.MaKh)
                    .HasConstraintName("FK_HopDong_KhachHang");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.HopDongs)
                    .HasForeignKey(d => d.MaNv)
                    .HasConstraintName("FK_HopDong_NhanVien");

                entity.HasOne(d => d.MaTaiSanNavigation)
                    .WithMany(p => p.HopDongs)
                    .HasForeignKey(d => d.MaTaiSan)
                    .HasConstraintName("FK_HopDong_TaiSan");

                entity.HasOne(d => d.MaTrangThaiNavigation)
                    .WithMany(p => p.HopDongs)
                    .HasForeignKey(d => d.MaTrangThai)
                    .HasConstraintName("FK_HopDong_TrangThai");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh);

                entity.ToTable("KhachHang");

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.Cmnd)
                    .HasMaxLength(15)
                    .HasColumnName("CMND")
                    .IsFixedLength(true);

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Mkhash).HasColumnName("MKHash");

                entity.Property(e => e.Mksalt).HasColumnName("MKSalt");

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.SoDt)
                    .HasMaxLength(11)
                    .HasColumnName("SoDT")
                    .IsFixedLength(true);

                entity.Property(e => e.TenKh)
                    .HasMaxLength(50)
                    .HasColumnName("TenKH");
            });

            modelBuilder.Entity<LichSuDongLai>(entity =>
            {
                entity.HasKey(e => e.MaLichSu);

                entity.ToTable("LichSuDongLai");

                entity.Property(e => e.NgayDongLai).HasColumnType("datetime");

                entity.Property(e => e.TienDv).HasColumnName("TienDV");

                entity.HasOne(d => d.MaHopDongNavigation)
                    .WithMany(p => p.LichSuDongLais)
                    .HasForeignKey(d => d.MaHopDong)
                    .HasConstraintName("FK_LichSuDongLai_HopDong");

                entity.HasOne(d => d.MaTrangThaiNavigation)
                    .WithMany(p => p.LichSuDongLais)
                    .HasForeignKey(d => d.MaTrangThai)
                    .HasConstraintName("FK_LichSuDongLai_TrangThai");
            });

            modelBuilder.Entity<LoaiTaiSan>(entity =>
            {
                entity.HasKey(e => e.MaLoai);

                entity.ToTable("LoaiTaiSan");

                entity.Property(e => e.MaPhiDv).HasColumnName("MaPhiDV");

                entity.Property(e => e.TenLoai).HasMaxLength(50);

                entity.HasOne(d => d.MaPhiDvNavigation)
                    .WithMany(p => p.LoaiTaiSans)
                    .HasForeignKey(d => d.MaPhiDv)
                    .HasConstraintName("FK_LoaiTaiSan_DichVu");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv);

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.Cmmn)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("CMMN");

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mkhash).HasColumnName("MKHash");

                entity.Property(e => e.Mksalt).HasColumnName("MKSalt");

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenNv)
                    .HasMaxLength(50)
                    .HasColumnName("TenNV");
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.MaToken);

                entity.ToTable("RefreshToken");

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.NgayHetHan).HasColumnType("datetime");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.MaKh)
                    .HasConstraintName("FK_RefreshTokens_KhachHang");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.MaNv)
                    .HasConstraintName("FK_RefreshTokens_NhanVien");
            });

            modelBuilder.Entity<TaiSan>(entity =>
            {
                entity.HasKey(e => e.MaTaiSan);

                entity.ToTable("TaiSan");

                entity.Property(e => e.NgayThanhLy).HasColumnType("datetime");

                entity.Property(e => e.Nsx)
                    .HasMaxLength(20)
                    .HasColumnName("NSX");

                entity.Property(e => e.TenTaiSan).HasMaxLength(50);

                entity.Property(e => e.ThuongHieu).HasMaxLength(50);

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.TaiSans)
                    .HasForeignKey(d => d.MaLoai)
                    .HasConstraintName("FK_TaiSan_LoaiTaiSan");

                entity.HasOne(d => d.MaTrangThaiNavigation)
                    .WithMany(p => p.TaiSans)
                    .HasForeignKey(d => d.MaTrangThai)
                    .HasConstraintName("FK_TaiSan_TrangThai");
            });

            modelBuilder.Entity<TrangThai>(entity =>
            {
                entity.HasKey(e => e.MaTrangThai);

                entity.ToTable("TrangThai");

                entity.Property(e => e.TenTrangThai).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
