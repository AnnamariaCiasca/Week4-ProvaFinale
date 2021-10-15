using Gestore.Core.BusinessLayer;
using Gestore.Core.Models;
using Gestore.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Gestore.Wcf
{
    public class CustomerService : ICustomerService
    {
        private readonly MainBusinessLayer mainBusinessLayer;

        public CustomerService()
        {
            mainBusinessLayer = new MainBusinessLayer(
                new EFCustomerRepository(),
                new EFOrderRepository()
            );
        }

        public bool CreateCustomer(Customer customer)
        {
            if (customer == null)
            {
                return false;
            }
            return mainBusinessLayer.CreateCustomer(customer);
        }



        public bool DeleteCustomerById(int id)
        {
            if (id <= 0)
            {
                return false;
            }
            return mainBusinessLayer.DeleteCustomerById(id);
        }

        public List<Customer> FetchAllCustomers()
        {
            return mainBusinessLayer.FetchAllCustomers();
        }

        public Customer GetCustomerById(int idCustomer)
        {
            if (idCustomer <= 0)
            {
                return null;
            }
            return mainBusinessLayer.GetCustomerById(idCustomer);
        }

        public bool UpdateCustomer(Customer customer)
        {
            if (customer == null)
            {
                return false;
            }

            return mainBusinessLayer.UpdateCustomer(customer);
        }
    }
}
