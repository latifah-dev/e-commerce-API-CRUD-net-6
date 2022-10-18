using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PALUGADA.API.Datas.Entities;

namespace PALUGADA.API.Datas
{
    public partial class DBPALUGADAContext : DbContext
    {
        public DBPALUGADAContext()
        {
        }

        public DBPALUGADAContext(DbContextOptions<DBPALUGADAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barang> Barangs { get; set; } = null!;
        public virtual DbSet<Ekspedisi> Ekspedisis { get; set; } = null!;
        public virtual DbSet<Karyawan> Karyawans { get; set; } = null!;
        public virtual DbSet<Pembeli> Pembelis { get; set; } = null!;
        public virtual DbSet<Penjual> Penjuals { get; set; } = null!;
        public virtual DbSet<Transaksi> Transaksis { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost; Port=5432; Database=DBPALUGADA; User Id=postgres; Password=lupakatasandi;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barang>(entity =>
            {
                entity.HasKey(e => e.IdBarang)
                    .HasName("barang_pk");

                entity.ToTable("Barang");

                entity.Property(e => e.IdBarang)
                    .HasColumnName("id_barang")
                    .HasDefaultValueSql("nextval('barang_id_barang_seq'::regclass)");

                entity.Property(e => e.DeskripsiBarang).HasColumnName("deskripsi_barang");

                entity.Property(e => e.GambarBarang)
                    .HasColumnType("oid")
                    .HasColumnName("gambar_barang");

                entity.Property(e => e.HargaBarang).HasColumnName("harga_barang");

                entity.Property(e => e.IdPenjual).HasColumnName("id_penjual");

                entity.Property(e => e.JenisBarang)
                    .HasColumnType("character varying")
                    .HasColumnName("jenis_barang");

                entity.Property(e => e.KodeBarang)
                    .HasColumnType("character varying")
                    .HasColumnName("kode_barang");

                entity.Property(e => e.NamaBarang)
                    .HasColumnType("character varying")
                    .HasColumnName("nama_barang");

                entity.Property(e => e.StokBarang).HasColumnName("stok_barang");

                entity.HasOne(d => d.IdPenjualNavigation)
                    .WithMany(p => p.Barangs)
                    .HasForeignKey(d => d.IdPenjual)
                    .HasConstraintName("barang_fk");
            });

            modelBuilder.Entity<Ekspedisi>(entity =>
            {
                entity.HasKey(e => e.IdEkspedisi)
                    .HasName("ekspedisi_pk");

                entity.ToTable("ekspedisi");

                entity.Property(e => e.IdEkspedisi)
                    .ValueGeneratedNever()
                    .HasColumnName("id_ekspedisi");

                entity.Property(e => e.AlamatEkspedisi)
                    .HasColumnType("character varying")
                    .HasColumnName("alamat_ekspedisi");

                entity.Property(e => e.NamaEkspedisi)
                    .HasColumnType("character varying")
                    .HasColumnName("nama_ekspedisi");
            });

            modelBuilder.Entity<Karyawan>(entity =>
            {
                entity.HasKey(e => e.IdKaryawan)
                    .HasName("karyawan_pk");

                entity.ToTable("karyawan");

                entity.Property(e => e.IdKaryawan)
                    .ValueGeneratedNever()
                    .HasColumnName("id_karyawan");

                entity.Property(e => e.NamaKaryawan)
                    .HasColumnType("character varying")
                    .HasColumnName("nama_karyawan");

                entity.Property(e => e.Password)
                    .HasColumnType("character varying")
                    .HasColumnName("password");

                entity.Property(e => e.Posisi)
                    .HasColumnType("character varying")
                    .HasColumnName("posisi");

                entity.Property(e => e.Username)
                    .HasColumnType("character varying")
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Pembeli>(entity =>
            {
                entity.HasKey(e => e.IdPembeli)
                    .HasName("Pembeli_pkey");

                entity.ToTable("Pembeli");

                entity.Property(e => e.IdPembeli)
                    .ValueGeneratedNever()
                    .HasColumnName("id_pembeli");

                entity.Property(e => e.AlamatPembeli).HasColumnName("alamat_pembeli");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.NamaPembeli)
                    .HasMaxLength(30)
                    .HasColumnName("nama_pembeli");

                entity.Property(e => e.NegaraPembeli)
                    .HasColumnType("character varying")
                    .HasColumnName("negara_pembeli");

                entity.Property(e => e.NotelpPembeli)
                    .HasColumnType("character varying")
                    .HasColumnName("notelp_pembeli");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Pembelis)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("pembeli_fk");
            });

            modelBuilder.Entity<Penjual>(entity =>
            {
                entity.HasKey(e => e.IdPenjual)
                    .HasName("Penjual_pkey");

                entity.ToTable("Penjual");

                entity.Property(e => e.IdPenjual)
                    .ValueGeneratedNever()
                    .HasColumnName("id_penjual");

                entity.Property(e => e.AlamatToko).HasColumnName("alamat_toko");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.KodeToko)
                    .HasMaxLength(10)
                    .HasColumnName("kode_toko");

                entity.Property(e => e.NamaToko)
                    .HasMaxLength(30)
                    .HasColumnName("nama_toko");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Penjuals)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("penjual_fk");
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi)
                    .HasName("transaksi_pk");

                entity.ToTable("transaksi");

                entity.Property(e => e.IdTransaksi)
                    .ValueGeneratedNever()
                    .HasColumnName("id_transaksi");

                entity.Property(e => e.IdBarang).HasColumnName("id_barang");

                entity.Property(e => e.IdEkspedisi).HasColumnName("id_ekspedisi");

                entity.Property(e => e.IdPembeli).HasColumnName("id_pembeli");

                entity.Property(e => e.IdPenjual).HasColumnName("id_penjual");

                entity.Property(e => e.JenisPembayaran)
                    .HasColumnType("character varying")
                    .HasColumnName("jenis_pembayaran");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Status)
                    .HasColumnType("character varying")
                    .HasColumnName("status");

                entity.Property(e => e.StatusPembayaran)
                    .HasColumnType("character varying")
                    .HasColumnName("status_pembayaran");

                entity.Property(e => e.TglBayar).HasColumnName("tgl_bayar");

                entity.Property(e => e.TglBeli).HasColumnName("tgl_beli");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.IdBarangNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdBarang)
                    .HasConstraintName("transaksi_fk");

                entity.HasOne(d => d.IdEkspedisiNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdEkspedisi)
                    .HasConstraintName("transaksi_fk_3");

                entity.HasOne(d => d.IdPembeliNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdPembeli)
                    .HasConstraintName("transaksi_fk_1");

                entity.HasOne(d => d.IdPenjualNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdPenjual)
                    .HasConstraintName("transaksi_fk_2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("User_pkey");

                entity.ToTable("User");

                entity.Property(e => e.IdUser)
                    .ValueGeneratedNever()
                    .HasColumnName("id_user");

                entity.Property(e => e.EmailUser)
                    .HasColumnType("character varying")
                    .HasColumnName("email_user");

                entity.Property(e => e.NohpUser)
                    .HasColumnType("character varying")
                    .HasColumnName("nohp_user");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .HasColumnName("password")
                    .IsFixedLength();

                entity.Property(e => e.TipeUser)
                    .HasMaxLength(30)
                    .HasColumnName("tipe_user")
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .HasColumnName("username")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
