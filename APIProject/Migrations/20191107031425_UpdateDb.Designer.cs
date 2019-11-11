﻿// <auto-generated />
using System;
using APIProject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIProject.Migrations
{
    [DbContext(typeof(LawyerAPIDBContext))]
    [Migration("20191107031425_UpdateDb")]
    partial class UpdateDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APIProject.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("District");

                    b.Property<string>("Division");

                    b.Property<string>("FullAddress");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Thana");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("APIProject.Models.ClientLawyerAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<int?>("ClientProfileId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<int>("LawyerId");

                    b.Property<int?>("LawyerProfileId");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("ClientProfileId");

                    b.HasIndex("LawyerProfileId");

                    b.ToTable("ClientLawyerAssignment");
                });

            modelBuilder.Entity("APIProject.Models.ClientProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Mobile")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("ClientProfile");
                });

            modelBuilder.Entity("APIProject.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DegreeName");

                    b.Property<string>("InstituteName");

                    b.Property<bool>("IsActive");

                    b.Property<int?>("LawyerProfileId");

                    b.Property<string>("Order");

                    b.Property<string>("Passyear");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("LawyerProfileId");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("APIProject.Models.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Details");

                    b.Property<string>("ExperienceArea");

                    b.Property<long>("FromDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("JobTitle");

                    b.Property<int?>("LawyerProfileId");

                    b.Property<string>("Organization");

                    b.Property<long>("ToDate");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("LawyerProfileId");

                    b.ToTable("Experience");
                });

            modelBuilder.Entity("APIProject.Models.FileAttachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("FileContent");

                    b.Property<string>("FileName");

                    b.Property<string>("FileType");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<int>("UploadType");

                    b.HasKey("Id");

                    b.ToTable("FileAttachment");
                });

            modelBuilder.Entity("APIProject.Models.LawChamber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<int>("AssociatesLimit");

                    b.Property<int?>("ChamberHeadId");

                    b.Property<string>("ChamberName");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<int?>("PackageSettingsId");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ChamberHeadId");

                    b.HasIndex("PackageSettingsId");

                    b.ToTable("LawChambers");
                });

            modelBuilder.Entity("APIProject.Models.LawyerProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<string>("Bio");

                    b.Property<int>("BioCharLimit");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<int?>("LawChamberId");

                    b.Property<string>("Mobile")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<int?>("PackageSettingsId");

                    b.Property<int?>("ProfilePicId");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("WorkingArea");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("LawChamberId");

                    b.HasIndex("PackageSettingsId");

                    b.HasIndex("ProfilePicId");

                    b.ToTable("LawyerProfile");
                });

            modelBuilder.Entity("APIProject.Models.PackageSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<int>("Package");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("PackageSettings");
                });

            modelBuilder.Entity("APIProject.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Mobile")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<int>("UserType");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("APIProject.Models.ClientLawyerAssignment", b =>
                {
                    b.HasOne("APIProject.Models.ClientProfile", "ClientProfile")
                        .WithMany()
                        .HasForeignKey("ClientProfileId");

                    b.HasOne("APIProject.Models.LawyerProfile", "LawyerProfile")
                        .WithMany()
                        .HasForeignKey("LawyerProfileId");
                });

            modelBuilder.Entity("APIProject.Models.ClientProfile", b =>
                {
                    b.HasOne("APIProject.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("APIProject.Models.Education", b =>
                {
                    b.HasOne("APIProject.Models.LawyerProfile")
                        .WithMany("Education")
                        .HasForeignKey("LawyerProfileId");
                });

            modelBuilder.Entity("APIProject.Models.Experience", b =>
                {
                    b.HasOne("APIProject.Models.LawyerProfile")
                        .WithMany("Experience")
                        .HasForeignKey("LawyerProfileId");
                });

            modelBuilder.Entity("APIProject.Models.LawChamber", b =>
                {
                    b.HasOne("APIProject.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("APIProject.Models.Users", "ChamberHead")
                        .WithMany()
                        .HasForeignKey("ChamberHeadId");

                    b.HasOne("APIProject.Models.PackageSettings", "PackageSettings")
                        .WithMany()
                        .HasForeignKey("PackageSettingsId");
                });

            modelBuilder.Entity("APIProject.Models.LawyerProfile", b =>
                {
                    b.HasOne("APIProject.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("APIProject.Models.LawChamber")
                        .WithMany("Associates")
                        .HasForeignKey("LawChamberId");

                    b.HasOne("APIProject.Models.PackageSettings", "PackageSettings")
                        .WithMany()
                        .HasForeignKey("PackageSettingsId");

                    b.HasOne("APIProject.Models.FileAttachment", "ProfilePic")
                        .WithMany()
                        .HasForeignKey("ProfilePicId");
                });
#pragma warning restore 612, 618
        }
    }
}
