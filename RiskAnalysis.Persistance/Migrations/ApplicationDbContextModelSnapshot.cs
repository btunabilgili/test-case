﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RiskAnalysis.Persistance.Contexts;

#nullable disable

namespace RiskAnalysis.Persistance.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RiskAnalysis.Domain.Agreement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AgreementDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AgreementDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PartnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("RiskLevel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PartnerId");

                    b.ToTable("Agreements");
                });

            modelBuilder.Entity("RiskAnalysis.Domain.JobSubject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PartnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SubjectDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PartnerId");

                    b.ToTable("JobSubjects");
                });

            modelBuilder.Entity("RiskAnalysis.Domain.Partner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartnerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("RiskAnalysis.Domain.RiskAnalysis", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AnalysisDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("JobSubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("RiskScore")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobSubjectId");

                    b.ToTable("RiskAnalyses");
                });

            modelBuilder.Entity("RiskAnalysis.Domain.Agreement", b =>
                {
                    b.HasOne("RiskAnalysis.Domain.Partner", "Partner")
                        .WithMany("Agreements")
                        .HasForeignKey("PartnerId");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("RiskAnalysis.Domain.JobSubject", b =>
                {
                    b.HasOne("RiskAnalysis.Domain.Partner", "Partner")
                        .WithMany("JobSubjects")
                        .HasForeignKey("PartnerId");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("RiskAnalysis.Domain.RiskAnalysis", b =>
                {
                    b.HasOne("RiskAnalysis.Domain.JobSubject", "JobSubject")
                        .WithMany()
                        .HasForeignKey("JobSubjectId");

                    b.Navigation("JobSubject");
                });

            modelBuilder.Entity("RiskAnalysis.Domain.Partner", b =>
                {
                    b.Navigation("Agreements");

                    b.Navigation("JobSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
