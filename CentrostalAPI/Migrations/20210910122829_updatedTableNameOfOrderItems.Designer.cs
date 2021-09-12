﻿// <auto-generated />
using System;
using CentrostalAPI.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CentrostalAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210910122829_updatedTableNameOfOrderItems")]
    partial class updatedTableNameOfOrderItems
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CentrostalAPI.DB.Models.Item", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<int>("current")
                        .HasColumnType("int");

                    b.Property<int>("isOriginal")
                        .HasColumnType("int");

                    b.Property<int>("itemTemplateId")
                        .HasColumnType("int");

                    b.Property<int>("steelTypeId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("itemTemplateId");

                    b.HasIndex("steelTypeId");

                    b.ToTable("items");
                });

            modelBuilder.Entity("CentrostalAPI.DB.Models.ItemTemplate", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("number")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("itemTemplates");
                });

            modelBuilder.Entity("CentrostalAPI.DB.Models.ItemTemplateCurrent", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("current")
                        .HasColumnType("int");

                    b.Property<int>("itemTemplateId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("itemTemplateId");

                    b.ToTable("itemTemplateCurrents");
                });

            modelBuilder.Entity("CentrostalAPI.DB.Models.ItemTemplateSteelType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("itemTemplateId")
                        .HasColumnType("int");

                    b.Property<int>("steelTypeId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("itemTemplateId");

                    b.HasIndex("steelTypeId");

                    b.ToTable("itemTemplateSteelTypes");
                });

            modelBuilder.Entity("CentrostalAPI.DB.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("executedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("lastEditedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("orderingUserId")
                        .HasColumnType("int");

                    b.Property<int>("statusId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("orderingUserId");

                    b.HasIndex("statusId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("CentrostalAPI.DB.Models.OrderItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("amountDelta")
                        .HasColumnType("int");

                    b.Property<int>("itemId")
                        .HasColumnType("int");

                    b.Property<int>("orderId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("itemId");

                    b.HasIndex("orderId");

                    b.ToTable("orderItems");
                });

            modelBuilder.Entity("CentrostalAPI.DB.Models.Status", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("name")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("statuses");
                });

            modelBuilder.Entity("CentrostalAPI.DB.Models.SteelType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("typeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("steelTypes");
                });

            modelBuilder.Entity("CentrostalAPI.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("isBlocked")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("passwordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("CentrostalAPI.DB.Models.Item", b =>
                {
                    b.HasOne("CentrostalAPI.DB.Models.ItemTemplate", "itemTemplate")
                        .WithMany("items")
                        .HasForeignKey("itemTemplateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CentrostalAPI.DB.Models.SteelType", "steelType")
                        .WithMany("items")
                        .HasForeignKey("steelTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("itemTemplate");

                    b.Navigation("steelType");
                });

            modelBuilder.Entity("CentrostalAPI.DB.Models.ItemTemplateCurrent", b =>
                {
                    b.HasOne("CentrostalAPI.DB.Models.ItemTemplate", "itemTemplate")
                        .WithMany("currents")
                        .HasForeignKey("itemTemplateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("itemTemplate");
                });

            modelBuilder.Entity("CentrostalAPI.DB.Models.ItemTemplateSteelType", b =>
                {
                    b.HasOne("CentrostalAPI.DB.Models.ItemTemplate", "itemTemplate")
                        .WithMany("steelTypes")
                        .HasForeignKey("itemTemplateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CentrostalAPI.DB.Models.SteelType", "steelType")
                        .WithMany("itemTemplateSteelTypes")
                        .HasForeignKey("steelTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("itemTemplate");

                    b.Navigation("steelType");
                });

            modelBuilder.Entity("CentrostalAPI.DB.Models.Order", b =>
                {
                    b.HasOne("CentrostalAPI.Models.User", "orderingUser")
                        .WithMany("orders")
                        .HasForeignKey("orderingUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CentrostalAPI.DB.Models.Status", "status")
                        .WithMany("orders")
                        .HasForeignKey("statusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("orderingUser");

                    b.Navigation("status");
                });

            modelBuilder.Entity("CentrostalAPI.DB.Models.OrderItem", b =>
                {
                    b.HasOne("CentrostalAPI.DB.Models.Item", "item")
                        .WithMany("orderItems")
                        .HasForeignKey("itemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CentrostalAPI.DB.Models.Order", "order")
                        .WithMany("orderItems")
                        .HasForeignKey("orderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("item");

                    b.Navigation("order");
                });

            modelBuilder.Entity("CentrostalAPI.DB.Models.Item", b =>
                {
                    b.Navigation("orderItems");
                });

            modelBuilder.Entity("CentrostalAPI.DB.Models.ItemTemplate", b =>
                {
                    b.Navigation("currents");

                    b.Navigation("items");

                    b.Navigation("steelTypes");
                });

            modelBuilder.Entity("CentrostalAPI.DB.Models.Order", b =>
                {
                    b.Navigation("orderItems");
                });

            modelBuilder.Entity("CentrostalAPI.DB.Models.Status", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("CentrostalAPI.DB.Models.SteelType", b =>
                {
                    b.Navigation("items");

                    b.Navigation("itemTemplateSteelTypes");
                });

            modelBuilder.Entity("CentrostalAPI.Models.User", b =>
                {
                    b.Navigation("orders");
                });
#pragma warning restore 612, 618
        }
    }
}