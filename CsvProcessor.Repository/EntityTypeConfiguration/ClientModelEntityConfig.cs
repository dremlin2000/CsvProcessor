using Data.EFRepository.Base.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using ScvProcessor.Core.Model;

namespace CsvProcessor.Repository.EntityTypeConfiguration
{
    public class ClientModelEntityConfig: EntityBaseConfiguration<Client, Guid>
    {
        public override void Configure(EntityTypeBuilder<Client> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(Client));
        }
    }
}
