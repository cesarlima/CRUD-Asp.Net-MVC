using ExemploArquitetura.Commands.Interfaces;
using System;
using System.ComponentModel;

namespace ExemploArquitetura.Commands.Results
{
    public class CustomerCommandResult : ICommandResult
    {
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }
        [DisplayName("Celular")]
        public string CellPhone { get; set; }
        [DisplayName("E-mail")]
        public string Email { get; set; }


        public CustomerCommandResult()
        { }

        public CustomerCommandResult(Guid id, string name, string cellPhone, string email)
        {
            Id = id;
            Name = name;
            CellPhone = cellPhone;
            Email = email;
        }
    }
}
