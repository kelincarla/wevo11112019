using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Maps
{
    public sealed class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()

        {
            this.ToTable("USUARIO");

            this.HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("ID")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.Nome)
                .HasColumnName("NOME")
                .IsRequired()
                .HasMaxLength(200);

            this.Property(x => x.Cpf)
                .HasColumnName("CPF")
                .IsRequired();

            this.Property(x => x.Email)
                .HasColumnName("EMAIL")
                .IsRequired()
                .HasMaxLength(100);

            this.Property(x => x.Telefone)
                .HasColumnName("TELEFONE")
                .IsRequired();

            this.Property(x => x.Sexo)
                .HasColumnName("SEXO")
                .IsRequired()
                .HasMaxLength(1);

            this.Property(x => x.DataNascimento)
                .HasColumnName("DATANASCIMENTO")
                .IsRequired();






        }
    }
}
