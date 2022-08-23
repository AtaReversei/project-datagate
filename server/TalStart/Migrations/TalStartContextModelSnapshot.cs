﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TalStart.Models;

#nullable disable

namespace TalStart.Migrations
{
    [DbContext(typeof(TalStartContext))]
    partial class TalStartContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TalStart.Models.DataSet", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.HasIndex("Username");

                    b.ToTable("DataSet");
                });

            modelBuilder.Entity("TalStart.Models.PipelineDbo", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("DestinationDatasetName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("JSON")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SourceDatasetName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.HasIndex("DestinationDatasetName");

                    b.HasIndex("SourceDatasetName");

                    b.HasIndex("Username");

                    b.ToTable("Pipelines");
                });

            modelBuilder.Entity("TalStart.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TalStart.Models.DataSet", b =>
                {
                    b.HasOne("TalStart.Models.User", "User")
                        .WithMany("ListOfDataSets")
                        .HasForeignKey("Username");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TalStart.Models.PipelineDbo", b =>
                {
                    b.HasOne("TalStart.Models.DataSet", "DestinationDataset")
                        .WithMany()
                        .HasForeignKey("DestinationDatasetName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TalStart.Models.DataSet", "SourceDataset")
                        .WithMany()
                        .HasForeignKey("SourceDatasetName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TalStart.Models.User", "User")
                        .WithMany("ListOfPipelines")
                        .HasForeignKey("Username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DestinationDataset");

                    b.Navigation("SourceDataset");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TalStart.Models.User", b =>
                {
                    b.Navigation("ListOfDataSets");

                    b.Navigation("ListOfPipelines");
                });
#pragma warning restore 612, 618
        }
    }
}
