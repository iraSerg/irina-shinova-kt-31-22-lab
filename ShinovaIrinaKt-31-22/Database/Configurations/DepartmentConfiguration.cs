using ShinovaIrinaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShinovaIrinaKt_31_22.Database.Helpers;
using System.Reflection.Emit;


namespace ShinovaIrinaKt_31_22.Database.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        private const string TableName = "cd_department";

        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder
                .HasKey(d => d.DepartmentId)
                .HasName($"pk_{TableName}_department_id");

            builder.Property(d => d.DepartmentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("department_id")
                .HasComment("Идентификатор кафедры");

            builder.Property(d => d.Name)
                .IsRequired()
                .HasColumnName("c_department_name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100)
                .HasComment("Название кафедры");

            builder.HasOne(d => d.Head)
                .WithOne()  
                .HasForeignKey<Department>(d => d.HeadId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Navigation(d => d.Head).AutoInclude(); 

            builder.HasMany(d => d.Teachers)
                .WithOne(t => t.Department)
                .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.ToTable(TableName);
        }
    }
}
