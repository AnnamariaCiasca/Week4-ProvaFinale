using Gestore.Core.Interfaces;
using Gestore.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestore.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderRepository orderRepository;
        public MainBusinessLayer(ICustomerRepository customerRep, IOrderRepository orderRep)
        {
            customerRepository = customerRep;
            orderRepository = orderRep;
        }

        public bool CreateCustomer(Customer customer)
        {
            if (customer == null)
            {
                return false;
            }

            return customerRepository.Create(customer);
        }

        public bool CreateOrder(Order order)
        {
            if (order == null)
            {
                return false;
            }
            return orderRepository.Create(order);
        }

        public bool DeleteCustomerById(int id)
        {
            if (id <= 0)
            {
                return false;
            }
            return customerRepository.Delete(id);
        }

        public bool DeleteOrderById(int id)
        {
            if (id <= 0)
            {
                return false;
            }
            return orderRepository.Delete(id);
        }

        public List<Customer> FetchAllCustomers()
        {
            return customerRepository.Fetch();
        }

        public List<Order> FetchAllOrders()
        {
            return orderRepository.Fetch();
        }

        public Customer GetCustomerById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return customerRepository.GetById(id);
        }

        public Order GetOrderById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return orderRepository.GetById(id);
        }

      

        public bool UpdateCustomer(Customer customer)
        {
            if (customer == null)
            {
                return false;
            }
            return customerRepository.Update(customer);
        }

        public bool UpdateOrder(Order order)
        {
            if (order == null)
            {
                return false;
            }
            return orderRepository.Update(order);
        }
    }
}

