using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLibaryAPI.Models
{
    public class LibaryDbContext : DbContext
    {
        public LibaryDbContext(DbContextOptions<LibaryDbContext> options) : base(options)
        {
        }

        public DbSet<Library> Books { get; set; }
        public DbSet<Loans> Loans { get; set; }
        public DbSet<Logins> Logins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Library>().HasData(new Library
            {
                BookId = 1,
                AuthorName = "Andrzej Sapkowski",
                BookName = "Wiedźmin - Tom 1.",
                ImageUrl = "https://ecsmedia.pl/c/ostatnie-zyczenie-wiedzmin-tom-1-b-iext34567993.jpg",
                ReleaseDate = "2019-04-30",
                AvailableBooks = 5
            });
            modelBuilder.Entity<Library>().HasData(new Library
            {
                BookId = 2,
                AuthorName = "Dmitry Glukhovsky",
                BookName = "Metro 2035",
                ImageUrl = "https://cdn-lubimyczytac.pl/upload/books/4864000/4864257/693344-352x500.jpg",
                ReleaseDate = "2015-05-18",
                AvailableBooks = 4
            });
            modelBuilder.Entity<Loans>().HasData(new Models.Loans
            {
                LoanId = 1,
                BookId = 1,
                ClientId = 0944234,
                ClientName = "Magdziak",
                ClientSurname = "Mateusz",
                LoanDate = "2019-04-04"
            });
        }


    }
}
