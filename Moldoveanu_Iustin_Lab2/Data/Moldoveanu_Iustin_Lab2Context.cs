using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moldoveanu_Iustin_Lab2.Models;

namespace Moldoveanu_Iustin_Lab2.Data
{
    public class Moldoveanu_Iustin_Lab2Context : DbContext
    {
        public Moldoveanu_Iustin_Lab2Context (DbContextOptions<Moldoveanu_Iustin_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Moldoveanu_Iustin_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Moldoveanu_Iustin_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Moldoveanu_Iustin_Lab2.Models.Author> Authors { get; set; } = default!;
        public DbSet<Moldoveanu_Iustin_Lab2.Models.Category> Category { get; set; } = default!;
        public DbSet<Moldoveanu_Iustin_Lab2.Models.BookCategory> BookCategory { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookID, bc.CategoryID });

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookID);

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryID);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Borrowing)
                .WithOne(br => br.Book)
                .HasForeignKey<Borrowing>(br => br.BookID);

            modelBuilder.Entity<Borrowing>()
                .HasOne(br => br.Member)
                .WithMany(m => m.Borrowings)
                .HasForeignKey(br => br.MemberID);
        }
        public DbSet<Moldoveanu_Iustin_Lab2.Models.Member> Member { get; set; } = default!;
        public DbSet<Moldoveanu_Iustin_Lab2.Models.Borrowing> Borrowing { get; set; } = default!;
    }

}
