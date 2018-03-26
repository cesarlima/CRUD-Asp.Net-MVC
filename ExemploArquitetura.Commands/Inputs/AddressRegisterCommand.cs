using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExemploArquitetura.Commands.Inputs
{
    public class AddressRegisterCommand
    {
        [Required]
        [DisplayName("Rua")]
        public string Street { get; set; }
        [Required]
        [DisplayName("Número")]
        public string Number { get; set; }
        [Required]
        [DisplayName("CEP")]
        public string ZipCode { get; set; }
        [Required]
        [DisplayName("Estado")]
        public int StateCode { get; set; }
        [Required]
        [DisplayName("Cidade")]
        public int CityCode { get; set; }

        public AddressRegisterCommand()
        { }

        public AddressRegisterCommand(string street, string number, string zipCode, int stateCode, int cityCode)
        {
            Street = street;
            Number = number;
            ZipCode = zipCode;
            StateCode = stateCode;
            CityCode = cityCode;
        }
    }
}
