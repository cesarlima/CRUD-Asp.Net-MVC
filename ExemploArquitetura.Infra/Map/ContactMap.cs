using ExemploArquitetura.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ExemploArquitetura.Infra.Map
{
    public class ContactMap : EntityTypeConfiguration<Contact>
    {
        public ContactMap()
        {
            ToTable("Contact");

            HasKey(x => x.Id);

            Property(x => x.CellPhone).HasMaxLength(20);
            Property(x => x.Phone).HasMaxLength(20);
            Property(x => x.Email).HasMaxLength(40);
        }
    }
}
