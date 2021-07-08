﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SacramentMeetingPlanner.Data;

namespace SacramentMeetingPlanner.Migrations
{
    [DbContext(typeof(MeetingContext))]
    partial class MeetingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Meeting", b =>
                {
                    b.Property<int>("MeetingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClosingNumber")
                        .HasColumnType("int");

                    b.Property<string>("ClosingPrayerBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClosingSong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Conductor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IntermediateSong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IntermediateSongNumber")
                        .HasColumnType("int");

                    b.Property<string>("MusicalNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpeningPrayerBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpeningSong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OpeningSongNumber")
                        .HasColumnType("int");

                    b.Property<string>("SacramentSong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SacramentSongNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartAt")
                        .HasColumnType("datetime2");

                    b.HasKey("MeetingId");

                    b.ToTable("Meeting");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Speaker", b =>
                {
                    b.Property<int>("SpeakerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MeetingId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpeakerId");

                    b.ToTable("Speaker");
                });
#pragma warning restore 612, 618
        }
    }
}