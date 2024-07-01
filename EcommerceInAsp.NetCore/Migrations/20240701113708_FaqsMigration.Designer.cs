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
    [Migration("20240701113708_FaqsMigration")]
    partial class FaqsMigration
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

            modelBuilder.Entity("EcommerceInAsp.NetCore.Models.Category", b =>
                {
                    b.Property<int>("category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("category_name")
                        .HasColumnType("int");

                    b.HasKey("category_id");

                    b.ToTable("tbl_Category");
                });

            modelBuilder.Entity("EcommerceInAsp.NetCore.Models.Customer", b =>
                {
                    b.Property<int>("customer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("customer_address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customer_country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customer_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customer_id_city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customer_id_gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customer_image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customer_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customer_password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customer_phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("customer_id");

                    b.ToTable("tbl_Customer");
                });

            modelBuilder.Entity("EcommerceInAsp.NetCore.Models.Faqs", b =>
                {
                    b.Property<int>("faq_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("faq_answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("faq_question")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("faq_id");

                    b.ToTable("tbl_Faqs");
                });

            modelBuilder.Entity("EcommerceInAsp.NetCore.Models.Feedback", b =>
                {
                    b.Property<int>("feedback_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("user_message")
                        .HasColumnType("int");

                    b.Property<int>("user_name")
                        .HasColumnType("int");

                    b.HasKey("feedback_id");

                    b.ToTable("tbl_Feedback");
                });

            modelBuilder.Entity("EcommerceInAsp.NetCore.Models.Product", b =>
                {
                    b.Property<int>("product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cat_id")
                        .HasColumnType("int");

                    b.Property<string>("product_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("product_image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("product_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("product_price")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("product_id");

                    b.ToTable("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
