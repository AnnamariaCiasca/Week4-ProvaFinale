using Gestore.Core.Interfaces;
using Gestore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestore.EF.Repositories
{
    public class EFCustomerRepository : ICustomerRepository { 
    
        private OrderContext ctx;
        public EFCustomerRepository() : this(new OrderContext())
        {

        }

        public EFCustomerRepository(OrderContext context)
    {
        ctx = context;
    }
    
        public bool Create(Customer item)
        {
            if (item == null)
                return false;

            try
            {
                ctx.Customers.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                string message = ex.Message;
                return false;
            }
        }

        public bool Delete(int id)
        {
            if (id <= 0)
            {
                return false;
            }
            try
            {
                var customer = ctx.Customers.Find(id);

                if (customer != null)

                    ctx.Customers.Remove(customer);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Customer> Fetch()
        {
            try
            {
                return ctx.Customers.ToList();
            }
            catch (Exception)
            {
                return new List<Customer>();
            }
        }

        public Customer GetById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return ctx.Customers.Find(id);
        }

        public bool Update(Customer item)
        {
            if (item == null)
            {
                return false;
            }
            try
            {
                ctx.Customers.Update(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
