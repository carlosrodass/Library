﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyLibrary.Persistence.DataBaseContext;

#nullable disable

namespace MyLibrary.Persistence.Migrations
{
    [DbContext(typeof(LibraryDatabaseContext))]
    [Migration("20240216141143_setFieldToNullable")]
    partial class setFieldToNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyLibrary.Domain.Models.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AuthorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Isbn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("LibraryId")
                        .HasColumnType("bigint");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LibraryId");

                    b.HasIndex("StatusId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("MyLibrary.Domain.Models.KeyPoint", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ResumeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("KeyPoint");
                });

            modelBuilder.Entity("MyLibrary.Domain.Models.Library", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("AllBooksReaded")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Libraries");
                });

            modelBuilder.Entity("MyLibrary.Domain.Models.Resume", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long>("BookId")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ResumeTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ResumeTypeId");

                    b.ToTable("Resume");
                });

            modelBuilder.Entity("MyLibrary.Domain.Models.ResumeType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("ResumeTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Chapter"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Full"
                        });
                });

            modelBuilder.Entity("MyLibrary.Domain.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Status");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Private"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Public"
                        });
                });

            modelBuilder.Entity("MyLibrary.Domain.Models.Book", b =>
                {
                    b.HasOne("MyLibrary.Domain.Models.Library", "Library")
                        .WithMany("Books")
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MyLibrary.Domain.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Library");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("MyLibrary.Domain.Models.KeyPoint", b =>
                {
                    b.HasOne("MyLibrary.Domain.Models.Resume", "Resume")
                        .WithMany("KeyPoints")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("MyLibrary.Domain.Models.Library", b =>
                {
                    b.HasOne("MyLibrary.Domain.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("MyLibrary.Domain.Models.Resume", b =>
                {
                    b.HasOne("MyLibrary.Domain.Models.Book", "Book")
                        .WithMany("Resumes")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MyLibrary.Domain.Models.ResumeType", "ResumeType")
                        .WithMany()
                        .HasForeignKey("ResumeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("ResumeType");
                });

            modelBuilder.Entity("MyLibrary.Domain.Models.Book", b =>
                {
                    b.Navigation("Resumes");
                });

            modelBuilder.Entity("MyLibrary.Domain.Models.Library", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("MyLibrary.Domain.Models.Resume", b =>
                {
                    b.Navigation("KeyPoints");
                });
#pragma warning restore 612, 618
        }
    }
}
