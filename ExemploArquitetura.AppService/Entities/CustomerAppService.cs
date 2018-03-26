using ExemploArquitetura.Commands.Inputs;
using ExemploArquitetura.Commands.Results;
using ExemploArquitetura.Domain.Entities;
using ExemploArquitetura.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExemploArquitetura.AppService.Entities
{
    public class CustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;

        public CustomerAppService(ICustomerRepository customerRepository, IAddressRepository addressRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
        }

        public void Save(CustomerRegisterCommand command)
        {
            var customer = new Customer(command.Name
                                      , command.Lastname
                                      , command.CPF
                                      , new Contact(command.Contact.Phone, command.Contact.CellPhone, command.Contact.Email)
                                      , new Address(command.Address.Street
                                                  , command.Address.Number
                                                  , command.Address.ZipCode
                                                  , _addressRepository.GetCity(command.Address.CityCode)));

            _customerRepository.Save(customer);
        }
        public void Update(CustomerRegisterCommand command)
        {
            var customer = _customerRepository.Get(command.Id);
            var city = _addressRepository.GetCity(command.Address.CityCode);

            customer.Contact.Update(command.Contact.Phone, command.Contact.CellPhone, command.Contact.Email);
            customer.Address.Update(command.Address.Street, command.Address.Number, command.Address.ZipCode, city);
            customer.Update(command.Name, command.Lastname, command.CPF);

            _customerRepository.Update(customer);
        }
        public IEnumerable<CustomerCommandResult> GetAll()
        {
            return _customerRepository.GetAll().Select(customer => new CustomerCommandResult()
            {
                Id = customer.Id,
                Name = customer.Name,
                CellPhone = customer.Contact.CellPhone,
                Email = customer.Contact.Email
            });
        }
        public CustomerRegisterCommand Get(Guid id)
        {
            var customer = _customerRepository.Get(id);

            return new CustomerRegisterCommand(customer.Id
                                             , customer.Name
                                             , customer.Lastname
                                             , customer.CPF
                                             , new ContactRegisterCommand(customer.Contact.Phone, customer.Contact.CellPhone, customer.Contact.Email)
                                             , new AddressRegisterCommand(customer.Address.Street
                                                                        , customer.Address.Number
                                                                        , customer.Address.ZipCode
                                                                        , customer.Address.City.StateCode
                                                                        , customer.Address.City.Code));
        }
    }
}
