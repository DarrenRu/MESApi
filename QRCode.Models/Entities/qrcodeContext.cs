using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QRCode.Models.Entities
{
    public partial class qrcodeContext : DbContext
    {
        public qrcodeContext()
        {
        }

        public qrcodeContext(DbContextOptions<qrcodeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=Tku8833122;database=qrcode");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account", "qrcode");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreateDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifyDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.NickName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnType("tinyint(4)");

                entity.Property(e => e.Token)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student", "qrcode");

                entity.HasIndex(e => e.AccountId)
                    .HasName("Account_Id_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AccountId)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CardNumber).HasColumnType("int(11)");

                entity.Property(e => e.ChineseName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("無");

                entity.Property(e => e.Class)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("無");

                entity.Property(e => e.ClassNumber).HasColumnType("int(11)");

                entity.Property(e => e.CreateDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("無");

                entity.Property(e => e.Gender).HasColumnType("tinyint(4)");

                entity.Property(e => e.GoOutWeekdays).HasColumnType("int(11)");

                entity.Property(e => e.GoOutWeekdaysT).HasColumnType("tinyint(4)");

                entity.Property(e => e.GoOutWeekends).HasColumnType("int(11)");

                entity.Property(e => e.GoOutWeekendsT).HasColumnType("tinyint(4)");

                entity.Property(e => e.ModifyDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Number)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.OvernightWeekends).HasColumnType("int(11)");

                entity.Property(e => e.OvernightWeekendsT).HasColumnType("tinyint(4)");

                entity.Property(e => e.Qrcode)
                    .HasColumnName("QRCode")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Year).HasColumnType("int(11)");
            });
        }
    }
}
