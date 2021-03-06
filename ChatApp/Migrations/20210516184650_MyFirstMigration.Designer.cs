// <auto-generated />
using ChatApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChatApp.Migrations
{
    [DbContext(typeof(MvcChatContext))]
    [Migration("20210516184650_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChatApp.Models.ChatAppModel", b =>
                {
                    b.Property<int>("korisnikID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("korisnik_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("korisnik_ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("korisnik_korisnicko_ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("korisnik_logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("korisnik_sifra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("korisnik_status")
                        .HasColumnType("bit");

                    b.HasKey("korisnikID");

                    b.ToTable("ChatAppModel");
                });
#pragma warning restore 612, 618
        }
    }
}
