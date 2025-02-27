﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentClassLibrary;

#nullable disable

namespace StudentClassLibrary.Migrations
{
    [DbContext(typeof(StudentAndModulesDb))]
    partial class StudentAndModulesDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("StudentClassLibrary.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Department")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lecturer")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("StudentClassLibrary.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentClassLibrary.StudentModule", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModuleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentId", "ModuleId");

                    b.HasIndex("ModuleId");

                    b.ToTable("StudentModules");
                });

            modelBuilder.Entity("StudentClassLibrary.StudentModule", b =>
                {
                    b.HasOne("StudentClassLibrary.Module", "FK_Module")
                        .WithMany("StudentModules")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentClassLibrary.Student", "FK_Student")
                        .WithMany("StudentModules")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FK_Module");

                    b.Navigation("FK_Student");
                });

            modelBuilder.Entity("StudentClassLibrary.Module", b =>
                {
                    b.Navigation("StudentModules");
                });

            modelBuilder.Entity("StudentClassLibrary.Student", b =>
                {
                    b.Navigation("StudentModules");
                });
#pragma warning restore 612, 618
        }
    }
}
