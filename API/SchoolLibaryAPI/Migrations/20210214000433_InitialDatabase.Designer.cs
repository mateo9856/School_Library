﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolLibaryAPI.Models;

namespace SchoolLibaryAPI.Migrations
{
    [DbContext(typeof(LibaryDbContext))]
    [Migration("20210214000433_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("SchoolLibaryAPI.Models.Libary", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AuthorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AvailableBooks")
                        .HasColumnType("int");

                    b.Property<string>("BookName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReleaseDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            AuthorName = "Andrzej Sapkowski",
                            AvailableBooks = 5,
                            BookName = "Wiedźmin - Tom 1.",
                            ImageUrl = "https://ecsmedia.pl/c/ostatnie-zyczenie-wiedzmin-tom-1-b-iext34567993.jpg",
                            ReleaseDate = "2019-04-30"
                        },
                        new
                        {
                            BookId = 2,
                            AuthorName = "Dmitry Glukhovsky",
                            AvailableBooks = 4,
                            BookName = "Metro 2035",
                            ImageUrl = "https://cdn-lubimyczytac.pl/upload/books/4864000/4864257/693344-352x500.jpg",
                            ReleaseDate = "2015-05-18"
                        });
                });

            modelBuilder.Entity("SchoolLibaryAPI.Models.Loans", b =>
                {
                    b.Property<int>("LoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<long>("ClientId")
                        .HasColumnType("bigint");

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientSurname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoanDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoanId");

                    b.HasIndex("BookId");

                    b.ToTable("Loans");

                    b.HasData(
                        new
                        {
                            LoanId = 1,
                            BookId = 1,
                            ClientId = 944234L,
                            ClientName = "Magdziak",
                            ClientSurname = "Mateusz",
                            LoanDate = "2019-04-04"
                        });
                });

            modelBuilder.Entity("SchoolLibaryAPI.Models.Logins", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoginId");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("SchoolLibaryAPI.Models.Loans", b =>
                {
                    b.HasOne("SchoolLibaryAPI.Models.Libary", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });
#pragma warning restore 612, 618
        }
    }
}