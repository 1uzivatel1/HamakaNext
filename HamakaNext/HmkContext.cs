using HamakaNext.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace HamakaNext
{
    public class HmkContext:DbContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseMySQL("server=localhost;database=Hamaka;user=root;password=hamaka");
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Email).IsRequired();

            });

            modelBuilder.Entity<Book>
            (entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Author);
                entity.Property(e => e.Title);
                entity.Property(e => e.Published);
                entity.Property(e => e.PageCount);
                entity.HasOne(d => d.User).WithMany(d => d.Books);
            }    
                );
        }

        public DbSet<HamakaNext.Models.Book> Book { get; set; }
    }

}
