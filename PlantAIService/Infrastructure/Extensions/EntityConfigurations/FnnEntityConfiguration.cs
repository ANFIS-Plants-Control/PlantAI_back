using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Extensions.EntityConfigurations
{
    public class FnnEntityConfiguration : IEntityTypeConfiguration<Fnn>
    {
        public void Configure(EntityTypeBuilder<Fnn> builder)
        {
            builder.HasKey(f => f.Id);
            builder.HasOne(f => f.ControlElement)
                .WithOne(x => x.Fnn);
        }
    }
}
