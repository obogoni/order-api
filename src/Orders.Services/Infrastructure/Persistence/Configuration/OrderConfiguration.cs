using Microsoft.EntityFrameworkCore;
using Orders.Domain;

namespace Orders.Infrastructure.Persistance.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(x => x.Id);

        builder
          .Property(x => x.CreatedAt)
          .IsRequired();

        builder.HasIndex(x => x.CreatedAt)
          .HasDatabaseName("IX_Orders_CreatedAt");

        builder
          .Property(x => x.Status)
          .HasColumnType("SMALLINT")
          .IsRequired();

        builder.HasIndex(x => x.Status)
            .HasDatabaseName("IX_Orders_Status");

        builder
          .Property(x => x.CanceledAt);
    }
}
