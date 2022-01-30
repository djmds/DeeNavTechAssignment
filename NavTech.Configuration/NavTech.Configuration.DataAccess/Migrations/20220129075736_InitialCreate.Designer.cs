﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NavTech.Configuration.DataAccess;

namespace NavTech.Configuration.DataAccess.Migrations
{
    [DbContext(typeof(ConfigurationContext))]
    [Migration("20220129075736_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NavTech.Configuration.DataAccess.Models.EntityConfiguration", b =>
                {
                    b.Property<int>("EntityConfigurationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EntityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FieldSource")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("bit");

                    b.Property<int>("MaxLength")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("EntityConfigurationID");

                    b.ToTable("EntityConfigurations");
                });
#pragma warning restore 612, 618
        }
    }
}
