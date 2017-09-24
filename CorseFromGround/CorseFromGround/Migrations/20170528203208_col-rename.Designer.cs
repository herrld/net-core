﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CorseFromGround.DataAccess;

namespace CorseFromGround.Migrations
{
    [DbContext(typeof(WorldContext))]
    [Migration("20170528203208_col-rename")]
    partial class colrename
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CouseFromGround.DataModels.Stop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Arrival");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<int>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("Stops");
                });

            modelBuilder.Entity("CouseFromGround.DataModels.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Name");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("CouseFromGround.DataModels.Stop", b =>
                {
                    b.HasOne("CouseFromGround.DataModels.Trip", "Trip")
                        .WithMany("Stops")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
