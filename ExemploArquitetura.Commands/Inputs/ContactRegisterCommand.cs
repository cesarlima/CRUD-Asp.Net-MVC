using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExemploArquitetura.Commands.Inputs
{
    public class ContactRegisterCommand
    {
        [Required]
        [DisplayName("Telefone")]
        public string Phone { get; set; }
        [Required]
        [DisplayName("Celular")]
        public string CellPhone { get; set; }
        [Required]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        public ContactRegisterCommand()
        { }

        public ContactRegisterCommand(string phone, string cellPhone, string email)
        {
            Phone = phone;
            CellPhone = cellPhone;
            Email = email;
        }
    }
}
