﻿// <auto-generated />
using System;
using MediAR.Modules.Membership.Core.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MediAR.Modules.Membership.Core.DAL.EF.Migrations
{
    [DbContext(typeof(MembershipDbContext))]
    partial class MembershipDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MediAR.Modules.Membership.Core.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("MediAR.Modules.Membership.Core.Entities.ApplicationUserRole", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId", "ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ApplicationUserRoles");
                });

            modelBuilder.Entity("MediAR.Modules.Membership.Core.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MediAR.Modules.Membership.Core.Entities.UserProfile", b =>
                {
                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UDF1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UDF2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UDF3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UDF4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UDF5")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicationUserId");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("MediAR.Modules.Membership.Core.Entities.UserToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("ExpTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("MediAR.Modules.Membership.Core.Entities.ApplicationUserRole", b =>
                {
                    b.HasOne("MediAR.Modules.Membership.Core.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediAR.Modules.Membership.Core.Entities.Role", "Role")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MediAR.Modules.Membership.Core.Entities.UserProfile", b =>
                {
                    b.HasOne("MediAR.Modules.Membership.Core.Entities.ApplicationUser", "ApplicationUser")
                        .WithOne("UserProfile")
                        .HasForeignKey("MediAR.Modules.Membership.Core.Entities.UserProfile", "ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("MediAR.Modules.Membership.Core.Entities.UserToken", b =>
                {
                    b.HasOne("MediAR.Modules.Membership.Core.Entities.ApplicationUser", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MediAR.Modules.Membership.Core.Entities.ApplicationUser", b =>
                {
                    b.Navigation("Roles");

                    b.Navigation("Tokens");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("MediAR.Modules.Membership.Core.Entities.Role", b =>
                {
                    b.Navigation("ApplicationUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
