﻿// <auto-generated />
using System;
using IceJamsDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IceJamsDB.Migrations
{
    [DbContext(typeof(IceJamsDBContext))]
    partial class IceJamsDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("icejam")
                .HasAnnotation("Npgsql:PostgresExtension:postgis", "'postgis', '', ''")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("IceJamsDB.Resources.Agency", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasMaxLength(6);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Agencies");
                });

            modelBuilder.Entity("IceJamsDB.Resources.Damage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DamageTypeID");

                    b.Property<DateTime>("DateTimeReported");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("IceJamID");

                    b.Property<DateTime>("LastModified");

                    b.HasKey("ID");

                    b.HasIndex("DamageTypeID");

                    b.HasIndex("IceJamID");

                    b.ToTable("Damages");
                });

            modelBuilder.Entity("IceJamsDB.Resources.DamageType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("ExampleImageURL");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("DamageTypes");
                });

            modelBuilder.Entity("IceJamsDB.Resources.File", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DamageID");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("FileTypeID");

                    b.Property<int>("IceJamID");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("URL")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("DamageID");

                    b.HasIndex("FileTypeID");

                    b.HasIndex("IceJamID");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("IceJamsDB.Resources.FileType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("FileTypes");
                });

            modelBuilder.Entity("IceJamsDB.Resources.IceCondition", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments");

                    b.Property<DateTime>("DateTime");

                    b.Property<Point>("DownstreamEndLocation");

                    b.Property<int>("IceConditionTypeID");

                    b.Property<int>("IceJamID");

                    b.Property<bool>("IsChanging");

                    b.Property<bool>("IsEstimated");

                    b.Property<DateTime>("LastModified");

                    b.Property<double>("Measurement");

                    b.Property<int>("RoughnessTypeID");

                    b.Property<Point>("UpstreamEndLocation");

                    b.HasKey("ID");

                    b.HasIndex("IceConditionTypeID");

                    b.HasIndex("IceJamID");

                    b.HasIndex("RoughnessTypeID");

                    b.ToTable("IceConditions");
                });

            modelBuilder.Entity("IceJamsDB.Resources.IceConditionType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("IceConditionTypes");
                });

            modelBuilder.Entity("IceJamsDB.Resources.IceJam", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("JamTypeID");

                    b.Property<DateTime>("LastModified");

                    b.Property<DateTime>("ObservationDateTime");

                    b.Property<int>("ObserverID");

                    b.Property<int>("SiteID");

                    b.HasKey("ID");

                    b.HasIndex("JamTypeID");

                    b.HasIndex("ObserverID");

                    b.HasIndex("SiteID");

                    b.ToTable("IceJams");
                });

            modelBuilder.Entity("IceJamsDB.Resources.JamType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("ExampleImageURL");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("JamTypes");
                });

            modelBuilder.Entity("IceJamsDB.Resources.Observer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AgencyID");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("OtherInfo");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PrimaryPhone");

                    b.Property<int>("RoleID");

                    b.Property<string>("Salt")
                        .IsRequired();

                    b.Property<string>("SecondaryPhone");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("AgencyID");

                    b.HasIndex("RoleID");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Observers");
                });

            modelBuilder.Entity("IceJamsDB.Resources.RiverCondition", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments");

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("IceJamID");

                    b.Property<bool?>("IsChanging");

                    b.Property<bool?>("IsFlooding");

                    b.Property<DateTime>("LastModified");

                    b.Property<double?>("Measurement");

                    b.Property<int>("RiverConditionTypeID");

                    b.Property<int?>("StageTypeID");

                    b.HasKey("ID");

                    b.HasIndex("IceJamID");

                    b.HasIndex("RiverConditionTypeID");

                    b.HasIndex("StageTypeID");

                    b.ToTable("RiverConditions");
                });

            modelBuilder.Entity("IceJamsDB.Resources.RiverConditionType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("RiverConditionTypes");
                });

            modelBuilder.Entity("IceJamsDB.Resources.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("IceJamsDB.Resources.RoughnessType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("RoughnessTypes");
                });

            modelBuilder.Entity("IceJamsDB.Resources.Site", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AHPSID");

                    b.Property<string>("Comments");

                    b.Property<string>("County")
                        .IsRequired();

                    b.Property<int>("HUC");

                    b.Property<string>("Landmarks");

                    b.Property<DateTime>("LastModified");

                    b.Property<Point>("Location")
                        .IsRequired();

                    b.Property<int>("Name");

                    b.Property<string>("RiverName")
                        .IsRequired();

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("USGSID");

                    b.HasKey("ID");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("IceJamsDB.Resources.StageType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("StageTypes");
                });

            modelBuilder.Entity("IceJamsDB.Resources.WeatherCondition", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments")
                        .IsRequired();

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("IceJamID");

                    b.Property<bool>("IsChanging");

                    b.Property<bool>("IsEstimated");

                    b.Property<DateTime>("LastModified");

                    b.Property<double>("Measurement");

                    b.Property<int>("WeatherConditionTypeID");

                    b.HasKey("ID");

                    b.HasIndex("IceJamID");

                    b.HasIndex("WeatherConditionTypeID");

                    b.ToTable("WeatherConditions");
                });

            modelBuilder.Entity("IceJamsDB.Resources.WeatherConditionType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("WeatherConditionTypes");
                });

            modelBuilder.Entity("IceJamsDB.Resources.Damage", b =>
                {
                    b.HasOne("IceJamsDB.Resources.DamageType", "Type")
                        .WithMany()
                        .HasForeignKey("DamageTypeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IceJamsDB.Resources.IceJam")
                        .WithMany("Damages")
                        .HasForeignKey("IceJamID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IceJamsDB.Resources.File", b =>
                {
                    b.HasOne("IceJamsDB.Resources.Damage")
                        .WithMany("Files")
                        .HasForeignKey("DamageID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IceJamsDB.Resources.FileType", "Type")
                        .WithMany()
                        .HasForeignKey("FileTypeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IceJamsDB.Resources.IceJam")
                        .WithMany("Files")
                        .HasForeignKey("IceJamID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IceJamsDB.Resources.IceCondition", b =>
                {
                    b.HasOne("IceJamsDB.Resources.IceConditionType", "Type")
                        .WithMany()
                        .HasForeignKey("IceConditionTypeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IceJamsDB.Resources.IceJam")
                        .WithMany("IceConditions")
                        .HasForeignKey("IceJamID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IceJamsDB.Resources.RoughnessType", "RoughnessType")
                        .WithMany()
                        .HasForeignKey("RoughnessTypeID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("IceJamsDB.Resources.IceJam", b =>
                {
                    b.HasOne("IceJamsDB.Resources.JamType", "Type")
                        .WithMany()
                        .HasForeignKey("JamTypeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IceJamsDB.Resources.Observer", "Observer")
                        .WithMany()
                        .HasForeignKey("ObserverID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IceJamsDB.Resources.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("IceJamsDB.Resources.Observer", b =>
                {
                    b.HasOne("IceJamsDB.Resources.Agency", "Agency")
                        .WithMany()
                        .HasForeignKey("AgencyID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IceJamsDB.Resources.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("IceJamsDB.Resources.RiverCondition", b =>
                {
                    b.HasOne("IceJamsDB.Resources.IceJam")
                        .WithMany("RiverConditions")
                        .HasForeignKey("IceJamID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IceJamsDB.Resources.RiverConditionType", "Type")
                        .WithMany()
                        .HasForeignKey("RiverConditionTypeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IceJamsDB.Resources.StageType", "StageType")
                        .WithMany()
                        .HasForeignKey("StageTypeID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("IceJamsDB.Resources.WeatherCondition", b =>
                {
                    b.HasOne("IceJamsDB.Resources.IceJam")
                        .WithMany("WeatherConditions")
                        .HasForeignKey("IceJamID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IceJamsDB.Resources.WeatherConditionType", "Type")
                        .WithMany()
                        .HasForeignKey("WeatherConditionTypeID")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
