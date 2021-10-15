using Gestore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Gestore.Wcf
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        List<Customer> FetchAllCustomers();

        [OperationContract]
        Customer GetCustomerById(int idCustomer);

        [OperationContract]
        bool CreateCustomer(Customer customer);

        [OperationContract]
        bool UpdateCustomer(Customer customer);

        [OperationContract]
        bool DeleteCustomerById(int id);

    }

    
}
