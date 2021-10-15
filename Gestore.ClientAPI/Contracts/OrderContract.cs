using System;
using System.Collections.Generic;
using System.Text;

namespace Gestore.ClientAPI.Contracts
{
    public class OrderContract
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderCode { get; set; }
        public string ProductCode { get; set; }
        public decimal Amount { get; set; }
        public int CustomerId { get; set; }
    }
}
