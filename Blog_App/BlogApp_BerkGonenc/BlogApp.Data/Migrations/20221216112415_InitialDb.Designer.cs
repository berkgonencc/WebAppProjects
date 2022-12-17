﻿// <auto-generated />
using System;
using BlogApp.Data.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlogApp.Data.Migrations
{
    [DbContext(typeof(MyAppContext))]
    [Migration("20221216112415_InitialDb")]
    partial class InitialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("BlogApp.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Slug")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Crypto Category",
                            IsDeleted = false,
                            IsPublished = false,
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency",
                            PublishedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Slug = "cryptocurrency"
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Artificial Intelligence Category",
                            IsDeleted = false,
                            IsPublished = false,
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Artificial Intelligence",
                            PublishedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Slug = "artificial-intelligence"
                        },
                        new
                        {
                            Id = 3,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Web3 Category",
                            IsDeleted = false,
                            IsPublished = false,
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Web3",
                            PublishedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Slug = "web3"
                        },
                        new
                        {
                            Id = 4,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Programming Category",
                            IsDeleted = false,
                            IsPublished = false,
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Programming",
                            PublishedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Slug = "programming"
                        });
                });

            modelBuilder.Entity("BlogApp.Entity.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CommentContent")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ParentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParentPostId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PostedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("ParentPostId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CommentContent = "Lorem ipsum dolor",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            IsPublished = false,
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ParentPostId = 1,
                            PublishedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CommentContent = "Lorem ipsum dolor",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            IsPublished = false,
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ParentId = 1,
                            ParentPostId = 1,
                            PublishedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CommentContent = "Lorem ipsum dolor",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            IsPublished = false,
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ParentId = 1,
                            ParentPostId = 1,
                            PublishedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            CommentContent = "Lorem ipsum dolor",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            IsPublished = false,
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ParentPostId = 2,
                            PublishedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            CommentContent = "Lorem ipsum dolor",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            IsPublished = false,
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ParentPostId = 3,
                            PublishedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("BlogApp.Entity.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostContent")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Slug")
                        .HasColumnType("TEXT");

                    b.Property<string>("Summary")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "1.png",
                            IsDeleted = false,
                            IsPublished = true,
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PostContent = "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.",
                            PublishedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Slug = "lorem-ipsum-dolor",
                            Summary = "Lorem ipsum dolor sit amet.",
                            Title = "Lorem ipsum dolor."
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "2.png",
                            IsDeleted = false,
                            IsPublished = true,
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PostContent = "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.",
                            PublishedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Slug = "lorem-ipsum-dolor",
                            Summary = "Lorem ipsum dolor sit amet.",
                            Title = "Lorem ipsum dolor."
                        },
                        new
                        {
                            Id = 3,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "3.png",
                            IsDeleted = false,
                            IsPublished = false,
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PostContent = "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.",
                            PublishedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Slug = "lorem-ipsum-dolor",
                            Summary = "Lorem ipsum dolor sit amet.",
                            Title = "Lorem ipsum dolor."
                        },
                        new
                        {
                            Id = 4,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "4.png",
                            IsDeleted = false,
                            IsPublished = true,
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PostContent = "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.",
                            PublishedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Slug = "lorem-ipsum-dolor",
                            Summary = "Lorem ipsum dolor sit amet.",
                            Title = "Lorem ipsum dolor."
                        },
                        new
                        {
                            Id = 5,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "5.png",
                            IsDeleted = false,
                            IsPublished = true,
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PostContent = "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.",
                            PublishedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Slug = "lorem-ipsum-dolor",
                            Summary = "Lorem ipsum dolor sit amet.",
                            Title = "Lorem ipsum dolor."
                        },
                        new
                        {
                            Id = 6,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "6.png",
                            IsDeleted = false,
                            IsPublished = true,
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PostContent = "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.",
                            PublishedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Slug = "lorem-ipsum-dolor",
                            Summary = "Lorem ipsum dolor sit amet.",
                            Title = "Lorem ipsum dolor."
                        },
                        new
                        {
                            Id = 7,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "7.png",
                            IsDeleted = false,
                            IsPublished = true,
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PostContent = "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.",
                            PublishedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Slug = "lorem-ipsum-dolor",
                            Summary = "Lorem ipsum dolor sit amet.",
                            Title = "Lorem ipsum dolor."
                        },
                        new
                        {
                            Id = 8,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "8.png",
                            IsDeleted = false,
                            IsPublished = true,
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PostContent = "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.",
                            PublishedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Slug = "lorem-ipsum-dolor",
                            Summary = "Lorem ipsum dolor sit amet.",
                            Title = "Lorem ipsum dolor."
                        },
                        new
                        {
                            Id = 9,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "9.png",
                            IsDeleted = false,
                            IsPublished = true,
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PostContent = "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.",
                            PublishedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Slug = "lorem-ipsum-dolor",
                            Summary = "Lorem ipsum dolor sit amet.",
                            Title = "Lorem ipsum dolor."
                        },
                        new
                        {
                            Id = 10,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "10.png",
                            IsDeleted = false,
                            IsPublished = true,
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PostContent = "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.",
                            PublishedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Slug = "lorem-ipsum-dolor",
                            Summary = "Lorem ipsum dolor sit amet.",
                            Title = "Lorem ipsum dolor."
                        });
                });

            modelBuilder.Entity("BlogApp.Entity.PostCategory", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PostId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("PostCategories");

                    b.HasData(
                        new
                        {
                            PostId = 1,
                            CategoryId = 1
                        },
                        new
                        {
                            PostId = 2,
                            CategoryId = 1
                        },
                        new
                        {
                            PostId = 3,
                            CategoryId = 1
                        },
                        new
                        {
                            PostId = 1,
                            CategoryId = 3
                        },
                        new
                        {
                            PostId = 2,
                            CategoryId = 3
                        },
                        new
                        {
                            PostId = 3,
                            CategoryId = 3
                        },
                        new
                        {
                            PostId = 4,
                            CategoryId = 3
                        },
                        new
                        {
                            PostId = 5,
                            CategoryId = 4
                        },
                        new
                        {
                            PostId = 6,
                            CategoryId = 4
                        },
                        new
                        {
                            PostId = 7,
                            CategoryId = 3
                        },
                        new
                        {
                            PostId = 8,
                            CategoryId = 3
                        },
                        new
                        {
                            PostId = 9,
                            CategoryId = 2
                        },
                        new
                        {
                            PostId = 10,
                            CategoryId = 2
                        });
                });

            modelBuilder.Entity("BlogApp.Entity.Comment", b =>
                {
                    b.HasOne("BlogApp.Entity.Comment", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("BlogApp.Entity.Post", "ParentPost")
                        .WithMany("Comments")
                        .HasForeignKey("ParentPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("ParentPost");
                });

            modelBuilder.Entity("BlogApp.Entity.PostCategory", b =>
                {
                    b.HasOne("BlogApp.Entity.Category", "Category")
                        .WithMany("PostCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlogApp.Entity.Post", "Post")
                        .WithMany("PostCategories")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("BlogApp.Entity.Category", b =>
                {
                    b.Navigation("PostCategories");
                });

            modelBuilder.Entity("BlogApp.Entity.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PostCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
