﻿// <auto-generated />
using System;
using ITIWebApi.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ITIWebApi.Migrations
{
    [DbContext(typeof(ITIContext))]
    partial class ITIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ITIWebApi.Models.Course", b =>
                {
                    b.Property<int>("Crs_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Crs_Id"));

                    b.Property<int?>("Crs_Duration")
                        .HasColumnType("int");

                    b.Property<string>("Crs_Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Top_Id")
                        .HasColumnType("int");

                    b.HasKey("Crs_Id");

                    b.HasIndex("Top_Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("ITIWebApi.Models.Department", b =>
                {
                    b.Property<int>("Dept_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Dept_Id"));

                    b.Property<string>("Dept_Desc")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Dept_Location")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Dept_Manager")
                        .HasColumnType("int");

                    b.Property<string>("Dept_Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateOnly?>("Manager_hiredate")
                        .HasColumnType("date");

                    b.HasKey("Dept_Id");

                    b.HasIndex("Dept_Manager");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("ITIWebApi.Models.Ins_Course", b =>
                {
                    b.Property<int>("Ins_Id")
                        .HasColumnType("int");

                    b.Property<int>("Crs_Id")
                        .HasColumnType("int");

                    b.Property<string>("Evaluation")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Ins_Id", "Crs_Id");

                    b.HasIndex("Crs_Id");

                    b.ToTable("Ins_Course");
                });

            modelBuilder.Entity("ITIWebApi.Models.Instructor", b =>
                {
                    b.Property<int>("Ins_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ins_Id"));

                    b.Property<int?>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<string>("Ins_Degree")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ins_Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("money");

                    b.HasKey("Ins_Id");

                    b.HasIndex("Dept_Id");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("ITIWebApi.Models.Stud_Course", b =>
                {
                    b.Property<int>("Crs_Id")
                        .HasColumnType("int");

                    b.Property<int>("St_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Grade")
                        .HasColumnType("int");

                    b.HasKey("Crs_Id", "St_Id");

                    b.HasIndex("St_Id");

                    b.ToTable("Stud_Course");
                });

            modelBuilder.Entity("ITIWebApi.Models.Student", b =>
                {
                    b.Property<int>("St_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("St_Id"));

                    b.Property<int?>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<string>("St_Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("St_Age")
                        .HasColumnType("int");

                    b.Property<string>("St_Fname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("St_Lname")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("St_super")
                        .HasColumnType("int");

                    b.HasKey("St_Id");

                    b.HasIndex("Dept_Id");

                    b.HasIndex("St_super");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("ITIWebApi.Models.Topic", b =>
                {
                    b.Property<int>("Top_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Top_Id"));

                    b.Property<string>("Top_Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Top_Id");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("ITIWebApi.Models.stdDelHisto_audit", b =>
                {
                    b.Property<DateOnly?>("_date")
                        .HasColumnType("date");

                    b.Property<string>("_note")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("sreverName")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.ToTable("stdDelHisto_audit");
                });

            modelBuilder.Entity("ITIWebApi.Models.stdHisto_audit", b =>
                {
                    b.Property<DateOnly?>("_date")
                        .HasColumnType("date");

                    b.Property<string>("_note")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("srtverName")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.ToTable("stdHisto_audit");
                });

            modelBuilder.Entity("ITIWebApi.Models.Course", b =>
                {
                    b.HasOne("ITIWebApi.Models.Topic", "Top")
                        .WithMany("Courses")
                        .HasForeignKey("Top_Id");

                    b.Navigation("Top");
                });

            modelBuilder.Entity("ITIWebApi.Models.Department", b =>
                {
                    b.HasOne("ITIWebApi.Models.Instructor", "Dept_ManagerNavigation")
                        .WithMany("Departments")
                        .HasForeignKey("Dept_Manager");

                    b.Navigation("Dept_ManagerNavigation");
                });

            modelBuilder.Entity("ITIWebApi.Models.Ins_Course", b =>
                {
                    b.HasOne("ITIWebApi.Models.Course", "Crs")
                        .WithMany("Ins_Courses")
                        .HasForeignKey("Crs_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITIWebApi.Models.Instructor", "Ins")
                        .WithMany("Ins_Courses")
                        .HasForeignKey("Ins_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crs");

                    b.Navigation("Ins");
                });

            modelBuilder.Entity("ITIWebApi.Models.Instructor", b =>
                {
                    b.HasOne("ITIWebApi.Models.Department", "Dept")
                        .WithMany("Instructors")
                        .HasForeignKey("Dept_Id");

                    b.Navigation("Dept");
                });

            modelBuilder.Entity("ITIWebApi.Models.Stud_Course", b =>
                {
                    b.HasOne("ITIWebApi.Models.Course", "Crs")
                        .WithMany("Stud_Courses")
                        .HasForeignKey("Crs_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITIWebApi.Models.Student", "St")
                        .WithMany("Stud_Courses")
                        .HasForeignKey("St_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crs");

                    b.Navigation("St");
                });

            modelBuilder.Entity("ITIWebApi.Models.Student", b =>
                {
                    b.HasOne("ITIWebApi.Models.Department", "Dept")
                        .WithMany("Students")
                        .HasForeignKey("Dept_Id");

                    b.HasOne("ITIWebApi.Models.Student", "St_superNavigation")
                        .WithMany("InverseSt_superNavigation")
                        .HasForeignKey("St_super");

                    b.Navigation("Dept");

                    b.Navigation("St_superNavigation");
                });

            modelBuilder.Entity("ITIWebApi.Models.Course", b =>
                {
                    b.Navigation("Ins_Courses");

                    b.Navigation("Stud_Courses");
                });

            modelBuilder.Entity("ITIWebApi.Models.Department", b =>
                {
                    b.Navigation("Instructors");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("ITIWebApi.Models.Instructor", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Ins_Courses");
                });

            modelBuilder.Entity("ITIWebApi.Models.Student", b =>
                {
                    b.Navigation("InverseSt_superNavigation");

                    b.Navigation("Stud_Courses");
                });

            modelBuilder.Entity("ITIWebApi.Models.Topic", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
