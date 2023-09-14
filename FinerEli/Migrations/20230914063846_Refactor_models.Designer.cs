﻿// <auto-generated />
using FinerEli.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinerEli.Migrations
{
    [DbContext(typeof(FoodsContext))]
    [Migration("20230914063846_Refactor_models")]
    partial class Refactor_models
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("FinerEli.Models.ComponentClass", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.ToTable("ComponentClasses");
                });

            modelBuilder.Entity("FinerEli.Models.ComponentUnit", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.ToTable("ComponentUnits");
                });

            modelBuilder.Entity("FinerEli.Models.ComponentValue", b =>
                {
                    b.Property<int>("FoodId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EufdNameThsCode")
                        .HasColumnType("TEXT");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("FoodId", "EufdNameThsCode");

                    b.HasIndex("EufdNameThsCode");

                    b.ToTable("ComponentValues");
                });

            modelBuilder.Entity("FinerEli.Models.EufdName", b =>
                {
                    b.Property<string>("ThsCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ThsCode");

                    b.ToTable("EufdNames");
                });

            modelBuilder.Entity("FinerEli.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("FinerEli.Models.ComponentValue", b =>
                {
                    b.HasOne("FinerEli.Models.EufdName", "EufdName")
                        .WithMany()
                        .HasForeignKey("EufdNameThsCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinerEli.Models.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EufdName");

                    b.Navigation("Food");
                });
#pragma warning restore 612, 618
        }
    }
}