using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFinancas.API.Damain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinancas.API.Data.Mappings
{
    public class ApagarMap : IEntityTypeConfiguration<Apagar>
    {
        public void Configure(EntityTypeBuilder<Apagar> builder)
        {
            builder.ToTable("apagar")
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

             builder.Property(p => p.ValorPago)
            .HasColumnType("double precision")
            .IsRequired();

            builder.Property(p => p.Observacao)
            .HasColumnType("VARCHAR");
            
            builder.Property(p => p.DataCadastro)
            .HasColumnType("timestamp")
            .IsRequired();
            
            builder.Property(p => p.DataVancimento)
            .HasColumnType("timestamp")
            .IsRequired();

            builder.Property(p => p.DataReferencia)
            .HasColumnType("timestamp");            

            builder.Property(p => p.DataPagamento)
            .HasColumnType("timestamp");

            builder.Property(p => p.DataInativacao)
            .HasColumnType("timestamp");

        }        
    }
}