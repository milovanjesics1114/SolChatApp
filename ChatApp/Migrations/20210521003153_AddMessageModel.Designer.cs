﻿// <auto-generated />
using System;
using ChatApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChatApp.Migrations
{
    [DbContext(typeof(MvcChatContext))]
    [Migration("20210521003153_AddMessageModel")]
    partial class AddMessageModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChatApp.Models.ChatAppModel", b =>
                {
                    b.Property<int>("korisnikID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("korisnik_email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("korisnik_ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("korisnik_korisnicko_ime")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("korisnik_logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("korisnik_sifra")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("korisnik_status")
                        .HasColumnType("bit");

                    b.HasKey("korisnikID");

                    b.ToTable("ChatAppModel");
                });

            modelBuilder.Entity("ChatApp.Models.MessageModel", b =>
                {
                    b.Property<int>("porukaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("korisnik_korisnikID")
                        .HasColumnType("int");

                    b.Property<string>("sadrzaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("vreme_poruke")
                        .HasColumnType("datetime2");

                    b.HasKey("porukaID");

                    b.ToTable("MessageModel");
                });
#pragma warning restore 612, 618
        }
    }
}