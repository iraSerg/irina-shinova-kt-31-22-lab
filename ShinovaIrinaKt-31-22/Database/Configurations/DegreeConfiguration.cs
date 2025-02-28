using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShinovaIrinaKt_31_22.Database.Helpers;
using ShinovaIrinaKt_31_22.Models;

namespace ShinovaIrinaKt_31_22.Database.Configurations
{
    public class DegreeConfiguration : IEntityTypeConfiguration<Degree>
    {
        private const string TableName = "cd_degree";

        public void Configure(EntityTypeBuilder<Degree> builder)
        {
            builder
                .HasKey(d => d.DegreeId)
                .HasName($"pk_{TableName}_degree_id");

            builder.Property(d => d.DegreeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("degree_id")
                .HasComment("Идентификатор ученой степени");

            builder.Property(d => d.Name)
                .IsRequired()
                .HasColumnName("c_degree_name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(50)
                .HasComment("Название ученой степени");

            builder.ToTable(TableName);
        }
    }

}
