using Core.Models.mqtt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Extensions.EntityConfigurations
{
    public class TopicDefinitionEntityConfiguration : IEntityTypeConfiguration<TopicDefinition>
    {
        public void Configure(EntityTypeBuilder<TopicDefinition> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Topic)
                .IsUnique(true);
        }
    }
}
