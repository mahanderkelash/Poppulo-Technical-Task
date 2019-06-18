﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PoppuloTechnicalTask.Models.DbContext;

namespace PoppuloTechnicalTask.Migrations
{
    [DbContext(typeof(PoppuloDbContext))]
    [Migration("20190615094613_initialdbclasses1")]
    partial class initialdbclasses1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PoppuloTechnicalTask.Models.InventoryCategory.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired();

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PoppuloTechnicalTask.Models.InventoryCategory.InventoryItem", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<string>("ItemName")
                        .IsRequired();

                    b.Property<double>("ItemPrice");

                    b.Property<int>("ItemQuantity");

                    b.HasKey("ItemId");

                    b.HasIndex("CategoryId");

                    b.ToTable("InventoryItems");
                });

            modelBuilder.Entity("PoppuloTechnicalTask.Models.InventoryCategory.InventoryItem", b =>
                {
                    b.HasOne("PoppuloTechnicalTask.Models.InventoryCategory.Category", "Categories")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
