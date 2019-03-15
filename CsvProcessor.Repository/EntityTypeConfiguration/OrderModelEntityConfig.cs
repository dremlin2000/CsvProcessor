using Data.EFRepository.Base.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using ScvProcessor.Core.Model;

namespace CsvProcessor.Repository.EntityTypeConfiguration
{
    public class OrderModelEntityConfig: EntityBaseConfiguration<Order, Guid>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(Order));
        }
    }
}
