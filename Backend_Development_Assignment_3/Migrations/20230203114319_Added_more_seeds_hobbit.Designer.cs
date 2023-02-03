﻿// <auto-generated />
using System;
using Backend_Development_Assignment_3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend_Development_Assignment_3.Migrations
{
    [DbContext(typeof(DataStoreDbContext))]
    [Migration("20230203114319_Added_more_seeds_hobbit")]
    partial class Added_more_seeds_hobbit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Backend_Development_Assignment_3.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Alias")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("PictureUrl")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alias = "null",
                            FullName = "Frodo Baggins",
                            Gender = 0,
                            PictureUrl = "https://static.wikia.nocookie.net/lotr/images/3/32/Frodo_%28FotR%29.png/revision/latest?cb=20221006065757"
                        },
                        new
                        {
                            Id = 2,
                            Alias = "null",
                            FullName = "Arwen",
                            Gender = 1,
                            PictureUrl = "https://static.wikia.nocookie.net/lotr/images/6/64/Arwen_-_The_Fellowship_Of_The_Ring.jpg/revision/latest/scale-to-width-down/322?cb=20210625164207"
                        },
                        new
                        {
                            Id = 3,
                            Alias = "null",
                            FullName = "Aragorn",
                            Gender = 0,
                            PictureUrl = "https://static.wikia.nocookie.net/lotr/images/b/b6/Aragorn_profile.jpg/revision/latest/scale-to-width-down/333?cb=20170121121423"
                        },
                        new
                        {
                            Id = 4,
                            Alias = "null",
                            FullName = "Darth Vader",
                            Gender = 0,
                            PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/32/Star_Wars_-_Darth_Vader.jpg/375px-Star_Wars_-_Darth_Vader.jpg"
                        },
                        new
                        {
                            Id = 5,
                            Alias = "null",
                            FullName = "Sophie",
                            Gender = 1,
                            PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/47/Amanda_Seyfried_%282019%29.jpg/375px-Amanda_Seyfried_%282019%29.jpg"
                        },
                        new
                        {
                            Id = 6,
                            Alias = "null",
                            FullName = "Ron Weasley",
                            Gender = 1,
                            PictureUrl = "https://upload.wikimedia.org/wikipedia/en/5/5e/Ron_Weasley_poster.jpg"
                        },
                        new
                        {
                            Id = 7,
                            Alias = "null",
                            FullName = "Bilbo Baggins",
                            Gender = 0,
                            PictureUrl = "https://static01.nyt.com/images/2012/12/14/arts/14HOBBIT/14HOBBIT-superJumbo.jpg"
                        },
                        new
                        {
                            Id = 8,
                            Alias = "null",
                            FullName = "Smaug",
                            Gender = 0,
                            PictureUrl = "https://static.wikia.nocookie.net/lotr/images/6/6a/%22And_do_you_now%3F%22.JPG/revision/latest?cb=20210913160938"
                        });
                });

            modelBuilder.Entity("Backend_Development_Assignment_3.Models.Franchise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Franchises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Frodo takes a ring to a mountain",
                            Name = "Lord of the rings"
                        },
                        new
                        {
                            Id = 2,
                            Description = "A Fascist government led by two religious fanatics with superpowers, is overthrown by a terrorist organisation supporting another off-shoot branch of religious fanatics with superpowers (who kidnap infants to indoctrinate them) and one of their heroes is space big-foot.",
                            Name = "Star Wars"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Singing in Greece",
                            Name = "Mamma mia"
                        },
                        new
                        {
                            Id = 4,
                            Description = "You are a wizard harry",
                            Name = "Harry Potter"
                        });
                });

            modelBuilder.Entity("Backend_Development_Assignment_3.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Director")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int?>("FranchiseId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PictureUrl")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TrailerUrl")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Director = "Peter Jackson",
                            FranchiseId = 1,
                            Genre = "Fantasy",
                            PictureUrl = "https://m.media-amazon.com/images/M/MV5BN2EyZjM3NzUtNWUzMi00MTgxLWI0NTctMzY4M2VlOTdjZWRiXkEyXkFqcGdeQXVyNDUzOTQ5MjY@._V1_.jpg",
                            ReleaseYear = 2001,
                            Title = "The Fellowship of the Ring",
                            TrailerUrl = "https://www.youtube.com/watch?v=V75dMMIW2B4"
                        },
                        new
                        {
                            Id = 2,
                            Director = "George Lucas",
                            FranchiseId = 2,
                            Genre = "Science fiction,Fantasy",
                            PictureUrl = "https://static.bokelskere.no/452990425bf3ebf21bbd5132dc0907472ee5a1f237f528af34fe14d1.jpeg",
                            ReleaseYear = 2002,
                            Title = "Star Wars: Episode II — Attack of the Clones",
                            TrailerUrl = "https://www.youtube.com/watch?v=gYbW1F_c9eM"
                        },
                        new
                        {
                            Id = 3,
                            Director = "Phyllida Lloyd",
                            FranchiseId = 3,
                            Genre = "Musical",
                            PictureUrl = "https://m.media-amazon.com/images/M/MV5BMTA2MDU0MjM0MzReQTJeQWpwZ15BbWU3MDYwNzgwNzE@._V1_.jpg",
                            ReleaseYear = 2008,
                            Title = "Mamma Mia",
                            TrailerUrl = "https://www.youtube.com/watch?v=lkN-A00WLYE"
                        },
                        new
                        {
                            Id = 4,
                            Director = "Carolynne Cunningham",
                            FranchiseId = 1,
                            Genre = "Fantasy",
                            PictureUrl = "https://static1.colliderimages.com/wordpress/wp-content/uploads/2021/08/the-hobbit-an-unexpected-journey.jpg?q=50&fit=contain&w=1140&h=&dpr=1.5",
                            ReleaseYear = 2012,
                            Title = "The Hobbit - an unexpected journey",
                            TrailerUrl = "https://www.youtube.com/watch?v=SDnYMbYB-nU"
                        });
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("CharacterMovie");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            MoviesId = 1
                        },
                        new
                        {
                            CharacterId = 2,
                            MoviesId = 1
                        },
                        new
                        {
                            CharacterId = 3,
                            MoviesId = 1
                        },
                        new
                        {
                            CharacterId = 4,
                            MoviesId = 2
                        },
                        new
                        {
                            CharacterId = 5,
                            MoviesId = 3
                        },
                        new
                        {
                            CharacterId = 7,
                            MoviesId = 1
                        },
                        new
                        {
                            CharacterId = 7,
                            MoviesId = 4
                        },
                        new
                        {
                            CharacterId = 8,
                            MoviesId = 4
                        });
                });

            modelBuilder.Entity("Backend_Development_Assignment_3.Models.Movie", b =>
                {
                    b.HasOne("Backend_Development_Assignment_3.Models.Franchise", "Franchise")
                        .WithMany("Movies")
                        .HasForeignKey("FranchiseId");

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.HasOne("Backend_Development_Assignment_3.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend_Development_Assignment_3.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend_Development_Assignment_3.Models.Franchise", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
