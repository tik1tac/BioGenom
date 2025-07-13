using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biogenom.Shared.Model.Configuration;

internal class ConfigurataionElements : IEntityTypeConfiguration<ElementsEntity>
{
    public void Configure(EntityTypeBuilder<ElementsEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

    }
}
