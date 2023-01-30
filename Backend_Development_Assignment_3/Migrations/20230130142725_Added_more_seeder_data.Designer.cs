﻿// <auto-generated />
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
    [Migration("20230130142725_Added_more_seeder_data")]
    partial class Added_more_seeder_data
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

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
                        });
                });

            modelBuilder.Entity("Backend_Development_Assignment_3.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FranchiseId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrailerUrl")
                        .HasColumnType("nvarchar(max)");

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
                        });
                });

            modelBuilder.Entity("Backend_Development_Assignment_3.Models.Movie", b =>
                {
                    b.HasOne("Backend_Development_Assignment_3.Models.Franchise", "Franchise")
                        .WithMany("Movies")
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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