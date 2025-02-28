using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShinovaIrinaKt_31_22.Database.Helpers;
using ShinovaIrinaKt_31_22.Models;

namespace ShinovaIrinaKt_31_22.Database.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        private const string TableName = "cd_position";

        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder
                .HasKey(p => p.PositionId)
                .HasName($"pk_{TableName}_position_id");

            builder.Property(p => p.PositionId)
                .ValueGeneratedOnAdd()
                .HasColumnName("position_id")
                .HasComment("Идентификатор должности");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("c_position_name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(50)
                .HasComment("Название должности");

            builder.ToTable(TableName);
        }
    }

}
