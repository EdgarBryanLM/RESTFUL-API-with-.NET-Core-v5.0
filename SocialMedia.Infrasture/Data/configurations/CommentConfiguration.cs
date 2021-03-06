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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        void IEntityTypeConfiguration<Comment>.Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comentario");
            builder.HasKey(e => e.id);

            builder.Property(e => e.id).HasColumnName("IdComentario")
            .ValueGeneratedNever();

            builder.Property(e => e.PostId).HasColumnName("IdPublicacion");

            builder.Property(e => e.UserId).HasColumnName("IdUsuario");

            builder.Property(e => e.IsActive).HasColumnName("Activo");



            builder.Property(e => e.Description).HasColumnName("Descripcion")
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Date).HasColumnName("Fecha")
            .HasColumnType("datetime");

            builder.HasOne(d => d.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentario_Publicacion");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentario_Usuario");
        }
    }
}
