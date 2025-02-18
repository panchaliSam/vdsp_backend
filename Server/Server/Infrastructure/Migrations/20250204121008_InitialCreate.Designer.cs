﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Infrastructure.Data;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250204121008_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Server.DomainLayer.Models.Entities.Customer", b =>
                {
                    b.Property<int>("CusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cus_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CusId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext")
                        .HasColumnName("cus_first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("cus_last_name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("phone");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("CusId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Server.DomainLayer.Models.Entities.Package", b =>
                {
                    b.Property<int>("PackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("package_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PackageId"));

                    b.Property<int>("NoOfPhotos")
                        .HasColumnType("int")
                        .HasColumnName("no_of_photos");

                    b.Property<string>("PackageName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("package_name");

                    b.Property<double>("PackagePrice")
                        .HasColumnType("double")
                        .HasColumnName("package_price");

                    b.HasKey("PackageId");

                    b.ToTable("Package");
                });

            modelBuilder.Entity("Server.DomainLayer.Models.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("role_name");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Server.DomainLayer.Models.Entities.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("staff_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("StaffId"));

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.Property<string>("StaffFirstName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("staff_first_name");

                    b.Property<string>("StaffLastName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("staff_last_name");

                    b.Property<int>("TeamId")
                        .HasColumnType("int")
                        .HasColumnName("team_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("StaffId");

                    b.HasIndex("RoleId");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("Server.DomainLayer.Models.Entities.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("team_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TeamId"));

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("team_name");

                    b.HasKey("TeamId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("Server.DomainLayer.Models.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("UserToken")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("user_token");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("Server.DomainLayer.Models.Entities.Customer", b =>
                {
                    b.HasOne("Server.DomainLayer.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Server.DomainLayer.Models.Entities.Staff", b =>
                {
                    b.HasOne("Server.DomainLayer.Models.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.DomainLayer.Models.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.DomainLayer.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("Team");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
