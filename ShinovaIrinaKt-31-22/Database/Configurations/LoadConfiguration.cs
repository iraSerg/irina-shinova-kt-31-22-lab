using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShinovaIrinaKt_31_22.Database.Helpers;
using ShinovaIrinaKt_31_22.Models;

namespace ShinovaIrinaKt_31_22.Database.Configurations
{
    public class LoadConfiguration : IEntityTypeConfiguration<Load>
    {
        private const string TableName = "cd_load";

        public void Configure(EntityTypeBuilder<Load> builder)
        {
            builder
                .HasKey(l => l.LoadId)
                .HasName($"pk_{TableName}_load_id");

            builder.Property(l => l.LoadId)
                .ValueGeneratedOnAdd()
                .HasColumnName("load_id")
                .HasComment("Идентификатор нагрузки");

            builder.Property(l => l.Hours)
                .IsRequired()
                .HasColumnName("c_load_hours")
                .HasColumnType(ColumnType.Int)
                .HasComment("Количество часов нагрузки");

            builder.HasOne(l => l.Teacher)
                .WithMany(t => t.Loads)
                .HasForeignKey(l => l.TeacherId);

            builder.ToTable(TableName);
        }
    }

}
