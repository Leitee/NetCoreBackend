﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetCore.ServiceData.Data;

namespace NetCore.ServiceData.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity("NetCore.Model.Entities.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GradeId");

                    b.Property<string>("Name");

                    b.Property<int>("Shift");

                    b.HasKey("ClassId");

                    b.HasIndex("GradeId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("NetCore.Model.Entities.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("GradeId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("NetCore.Model.Entities.Class", b =>
                {
                    b.HasOne("NetCore.Model.Entities.Grade", "Garade")
                        .WithMany("Classes")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
