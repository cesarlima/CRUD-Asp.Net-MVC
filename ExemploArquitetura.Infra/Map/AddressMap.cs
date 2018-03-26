using ExemploArquitetura.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ExemploArquitetura.Infra.Map
{
    internal class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            ToTable("Address");

            HasKey(x => x.Id);

            Property(x => x.Number).IsRequired().HasMaxLength(10);
            Property(x => x.Street).IsRequired().HasMaxLength(60);
            Property(x => x.ZipCode).IsRequired().HasMaxLength(15);

            HasRequired(x => x.City)
                .WithMany()
                .Map(x => x.MapKey("city"));
        }
    }
}
