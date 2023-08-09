﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PS.Data;

namespace PS.Data.Migrations
{
    [DbContext(typeof(PSContext))]
    [Migration("20220422083307_new")]
    partial class @new
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProductProvider", b =>
                {
                    b.Property<int>("ProductsProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProvidersId")
                        .HasColumnType("int");

                    b.HasKey("ProductsProductId", "ProvidersId");

                    b.HasIndex("ProvidersId");

                    b.ToTable("Providings");
                });

            modelBuilder.Entity("Ps.Domain.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("MyName");

                    b.HasKey("CategoryId");

                    b.ToTable("MyCategories");
                });

            modelBuilder.Entity("Ps.Domain.Entities.Client", b =>
                {
                    b.Property<string>("CIN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateNaisssance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CIN");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Ps.Domain.Entities.Facture", b =>
                {
                    b.Property<DateTime>("DateAchat")
                        .HasColumnType("datetime2");

                    b.Property<string>("ClientFK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProductFK")
                        .HasColumnType("int");

                    b.Property<float>("Prix")
                        .HasColumnType("real");

                    b.HasKey("DateAchat", "ClientFK", "ProductFK");

                    b.HasIndex("ClientFK");

                    b.HasIndex("ProductFK");

                    b.ToTable("Facture");
                });

            modelBuilder.Entity("Ps.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateProd")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsBiological")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("MyName");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryFK");

                    b.ToTable("Products");

                    b.HasDiscriminator<int>("IsBiological").HasValue(0);
                });

            modelBuilder.Entity("Ps.Domain.Entities.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datecreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("Ps.Domain.Entities.Biological", b =>
                {
                    b.HasBaseType("Ps.Domain.Entities.Product");

                    b.Property<string>("Herbs")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Ps.Domain.Entities.Chemical", b =>
                {
                    b.HasBaseType("Ps.Domain.Entities.Product");

                    b.Property<string>("LabeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("ProductProvider", b =>
                {
                    b.HasOne("Ps.Domain.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ps.Domain.Entities.Provider", null)
                        .WithMany()
                        .HasForeignKey("ProvidersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ps.Domain.Entities.Facture", b =>
                {
                    b.HasOne("Ps.Domain.Entities.Client", "Client")
                        .WithMany("Factures")
                        .HasForeignKey("ClientFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ps.Domain.Entities.Product", "Product")
                        .WithMany("Factures")
                        .HasForeignKey("ProductFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ps.Domain.Entities.Product", b =>
                {
                    b.HasOne("Ps.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Ps.Domain.Entities.Chemical", b =>
                {
                    b.OwnsOne("Ps.Domain.Entities.Address", "Address", b1 =>
                        {
                            b1.Property<int>("ChemicalProductId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("MyCity");

                            b1.Property<string>("StreetAdress")
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("MyStreet");

                            b1.HasKey("ChemicalProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ChemicalProductId");
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Ps.Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Ps.Domain.Entities.Client", b =>
                {
                    b.Navigation("Factures");
                });

            modelBuilder.Entity("Ps.Domain.Entities.Product", b =>
                {
                    b.Navigation("Factures");
                });
#pragma warning restore 612, 618
        }
    }
}
