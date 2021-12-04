using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsoleApp1
{
    public partial class MallCenterContext : DbContext
    {
        public MallCenterContext()
        {
        }

        public MallCenterContext(DbContextOptions<MallCenterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Клиент> Клиентs { get; set; } = null!;
        public virtual DbSet<Поставщики> Поставщикиs { get; set; } = null!;
        public virtual DbSet<Сделка> Сделкаs { get; set; } = null!;
        public virtual DbSet<Склад> Складs { get; set; } = null!;
        public virtual DbSet<Сотрудник> Сотрудникs { get; set; } = null!;
        public virtual DbSet<Товар> Товарs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-9OICVCM\SQLTAB;Initial Catalog=MallCenter;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Клиент>(entity =>
            {
                entity.HasKey(e => e.IdКлиента);

                entity.ToTable("Клиент");

                entity.Property(e => e.IdКлиента).HasColumnName("ID_Клиента");

                entity.Property(e => e.Имя)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Пол)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Поставщики>(entity =>
            {
                entity.HasKey(e => e.IdПоставщика);

                entity.ToTable("Поставщики");

                entity.Property(e => e.IdПоставщика).HasColumnName("ID_Поставщика");

                entity.Property(e => e.Наименование)
                    .HasMaxLength(15)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Сделка>(entity =>
            {
                entity.HasKey(e => e.IdСделки);

                entity.ToTable("Сделка");

                entity.Property(e => e.IdСделки)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Сделки");

                entity.Property(e => e.Дата).HasColumnType("date");

                entity.Property(e => e.Количество).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.КодКлиентаNavigation)
                    .WithMany(p => p.Сделкаs)
                    .HasForeignKey(d => d.КодКлиента)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Сделка_Клиент");

                entity.HasOne(d => d.КодНаСкладеNavigation)
                    .WithMany(p => p.Сделкаs)
                    .HasForeignKey(d => d.КодНаСкладе)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Сделка_Склад");

                entity.HasOne(d => d.КодСотрудникаNavigation)
                    .WithMany(p => p.Сделкаs)
                    .HasForeignKey(d => d.КодСотрудника)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Сделка_Сотрудник");
            });

            modelBuilder.Entity<Склад>(entity =>
            {
                entity.HasKey(e => e.IdПоставки)
                    .HasName("PK_Склад_1");

                entity.ToTable("Склад");

                entity.Property(e => e.IdПоставки).HasColumnName("ID_Поставки");

                entity.Property(e => e.ДатаПоставки).HasColumnType("date");

                entity.Property(e => e.Количество).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Цена).HasColumnType("money");

                entity.HasOne(d => d.КодПоставщикаNavigation)
                    .WithMany(p => p.Складs)
                    .HasForeignKey(d => d.КодПоставщика)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Склад_Поставщики");

                entity.HasOne(d => d.КодТовараNavigation)
                    .WithMany(p => p.Складs)
                    .HasForeignKey(d => d.КодТовара)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Склад_Товар");
            });

            modelBuilder.Entity<Сотрудник>(entity =>
            {
                entity.HasKey(e => e.IdСотрудника);

                entity.ToTable("Сотрудник");

                entity.Property(e => e.IdСотрудника).HasColumnName("ID_Сотрудника");

                entity.Property(e => e.ДатаУстройстваНаРаботу).HasColumnType("date");

                entity.Property(e => e.Имя)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.КодРуководителя)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Товар>(entity =>
            {
                entity.HasKey(e => e.IdТовара);

                entity.ToTable("Товар");

                entity.Property(e => e.IdТовара).HasColumnName("ID_Товара");

                entity.Property(e => e.Наименование)
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Описание).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
