﻿// <auto-generated />
using InterBanking.Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InterBanking.Infrastructure.Persistance.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20250310215546_AddedPropertiesCreatedBeneficiaryAndChangedAmountType")]
    partial class AddedPropertiesCreatedBeneficiaryAndChangedAmountType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("InterBanking.Core.Domain.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountNumber")
                        .HasColumnType("integer");

                    b.Property<int?>("AccountType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<int?>("Currency")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("InterBanking.Core.Domain.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("double precision")
                        .HasDefaultValue(0.0);

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("DestinationAccountId")
                        .HasColumnType("integer");

                    b.Property<int>("OriginAccountId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DestinationAccountId");

                    b.HasIndex("OriginAccountId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("InterBanking.Core.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("InterBanking.Core.Domain.Entities.Account", null)
                        .WithMany("Transactions")
                        .HasForeignKey("DestinationAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InterBanking.Core.Domain.Entities.Account", "OriginAccount")
                        .WithMany()
                        .HasForeignKey("OriginAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OriginAccount");
                });

            modelBuilder.Entity("InterBanking.Core.Domain.Entities.Account", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
