﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RAS.Bootcamp.Mvc.Net.Models;

#nullable disable

namespace RAS.Bootcamp.Mvc.Net.Models.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221023233003_AddTableTransaksi")]
    partial class AddTableTransaksi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RAS.Bootcamp.Mvc.Net.Models.Entities.Barang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Filename")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<decimal>("Harga")
                        .HasColumnType("numeric");

                    b.Property<int>("IdPenjual")
                        .HasColumnType("integer");

                    b.Property<string>("Kode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Stok")
                        .HasColumnType("integer");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.HasIndex("IdPenjual");

                    b.ToTable("Barangs");
                });

            modelBuilder.Entity("RAS.Bootcamp.Mvc.Net.Models.Entities.ItemTransaksi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Harga")
                        .HasColumnType("numeric");

                    b.Property<int>("IdBarang")
                        .HasColumnType("integer");

                    b.Property<int>("IdTransaksi")
                        .HasColumnType("integer");

                    b.Property<int>("Jumlah")
                        .HasColumnType("integer");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("IdBarang");

                    b.HasIndex("IdTransaksi");

                    b.ToTable("ItemTransaksi");
                });

            modelBuilder.Entity("RAS.Bootcamp.Mvc.Net.Models.Entities.Keranjang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("HargaSatuan")
                        .HasColumnType("numeric");

                    b.Property<int>("IdBarang")
                        .HasColumnType("integer");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<int>("Jumlah")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdBarang");

                    b.HasIndex("IdUser");

                    b.ToTable("Keranjangs");
                });

            modelBuilder.Entity("RAS.Bootcamp.Mvc.Net.Models.Entities.Pembeli", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Alamat")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<string>("NoHp")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Pembelies");
                });

            modelBuilder.Entity("RAS.Bootcamp.Mvc.Net.Models.Entities.Penjual", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Alamat")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<string>("NamaToko")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Penjuals");
                });

            modelBuilder.Entity("RAS.Bootcamp.Mvc.Net.Models.Entities.Transaksi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AlamatPengiriman")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<string>("MetodePembayaran")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StatusBayar")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StatusTransaksi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("TotalHarga")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Transaksi");
                });

            modelBuilder.Entity("RAS.Bootcamp.Mvc.Net.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tipe")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RAS.Bootcamp.Mvc.Net.Models.Entities.Barang", b =>
                {
                    b.HasOne("RAS.Bootcamp.Mvc.Net.Models.Entities.Penjual", "Penjual")
                        .WithMany("Barangs")
                        .HasForeignKey("IdPenjual")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Penjual");
                });

            modelBuilder.Entity("RAS.Bootcamp.Mvc.Net.Models.Entities.ItemTransaksi", b =>
                {
                    b.HasOne("RAS.Bootcamp.Mvc.Net.Models.Entities.Barang", "Barang")
                        .WithMany()
                        .HasForeignKey("IdBarang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RAS.Bootcamp.Mvc.Net.Models.Entities.Transaksi", "Transaksi")
                        .WithMany("ItemTransaksi")
                        .HasForeignKey("IdTransaksi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barang");

                    b.Navigation("Transaksi");
                });

            modelBuilder.Entity("RAS.Bootcamp.Mvc.Net.Models.Entities.Keranjang", b =>
                {
                    b.HasOne("RAS.Bootcamp.Mvc.Net.Models.Entities.Barang", "Barang")
                        .WithMany()
                        .HasForeignKey("IdBarang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RAS.Bootcamp.Mvc.Net.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barang");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RAS.Bootcamp.Mvc.Net.Models.Entities.Pembeli", b =>
                {
                    b.HasOne("RAS.Bootcamp.Mvc.Net.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RAS.Bootcamp.Mvc.Net.Models.Entities.Penjual", b =>
                {
                    b.HasOne("RAS.Bootcamp.Mvc.Net.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RAS.Bootcamp.Mvc.Net.Models.Entities.Transaksi", b =>
                {
                    b.HasOne("RAS.Bootcamp.Mvc.Net.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RAS.Bootcamp.Mvc.Net.Models.Entities.Penjual", b =>
                {
                    b.Navigation("Barangs");
                });

            modelBuilder.Entity("RAS.Bootcamp.Mvc.Net.Models.Entities.Transaksi", b =>
                {
                    b.Navigation("ItemTransaksi");
                });
#pragma warning restore 612, 618
        }
    }
}
