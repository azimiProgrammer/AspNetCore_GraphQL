﻿// <auto-generated />
using GraphQLApi.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GraphQLApi.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220429125149_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("GraphQLApi.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Instructor")
                        .HasColumnType("TEXT");

                    b.Property<string>("Level")
                        .HasColumnType("TEXT");

                    b.Property<int>("PaymentType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("GraphQLApi.Entities.Lecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("SectionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SeqNo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("Lecture");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Lecture");
                });

            modelBuilder.Entity("GraphQLApi.Entities.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Review")
                        .HasColumnType("TEXT");

                    b.Property<int>("StarValue")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StudentName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("GraphQLApi.Entities.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SeqNo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("GraphQLApi.Entities.Assignment", b =>
                {
                    b.HasBaseType("GraphQLApi.Entities.Lecture");

                    b.Property<string>("Instructions")
                        .HasColumnType("TEXT");

                    b.Property<string>("Questions")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Assignment");
                });

            modelBuilder.Entity("GraphQLApi.Entities.Subject", b =>
                {
                    b.HasBaseType("GraphQLApi.Entities.Lecture");

                    b.Property<string>("MediaUrl")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Subject");
                });

            modelBuilder.Entity("GraphQLApi.Entities.Lecture", b =>
                {
                    b.HasOne("GraphQLApi.Entities.Section", null)
                        .WithMany("Lectures")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GraphQLApi.Entities.Rating", b =>
                {
                    b.HasOne("GraphQLApi.Entities.Course", null)
                        .WithMany("Ratings")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GraphQLApi.Entities.Course", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("GraphQLApi.Entities.Section", b =>
                {
                    b.Navigation("Lectures");
                });
#pragma warning restore 612, 618
        }
    }
}
