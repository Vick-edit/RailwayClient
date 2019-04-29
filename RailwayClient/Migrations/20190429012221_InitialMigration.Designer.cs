﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RailwayClient.DataAccess.SettingsEF;

namespace RailwayClient.Migrations
{
    [DbContext(typeof(RailwayContext))]
    [Migration("20190429012221_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("RailwayClient.DataAccess.Entities.Railway", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("Code");

                    b.Property<int>("CountryId");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.Property<string>("TelegraphName");

                    b.HasKey("Id");

                    b.ToTable("Railways");
                });

            modelBuilder.Entity("RailwayClient.DataAccess.Entities.Station", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodeOSGD");

                    b.Property<int?>("CountryId");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<bool>("FreightSign");

                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .HasMaxLength(40);

                    b.Property<string>("Name12Char")
                        .HasMaxLength(12);

                    b.Property<int?>("RailwayDepartmentId");

                    b.Property<int?>("RailwayId");

                    b.HasKey("Code");

                    b.HasIndex("RailwayId");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("RailwayClient.DataAccess.Entities.Station", b =>
                {
                    b.HasOne("RailwayClient.DataAccess.Entities.Railway", "Railway")
                        .WithMany()
                        .HasForeignKey("RailwayId");
                });
#pragma warning restore 612, 618
        }
    }
}
