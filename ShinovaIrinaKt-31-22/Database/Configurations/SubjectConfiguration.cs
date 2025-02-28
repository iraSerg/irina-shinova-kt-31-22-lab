using ShinovaIrinaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShinovaIrinaKt_31_22.Database.Helpers;

namespace ShinovaIrinaKt_31_22.Database.Configurations
{
    
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        private const string TableName = "cd_subject";

        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder
                .HasKey(d => d.SubjectId)
                .HasName($"pk_{TableName}_subject_id");

            builder.Property(d => d.SubjectId)
                .ValueGeneratedOnAdd()
                .HasColumnName("subject_id")
                .HasComment("Идентификатор дисциплины");

            builder.Property(d => d.Name)
                .IsRequired()
                .HasColumnName("c_subject_name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100)
                .HasComment("Название дисциплины");

            builder.HasOne(s => s.Teacher)
                            .WithMany()
                            .HasForeignKey(s => s.TeacherId)
                            .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(TableName);
        }
    }

}
