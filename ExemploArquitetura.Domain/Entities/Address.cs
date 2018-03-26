namespace ExemploArquitetura.Domain.Entities
{
    public class Address : Entity
    {
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string ZipCode { get; private set; }
        public virtual City City { get; private set; }

        protected Address()
        { }
        public Address(string street, string number, string zipCode, City city)
        {
            Update(street, number, zipCode, city);
        }

        public void Update(string street, string number, string zipCode, City city)
        {
            Street = street;
            Number = number;
            ZipCode = zipCode;
            City = city;
        }
    }
}
