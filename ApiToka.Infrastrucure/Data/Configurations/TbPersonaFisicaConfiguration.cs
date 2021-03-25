namespace ApiToka.Infrastrucure.Data.Configurations
{
    using ApiToka.Core.Entites;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    class TbPersonaFisicaConfiguration : IEntityTypeConfiguration<TbPersonasFisicas>
    {
        public void Configure(EntityTypeBuilder<TbPersonasFisicas> builder)
        {
            builder.HasKey(e => e.IdPersonaFisica);

            builder.ToTable("Tb_PersonasFisicas");

            builder.Property(e => e.Activo).HasDefaultValueSql("((1))");

            builder.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.FechaActualizacion).HasColumnType("datetime");

            builder.Property(e => e.FechaNacimiento).HasColumnType("date");

            builder.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Rfc)
                .HasColumnName("RFC")
                .HasMaxLength(13)
                .IsUnicode(false);
        }
    }
}
