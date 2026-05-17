using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Extensions
{
    internal class DataGroupEntityConfiguration : IEntityTypeConfiguration<DataGroup>
    {
        public void Configure(EntityTypeBuilder<DataGroup> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
