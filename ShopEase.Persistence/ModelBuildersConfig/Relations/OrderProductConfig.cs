using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopEase.Domain.Entities.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEase.Persistence.ModelBuildersConfig.Relations;

internal class OrderProductConfig : IEntityTypeConfiguration<OrderProduct>
{
    public void Configure(EntityTypeBuilder<OrderProduct> builder)
    {
        builder.ToTable(nameof(OrderProduct));

        builder
            .HasKey(op => new { op.OrderId, op.ProductId });


    }
}
