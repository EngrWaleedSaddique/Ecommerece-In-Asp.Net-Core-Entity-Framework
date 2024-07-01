﻿// <auto-generated />
using EcommerceInAsp.NetCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EcommerceInAsp.NetCore.Migrations
{
    [DbContext(typeof(mycontext))]
    [Migration("20240701110600_adminmigration")]
    partial class adminmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EcommerceInAsp.NetCore.Models.Admin", b =>
                {
                    b.Property<int>("admin_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("admin_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("admin_image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("admin_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("admin_password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("admin_id");

                    b.ToTable("tbl_admin");
                });
#pragma warning restore 612, 618
        }
    }
}