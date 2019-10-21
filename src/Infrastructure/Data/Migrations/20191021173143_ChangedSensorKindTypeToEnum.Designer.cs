﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191021173143_ChangedSensorKindTypeToEnum")]
    partial class ChangedSensorKindTypeToEnum
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppCore.Entities.InputSensorData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValue(new DateTime(2019, 10, 21, 19, 31, 43, 753, DateTimeKind.Local));

                    b.Property<int>("SensorBlockId");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("SensorBlockId");

                    b.ToTable("InputSensorData");
                });

            modelBuilder.Entity("AppCore.Entities.OutputSensorData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SensorBlockId");

                    b.Property<byte>("State");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("SensorBlockId");

                    b.ToTable("OutputSensorData");
                });

            modelBuilder.Entity("AppCore.Entities.SensorBlock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("ParentWindowId");

                    b.Property<byte>("PositionId");

                    b.Property<int>("SensorKindId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ParentWindowId");

                    b.HasIndex("SensorKindId");

                    b.ToTable("Sensor");
                });

            modelBuilder.Entity("AppCore.Entities.SensorKind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("SensorKind");
                });

            modelBuilder.Entity("AppCore.Entities.TerraristicWindow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("ApiKey")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new Guid("44313a74-d595-4bf5-aeed-fd3528930e6a"));

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValue(new DateTime(2019, 10, 21, 19, 31, 43, 765, DateTimeKind.Local));

                    b.Property<string>("Description");

                    b.Property<DateTime>("ModificationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2019, 10, 21, 19, 31, 43, 766, DateTimeKind.Local));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("TerraristicWindow");
                });

            modelBuilder.Entity("AppCore.Entities.InputSensorData", b =>
                {
                    b.HasOne("AppCore.Entities.SensorBlock", "SensorBlock")
                        .WithMany("Inputs")
                        .HasForeignKey("SensorBlockId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AppCore.Entities.OutputSensorData", b =>
                {
                    b.HasOne("AppCore.Entities.SensorBlock", "SensorBlock")
                        .WithMany("Outputs")
                        .HasForeignKey("SensorBlockId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AppCore.Entities.SensorBlock", b =>
                {
                    b.HasOne("AppCore.Entities.TerraristicWindow", "ParentWindow")
                        .WithMany("SensorBlocks")
                        .HasForeignKey("ParentWindowId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AppCore.Entities.SensorKind", "SensorKind")
                        .WithMany()
                        .HasForeignKey("SensorKindId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
