using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Extensions.EntityConfigurations
{
    public class ControlElementEntityConfiguration : IEntityTypeConfiguration<ControlElement>
    {
        public void Configure(EntityTypeBuilder<ControlElement> builder)
        {
            builder.HasKey(ce => ce.Id);
        }
    }
}
