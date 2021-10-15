using Gestore.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestore.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        #region CUSTOMER
        List<Customer> FetchAllCustomers();
        Customer GetCustomerById(int id);
        bool CreateCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomerById(int id);
        #endregion

        #region ORDER
        List<Order> FetchAllOrders();
        Order GetOrderById(int id);
        bool CreateOrder(Order order);
        bool UpdateOrder(Order order);
        bool DeleteOrderById(int id);

        #endregion

  
    }
}

