namespace ExemploArquitetura.Domain.Entities
{
    public class Customer : Entity
    {
        public string Name { get; private set; }
        public string Lastname { get; private set; }
        public string CPF { get; private set; }
        public virtual Contact Contact { get; private set; }
        public virtual Address Address { get; private set; }


        protected Customer()
        { }
        public Customer(string name, string lastName, string cpf, Contact contact, Address address)
        {
            Update(name, lastName, cpf);
            Contact = contact;
            Address = address;
        }

        public void Update(string name, string lastName, string cpf)
        {
            Name = name;
            Lastname = lastName;
            CPF = cpf;
        }
    }
}
