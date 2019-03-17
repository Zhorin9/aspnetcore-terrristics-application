﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web.Data.Entities;

namespace Web.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190315102506_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Web.Data.Entities.InputSensorData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValue(new DateTime(2019, 3, 15, 11, 25, 6, 77, DateTimeKind.Local));

                    b.Property<int>("SensorBlockId");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("SensorBlockId");

                    b.ToTable("InputSensorData");
                });

            modelBuilder.Entity("Web.Data.Entities.OutputSensorData", b =>
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

            modelBuilder.Entity("Web.Data.Entities.SensorBlock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("ParrentWindowId");

                    b.Property<byte>("PositionId");

                    b.Property<int>("SensorKindId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ParrentWindowId");

                    b.HasIndex("SensorKindId");

                    b.ToTable("Sensor");
                });

            modelBuilder.Entity("Web.Data.Entities.SensorKind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<byte>("Type");

                    b.HasKey("Id");

                    b.ToTable("SensorKind");
                });

            modelBuilder.Entity("Web.Data.Entities.TerraristicWindow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("ApiKey")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new Guid("ce2515c6-651f-44f9-8305-0be32ea323d1"));

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValue(new DateTime(2019, 3, 15, 11, 25, 6, 91, DateTimeKind.Local));

                    b.Property<DateTime>("ModificationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2019, 3, 15, 11, 25, 6, 91, DateTimeKind.Local));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("TerraristicWindow");
                });

            modelBuilder.Entity("Web.Data.Entities.InputSensorData", b =>
                {
                    b.HasOne("Web.Data.Entities.SensorBlock", "SensorBlock")
                        .WithMany("Inputs")
                        .HasForeignKey("SensorBlockId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Web.Data.Entities.OutputSensorData", b =>
                {
                    b.HasOne("Web.Data.Entities.SensorBlock", "SensorBlock")
                        .WithMany("Outputs")
                        .HasForeignKey("SensorBlockId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Web.Data.Entities.SensorBlock", b =>
                {
                    b.HasOne("Web.Data.Entities.TerraristicWindow", "ParrentWindow")
                        .WithMany("SensorBlocks")
                        .HasForeignKey("ParrentWindowId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Web.Data.Entities.SensorKind", "SensorKind")
                        .WithMany()
                        .HasForeignKey("SensorKindId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}