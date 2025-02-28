using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShinovaIrinaKt_31_22.Database.Helpers;
using ShinovaIrinaKt_31_22.Models;

namespace ShinovaIrinaKt_31_22.Database.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        private const string TableName = "cd_teacher";

        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder
                .HasKey(t => t.TeacherId)
                .HasName($"pk_{TableName}_teacher_id");

            builder.Property(t => t.TeacherId)
                .ValueGeneratedOnAdd()
                .HasColumnName("teacher_id")
                .HasComment("Идентификатор преподавателя");

            builder.Property(t => t.FirstName)
                .IsRequired()
                .HasColumnName("c_teacher_firstname")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100)
                .HasComment("Имя преподавателя");

            builder.Property(t => t.LastName)
                .IsRequired()
                .HasColumnName("c_teacher_lastname")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100)
                .HasComment("Фамилия преподавателя");

            builder.Property(t => t.MiddleName)
                .HasColumnName("c_teacher_middlename")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100)
                .HasComment("Отчество преподавателя");
           
            builder.HasOne(t => t.Degree)
                .WithMany(d => d.Teachers)
                .HasForeignKey(t => t.DegreeId)
                .OnDelete(DeleteBehavior.Restrict); 

            
            builder.HasOne(t => t.Position)
                .WithMany(p => p.Teachers)
                .HasForeignKey(t => t.PositionId)
                .OnDelete(DeleteBehavior.Restrict); 

          
            builder.HasOne(t => t.Department)
                .WithMany(d => d.Teachers)
                .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(t => t.Loads)
                .WithOne(l => l.Teacher)
                .HasForeignKey(l => l.TeacherId)
                .OnDelete(DeleteBehavior.Cascade); 


            builder.ToTable(TableName);
        }
    }
}
