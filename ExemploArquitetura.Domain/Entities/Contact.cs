using System.Collections.Generic;

namespace ExemploArquitetura.Domain.Entities
{
    public class Contact : Entity
    {
        public string Phone { get; private set; }
        public string CellPhone { get; private set; }
        public string Email { get; private set; }

        protected Contact()
        { }

        public Contact(string phone, string cellPhone, string email)
        {
            Update(phone, cellPhone, email);
        }

        public void Update(string phone, string cellPhone, string email)
        {
            Phone = phone;
            CellPhone = cellPhone;
            Email = email;
        }
    }
}
