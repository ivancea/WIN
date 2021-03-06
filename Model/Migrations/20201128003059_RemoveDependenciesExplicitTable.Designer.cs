﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WhatIsNext.Model.Contexts;

namespace WhatIsNext.Migrations
{
    [DbContext(typeof(WinContext))]
    [Migration("20201128003059_RemoveDependenciesExplicitTable")]
    partial class RemoveDependenciesExplicitTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ConceptConcept", b =>
                {
                    b.Property<int>("DependantConceptsId")
                        .HasColumnType("integer");

                    b.Property<int>("DependenciesId")
                        .HasColumnType("integer");

                    b.HasKey("DependantConceptsId", "DependenciesId");

                    b.HasIndex("DependenciesId");

                    b.ToTable("ConceptConcept");
                });

            modelBuilder.Entity("WhatIsNext.Model.Entities.Concept", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("GraphId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GraphId");

                    b.ToTable("Concepts");
                });

            modelBuilder.Entity("WhatIsNext.Model.Entities.Graph", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Graphs");
                });

            modelBuilder.Entity("ConceptConcept", b =>
                {
                    b.HasOne("WhatIsNext.Model.Entities.Concept", null)
                        .WithMany()
                        .HasForeignKey("DependantConceptsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WhatIsNext.Model.Entities.Concept", null)
                        .WithMany()
                        .HasForeignKey("DependenciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WhatIsNext.Model.Entities.Concept", b =>
                {
                    b.HasOne("WhatIsNext.Model.Entities.Graph", "Graph")
                        .WithMany("Concepts")
                        .HasForeignKey("GraphId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Graph");
                });

            modelBuilder.Entity("WhatIsNext.Model.Entities.Graph", b =>
                {
                    b.Navigation("Concepts");
                });
#pragma warning restore 612, 618
        }
    }
}
