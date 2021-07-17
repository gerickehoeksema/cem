using CEM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CEM.DAL.Configuration
{
    public class ImageConfiguration : EntityBaseConfiguration<Image>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Image", "image");
        }
    }
}
