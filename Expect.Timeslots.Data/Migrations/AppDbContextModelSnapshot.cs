﻿// <auto-generated />
using System;
using Expect.Timeslots.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Expect.Timeslots.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Expect.Timeslots.Domain.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid?>("PlatformId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlatformId");

                    b.ToTable("Companys");
                });

            modelBuilder.Entity("Expect.Timeslots.Domain.Models.CompanySchedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<int[]>("DayOfWeeks")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<TimeOnly>("From")
                        .HasColumnType("time without time zone");

                    b.Property<int>("MaxTaskCount")
                        .HasColumnType("integer");

                    b.Property<int[]>("TaskTypes")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<TimeOnly>("To")
                        .HasColumnType("time without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanySchedules");
                });

            modelBuilder.Entity("Expect.Timeslots.Domain.Models.Gate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<Guid>("PlatformId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlatformId");

                    b.ToTable("Gates");
                });

            modelBuilder.Entity("Expect.Timeslots.Domain.Models.GateSchedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int[]>("DayOfWeeks")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<TimeOnly>("From")
                        .HasColumnType("time without time zone");

                    b.Property<Guid>("GateId")
                        .HasColumnType("uuid");

                    b.Property<int[]>("TaskTypes")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<TimeOnly>("To")
                        .HasColumnType("time without time zone");

                    b.HasKey("Id");

                    b.HasIndex("GateId");

                    b.ToTable("GateSchedules");
                });

            modelBuilder.Entity("Expect.Timeslots.Domain.Models.Platform", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("Expect.Timeslots.Domain.Models.Timeslot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("From")
                        .HasColumnType("time without time zone");

                    b.Property<Guid>("GateId")
                        .HasColumnType("uuid");

                    b.Property<int>("TaskType")
                        .HasColumnType("integer");

                    b.Property<TimeOnly>("To")
                        .HasColumnType("time without time zone");

                    b.HasKey("Id");

                    b.HasIndex("GateId");

                    b.ToTable("Timeslots");
                });

            modelBuilder.Entity("Expect.Timeslots.Domain.Models.Company", b =>
                {
                    b.HasOne("Expect.Timeslots.Domain.Models.Platform", null)
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Expect.Timeslots.Domain.Models.CompanySchedule", b =>
                {
                    b.HasOne("Expect.Timeslots.Domain.Models.Company", null)
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Expect.Timeslots.Domain.Models.Gate", b =>
                {
                    b.HasOne("Expect.Timeslots.Domain.Models.Platform", null)
                        .WithMany("Gates")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Expect.Timeslots.Domain.Models.GateSchedule", b =>
                {
                    b.HasOne("Expect.Timeslots.Domain.Models.Gate", null)
                        .WithMany()
                        .HasForeignKey("GateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Expect.Timeslots.Domain.Models.Timeslot", b =>
                {
                    b.HasOne("Expect.Timeslots.Domain.Models.Gate", null)
                        .WithMany()
                        .HasForeignKey("GateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Expect.Timeslots.Domain.Models.Platform", b =>
                {
                    b.Navigation("Gates");
                });
#pragma warning restore 612, 618
        }
    }
}
