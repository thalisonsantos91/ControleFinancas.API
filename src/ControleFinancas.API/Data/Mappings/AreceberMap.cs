using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFinancas.API.Damain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinancas.API.Data.Mappings
{
    public class AreceberMap : IEntityTypeConfiguration<Areceber>
    {
        public void Configure(EntityTypeBuilder<Areceber> builder)
        {
            builder.ToTable("areceber")
            .HasKey(p => p.Id);

             builder.HasOne(p => p.Usuario)
            .WithMany()
            .HasForeignKey(fk => fk.IdUsuario);
           
            builder.HasOne(p => p.Lancamento)
            .WithMany()
            .HasForeignKey(fk => fk.IdLancamento);

            builder.Property(p => p.Descricao)
            .HasColumnType("VARCHAR")
            .IsRequired();

            builder.Property(p => p.ValorOriginal)
            .HasColumnType("double precision")
            .IsRequired();

             builder.Property(p => p.ValorRecebido)
            .HasColumnType("double precision")
            .IsRequired();

            builder.Property(p => p.Observacao)
            .HasColumnType("VARCHAR");
            
            builder.Property(p => p.DataCadastro)
            .HasColumnType("timestamp")
            .IsRequired();
            
            builder.Property(p => p.DataVencimento)
            .HasColumnType("timestamp")
            .IsRequired();

            builder.Property(p => p.DataReferencia)
            .HasColumnType("timestamp");            

            builder.Property(p => p.DataRecebimento)
            .HasColumnType("timestamp");

            builder.Property(p => p.DataInativacao)
            .HasColumnType("timestamp");

        }        
    }
}