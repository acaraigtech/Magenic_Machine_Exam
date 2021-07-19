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
    [Migration("20210717081138_alter_table_CardType")]
    partial class alter_table_CardType
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

                    b.Property<Guid>("CardTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ValidityDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CardTypeId")
                        .IsUnique();

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Q_LESS_Transport.Domain.Models.CardType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("FareAmount")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime>("Validity")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CardTypes");
                });

            modelBuilder.Entity("Q_LESS_Transport.Domain.Models.DiscountCard", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<Guid>("CardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CardId")
                        .IsUnique();

                    b.ToTable("DiscountCards");
                });

            modelBuilder.Entity("Q_LESS_Transport.Domain.Models.Card", b =>
                {
                    b.HasOne("Q_LESS_Transport.Domain.Models.CardType", "CardType")
                        .WithOne("Card")
                        .HasForeignKey("Q_LESS_Transport.Domain.Models.Card", "CardTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CardType");
                });

            modelBuilder.Entity("Q_LESS_Transport.Domain.Models.DiscountCard", b =>
                {
                    b.HasOne("Q_LESS_Transport.Domain.Models.Card", "Card")
                        .WithOne("DiscountCard")
                        .HasForeignKey("Q_LESS_Transport.Domain.Models.DiscountCard", "CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");
                });

            modelBuilder.Entity("Q_LESS_Transport.Domain.Models.Card", b =>
                {
                    b.Navigation("DiscountCard");
                });

            modelBuilder.Entity("Q_LESS_Transport.Domain.Models.CardType", b =>
                {
                    b.Navigation("Card");
                });
#pragma warning restore 612, 618
        }
    }
}
