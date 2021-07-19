﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Q_LESS_Transport.Presistence;

namespace Q_LESS_Transport.Migrations
{
    [DbContext(typeof(QLESSTransportAPIContextDb))]
    [Migration("20210717102819_alter_Relationship_v2")]
    partial class alter_Relationship_v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Q_LESS_Transport.Domain.Models.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<Guid>("CardTypeDetailsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ValidUntil")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CardTypeDetailsId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Q_LESS_Transport.Domain.Models.CardTypeDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("FareAmount")
                        .HasColumnType("float");

                    b.Property<double>("InitialLoad")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("YearOfValidity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CardTypeDetails");
                });

            modelBuilder.Entity("Q_LESS_Transport.Domain.Models.DiscountCard", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<Guid>("CardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsSenior")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.ToTable("DiscountCards");
                });

            modelBuilder.Entity("Q_LESS_Transport.Domain.Models.Card", b =>
                {
                    b.HasOne("Q_LESS_Transport.Domain.Models.CardTypeDetails", "CardTypeDetails")
                        .WithMany("Card")
                        .HasForeignKey("CardTypeDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CardTypeDetails");
                });

            modelBuilder.Entity("Q_LESS_Transport.Domain.Models.DiscountCard", b =>
                {
                    b.HasOne("Q_LESS_Transport.Domain.Models.Card", "Card")
                        .WithMany("DiscountCard")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");
                });

            modelBuilder.Entity("Q_LESS_Transport.Domain.Models.Card", b =>
                {
                    b.Navigation("DiscountCard");
                });

            modelBuilder.Entity("Q_LESS_Transport.Domain.Models.CardTypeDetails", b =>
                {
                    b.Navigation("Card");
                });
#pragma warning restore 612, 618
        }
    }
}
