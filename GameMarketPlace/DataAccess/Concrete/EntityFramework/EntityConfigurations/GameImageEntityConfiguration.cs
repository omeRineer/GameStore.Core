using Entities.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.EntityConfigurations
{
    public class GameImageEntityConfiguration : IEntityTypeConfiguration<GameImage>
    {
        public void Configure(EntityTypeBuilder<GameImage> builder)
        {
            builder.ToTable("GameImages");

            builder
                .HasKey(x => x.Id);
        }
    }
}
