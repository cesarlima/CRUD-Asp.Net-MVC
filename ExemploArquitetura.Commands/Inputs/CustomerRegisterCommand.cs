using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExemploArquitetura.Commands.Inputs
{
    public class CustomerRegisterCommand
    {
        public Guid Id { get; set; }
        [Required]
        [DisplayName("Nome")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Sobre Nome")]
        public string Lastname { get; set; }
        [Required]
        [DisplayName("CPF")]
        public string CPF { get; set; }

        public ContactRegisterCommand Contact { get; set; }
        public AddressRegisterCommand Address { get; set; }


        public CustomerRegisterCommand()
        { }

        public CustomerRegisterCommand(Guid id, string name, string lastname, string cPF, ContactRegisterCommand contact, AddressRegisterCommand address)
        {
            Id = id;
            Name = name;
            Lastname = lastname;
            CPF = cPF;
            Contact = contact;
            Address = address;
        }
    }
}
