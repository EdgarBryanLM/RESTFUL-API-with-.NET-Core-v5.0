using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrasture.Data.configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        void IEntityTypeConfiguration<User>.Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(e => e.id);


            builder.Property(e => e.id).HasColumnName("IdUsuario");

            builder.Property(e => e.Names).HasColumnName("Nombres")
           .IsRequired()
           .HasMaxLength(50)
           .IsUnicode(false);

            builder.Property(e => e.LastName).HasColumnName("Apellidos")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.DateBird).HasColumnName("FechaNacimiento")
            .HasColumnType("datetime");

            builder.Property(e => e.IsActive).HasColumnName("Activo");


            builder.Property(e => e.Telephone).HasColumnName("telefono")
                .HasMaxLength(10)
                .IsUnicode(false);
        }
    }
}
