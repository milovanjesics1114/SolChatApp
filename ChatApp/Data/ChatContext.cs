using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChatApp.Models;

namespace ChatApp.Data
{
    public class MvcChatContext : DbContext
    {



        public MvcChatContext(DbContextOptions<MvcChatContext> options)
            : base(options)
        {
        }

        public DbSet<ChatAppModel> ChatAppModel { get; set; }

        public DbSet<MessageModel> MessageModel { get; set; }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ChatDB;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MessageModel>()
                .HasOne<ChatAppModel>(s => s.ChatAppModel)
                .WithMany(g => g.MessageModels)
                .HasForeignKey(s => s.korisnik_korisnikID);
        }

        public DbSet<ChatAppModel> ChatAppModels { get; set; }
        public DbSet<MessageModel> MessageModels { get; set; }
        /*
        public MvcChatContext(DbContextOptions<MvcChatContext> options)
            : base(options)
        {
        }

        public DbSet<ChatAppModel> ChatAppModel { get; set; }

        public DbSet<MessageModel> MessageModel { get; set; }

         public MvcChatContext(DbContextOptions<MvcChatContext> options)
           : base(options)
        {
        }

        public DbSet<ChatAppModel> ChatAppModel { get; set; }
        public DbSet<MessageModel> MessageModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /* modelBuilder.Entity<MessageModel>()
           .HasOne<ChatAppModel>(s => s.ChatAppModel)
           .WithMany(g => g.MessageModels) 
           .HasForeignKey(s => s.korisnik_korisnikID); 

            modelBuilder.Entity<ChatAppModel>(entity =>
            {
                entity.ToTable("ChatAppModel");



                entity.Property(e => e.korisnik_korisnicko_ime)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.korisnik_email)
                   .HasMaxLength(100)
                   .IsUnicode(false);


                entity.Property(e => e.korisnik_sifra)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            
        }*/

    }


}
