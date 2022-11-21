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

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersDept> UsersDepts { get; set; }

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
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.IdItem);

                entity.ToTable("item");

                entity.Property(e => e.IdItem).HasColumnName("id_item");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IdStatus).HasColumnName("id_status");

                entity.Property(e => e.IdType).HasColumnName("id_type");

                entity.Property(e => e.Img).HasColumnName("img");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Nsx).HasColumnName("NSX");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK_item_status");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.IdType)
                    .HasConstraintName("FK_item_type");
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.ToTable("RefreshToken");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Expires).HasColumnType("datetime");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_RefreshTokens_users");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole);

                entity.ToTable("role");

                entity.Property(e => e.IdRole).HasColumnName("id_role");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.IdStatus);

                entity.ToTable("status");

                entity.Property(e => e.IdStatus).HasColumnName("id_status");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.HasKey(e => e.IdType);

                entity.ToTable("type");

                entity.Property(e => e.IdType).HasColumnName("id_type");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created at");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("update at");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("users");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.IdDept).HasColumnName("id_dept");

                entity.Property(e => e.IdRole).HasColumnName("id_role");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Remember).HasColumnName("remember");

                entity.HasOne(d => d.IdDeptNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdDept)
                    .HasConstraintName("FK_users_usersdept");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK_users_role");
            });

            modelBuilder.Entity<UsersDept>(entity =>
            {
                entity.HasKey(e => e.IdDept)
                    .HasName("PK_usersdept");

                entity.ToTable("users_dept");

                entity.Property(e => e.IdDept).HasColumnName("id_dept");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.TotalDept).HasColumnName("total_dept");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
