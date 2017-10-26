﻿// <auto-generated />

using AspNetCoreWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreWebApi.Migrations
{
    [DbContext(typeof(CompContext))]
    [Migration("20171023021653_AddAddress3")]
    partial class AddAddress3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApiSandbox.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CamperId");

                    b.Property<string>("Country");

                    b.Property<string>("Province");

                    b.Property<string>("StreetName");

                    b.HasKey("Id");

                    b.HasIndex("CamperId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("WebApiSandbox.Models.Camper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Campers");
                });

            modelBuilder.Entity("WebApiSandbox.Models.Address", b =>
                {
                    b.HasOne("WebApiSandbox.Models.Camper", "Camper")
                        .WithMany("Addresses")
                        .HasForeignKey("CamperId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
