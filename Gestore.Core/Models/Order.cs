using Gestore.Core.Models;
using System;

namespace Gestore.Core
{
    public class Order 
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } 
        public string OrderCode { get; set; }
        public string ProductCode { get; set; }
        public decimal Amount { get; set; }


        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
