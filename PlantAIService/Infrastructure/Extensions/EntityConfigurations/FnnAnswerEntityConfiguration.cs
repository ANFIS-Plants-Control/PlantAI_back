using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Extensions.EntityConfigurations
{
    public class FnnAnswerEntityConfiguration : IEntityTypeConfiguration<FnnAnswer>
    {
        public void Configure(EntityTypeBuilder<FnnAnswer> builder)
        {
            builder.HasKey(fa => fa.Id);
            builder.HasOne(fa => fa.Fnn)
                .WithMany(x => x.FnnAnswers)
                .HasForeignKey(x => x.FnnId);
        }
    }
}
