﻿// <auto-generated />
using System;
using EduMaterialsDb.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EduMaterialsDb.Migrations
{
    [DbContext(typeof(EduMaterialsDbContext))]
    partial class EduMaterialsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EduMaterialsDb.Models.Entities.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(144)
                        .HasColumnType("nvarchar(144)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("EduMaterialsDb.Models.Entities.EduMaterial", b =>
                {
                    b.Property<int>("EduMaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EduMaterialId"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(144)
                        .HasColumnType("nvarchar(144)");

                    b.Property<int>("EduMaterialTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime>("PublishDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("EduMaterialId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("EduMaterialTypeId");

                    b.ToTable("EduMaterials");
                });

            modelBuilder.Entity("EduMaterialsDb.Models.Entities.EduMaterialReview", b =>
                {
                    b.Property<int>("EduMaterialReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EduMaterialReviewId"), 1L, 1);

                    b.Property<int>("EduMaterialId")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasMaxLength(144)
                        .HasColumnType("nvarchar(144)");

                    b.Property<int>("ReviewScore")
                        .HasColumnType("int");

                    b.HasKey("EduMaterialReviewId");

                    b.HasIndex("EduMaterialId");

                    b.ToTable("EduMaterialReviews");
                });

            modelBuilder.Entity("EduMaterialsDb.Models.Entities.EduMaterialType", b =>
                {
                    b.Property<int>("EduMaterialTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EduMaterialTypeId"), 1L, 1);

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasMaxLength(144)
                        .HasColumnType("nvarchar(144)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("EduMaterialTypeId");

                    b.ToTable("EduMaterialTypes");
                });

            modelBuilder.Entity("EduMaterialsDb.Models.Entities.EduMaterial", b =>
                {
                    b.HasOne("EduMaterialsDb.Models.Entities.Author", "Author")
                        .WithMany("EduMaterials")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EduMaterialsDb.Models.Entities.EduMaterialType", "EduMaterialType")
                        .WithMany()
                        .HasForeignKey("EduMaterialTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("EduMaterialType");
                });

            modelBuilder.Entity("EduMaterialsDb.Models.Entities.EduMaterialReview", b =>
                {
                    b.HasOne("EduMaterialsDb.Models.Entities.EduMaterial", "EduMaterial")
                        .WithMany("EduMaterialReviews")
                        .HasForeignKey("EduMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EduMaterial");
                });

            modelBuilder.Entity("EduMaterialsDb.Models.Entities.Author", b =>
                {
                    b.Navigation("EduMaterials");
                });

            modelBuilder.Entity("EduMaterialsDb.Models.Entities.EduMaterial", b =>
                {
                    b.Navigation("EduMaterialReviews");
                });
#pragma warning restore 612, 618
        }
    }
}
