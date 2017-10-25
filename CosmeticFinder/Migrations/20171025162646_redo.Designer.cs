﻿// <auto-generated />
using CosmeticFinder.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CosmeticFinder.Migrations
{
    [DbContext(typeof(CosmeticDbContext))]
    [Migration("20171025162646_redo")]
    partial class redo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CosmeticFinder.Models.Color", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value");

                    b.HasKey("ID");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("CosmeticFinder.Models.Cosmetic", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ColorID");

                    b.Property<string>("Description");

                    b.Property<int>("FinishID");

                    b.Property<int>("FormulationID");

                    b.Property<string>("Name");

                    b.Property<int>("RatingID");

                    b.Property<int>("SkinTypeID");

                    b.HasKey("ID");

                    b.HasIndex("ColorID");

                    b.HasIndex("FinishID");

                    b.HasIndex("FormulationID");

                    b.HasIndex("RatingID");

                    b.HasIndex("SkinTypeID");

                    b.ToTable("Cosmetics");
                });

            modelBuilder.Entity("CosmeticFinder.Models.CosmeticBag", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("userID");

                    b.HasKey("ID");

                    b.ToTable("CosmeticBags");
                });

            modelBuilder.Entity("CosmeticFinder.Models.CosmeticBag_Items", b =>
                {
                    b.Property<int>("CosmeticID");

                    b.Property<int>("CosmeticBagID");

                    b.HasKey("CosmeticID", "CosmeticBagID");

                    b.HasIndex("CosmeticBagID");

                    b.ToTable("CosmeticBag_Items");
                });

            modelBuilder.Entity("CosmeticFinder.Models.Finish", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value");

                    b.HasKey("ID");

                    b.ToTable("Finishs");
                });

            modelBuilder.Entity("CosmeticFinder.Models.Formulation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value");

                    b.HasKey("ID");

                    b.ToTable("Formulations");
                });

            modelBuilder.Entity("CosmeticFinder.Models.Rating", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value");

                    b.HasKey("ID");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("CosmeticFinder.Models.SkinType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value");

                    b.HasKey("ID");

                    b.ToTable("SkinTypes");
                });

            modelBuilder.Entity("CosmeticFinder.Models.Cosmetic", b =>
                {
                    b.HasOne("CosmeticFinder.Models.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CosmeticFinder.Models.Finish", "Finish")
                        .WithMany()
                        .HasForeignKey("FinishID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CosmeticFinder.Models.Formulation", "Formulation")
                        .WithMany()
                        .HasForeignKey("FormulationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CosmeticFinder.Models.Rating", "Rating")
                        .WithMany()
                        .HasForeignKey("RatingID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CosmeticFinder.Models.SkinType", "SkinType")
                        .WithMany()
                        .HasForeignKey("SkinTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CosmeticFinder.Models.CosmeticBag_Items", b =>
                {
                    b.HasOne("CosmeticFinder.Models.CosmeticBag", "CosmeticBag")
                        .WithMany("cosmetics_items")
                        .HasForeignKey("CosmeticBagID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CosmeticFinder.Models.Cosmetic", "Cosmetic")
                        .WithMany()
                        .HasForeignKey("CosmeticID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
