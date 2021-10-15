using Gestore.Core;
using Gestore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestore.EF.Repositories
{
    public class EFOrderRepository : IOrderRepository
    {
        private OrderContext ctx;

        public EFOrderRepository() : this(new OrderContext())
        {
        }

        public EFOrderRepository(OrderContext context)
        {
            ctx = context;
        }
        public bool Create(Order item)
        {
            if (item == null)
                return false;

            try
            {
                ctx.Orders.Add(item);
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
                var order = ctx.Orders.Find(id);
                
                if(order != null)
                
                    ctx.Orders.Remove(order);
                    ctx.SaveChanges();
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Order> Fetch()
        {
            try
            {
                return ctx.Orders.ToList();
            }
            catch (Exception)
            {
                return new List<Order>();
            }
        }

        public Order GetById(int id)
        {
            if(id <= 0)
            {
                return null;
            }

            return ctx.Orders.Find(id);
        }

        public bool Update(Order item)
        {
            if(item == null)
            {
                return false;
            }
            try
            {
                ctx.Orders.Update(item);
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
