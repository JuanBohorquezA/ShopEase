using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopEase.Domain.Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEase.Persistence.ModelBuildersConfig.Main
{
    internal class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category));

            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(c => c.Description)
                .HasMaxLength(500);

        }
    }
}
